using System.Collections.Generic;
using StockTickerLogic.Interfaces;

namespace StockTickerLogic
{
    public class PlayerTO: IPlayerTO
    {
        public string Name { get; set; }
        public IDictionary<StockId, IStockPositionTO> Portfolio { get; set; }
        public int Cash { get; set; }
        public int GetNetWorth()
        {
            int netWorth = Cash;
            foreach (var keyValuePair in Portfolio)
            {
                var stockPosition = keyValuePair.Value;
                netWorth += stockPosition.StockOwned.Value * stockPosition.NumberOwned;
            }
            return netWorth;
        }
    }
}
