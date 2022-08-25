using System.Text.Json;
using System.Text.Json.Serialization;

public class CustomDateTimeConverter : JsonConverter<DateOnly>
{ // https://makolyte.com/csharp-changing-the-json-serialization-date-format/
    private readonly string Format;
    public CustomDateTimeConverter(string format)
    {
        Format = format;
    }
    public override void Write(Utf8JsonWriter writer, DateOnly date, JsonSerializerOptions options)
    {
        writer.WriteStringValue(date.ToString(Format));
    }
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString(), Format, null);
    }
}