using System.Collections.Generic;
using StockTickerLogic.Interfaces;

namespace StockTickerLogic
{
    public class PlayerTO: IPlayerTO
    {
        public string Name { get; set; }
        public IDictionary<StockId, IStockPositionTO> Portfolio { get; set; }
        public int Cash { get; set; }
    }
}
