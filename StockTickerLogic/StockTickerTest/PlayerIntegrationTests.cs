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
    }
}
