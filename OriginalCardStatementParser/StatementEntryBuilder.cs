using OriginalCardStatementParser.Models;
using System.Globalization;

namespace OriginalCardStatementParser
{
    internal class StatementEntryBuilder
    {
        private MovDto? _mov;
        private int _order;

        private StatementEntryBuilder()
        {
        }

        public static StatementEntryBuilder Create()
        {
            return new StatementEntryBuilder();
        }

        public StatementEntryBuilder FromMovDto(MovDto mov)
        {
            _mov = mov;

            return this;
        }

        public StatementEntryBuilder WithOrder(int order)
        {
            _order = order;

            return this;
        }

        public StatementEntry Build()
        {
            DateTime createdAt = TranslateCreatedAt(_mov.Date);
            string description = _mov.Description ?? string.Empty;
            decimal amount = TranslateAmount(_mov.Amount);
            string cardDescription = TranslateCardDescription(_mov.EndingDigits);
            string category = string.Empty;

            return new StatementEntry(_order, createdAt, description, amount, cardDescription, category);
        }

        private static string TranslateCardDescription(string? endingDigits)
        {
            if (endingDigits != null)
            {
                return $"Cartão final {endingDigits}";
            }

            return "???";
        }

        private static decimal TranslateAmount(string? amount)
        {
            return decimal.Parse(amount ?? string.Empty, CultureInfo.GetCultureInfo("pt-BR"));
        }

        private static DateTime TranslateCreatedAt(string? date)
        {
            return DateTime.ParseExact(date ?? string.Empty, "dd/MM/yy", CultureInfo.InvariantCulture);
        }
    }
}