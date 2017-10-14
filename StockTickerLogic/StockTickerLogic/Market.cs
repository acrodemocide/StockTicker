using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    class Market
    {
        private const int MINIMUM = 5;
        private const int MIDDLE = 10;
        private const int MAXIMUM = 20;
        public static Market instance = null;
        List<int> possibleIncrementValues;
        List<int> stocks;
        List<int> upOrDown;

        private Market()
        {

        }

        public Market GetMarket()
        {
            if (instance == null)
            {
                instance = new Market();
            }
            return instance;
        }
    }
}
