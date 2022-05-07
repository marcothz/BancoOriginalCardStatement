using OriginalCardStatementParser.Models;
using System.Text.Json;

namespace OriginalCardStatementParser
{
    internal class Application
    {
        public async Task Execute()
        {
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new CurrencyConverter() }
            };

            var inputFileName = new DirectoryInfo(@"..\..\..\data\")
                .GetFiles("*.json")
                .OrderByDescending(f => f.LastWriteTime)
                .First()
                .FullName;

            using var stream = File.OpenRead(inputFileName);

            var statement = await JsonSerializer.DeserializeAsync<StatementDto>(stream, serializeOptions).AsTask();

            int order = 0;

            var entries = statement?.MovsByDay?.SelectMany(x => (x.Movs!))?
                //.Where(m => !IsIgnorableStatementEntry(m))
                .Select(m => ConvertToStatementEntry(m, ++order))
                .OrderByDescending(e => e.Order)
                .ToArray();

            var outputFileName = @"..\..\..\data\statement.txt";

            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }

            using var writer = new StreamWriter(File.OpenWrite(outputFileName));

            foreach (var entry in entries)
            {
                var text = $"{entry.CreatedAt:dd/MM/yyyy}\t{entry.Description}\t{entry.Amount}\t{(entry.IsRefund ? "✔️" : "")}\t{entry.CardDescription}";

                writer.WriteLine(text);
            }
        }

        private static StatementEntry ConvertToStatementEntry(MovDto mov, int order)
        {
            return StatementEntryBuilder.Create()
                .FromMovDto(mov)
                .WithOrder(order)
                .Build();
        }

        private static bool IsIgnorableStatementEntry(MovDto entry)
        {
            if (entry.Debit == false
                && string.Compare(entry.Description, "PAGAMENTO ORIGINAL", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }

            return false;
        }
    }
}