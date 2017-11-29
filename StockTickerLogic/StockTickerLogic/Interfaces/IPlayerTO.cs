using System.Collections.Generic;

namespace StockTickerLogic.Interfaces
{
    public interface IPlayerTO
    {
        string Name { get; set; }
        IDictionary<StockId, IStockPositionTO> Portfolio { get; set; }
        int Cash { get; set; }
    }
}
