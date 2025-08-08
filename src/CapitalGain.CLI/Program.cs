using CapitalGain.Infrastructure.CompositionRoot;

var (reader, useCase, writer) = CompositionRoot.Build();
string? line;
while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
{
    var operations = reader.Parse(line);
    var result = useCase.Execute(operations);
    Console.WriteLine(writer.Write(result));
}
