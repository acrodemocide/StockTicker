using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTickerLogic;

namespace StockTickerTest
{
    [TestClass]
    public class StockTickerIntegrationTests
    {
        [TestMethod]
        public void BasicGameTest()
        {
            const int STARTING_NET_WORTH = 5000;
            Game game = Game.GetGame();
            game.NewGame();
            Player player1 = new Player("Bob");
            Player player2 = new Player("Joe");
            Player player3 = new Player("Fred");
            Player player4 = new Player("Sue");
            Player player5 = new Player("Jane");
            Player player6 = new Player("Ann");
            Assert.AreEqual(player1.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player2.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player3.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player4.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player5.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player6.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player1.GetCashValue(), STARTING_NET_WORTH);
            Assert.AreEqual(player2.GetCashValue(), STARTING_NET_WORTH);
            Assert.AreEqual(player3.GetCashValue(), STARTING_NET_WORTH);
            Assert.AreEqual(player4.GetCashValue(), STARTING_NET_WORTH);
            Assert.AreEqual(player5.GetCashValue(), STARTING_NET_WORTH);
            Assert.AreEqual(player6.GetCashValue(), STARTING_NET_WORTH);
            game.AddPlayer(player1);
            game.AddPlayer(player2);
            game.AddPlayer(player3);
            game.AddPlayer(player4);
            game.AddPlayer(player5);
            game.AddPlayer(player6);
            game.BuyStock(player1.GetName(), StockId.BONDS, 5);
            game.BuyStock(player2.GetName(), StockId.GOLD, 5);
            game.BuyStock(player3.GetName(), StockId.GRAIN, 5);
            game.BuyStock(player4.GetName(), StockId.INDUSTRY, 5);
            game.BuyStock(player5.GetName(), StockId.OIL, 5);
            game.BuyStock(player6.GetName(), StockId.SILVER, 5);
            Assert.AreEqual(player1.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player2.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player3.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player4.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player5.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player6.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(player1.GetCashValue(), 0);
            Assert.AreEqual(player2.GetCashValue(), 0);
            Assert.AreEqual(player3.GetCashValue(), 0);
            Assert.AreEqual(player4.GetCashValue(), 0);
            Assert.AreEqual(player5.GetCashValue(), 0);
            Assert.AreEqual(player6.GetCashValue(), 0);
        }
    }
}
