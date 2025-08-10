using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CapitalGain.Infrastructure.Utils;

public class OneDecimalDoubleConverter:JsonConverter<double>
{
    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetDouble(out double value))
        {
            return value;
        }
        throw new JsonException("Invalid JSON format for double.");
    }

    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    {
        var decimalValue =Math.Round(value, 1);
        writer.WriteNumberValue(decimalValue);
    }
}

