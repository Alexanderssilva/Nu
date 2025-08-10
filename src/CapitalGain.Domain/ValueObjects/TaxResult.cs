using System;
using System.Text.Json.Serialization;

namespace CapitalGain.Domain.ValueObjects;

public class TaxResult
{
    [JsonPropertyName("tax")]
    public decimal Tax { get; set; }
}
