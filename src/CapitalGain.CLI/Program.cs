using CapitalGain.Domain.ValueObjects;
using CapitalGain.Infrastructure.CompositionRoot;

var (reader, useCase, writer) = CompositionRoot.Build();
string? line;
List<List<TaxResult>> results = [];
while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
{
    var operations = reader.Parse(line);
    var result = useCase.Execute(operations);
    result.ForEach(r => Console.WriteLine(writer.Write(r)));
}
