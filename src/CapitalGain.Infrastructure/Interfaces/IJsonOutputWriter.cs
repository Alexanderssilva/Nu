using System;
using CapitalGain.Domain.Entities;

namespace CapitalGain.Infrastructure.Interfaces;

public interface IJsonOutputWriter
{
    List<string> Write(List<List<Transaction>> operations);
}
