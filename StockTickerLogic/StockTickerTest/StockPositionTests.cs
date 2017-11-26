using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTickerLogic;

namespace StockTickerTest
{
    [TestClass]
    public class StockPositionTests
    {
        const int STARTING_VALUE = 1000;
        [TestMethod]
        public void GetShareValueReturnsCorrectValue()
        {
            StockPosition stockPostion = new StockPosition(new Stock(StockId.BONDS));
            var shareValue = stockPostion.GetShareValue();
            Assert.AreEqual(shareValue, STARTING_VALUE);
        }

        [TestMethod]
        public void GetTotalValueReturnsCorrectValueForOneStockOwned()
        {
            int numberOwned = 1;
            StockPosition stockPostion = new StockPosition(new Stock(StockId.BONDS));
            stockPostion.NumberOwned = numberOwned;
            var totalValue = stockPostion.GetTotalValue();
            Assert.AreEqual(totalValue, STARTING_VALUE);
        }

        [TestMethod]
        public void GetTotalValueReturnsCorrectValueForTwoStocksOwned()
        {
            int numberOwned = 2;
            StockPosition stockPostion = new StockPosition(new Stock(StockId.BONDS));
            stockPostion.NumberOwned = numberOwned;
            var totalValue = stockPostion.GetTotalValue();
            Assert.AreEqual(totalValue, STARTING_VALUE * numberOwned);
        }

        [TestMethod]
        public void GetTotalValueReturnsCorrectValueForThreeStocksOwned()
        {
            int numberOwned = 3;
            StockPosition stockPostion = new StockPosition(new Stock(StockId.BONDS));
            stockPostion.NumberOwned = numberOwned;
            var totalValue = stockPostion.GetTotalValue();
            Assert.AreEqual(totalValue, STARTING_VALUE * numberOwned);
        }

        [TestMethod]
        public void GetDividendPayoutReturnsCorrectValueForOneStockOwned()
        {
            const int NUMBER_OWNED = 1;
            const int DIVIDEND_AMOUNT = 10;
            const int DIVIDEND_MULTIPLIER = 10;
            const int EXPECTED_DIVIDEND_PAYOUT = DIVIDEND_AMOUNT * DIVIDEND_MULTIPLIER * NUMBER_OWNED;
            StockPosition stockPostion = new StockPosition(new Stock(StockId.BONDS));
            stockPostion.NumberOwned = NUMBER_OWNED;
            var dividendPayout = stockPostion.GetDividenPayout(DIVIDEND_AMOUNT);
            Assert.AreEqual(dividendPayout, EXPECTED_DIVIDEND_PAYOUT);
        }

        [TestMethod]
        public void GetDividendPayoutReturnsCorrectValueForTwoStocksOwned()
        {
            const int NUMBER_OWNED = 2;
            const int DIVIDEND_AMOUNT = 10;
            const int DIVIDEND_MULTIPLIER = 10;
            const int EXPECTED_DIVIDEND_PAYOUT = DIVIDEND_AMOUNT * DIVIDEND_MULTIPLIER * NUMBER_OWNED; 
            StockPosition stockPostion = new StockPosition(new Stock(StockId.BONDS));
            stockPostion.NumberOwned = NUMBER_OWNED;
            var dividendPayout = stockPostion.GetDividenPayout(DIVIDEND_AMOUNT);
            Assert.AreEqual(dividendPayout, EXPECTED_DIVIDEND_PAYOUT);
        }

        [TestMethod]
        public void GetDividendPayoutReturnsCorrectValueForThreeStocksOwned()
        {
            const int NUMBER_OWNED = 3;
            const int DIVIDEND_AMOUNT = 10;
            const int DIVIDEND_MULTIPLIER = 10;
            const int EXPECTED_DIVIDEND_PAYOUT = DIVIDEND_AMOUNT * DIVIDEND_MULTIPLIER * NUMBER_OWNED;
            StockPosition stockPostion = new StockPosition(new Stock(StockId.BONDS));
            stockPostion.NumberOwned = NUMBER_OWNED;
            var dividendPayout = stockPostion.GetDividenPayout(DIVIDEND_AMOUNT);
            Assert.AreEqual(dividendPayout, EXPECTED_DIVIDEND_PAYOUT);
        }
    }
}
