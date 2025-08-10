using System;
using CapitalGain.Domain.Entities;
using CapitalGain.Domain.ValueObjects;

namespace CapitalGain.Infrastructure.Interfaces;

public interface IJsonOutputWriter
{
    string Write(List<TaxResult> operations);
}
