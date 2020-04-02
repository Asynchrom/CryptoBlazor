using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoBlazor.Data;
using Google.Cloud.Firestore;

namespace CryptoBlazor.Data
{
    public class DataAccess
    {
        private string ProjectId;
        private FirestoreDb DB;

        
        public DataAccess()
        {
            string filepath = "Shared/crypt-a0911-firebase-adminsdk-3g6ci-899c02e695.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            ProjectId = "crypt-a0911";
            DB = FirestoreDb.Create(ProjectId);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", ProjectId);
        }
        
        //collectionName == "bitcoinHistory" , "ethereumHistory" , "tetherHistory" , bitcoin-cashHistory"
        //"bitcoin-svHistory" , "litecoinHistory", "eosHistory" , "binance-coinHistory" , "tezosHistory" , "unus-sed-leoHistory"
        public async Task<CryptoHistoryPrices> GetCryptoData(string collectionName)
        {
            try
            {
                Query cryptoQuery = DB.Collection(collectionName);
                QuerySnapshot cryptoQuerySnapshot = await cryptoQuery.GetSnapshotAsync();
                List<CryptoOneDailyPrice> cryptoPrices = new List<CryptoOneDailyPrice>();

                foreach (DocumentSnapshot documentSnapshot in cryptoQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> dbPrice = documentSnapshot.ToDictionary();

                        CryptoOneDailyPrice price = new CryptoOneDailyPrice(
                            dbPrice["datetime"].ToString(),
                            (double) dbPrice["marketcap"], 
                            (double) dbPrice["priceUsd"],
                            (double) dbPrice["priceBtc"],
                             (double) dbPrice["volume"]);
                        
                        cryptoPrices.Add(price);
                    }
                }
                string name = collectionName.Substring(0, collectionName.Length - 7);
                
                CryptoHistoryPrices data = new CryptoHistoryPrices();
                data.Name = name;
                data.historyPrices = cryptoPrices;
                return data;
            }
            catch
            {
                throw;
            }
        }
    }
}