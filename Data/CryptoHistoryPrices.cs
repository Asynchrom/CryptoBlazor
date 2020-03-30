using System.Collections.Generic;

namespace CryptoBlazor.Data
{
    public class CryptoHistoryPrices
    {
        public string Name { get; set;}
        public List<CryptoOneDailyPrice> historyPrices;
        
    }
}