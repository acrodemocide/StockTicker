using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTickerLogic.Interfaces;

namespace StockTickerLogic
{
    internal interface IStockMarket
    {
        void MarketMovement();
        void Reset();
        IQueryable<IStockTO> GetStocks();
        IStockTO GetStockById(StockId stockId);
    }
}
