using System;
using CapitalGain.Application.Interfaces;
using CapitalGain.Application.UseCases;
using CapitalGain.Domain;
using CapitalGain.Infrastructure.Interfaces;
using CapitalGain.Infrastructure.Json;
namespace CapitalGain.Infrastructure.CompositionRoot;

public class CompositionRoot
{
    public static (IJsonInputReader, IProcessOperationsUseCase, IJsonOutputWriter) Build()
    {
        IJsonInputReader reader = new JsonInputReader();
        IJsonOutputWriter writer = new JsonOutputWriter();
        IProcessOperationsUseCase useCase = new ProcessOperationsUseCase();
        return (reader, useCase, writer);
    }
}
