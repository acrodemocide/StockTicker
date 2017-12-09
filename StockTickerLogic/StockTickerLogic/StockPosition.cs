using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    internal class StockPosition: IStockPosition
    {
        private IStock _stockOwned;
        private int _numberOwned;
        private const int _DIVIDEND_MULTIPLIER = 10;

        public StockPosition(IStock stockOwned)
        {
            _stockOwned = stockOwned;
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
            return dividendAmount * _DIVIDEND_MULTIPLIER * _numberOwned;
        }

        public IStock GetStockOwned()
        {
            return _stockOwned;
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
