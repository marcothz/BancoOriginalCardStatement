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

            using var stream = File.OpenRead("statement.json");

            var statement = await JsonSerializer.DeserializeAsync<StatementDto>(stream, serializeOptions).AsTask();

            int order = 0;

            var entries = statement?.MovsByDay?.SelectMany(x => (x.Movs!))?
                .Select(m => ConvertToStatementEntry(m, ++order))
                .OrderByDescending(e => e.Order)
                .ToArray();

            using var writer = new StreamWriter(File.OpenWrite("statement.txt"));

            foreach (var entry in entries)
            {
                var text = $"{entry.CreatedAt:dd/MM/yyyy}\t{entry.Description}\t{entry.Amount}\t\t{entry.CardDescription}\t{entry.Category}";

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
    }
}