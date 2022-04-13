using System.Text.Json.Serialization;

namespace OriginalCardStatementParser.Models
{
    public partial class MovDto
    {
        [JsonPropertyName("additionalLabel")]
        public string? AdditionalLabel { get; set; }

        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        [JsonPropertyName("amountDollar")]
        public string? AmountDollar { get; set; }

        [JsonPropertyName("awaitingApproval")]
        public bool? AwaitingApproval { get; set; }

        [JsonPropertyName("currency")]
        public Currency? Currency { get; set; }

        [JsonPropertyName("currencyName")]
        public string? CurrencyName { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("debit")]
        public bool? Debit { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("endingDigits")]
        public string? EndingDigits { get; set; }

        [JsonPropertyName("installment")]
        public string? Installment { get; set; }

        [JsonPropertyName("priceDollar")]
        public string? PriceDollar { get; set; }

        [JsonPropertyName("showCurrencyName")]
        public bool? ShowCurrencyName { get; set; }
    }
}