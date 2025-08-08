using System;
using CapitalGain.Domain.Entities;

namespace CapitalGain.Application.Interfaces;

public interface IProcessOperationsUseCase
{
    string Execute(List<List<Transaction>> operations);
}

