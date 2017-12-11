using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTickerLogic;

namespace StockTickerTest
{
    [TestClass]
    public class GameTests
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
            Game game = Game.GetGame();
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
            game.AddPlayer(player1.GetName());
            game.AddPlayer(player2.GetName());
            game.AddPlayer(player3.GetName());
            game.AddPlayer(player4.GetName());
            game.AddPlayer(player5.GetName());
            game.AddPlayer(player6.GetName());
            game.BuyStock(player1.GetName(), StockId.BONDS, 5);
            game.BuyStock(player2.GetName(), StockId.GOLD, 5);
            game.BuyStock(player3.GetName(), StockId.GRAIN, 5);
            game.BuyStock(player4.GetName(), StockId.INDUSTRY, 5);
            game.BuyStock(player5.GetName(), StockId.OIL, 5);
            game.BuyStock(player6.GetName(), StockId.SILVER, 5);
            var gamePlayer1 = game.GetPlayer(player1.GetName());
            var gamePlayer2 = game.GetPlayer(player2.GetName());
            var gamePlayer3 = game.GetPlayer(player3.GetName());
            var gamePlayer4 = game.GetPlayer(player4.GetName());
            var gamePlayer5 = game.GetPlayer(player5.GetName());
            var gamePlayer6 = game.GetPlayer(player6.GetName());
            Assert.AreEqual(gamePlayer1.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(gamePlayer2.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(gamePlayer3.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(gamePlayer4.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(gamePlayer5.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(gamePlayer6.GetNetWorth(), STARTING_NET_WORTH);
            Assert.AreEqual(gamePlayer1.Cash, 0);
            Assert.AreEqual(gamePlayer2.Cash, 0);
            Assert.AreEqual(gamePlayer3.Cash, 0);
            Assert.AreEqual(gamePlayer4.Cash, 0);
            Assert.AreEqual(gamePlayer5.Cash, 0);
            Assert.AreEqual(gamePlayer6.Cash, 0);
        }
    }
}
