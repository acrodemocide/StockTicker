using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTickerLogic;

namespace StockTickerTest
{
    [TestClass]
    public class PlayerUnitTests
    {
        [TestMethod]
        public void BuyPosition_SingleStock_ValueEqualsCash_Test()
        {
            int endingCashValue = 0;
            StockId stockToBuy = StockId.BONDS;
            int numberOfStocksToBuy = 1;
            string playerName = "test";
            Mock<IDictionary<StockId, IStockPosition>> mockPortfolio = new Mock<IDictionary<StockId, IStockPosition>>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            List<StockId> mockDictionaryKeys = new List<StockId>();
            mockDictionaryKeys.Add(StockId.BONDS);
            List<IStockPosition> mockDicationaryValues = new List<IStockPosition>();
            mockDicationaryValues.Add(mockStockPosition.Object);
            int testShareValue = 5000;
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(testShareValue);
            mockPortfolio.SetupGet(x => x[It.IsAny<StockId>()]).Returns(mockStockPosition.Object);
            mockPortfolio.SetupGet(x => x.Keys).Returns(mockDictionaryKeys);
            mockPortfolio.SetupGet(x => x.Values).Returns(mockDicationaryValues);
            Player player = new Player(playerName, mockPortfolio.Object);

            try
            {
                player.BuyPosition(stockToBuy, numberOfStocksToBuy);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            Assert.AreEqual(player.GetCashValue(), endingCashValue);
        }

        [TestMethod]
        public void BuyPosition_NumberToBuyIsZero_Test()
        {
            int endingCashValue = 5000;
            StockId stockToBuy = StockId.BONDS;
            int numberOfStocksToBuy = 0;
            string playerName = "test";
            Mock<IDictionary<StockId, IStockPosition>> mockPortfolio = new Mock<IDictionary<StockId, IStockPosition>>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            List<StockId> mockDictionaryKeys = new List<StockId>();
            mockDictionaryKeys.Add(StockId.BONDS);
            List<IStockPosition> mockDicationaryValues = new List<IStockPosition>();
            mockDicationaryValues.Add(mockStockPosition.Object);
            int testShareValue = 5000;
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(testShareValue);
            mockPortfolio.SetupGet(x => x[It.IsAny<StockId>()]).Returns(mockStockPosition.Object);
            mockPortfolio.SetupGet(x => x.Keys).Returns(mockDictionaryKeys);
            mockPortfolio.SetupGet(x => x.Values).Returns(mockDicationaryValues);
            Player player = new Player(playerName, mockPortfolio.Object);

            try
            {
                player.BuyPosition(stockToBuy, numberOfStocksToBuy);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(player.GetCashValue(), endingCashValue);
        }

        [TestMethod]
        public void BuyPosition_NumberToBuyIsOne_ValueLessThanCash_Test()
        {
            int endingCashValue = 1000;
            StockId stockToBuy = StockId.BONDS;
            int numberOfStocksToBuy = 1;
            string playerName = "test";
            Mock<IDictionary<StockId, IStockPosition>> mockPortfolio = new Mock<IDictionary<StockId, IStockPosition>>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            List<StockId> mockDictionaryKeys = new List<StockId>();
            mockDictionaryKeys.Add(StockId.BONDS);
            List<IStockPosition> mockDicationaryValues = new List<IStockPosition>();
            mockDicationaryValues.Add(mockStockPosition.Object);
            int testShareValue = 4000;
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(testShareValue);
            mockPortfolio.SetupGet(x => x[It.IsAny<StockId>()]).Returns(mockStockPosition.Object);
            mockPortfolio.SetupGet(x => x.Keys).Returns(mockDictionaryKeys);
            mockPortfolio.SetupGet(x => x.Values).Returns(mockDicationaryValues);
            Player player = new Player(playerName, mockPortfolio.Object);

            try
            {
                player.BuyPosition(stockToBuy, numberOfStocksToBuy);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(player.GetCashValue(), endingCashValue);
        }
    }
}
