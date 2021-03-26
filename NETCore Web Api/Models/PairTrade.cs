using Newtonsoft.Json;

namespace NETCore_Web_Api.Models
{
    public class PairTrade
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "isBestMatch")]
        public bool IsBestMatch { get; set; }

        [JsonProperty(PropertyName = "isBuyerMaker")]
        public bool IsBuyerMaker { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "qty")]
        public float Quantity { get; set; }

        [JsonProperty(PropertyName = "quoteQty")]
        public float QuoteQuantity { get; set; }

        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }
    }
}
