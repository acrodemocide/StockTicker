using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    internal interface IStock
    {
        /// <summary>
        /// Resets the stock to its initial value for
        /// the start of the game.
        /// </summary>
        void Reset();
        StockId Id { get; set; }
        int Value { get; set; }
    }
}
