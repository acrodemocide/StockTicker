using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTickerLogic;

namespace StockTickerTest
{
    [TestClass]
    public class PlayerIntegrationTests
    {
        const int STARTING_CASH = 5000;
        [TestMethod]
        public void PlayerCorrectlyInitialized()
        {
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            Assert.AreEqual(player.GetCashValue(), STARTING_CASH);
            Assert.AreEqual(player.GetNetWorth(), STARTING_CASH);
        }

        [TestMethod]
        public void PlayerCanBuyGold()
        {
            const int NUM_POSITIONS = 1;
            const int REMAINING_CASH = 4000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            player.BuyPosition(StockId.GOLD, NUM_POSITIONS);
            Assert.AreEqual(player.GetCashValue(), REMAINING_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanBuySilver()
        {
            const int NUM_POSITIONS = 1;
            const int REMAINING_CASH = 4000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            player.BuyPosition(StockId.SILVER, NUM_POSITIONS);
            Assert.AreEqual(player.GetCashValue(), REMAINING_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanBuyOil()
        {
            const int NUM_POSITIONS = 1;
            const int REMAINING_CASH = 4000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            player.BuyPosition(StockId.OIL, NUM_POSITIONS);
            Assert.AreEqual(player.GetCashValue(), REMAINING_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanBuyBonds()
        {
            const int NUM_POSITIONS = 1;
            const int REMAINING_CASH = 4000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            player.BuyPosition(StockId.BONDS, NUM_POSITIONS);
            Assert.AreEqual(player.GetCashValue(), REMAINING_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanBuyIndustry()
        {
            const int NUM_POSITIONS = 1;
            const int REMAINING_CASH = 4000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            player.BuyPosition(StockId.INDUSTRY, NUM_POSITIONS);
            Assert.AreEqual(player.GetCashValue(), REMAINING_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanBuyGrain()
        {
            const int NUM_POSITIONS = 1;
            const int REMAINING_CASH = 4000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            player.BuyPosition(StockId.GRAIN, NUM_POSITIONS);
            Assert.AreEqual(player.GetCashValue(), REMAINING_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanBuyStockEqualToCash()
        {
            const int NUM_POSITIONS = 5;
            const int REMAINING_CASH = 0;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            player.BuyPosition(StockId.GRAIN, NUM_POSITIONS);
            Assert.AreEqual(player.GetCashValue(), REMAINING_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCannotBuyMoreStockThanCash()
        {
            const int NUM_POSITIONS = 6;
            const string ERROR_MESSAGE = "Not enough money";
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            try
            {
                player.BuyPosition(StockId.GRAIN, NUM_POSITIONS);
                Assert.Fail();
            }
            catch(ArgumentException ex)
            {
                
                Assert.AreEqual(ex.Message, ERROR_MESSAGE);
            }
        }

        [TestMethod]
        public void PlayerCanSellGold()
        {
            const int NUM_POSITIONS = 1;
            const int TOTAL_CASH = 5000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            try
            {
                player.BuyPosition(StockId.GOLD, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            try
            {
                player.SellPosition(StockId.GOLD, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(player.GetCashValue(), TOTAL_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanSellSilver()
        {
            const int NUM_POSITIONS = 1;
            const int TOTAL_CASH = 5000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            try
            {
                player.BuyPosition(StockId.SILVER, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            try
            {
                player.SellPosition(StockId.SILVER, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(player.GetCashValue(), TOTAL_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanSellOil()
        {
            const int NUM_POSITIONS = 1;
            const int TOTAL_CASH = 5000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            try
            {
                player.BuyPosition(StockId.OIL, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            try
            {
                player.SellPosition(StockId.OIL, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(player.GetCashValue(), TOTAL_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanSellBonds()
        {
            const int NUM_POSITIONS = 1;
            const int TOTAL_CASH = 5000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            try
            {
                player.BuyPosition(StockId.BONDS, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            try
            {
                player.SellPosition(StockId.BONDS, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(player.GetCashValue(), TOTAL_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanSellIndustry()
        {
            const int NUM_POSITIONS = 1;
            const int TOTAL_CASH = 5000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            try
            {
                player.BuyPosition(StockId.INDUSTRY, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            try
            {
                player.SellPosition(StockId.INDUSTRY, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(player.GetCashValue(), TOTAL_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanSellGrain()
        {
            const int NUM_POSITIONS = 1;
            const int TOTAL_CASH = 5000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            try
            {
                player.BuyPosition(StockId.GRAIN, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            try
            {
                player.SellPosition(StockId.GRAIN, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(player.GetCashValue(), TOTAL_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCanSellAllPositions()
        {
            const int NUM_POSITIONS = 5;
            const int TOTAL_CASH = 5000;
            const int TOTAL_NET_WORTH = 5000;
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            try
            {
                player.BuyPosition(StockId.GRAIN, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            try
            {
                player.SellPosition(StockId.GRAIN, NUM_POSITIONS);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.AreEqual(player.GetCashValue(), TOTAL_CASH);
            Assert.AreEqual(player.GetNetWorth(), TOTAL_NET_WORTH);
        }

        [TestMethod]
        public void PlayerCannotSellMoreThanHeOwns()
        {
            const int NUM_POSITIONS_TO_BUY = 5;
            const int NUM_POSITIONS_TO_SELL = 6;
            string ERROR_MESSAGE = "Not enough stocks to sell";
            string playerName = "Cool Guy";
            Player player = new Player(playerName);
            try
            {
                player.BuyPosition(StockId.GRAIN, NUM_POSITIONS_TO_BUY);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }

            try
            {
                player.SellPosition(StockId.GRAIN, NUM_POSITIONS_TO_SELL);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, ERROR_MESSAGE);
            }
        }
    }
}
