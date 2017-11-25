using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    class Stock: IStock
    {
        private const int START_VALUE = 1000;
        private StockId _id;
        private int _value;

        public Stock(StockId id)
        {
            _id = id;
            _value = START_VALUE;
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Resets the stock to its initial value for the start
        /// of the game.
        /// </summary>
        public void Reset()
        {
            _value = START_VALUE;
        }
    }
}
