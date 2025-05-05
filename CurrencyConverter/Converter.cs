namespace SingleTonPattern;
public class Converter
{
    private IEnumerable<ExchangeRate> _exchangRate;
    public Converter()
    {
        LoadExchange();
    }

    private void LoadExchange()
    {
        Thread.Sleep(2000);

        _exchangRate = new[]
        {
            new ExchangeRate("USD", "EUR", 0.85),
            new ExchangeRate("USD", "EGP", 50.8),
            new ExchangeRate("USD", "SAR", 3.75),
            new ExchangeRate("SAR", "EGP", 13.51),
        };
    }

    public double Convert(string from, string to, double amount)
    {
        if (from == to) return amount;

        var rate = _exchangRate.FirstOrDefault(x => x.baseCurrency == from && x.targetCurrency == to);
        if (rate == null) throw new Exception("Exchange rate not found");
        return amount * rate.rate;
    }
}
