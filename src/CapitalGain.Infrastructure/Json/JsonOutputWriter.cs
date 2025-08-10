using System.Globalization;
using System.Text.Json;
using CapitalGain.Domain.ValueObjects;
using CapitalGain.Infrastructure.Interfaces;
using CapitalGain.Infrastructure.Utils;

namespace CapitalGain.Infrastructure.Json;

public class JsonOutputWriter : IJsonOutputWriter
{
    public string Write(List<TaxResult> transactions)
    {
        var jsonResults = new List<TaxResult>();
        var result = transactions.Select(transaction => new
        {
            Tax = transaction.Tax == 0.0000m? 0: Math.Round(transaction.Tax, 1)
        }).ToList();
        var options = new JsonSerializerOptions();
        options.Converters.Add(new OneDecimalDoubleConverter());
        var json = JsonSerializer.Serialize(result,options);

        return json;
    }
}




