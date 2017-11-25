using System;
using System.Collections.Generic;

namespace StockTickerLogic
{
    internal class StockMarket : ISubject, IStockMarket
    {
        private const int DIVIDEND_MIN_VALUE = 1000;
        private List<IObserver> _observers;
        private IDictionary<StockId, IStock> _stocks;
        private static StockMarket instance = null;

        private StockMarket()
        {
            _observers = new List<IObserver>();
            _stocks = new Dictionary<StockId, IStock>();
            _stocks[StockId.GOLD] = new Stock(StockId.GOLD);
            _stocks[StockId.SILVER] = new Stock(StockId.SILVER);
            _stocks[StockId.OIL] = new Stock(StockId.OIL);
            _stocks[StockId.BONDS] = new Stock(StockId.BONDS);
            _stocks[StockId.INDUSTRY] = new Stock(StockId.INDUSTRY);
            _stocks[StockId.GRAIN] = new Stock(StockId.GRAIN);
        }

        public static StockMarket GetStockBoard()
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

        public virtual void MarketMovement()
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
            else if (action == DIVIDENDS && _stocks[id].Value >= DIVIDEND_MIN_VALUE)
            {
                NotifyObservers(id, amount);
            }
            else if (action == DOWN)
            {
                _stocks[id].Value -= amount;
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void NotifyObservers(StockId stockId, int dividendAmount)
        {
            foreach(IObserver observer in _observers)
            {
                observer.Update(stockId, dividendAmount);
            }
        }

        public void Reset()
        {
            _observers.Clear();
            foreach(KeyValuePair<StockId, IStock> entry in _stocks)
            {
                entry.Value.Reset();
            }
        }
    }
}
