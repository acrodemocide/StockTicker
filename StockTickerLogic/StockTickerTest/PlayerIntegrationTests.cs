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
    }
}
