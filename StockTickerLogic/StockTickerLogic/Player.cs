using System;
using System.Collections.Generic;

namespace StockTickerLogic
{
    internal class Player : IObserver
    {
        private string _name;
        // _portfolio holds all the possible stock positions a player can have
        //  in a game. If the player does not own a stock, then the stock
        //  stock position for that particular stock will indicate 0 are owned.
        private IDictionary<StockId, IStockPosition> _portfolio;
        private int _cash;

        public Player(string name, IDictionary<StockId, IStockPosition> portfolio)
        {
            _name = name;
            _cash = 5000;
            _portfolio = portfolio;
        }

        public void BuyPosition(StockId stockId, int numberOfStocks)
        {
            var stockToPurchase = _portfolio[stockId];
            int cost = stockToPurchase.GetShareValue() * numberOfStocks;
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
            foreach (KeyValuePair<StockId, IStockPosition> entry in _portfolio)
            {
                totalValue += entry.Value.GetTotalValue();
            }
            return totalValue;
        }

        /// <summary>
        /// Observer pattern update method. This is to update the
        /// dividends that the player collects when the stock market
        /// pays dividends
        /// </summary>
        /// <param name="stockId">Id of stock paying dividends</param>
        /// <param name="dividendAmount">number of dividends paid</param>
        public void Update(StockId stockId, int dividendAmount)
        {
            CollectDividends(stockId, dividendAmount);
        }

        public string GetName()
        {
            return _name;
        }

        public IDictionary<StockId, IStockPosition> GetPortfolio()
        {
            return _portfolio;
        }
    }
}
