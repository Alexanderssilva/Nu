using System.Globalization;
using System.Text.Json;
using CapitalGain.Domain.ValueObjects;
using CapitalGain.Infrastructure.Interfaces;

namespace CapitalGain.Infrastructure.Json;

public class JsonOutputWriter : IJsonOutputWriter
{
    public string Write(List<TaxResult> transactions)
    {
        var jsonResults = new List<TaxResult>();
        var result = transactions.Select(transaction => new
                                        {
                                            Tax = transaction.Tax.ToString("F1",CultureInfo.InvariantCulture)
                                        }).ToList();
        var json = JsonSerializer.Serialize(result);

        return json;
    }
}




