using System;
using System.Text.Json;
using CapitalGain.Domain.Entities;
using CapitalGain.Infrastructure.Interfaces;

namespace CapitalGain.Infrastructure.Json;

public class JsonOutputWriter : IJsonOutputWriter
{
public List<string> Write(List<List<Transaction>> transactions) =>
    [.. transactions.Select(operationList => JsonSerializer.Serialize(operationList))];

    
}

