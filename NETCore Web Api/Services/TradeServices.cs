using NETCore_Web_Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace NETCore_Web_Api.Services
{
    public class TradeServices
    {
        public string[] tokenPairs = { "ACM_USDT", "ACM_BUSD", "ASR_USDT", "ATM_USDT", "JUV_USDT", "JUV_BUSD", "OG_USDT", "PSG_USDT", "PSG_BUSD" };

        public Pair GetTrade(string symbol, int? limit)
        {
            string url = "https://api.binance.com/api/v3/trades";
            url += String.Format("?symbol={0}", symbol.Replace("_", ""));
            url += String.Format("&limit={0}", limit);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 1000 * 3;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var pair = new Pair();
            pair.Name = symbol;
            pair.Trades = JsonConvert.DeserializeObject<List<PairTrade>>(content);

            return pair;
        }

        public Pair GetTradeAsync(string symbol, int? limit)
        {
            string url = "https://api.binance.com/api/v3/trades";
            url += String.Format("?symbol={0}", symbol.Replace("_", ""));
            url += String.Format("&limit={0}", limit);

            var content = RequestServices.MakeAsyncRequest(url);

            var pair = new Pair();
            pair.Name = symbol;
            pair.Trades = JsonConvert.DeserializeObject<List<PairTrade>>(content.Result);

            return pair;
        }

        public List<Pair> GetAllTokens()
        {
            var pairList = new List<Pair>();
            foreach (var tokenPair in tokenPairs)
            {
                pairList.Add(GetTradeAsync(tokenPair, 10));
            }
            return pairList;
        }
    }
}
