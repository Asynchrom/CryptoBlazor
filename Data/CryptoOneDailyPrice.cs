namespace CryptoBlazor.Data
{
    public class CryptoOneDailyPrice
    {
        public string Datetime { get; set; }
        public double MarketCap { get; set; }
        public double PriceUsd { get; set; }
        public double PriceBtc { get; set; } //crypto price in bitcoins
        public double Volume { get; set; }

        public CryptoOneDailyPrice(string date, double cap, double usd, double btc, double vol)
        {
            Datetime = date;
            MarketCap = cap;
            PriceUsd = usd;
            PriceBtc = btc;
            Volume = vol;
        }
    }
}