using System;
using CapitalGain.Domain.Entities;

namespace CapitalGain.Domain.Service;

public class TaxCalculator
{

    public decimal _pmp = 0;
    private int _totalQuantity = 0;
    private decimal _accumulatedLoss = 0;

    public decimal CalulateTax(Money operation)
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

    private decimal SellOperation(Money operation)
    {
        decimal totalSale = operation.UnitCost * operation.Quantity;
        decimal grossProfit = (operation.UnitCost - _pmp) * operation.Quantity;

        if (totalSale <= 20000)
        {
            if (grossProfit < 0)
            {
                _accumulatedLoss += Math.Abs(grossProfit);
            }
            UpdateQuantityAfterSale(operation.Quantity);
            return 0;
        }

        if (grossProfit > 0)
        {
            decimal rebate = Math.Min(_accumulatedLoss, grossProfit);
            decimal taxableProfit = grossProfit - rebate;
            _accumulatedLoss -= rebate;

            decimal tax = taxableProfit * 0.20m;
            UpdateQuantityAfterSale(operation.Quantity);
            return tax;
        }
        else
        {
            _accumulatedLoss += Math.Abs(grossProfit);
            UpdateQuantityAfterSale(operation.Quantity);

            return 0;
        }
    }
    private void UpdateQuantityAfterSale(int quantitySold)
    {
        _totalQuantity -= quantitySold;
        if (_totalQuantity <= 0)
        {
            _totalQuantity = 0;
            _pmp = 0;
        }
    }

    private void PMPUpdate(Money operation)
    {
        _pmp = (_pmp * _totalQuantity + operation.UnitCost * operation.Quantity) / (_totalQuantity + operation.Quantity);
        _totalQuantity += operation.Quantity;
    }
}
