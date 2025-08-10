using System;
using System.Text.Json.Serialization;

namespace CapitalGain.Domain.Entities;

public class Money
{
    [JsonPropertyName("operation")]
    public string Operation { get; set; }="";
    [JsonPropertyName("unit-cost")]
    public double UnitCost { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonIgnore]
    public Operation OperationEnum
    {
        get => Enum.TryParse<Operation>(Operation, true, out var op)
                        ? op
                        : throw new ArgumentException("Invalid operation type");
    }
}

public enum Operation
{
    Buy,
    Sell
}