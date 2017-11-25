using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    internal interface IStockMarket
    {
        void MarketMovement();
        void Reset();
    }
}
