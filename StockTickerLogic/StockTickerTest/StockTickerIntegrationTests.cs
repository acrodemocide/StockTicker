using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTickerLogic;

namespace StockTickerTest
{
    [TestClass]
    public class StockTickerIntegrationTests
    {
        private IDictionary<StockId, IStockPosition> CreatePortfolio()
        {
            var portfolio = new Dictionary<StockId, IStockPosition>();
            portfolio[StockId.GOLD] = new StockPosition(new Stock(StockId.GOLD));
            portfolio[StockId.SILVER] = new StockPosition(new Stock(StockId.SILVER));
            portfolio[StockId.OIL] = new StockPosition(new Stock(StockId.OIL));
            portfolio[StockId.BONDS] = new StockPosition(new Stock(StockId.BONDS));
            portfolio[StockId.INDUSTRY] = new StockPosition(new Stock(StockId.INDUSTRY));
            portfolio[StockId.GRAIN] = new StockPosition(new Stock(StockId.GRAIN));
            return portfolio;
        }

        [TestMethod]
        public void BasicGameTest()
        {
            const int STARTING_NET_WORTH = 5000;
            Game game = Game.GetGame(StockMarket.GetStockBoard());
            game.NewGame();
            var player1Portfolio = CreatePortfolio();
            Player player1 = new Player("Bob", player1Portfolio);
            var player2Portfolio = CreatePortfolio();
            Player player2 = new Player("Joe", player2Portfolio);
            var player3Portfolio = CreatePortfolio();
            Player player3 = new Player("Fred", player3Portfolio);
            var player4Portfolio = CreatePortfolio();
            Player player4 = new Player("Sue", player4Portfolio);
            var player5Portfolio = CreatePortfolio();
            Player player5 = new Player("Jane", player5Portfolio);
            var player6Portfolio = CreatePortfolio();
            Player player6 = new Player("Ann", player6Portfolio);
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
