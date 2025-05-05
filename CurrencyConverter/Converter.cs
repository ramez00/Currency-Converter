namespace SingleTonPattern;
public class Converter
{
    private IEnumerable<ExchangeRate> _exchangRate;

    private static Lazy<Converter> _instance; // Lazy initialization

    private static readonly object _lock = new(); // Lock object for thread safety

    //private static Converter _instance = new(); // Eager initialization

    public static Converter Instance
    {
        get
        {
            lock (_lock) // Ensure thread safety
            {
                if (_instance == null)
                {
                    _instance = new Lazy<Converter>(() => new Converter());
                }
                return _instance.Value;
            }
        }
    }

    private Converter()
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
