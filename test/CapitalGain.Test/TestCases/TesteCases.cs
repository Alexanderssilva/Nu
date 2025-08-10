using CapitalGain.Infrastructure.CompositionRoot;

namespace CapitalGain.Test.TestCases;

[TestClass]
public class UnitTest1
{
    private readonly List<(string, string)> testInput =
    [
        (
            @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"": 100},{""operation"":""sell"", ""unit-cost"":15.00, ""quantity"": 50},{""operation"":""sell"", ""unit-cost"":15.00, ""quantity"": 50}]",
            @"[{""Tax"":0},{""Tax"":0},{""Tax"":0}]"
        ),
        (
            @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"": 10000},{""operation"":""sell"", ""unit-cost"":20.00, ""quantity"": 5000},{""operation"":""sell"", ""unit-cost"":5.00, ""quantity"": 5000}]",
            @"[{""Tax"":0},{""Tax"":10000.0},{""Tax"":0}]"
        ),
        (
            @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"": 10000},{""operation"":""sell"", ""unit-cost"":5.00, ""quantity"": 5000},{""operation"":""sell"", ""unit-cost"":20.00, ""quantity"": 3000}]",
            @"[{""Tax"":0},{""Tax"":0},{""Tax"":1000.0}]"
        ),
        (
            @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"": 10000},{""operation"":""buy"", ""unit-cost"":25.00, ""quantity"": 5000},{""operation"":""sell"", ""unit-cost"":15.00, ""quantity"": 10000}]",
            @"[{""Tax"":0},{""Tax"":0},{""Tax"":0}]"
        ),
        (
            @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"": 10000},{""operation"":""buy"", ""unit-cost"":25.00, ""quantity"": 5000},{""operation"":""sell"", ""unit-cost"":15.00, ""quantity"": 10000},{""operation"":""sell"", ""unit-cost"":25.00, ""quantity"": 5000}]",
            @"[{""Tax"":0},{""Tax"":0},{""Tax"":0},{""Tax"":10000.0}]"
        ),
        (
            @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"": 10000},{""operation"":""sell"", ""unit-cost"":2.00, ""quantity"": 5000},{""operation"":""sell"", ""unit-cost"":20.00, ""quantity"": 2000},{""operation"":""sell"", ""unit-cost"":20.00, ""quantity"": 2000},{""operation"":""sell"", ""unit-cost"":25.00, ""quantity"": 1000}]",
            @"[{""Tax"":0},{""Tax"":0},{""Tax"":0},{""Tax"":0},{""Tax"":3000.0}]"
        ),
        (
            @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"": 10000},{""operation"":""sell"", ""unit-cost"":2.00, ""quantity"": 5000},{""operation"":""sell"", ""unit-cost"":20.00, ""quantity"": 2000},{""operation"":""sell"", ""unit-cost"":20.00, ""quantity"": 2000},{""operation"":""sell"", ""unit-cost"":25.00, ""quantity"": 1000},{""operation"":""buy"", ""unit-cost"":20.00, ""quantity"": 10000},{""operation"":""sell"", ""unit-cost"":15.00, ""quantity"": 5000},{""operation"":""sell"", ""unit-cost"":30.00, ""quantity"": 4350},{""operation"":""sell"", ""unit-cost"":30.00, ""quantity"": 650}]",
            @"[{""Tax"":0},{""Tax"":0},{""Tax"":0},{""Tax"":0},{""Tax"":3000.0},{""Tax"":0},{""Tax"":0},{""Tax"":3700.0},{""Tax"":0}]"
        ),
        (
            @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"": 10000},{""operation"":""sell"", ""unit-cost"":50.00, ""quantity"": 10000},{""operation"":""buy"", ""unit-cost"":20.00, ""quantity"": 10000},{""operation"":""sell"", ""unit-cost"":50.00, ""quantity"": 10000}]",
            @"[{""Tax"":0},{""Tax"":80000.0},{""Tax"":0},{""Tax"":60000.0}]"
        ),
        (
            @"[{""operation"": ""buy"", ""unit-cost"": 5000.00, ""quantity"": 10},{""operation"": ""sell"", ""unit-cost"": 4000.00, ""quantity"": 5},{""operation"": ""buy"", ""unit-cost"": 15000.00, ""quantity"": 5},{""operation"": ""buy"", ""unit-cost"": 4000.00, ""quantity"": 2},{""operation"": ""buy"", ""unit-cost"": 23000.00, ""quantity"": 2},{""operation"": ""sell"", ""unit-cost"": 20000.00, ""quantity"": 1},{""operation"": ""sell"", ""unit-cost"": 12000.00, ""quantity"": 10},{""operation"": ""sell"", ""unit-cost"": 15000.00, ""quantity"": 3}]",
            @"[{""Tax"":0},{""Tax"":0},{""Tax"":0},{""Tax"":0},{""Tax"":0},{""Tax"":0},{""Tax"":1000.0},{""Tax"":2400.0}]"
        )
    ];


    [TestMethod]
    public void TestMethod1()
    {
        foreach (var (input, expected) in testInput)
        {
            var (reader, useCase, writer) = CompositionRoot.Build();
            var operations = reader.Parse(input);
            var result = useCase.Execute(operations);
            var output = result.Select(writer.Write).ToList();

            Assert.AreEqual(expected, output.FirstOrDefault());
        }
    }
}