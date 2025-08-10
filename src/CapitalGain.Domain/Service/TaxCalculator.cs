using System;
using CapitalGain.Domain.Entities;

namespace CapitalGain.Domain.Service;

public class TaxCalculator
{

    public double _pmp = 0;
    private int _totalQuantity = 0;
    private double _accumulatedLoss = 0;

    public double CalulateTax(Money operation)
    {
        switch (operation.OperationEnum)
        {
            case Operation.Buy:
                PMPUpdate(operation);
                return 0;
            case Operation.Sell:
                return SellOperation(operation);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

private double SellOperation(Money operation)
{
    double totalSale = operation.UnitCost * operation.Quantity;
    double grossProfit = (operation.UnitCost - _pmp) * operation.Quantity;

    if (totalSale <= 20000)
    {
        if (grossProfit < 0)
        {
            _accumulatedLoss += Math.Abs(grossProfit);
        }
        else if (grossProfit > 0)
        {
            double abatimento = Math.Min(_accumulatedLoss, grossProfit);
            _accumulatedLoss -= abatimento;
        }

        _totalQuantity -= operation.Quantity;
        if (_totalQuantity == 0) _pmp = 0;

        return 0;
    }

    if (grossProfit > 0)
    {
        double abatimento = Math.Min(_accumulatedLoss, grossProfit);
        grossProfit -= abatimento;
        _accumulatedLoss -= abatimento;

        double tax = grossProfit * 0.20;

        _totalQuantity -= operation.Quantity;
        if (_totalQuantity == 0) _pmp = 0;

        return tax;
    }
    else
    {
        _accumulatedLoss += Math.Abs(grossProfit);

        _totalQuantity -= operation.Quantity;
        if (_totalQuantity == 0) _pmp = 0;

        return 0;
    }
}

private void PMPUpdate(Money operation)
{
    _pmp = (_pmp * _totalQuantity + operation.UnitCost * operation.Quantity) / (_totalQuantity + operation.Quantity);
    _totalQuantity += operation.Quantity;
}
}
