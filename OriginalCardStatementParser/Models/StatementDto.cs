using System.Text.Json.Serialization;

namespace OriginalCardStatementParser.Models
{
    public partial class StatementDto
    {
        [JsonPropertyName("availableLimit")]
        public string? AvailableLimit { get; set; }

        [JsonPropertyName("availablePurchaseLimit")]
        public string? AvailablePurchaseLimit { get; set; }

        [JsonPropertyName("availablePurchaseLimitDouble")]
        public double? AvailablePurchaseLimitDouble { get; set; }

        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }

        [JsonPropertyName("cashLimit")]
        public string? CashLimit { get; set; }

        [JsonPropertyName("digitalInvoiceLine")]
        public string? DigitalInvoiceLine { get; set; }

        [JsonPropertyName("dueDate")]
        public long? DueDate { get; set; }

        [JsonPropertyName("dueDateTime")]
        public long? DueDateTime { get; set; }

        [JsonPropertyName("dueDateTimeString")]
        public string? DueDateTimeString { get; set; }

        [JsonPropertyName("expiryDay")]
        public string? ExpiryDay { get; set; }

        [JsonPropertyName("hasLiFees")]
        public bool? HasLiFees { get; set; }

        [JsonPropertyName("hasMore")]
        public bool? HasMore { get; set; }

        [JsonPropertyName("keyOfRestart")]
        public string? KeyOfRestart { get; set; }

        [JsonPropertyName("limitUse")]
        public double? LimitUse { get; set; }

        [JsonPropertyName("limitUsePercentage")]
        public double? LimitUsePercentage { get; set; }

        [JsonPropertyName("minimumPaymentAmount")]
        public string? MinimumPaymentAmount { get; set; }

        [JsonPropertyName("minimumPaymentAmountDouble")]
        public double? MinimumPaymentAmountDouble { get; set; }

        [JsonPropertyName("monthYear")]
        public string? MonthYear { get; set; }

        [JsonPropertyName("movsByDay")]
        public IEnumerable<MovsByDayDto>? MovsByDay { get; set; }

        [JsonPropertyName("paymentAmount")]
        public string? PaymentAmount { get; set; }

        [JsonPropertyName("paymentAmountDouble")]
        public double? PaymentAmountDouble { get; set; }

        [JsonPropertyName("purchaseLimit")]
        public string? PurchaseLimit { get; set; }

        [JsonPropertyName("purchaseLimitDouble")]
        public double? PurchaseLimitDouble { get; set; }

        [JsonPropertyName("quotation")]
        public QuotationDto? Quotation { get; set; }

        [JsonPropertyName("statementNumber")]
        public string? StatementNumber { get; set; }

        [JsonPropertyName("totalCredits")]
        public double? TotalCredits { get; set; }

        [JsonPropertyName("totalDebits")]
        public double? TotalDebits { get; set; }
    }
}