using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic
{
    class Player : IObserver
    {
        private string _name;
        private Dictionary<StockId, StockPosition> _portfolio;
        private int _cash;

        public Player(string name)
        {
            _name = name;
            _cash = 5000;

            _portfolio = new Dictionary<StockId, StockPosition>();
            _portfolio[StockId.GOLD] = new StockPosition(StockId.GOLD);
            _portfolio[StockId.SILVER] = new StockPosition(StockId.SILVER);
            _portfolio[StockId.OIL] = new StockPosition(StockId.OIL);
            _portfolio[StockId.BONDS] = new StockPosition(StockId.BONDS);
            _portfolio[StockId.INDUSTRY] = new StockPosition(StockId.INDUSTRY);
            _portfolio[StockId.GRAIN] = new StockPosition(StockId.GRAIN);
    }

        public void BuyPosition(StockId stockId, int numberOfStocks)
        {
            Stock stockToPurchase = Stock.GetStockInstance(stockId);
            int cost = stockToPurchase.Value * numberOfStocks;
            if (cost <= _cash)
            {
                _cash -= cost;
                _portfolio[stockId].NumberOwned += numberOfStocks;
            }
            else
            {
                throw new ArgumentException("Not enough money");
            }
        }

        public void SellPosition(StockId stockId, int numberOfStocks)
        {
            if (numberOfStocks <= _portfolio[stockId].NumberOwned)
            {
                int value = _portfolio[stockId].GetShareValue() * numberOfStocks;
                _cash += value;
                _portfolio[stockId].NumberOwned -= numberOfStocks;
            }
            else
            {
                throw new ArgumentException("Not enough stocks to sell");
            }
        }

        public void CollectDividends(StockId stockId, int dividendAmount)
        {
            int payout = _portfolio[stockId].GetDividenPayout(dividendAmount);
            _cash += payout;
        }

        public int GetCashValue()
        {
            return _cash;
        }

        public int GetNetWorth()
        {
            int totalValue = _cash;
            foreach (KeyValuePair<StockId, StockPosition> entry in _portfolio)
            {
                totalValue += entry.Value.GetTotalValue();
            }
            return totalValue;
        }

        public void Update(StockId stockId, int dividendAmount)
        {
            CollectDividends(stockId, dividendAmount);
        }
    }
}
