using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCore_Web_Api.Models;
using NETCore_Web_Api.Services;
using System.Collections.Generic;

namespace NETCore_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ILogger<TradeController> _logger;
        public TradeServices TS = new TradeServices();
        public TradeController(ILogger<TradeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetTrade")]
        public Pair GetTrade(string symbol = "BTC_USDT", int? limit = 10) => TS.GetTrade(symbol, limit);

        [HttpGet("GetAllTokens")]
        public List<Pair> GetAllTokens() => TS.GetAllTokens();
    }
}
