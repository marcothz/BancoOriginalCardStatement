using System.Text.Json.Serialization;

namespace OriginalCardStatementParser.Models
{
    public partial class MovsByDayDto
    {
        [JsonPropertyName("day")]
        public string? Day { get; set; }

        [JsonPropertyName("movs")]
        public IEnumerable<MovDto>? Movs { get; set; }
    }
}