using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace NETCore_Web_Api.Services
{
    public class TradeServices
    {
        public List<Pair> GetTrade(string symbol, int? limit)
        {
            string url = "https://api.binance.com/api/v3/trades";
            url += String.Format("?symbol={0}", symbol ?? "BTCUSDT");
            url += String.Format("&limit={0}", limit ?? 10);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 1000 * 5;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<List<Pair>>(content);
        }
    }
}
