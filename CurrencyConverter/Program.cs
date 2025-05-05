using SingleTonPattern;

while (true)
{
    Console.WriteLine("Enter the base currency (USD, EUR, EGP, SAR):");
    string baseCurrency = Console.ReadLine();
    Console.WriteLine("Enter the target currency (USD, EUR, EGP, SAR):");
    string targetCurrency = Console.ReadLine();
    Console.WriteLine("Enter the amount to convert:");
    double amount;
    while (!double.TryParse(Console.ReadLine(), out amount))
    {
        Console.WriteLine("Invalid amount. Please enter a valid number:");
    }
    try
    {
        double convertedAmount = Converter.Instance.Convert(baseCurrency, targetCurrency, amount);
        Console.WriteLine($"{amount} {baseCurrency} is equal to {convertedAmount} {targetCurrency}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    Console.WriteLine("Do you want to convert another amount? (yes/no)");
    string response = Console.ReadLine();
  
    if (response.ToLower() == "yes")
        break;

    Console.Clear();

}
