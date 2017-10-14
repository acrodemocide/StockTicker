using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    class StockPosition
    {
        private Stock _stockOwned;
        private int _numberOwned;

        public StockPosition(StockId id)
        {
            _stockOwned = Stock.GetStockInstance(id);
            _numberOwned = 0;
        }

        public int GetShareValue()
        {
            return _stockOwned.Value;
        }

        public int GetTotalValue()
        {
            return _stockOwned.Value * _numberOwned;
        }

        public int GetDividenPayout(int dividendAmount)
        {
            return dividendAmount * _numberOwned;
        }

        public int NumberOwned
        {
            get
            {
                return _numberOwned;
            }
            set
            {
                _numberOwned = value;
            }
        }
    }
}
