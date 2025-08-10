using System;
using CapitalGain.Domain.Entities;
using CapitalGain.Domain.ValueObjects;

namespace CapitalGain.Application.Interfaces;

public interface IProcessOperationsUseCase
{
    List<List<TaxResult>> Execute(List<List<Money>> operations);
}

