using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    class StockMarket
    {
        private Dictionary<StockId, Stock> _stocks;
        public static StockMarket instance = null;

        private StockMarket()
        {
            _stocks = new Dictionary<StockId, Stock>();
            _stocks[StockId.GOLD] = Stock.GetStockInstance(StockId.GOLD);
            _stocks[StockId.SILVER] = Stock.GetStockInstance(StockId.SILVER);
            _stocks[StockId.OIL] = Stock.GetStockInstance(StockId.OIL);
            _stocks[StockId.BONDS] = Stock.GetStockInstance(StockId.BONDS);
            _stocks[StockId.INDUSTRY] = Stock.GetStockInstance(StockId.INDUSTRY);
            _stocks[StockId.GRAIN] = Stock.GetStockInstance(StockId.GRAIN);
        }

        public StockMarket GetStocksBoard()
        {
            if (instance == null)
            {
                instance = new StockMarket();
            }
            return instance;
        }

        private void IncrementStock(StockId stockId, int incrementValue)
        {
            _stocks[stockId].Value += incrementValue;
        }

        public void MarketMovement()
        {
            const int FIVE = 1;
            const int TEN = 2;
            const int TWENTY = 3;
            const int DOWN = 1;
            const int DIVIDENDS = 2;
            const int UP = 3;
            const int NUMBER_OF_STOCKS_LIMIT = 7;
            Random rnd = new Random();
            
            int action = rnd.Next(1, 4);
            int selectedStock = rnd.Next(1, NUMBER_OF_STOCKS_LIMIT);
            
            int amount = 0;
            switch (rnd.Next(1, 4))
            {
                case FIVE:
                    amount = 5;
                    break;
                case TEN:
                    amount = 10;
                    break;
                case TWENTY:
                    amount = 20;
                    break;
            }

            StockId id = (StockId)selectedStock;
            if (action == UP)
            {
                _stocks[id].Value += amount;
            }
            else if (action == DIVIDENDS)
            {
                // TODO: Implement
            }
            else if (action == DOWN)
            {
                _stocks[id].Value -= amount;
            }
        }
    }
}
