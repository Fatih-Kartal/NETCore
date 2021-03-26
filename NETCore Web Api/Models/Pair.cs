using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Web_Api.Models
{
    public class Pair
    {
        public string Name { get; set; }
        public List<PairTrade> Trades { get; set; }
        public string First
        {
            get
            {
                return this.Name.Split("_")[0];
            }
        }
        public string Second
        {
            get
            {
                return this.Name.Split("_")[1];
            }
        }
    }
}
