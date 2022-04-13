using System.Text.Json;
using System.Text.Json.Serialization;

namespace OriginalCardStatementParser
{
    internal class CurrencyConverter : JsonConverter<Currency?>
    {
        public override Currency? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            var value = reader.GetString();
            if (value == "R$")
            {
                return Currency.BRL;
            }

            throw new Exception("Cannot unmarshal type Currency");
        }

        public override void Write(Utf8JsonWriter writer, Currency? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            switch (value)
            {
                case Currency.BRL:
                    writer.WriteStringValue("R$");
                    break;

                default:
                    throw new Exception("Cannot marshal type Currency");
            }
        }
    }
}