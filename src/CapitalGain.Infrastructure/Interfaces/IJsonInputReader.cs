using System;
using CapitalGain.Domain.Entities;
namespace CapitalGain.Infrastructure.Interfaces;

public interface IJsonInputReader
{
    public List<List<Transaction>> Parse(string line);
}
