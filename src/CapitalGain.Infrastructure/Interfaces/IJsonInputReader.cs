using System;
using CapitalGain.Domain.Entities;

namespace CapitalGain.Infrastructure.Interfaces;

public interface IJsonInputReader
{
    public List<List<Money>> Parse(string line);
}
