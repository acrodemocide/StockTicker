using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTickerLogic;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace StockTickerTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void MarketMovementOccursWithoutExceptionsWhenGameIsInProgress()
        {
            Mock<IStockMarket> stockMarketMock = new Mock<IStockMarket>();
            stockMarketMock.Setup(x => x.MarketMovement()).Verifiable();
            var game = Game.GetGame(stockMarketMock.Object);
            game.StartGame();

            game.MarketMovement();

            stockMarketMock.Verify(x => x.MarketMovement(), Times.Once());
        }
    }
}
