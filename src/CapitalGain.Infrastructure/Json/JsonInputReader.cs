using System;
using System.Text.Json;
using CapitalGain.Domain.Entities;
using CapitalGain.Infrastructure.Interfaces;
namespace CapitalGain.Infrastructure.Json;

public class JsonInputReader : IJsonInputReader
{
    public JsonInputReader()
    {
    }

    public List<List<Money>> Parse(string line)
    {
        var result = new List<List<Money>>();
        if (string.IsNullOrWhiteSpace(line))
            throw new ArgumentException("Input line cannot be null or empty.", nameof(line));

        try
        {
            var transaction = JsonSerializer.Deserialize<List<Money>>(line) ?? [];
            result.Add(transaction);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("Failed to parse JSON input.", ex);
        }

        return result;
    }

}
