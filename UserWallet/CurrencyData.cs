
public class CurrencyData
{
    private readonly int _currencyAdded;
    private bool _isGetAdded;

    protected CurrencyData(int currency, int currencyAdded)
    {
        Currency = currency;
        _currencyAdded = currencyAdded;
    }

    public int CurrencyAdded
    {
        get
        {
            _isGetAdded = true;
            return _currencyAdded;
        }
    }

    public int Currency { get; }

    public bool IsAnimationAddedEnd => _isGetAdded;
}
public class PointData :  CurrencyData
{
    public PointData(int currency, int currencyAdded) : base(currency, currencyAdded)
    {
    }
}
public class CoinsData :  CurrencyData
{
    public CoinsData(int countCurrency, int currencyAdded) : base(countCurrency, currencyAdded)
    {
    }
}

public class PremiumData : CurrencyData
{
    public PremiumData(int countCurrency, int currencyAdded) : base(countCurrency, currencyAdded)
    {
    }
}

