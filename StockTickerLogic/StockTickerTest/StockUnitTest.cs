using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTickerLogic;

namespace StockTickerTest
{
    [TestClass]
    public class StockUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stock asdf = Stock.GetStockInstance(StockId.BONDS);
        }
    }
}
