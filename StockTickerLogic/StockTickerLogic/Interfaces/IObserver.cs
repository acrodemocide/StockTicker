using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    interface IObserver
    {
        void Update(StockId stockId, int amount);
    }
}
