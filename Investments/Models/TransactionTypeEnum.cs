namespace Investments
{
	public enum TransactionTypeEnum
    {
        Transfer = 0,           // Tavaline ülekanne
        ServiceFee = 1,         // Teenustasu
        Buy = 2,                // Ostmine
        Sell = 3,               // Müümine
        Dividend = 4,           // Dividendimakse
        CurrencyExchange = 5    // Valuuta vahetamine
    }
}
