using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    class Stock
    {
        private const int START_VALUE = 1000;
        private StockId _id;
        private int _value;
        private static Stock instance = null;

        private Stock(StockId id)
        {
            _id = id;
            _value = START_VALUE;
        }

        public static Stock GetStockInstance(StockId id)
        {
            if (instance == null)
            {
                instance = new Stock(id);
            }
            return instance;
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
    }
}
