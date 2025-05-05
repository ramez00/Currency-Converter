namespace SingleTonPattern;
public class ExchangeRate
{
    public ExchangeRate(string baseCurrency,string targetCurrency,double rate)
    {
        this.baseCurrency = baseCurrency;
        this.targetCurrency = targetCurrency;
        this.rate = rate;
    }
    public string baseCurrency { get; }
    public string targetCurrency { get;}
    public Double rate { get; }
}
