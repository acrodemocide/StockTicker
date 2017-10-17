using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTickerLogic;

namespace StockTickerTest
{
    [TestClass]
    public class StockPositionUnitTests
    {
        const int STARTING_VALUE = 1000;
        [TestMethod]
        public void GetShareValueReturnsCorrectValue()
        {
            StockPosition stockPostion = new StockPosition(StockId.BONDS);
            var shareValue = stockPostion.GetShareValue();
            Assert.AreEqual(shareValue, STARTING_VALUE);
        }

        [TestMethod]
        public void GetTotalValueReturnsCorrectValueForOneStockOwned()
        {
            int numberOwned = 1;
            StockPosition stockPostion = new StockPosition(StockId.BONDS);
            stockPostion.NumberOwned = numberOwned;
            var totalValue = stockPostion.GetTotalValue();
            Assert.AreEqual(totalValue, STARTING_VALUE);
        }

        [TestMethod]
        public void GetTotalValueReturnsCorrectValueForTwoStocksOwned()
        {
            int numberOwned = 2;
            StockPosition stockPostion = new StockPosition(StockId.BONDS);
            stockPostion.NumberOwned = numberOwned;
            var totalValue = stockPostion.GetTotalValue();
            Assert.AreEqual(totalValue, STARTING_VALUE * numberOwned);
        }

        [TestMethod]
        public void GetTotalValueReturnsCorrectValueForThreeStocksOwned()
        {
            int numberOwned = 3;
            StockPosition stockPostion = new StockPosition(StockId.BONDS);
            stockPostion.NumberOwned = numberOwned;
            var totalValue = stockPostion.GetTotalValue();
            Assert.AreEqual(totalValue, STARTING_VALUE * numberOwned);
        }

        [TestMethod]
        public void GetDividendPayoutReturnsCorrectValueForOneStockOwned()
        {
            int numberOwned = 1;
            int dividendAmount = 10;
            StockPosition stockPostion = new StockPosition(StockId.BONDS);
            stockPostion.NumberOwned = numberOwned;
            var dividendPayout = stockPostion.GetDividenPayout(dividendAmount);
            Assert.AreEqual(dividendPayout, dividendAmount * numberOwned);
        }

        [TestMethod]
        public void GetDividendPayoutReturnsCorrectValueForTwoStocksOwned()
        {
            int numberOwned = 2;
            int dividendAmount = 10;
            StockPosition stockPostion = new StockPosition(StockId.BONDS);
            stockPostion.NumberOwned = numberOwned;
            var dividendPayout = stockPostion.GetDividenPayout(dividendAmount);
            Assert.AreEqual(dividendPayout, dividendAmount * numberOwned);
        }

        [TestMethod]
        public void GetDividendPayoutReturnsCorrectValueForThreeStocksOwned()
        {
            int numberOwned = 3;
            int dividendAmount = 10;
            StockPosition stockPostion = new StockPosition(StockId.BONDS);
            stockPostion.NumberOwned = numberOwned;
            var dividendPayout = stockPostion.GetDividenPayout(dividendAmount);
            Assert.AreEqual(dividendPayout, dividendAmount * numberOwned);
        }
    }
}
