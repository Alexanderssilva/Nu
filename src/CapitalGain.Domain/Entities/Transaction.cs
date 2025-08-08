using System;
using System.Text.Json.Serialization;

namespace CapitalGain.Domain.Entities;

public class Transaction
{
    [JsonPropertyName("operation")]
    public Operation OperationEnum { get; set; }
    [JsonPropertyName("unit-cost")]
    public double UnitCost { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}

public enum Operation
{
    Buy,
    Sell
}