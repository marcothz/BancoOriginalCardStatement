using System.Text.Json.Serialization;

namespace OriginalCardStatementParser.Models
{
    public partial class QuotationDto
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("valueFormated")]
        public string? ValueFormated { get; set; }
    }
}