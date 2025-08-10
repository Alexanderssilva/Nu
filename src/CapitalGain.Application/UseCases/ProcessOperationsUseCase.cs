using System;
using CapitalGain.Application.Interfaces;
using CapitalGain.Domain.Entities;
using CapitalGain.Domain.Service;
using CapitalGain.Domain.ValueObjects;

namespace CapitalGain.Application.UseCases;

public class ProcessOperationsUseCase : IProcessOperationsUseCase
{
    private TaxCalculator _taxCalculator;


    public List<List<TaxResult>> Execute(List<List<Money>> operationsList)
    {
        List<List<TaxResult>> results = [];
        foreach (var operations in operationsList)
        {
            results.Add(TaxResults(operations));
        }
        return results;
    }

    private List<TaxResult> TaxResults(List<Money> operations)
    {
        var taxResults = new List<TaxResult>();
        _taxCalculator = new TaxCalculator();
        foreach (var operation in operations)
        {
            var tax = _taxCalculator.CalulateTax(operation);
            taxResults.Add(new TaxResult
            {
                Tax = tax
            });
        }
        return taxResults;
    }




}
