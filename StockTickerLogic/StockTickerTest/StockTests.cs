using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTickerLogic;

namespace StockTickerTest
{
    [TestClass]
    public class StockUnitTest
    {
        const int START_VALUE = 1000;
        [TestMethod]
        public void CanGetStockInstance()
        {
            Stock stock = new Stock(StockId.GOLD);
            Assert.AreNotEqual(stock, null);
        }

        [TestMethod]
        public void ResetSetsValueBackToStartValue()
        {
            int newValue = 2000;
            Stock stock = new Stock(StockId.GOLD);
            stock.Value = newValue;
            stock.Reset();
            Assert.AreEqual(stock.Value, START_VALUE);
        }
    }
}
