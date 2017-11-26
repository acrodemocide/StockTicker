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
        private IDictionary<StockId, IStockPosition> _portfolio;

        [TestInitialize]
        private void TestInitialize()
        {
            
        }

        [TestCleanup]
        private void TestCleanup()
        {
            _portfolio = null;
        }

        [TestMethod]
        public void BuyPosition_ValueEqualsCash_Test()
        {
            const StockId StockToBuy = StockId.BONDS;
            const int TestShareValue = 5000;
            const int EndingCashValue = 0;
            const int NumberOfStocksToBuy = 1;
            const string PlayerName = "test";
            IDictionary<StockId, IStockPosition> mockPortfolio = new Dictionary<StockId, IStockPosition>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(TestShareValue);
            mockPortfolio[StockToBuy] = mockStockPosition.Object;
            Player player = new Player(PlayerName, mockPortfolio);

            try
            {
                player.BuyPosition(StockToBuy, NumberOfStocksToBuy);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            Assert.AreEqual(player.GetCashValue(), EndingCashValue);
        }

        [TestMethod]
        public void BuyPosition_NumberToBuyIsZero_Test()
        {
            const StockId StockToBuy = StockId.BONDS;
            const int TestShareValue = 5000;
            const int EndingCashValue = 5000;
            const int NumberOfStocksToBuy = 0;
            const string PlayerName = "test";
            IDictionary<StockId, IStockPosition> mockPortfolio = new Dictionary<StockId, IStockPosition>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(TestShareValue);
            mockPortfolio[StockToBuy] = mockStockPosition.Object;
            Player player = new Player(PlayerName, mockPortfolio);

            try
            {
                player.BuyPosition(StockToBuy, NumberOfStocksToBuy);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            Assert.AreEqual(player.GetCashValue(), EndingCashValue);
        }

        [TestMethod]
        public void BuyPosition_ValueLessThanCash_Test()
        {
            const StockId StockToBuy = StockId.BONDS;
            const int TestShareValue = 4000;
            const int EndingCashValue = 1000;
            const int NumberOfStocksToBuy = 1;
            const string PlayerName = "test";
            IDictionary<StockId, IStockPosition> mockPortfolio = new Dictionary<StockId, IStockPosition>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(TestShareValue);
            mockPortfolio[StockToBuy] = mockStockPosition.Object;
            Player player = new Player(PlayerName, mockPortfolio);

            try
            {
                player.BuyPosition(StockToBuy, NumberOfStocksToBuy);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            Assert.AreEqual(player.GetCashValue(), EndingCashValue);
        }

        [TestMethod]
        public void BuyPosition_ValueGreaterThanCash_Test()
        {
            const StockId StockToBuy = StockId.BONDS;
            const int TestShareValue = 6000;
            const int EndingCashValue = 5000;
            const int NumberOfStocksToBuy = 1;
            const string PlayerName = "test";
            IDictionary<StockId, IStockPosition> mockPortfolio = new Dictionary<StockId, IStockPosition>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(TestShareValue);
            mockPortfolio[StockToBuy] = mockStockPosition.Object;
            Player player = new Player(PlayerName, mockPortfolio);

            try
            {
                player.BuyPosition(StockToBuy, NumberOfStocksToBuy);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.AreEqual(player.GetCashValue(), EndingCashValue);
            }
        }

        [TestMethod]
        public void SellPostion_SellLessThanWhatIsOwned_Test()
        {
            const StockId StockOwned = StockId.BONDS;
            const int ExpectedCashValue = 9000;
            const int ShareValue = 1000;
            const int NumberOfStocksOwned = 5;
            const int NumberOfStocksToSell = 4;
            const string PlayerName = "test";
            IDictionary<StockId, IStockPosition> mockPortfolio = new Dictionary<StockId, IStockPosition>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(ShareValue);
            mockStockPosition.SetupGet(x => x.NumberOwned).Returns(NumberOfStocksOwned);
            mockPortfolio[StockOwned] = mockStockPosition.Object;
            Player player = new Player(PlayerName, mockPortfolio);

            try
            {
                player.SellPosition(StockOwned, NumberOfStocksToSell);
            }
            catch(ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(ExpectedCashValue, player.GetCashValue());
        }

        [TestMethod]
        public void SellPostion_SellAllThatIsOwned_Test()
        {
            const StockId StockOwned = StockId.BONDS;
            const int ExpectedCashValue = 10000;
            const int ShareValue = 1000;
            const int NumberOfStocksOwned = 5;
            const int NumberOfStocksToSell = 5;
            const string PlayerName = "test";
            IDictionary<StockId, IStockPosition> mockPortfolio = new Dictionary<StockId, IStockPosition>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(ShareValue);
            mockStockPosition.SetupGet(x => x.NumberOwned).Returns(NumberOfStocksOwned);
            mockPortfolio[StockOwned] = mockStockPosition.Object;
            Player player = new Player(PlayerName, mockPortfolio);

            try
            {
                player.SellPosition(StockOwned, NumberOfStocksToSell);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(ExpectedCashValue, player.GetCashValue());
        }

        [TestMethod]
        public void SellPostion_SellMoreThanWhatIsOwned_Test()
        {
            const StockId StockOwned = StockId.BONDS;
            const int ExpectedCashValue = 5000;
            const int ShareValue = 1000;
            const int NumberOfStocksOwned = 5;
            const int NumberOfStocksToSell = 6;
            const string PlayerName = "test";
            IDictionary<StockId, IStockPosition> mockPortfolio = new Dictionary<StockId, IStockPosition>();
            Mock<IStockPosition> mockStockPosition = new Mock<IStockPosition>();
            mockStockPosition.Setup(x => x.GetShareValue()).Returns(ShareValue);
            mockStockPosition.SetupGet(x => x.NumberOwned).Returns(NumberOfStocksOwned);
            mockPortfolio[StockOwned] = mockStockPosition.Object;
            Player player = new Player(PlayerName, mockPortfolio);

            try
            {
                player.SellPosition(StockOwned, NumberOfStocksToSell);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.AreEqual(ExpectedCashValue, player.GetCashValue());
            }
        }
    }
}
