using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCore_Web_Api.Services;
using System.Collections.Generic;

namespace NETCore_Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ILogger<TradeController> _logger;
        public TradeServices TS = new TradeServices();
        public TradeController(ILogger<TradeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Pair> GetTrade(string symbol, int? limit = null) => TS.GetTrade(symbol, limit);
    }
}
