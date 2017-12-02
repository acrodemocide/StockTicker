using System;
using System.Linq;
using System.Collections.Generic;
using StockTickerLogic.Interfaces;

namespace StockTickerLogic
{
    /// <summary>
    /// We have created the transfer objects needed to communicate with the
    /// outside world as well as the public methods here that are needed to
    /// interact with the game.
    /// 
    /// We will need to go through the module and ensure that all the classes
    /// that are supposed to be internal only are explicitly marked as such.
    /// We need to also explicitly designate the classes that are supposed to
    /// be public.
    /// 
    /// We will need to finish implementing the public methods for the facade
    /// and write tests for each of them. The methods created should be documented
    /// in both the concrete class and the interface. An interface should be
    /// created for the game class so that extensions can be made.
    /// 
    /// Once this is done, the stock ticker logical side (the game logic without
    /// the UI) will be finished and ready to be used by a UI.
    /// </summary>
    public class Game
    {
        private List<Player> _players;
        private IStockMarket _stockMarket;
        private bool _isGameInProgress;
        private bool _isNewGame;
        private static Game _instance = null;

        public Game()
        {
            // Initialize the stock market
            var stocks = new Dictionary<StockId, IStock>();
            stocks = new Dictionary<StockId, IStock>();
            stocks[StockId.GOLD] = new Stock(StockId.GOLD);
            stocks[StockId.SILVER] = new Stock(StockId.SILVER);
            stocks[StockId.OIL] = new Stock(StockId.OIL);
            stocks[StockId.BONDS] = new Stock(StockId.BONDS);
            stocks[StockId.INDUSTRY] = new Stock(StockId.INDUSTRY);
            stocks[StockId.GRAIN] = new Stock(StockId.GRAIN);
            _stockMarket = StockMarket.GetStockMarket(stocks);

            _players = new List<Player>();
            _isGameInProgress = false;
        }

        public static Game GetGame()
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
        }

        public bool IsGameInProgress()
        {
            return _isGameInProgress;
        }

        public bool IsNewGame()
        {
            return _isNewGame;
        }

        /// <summary>
        /// Clears and resets the game. Everything is returned to its
        /// initial state. All players are removed from the game. Players
        /// will need to be added before starting a new game.
        /// </summary>
        public void NewGame()
        {
            _players.Clear();
            _stockMarket.Reset();
            _isNewGame = true;
            _isGameInProgress = false;
        }

        /// <summary>
        /// This starts the actual game play. This call only succeeds after
        /// players have been added to the game.
        /// </summary>
        public void StartGame()
        {
            if (_players.Count < 1)
            {
                throw new InvalidOperationException("No players have been added to the game");
            }
            else
            {
                _isGameInProgress = true;
                _isNewGame = false;
            }
        }

        /// <summary>
        /// This method adds a player to the game. This can only be called
        /// after a new game has been arranged but before starting the game.
        /// </summary>
        /// <param name="playerName">Name of the player to add</param>
        public void AddPlayer(string playerName)
        {
            if (!_isGameInProgress)
            {
                // Initialize player portfolio
                var portfolio = new Dictionary<StockId, IStockPosition>();
                portfolio[StockId.GOLD] = new StockPosition(new Stock(StockId.GOLD));
                portfolio[StockId.SILVER] = new StockPosition(new Stock(StockId.SILVER));
                portfolio[StockId.OIL] = new StockPosition(new Stock(StockId.OIL));
                portfolio[StockId.BONDS] = new StockPosition(new Stock(StockId.BONDS));
                portfolio[StockId.INDUSTRY] = new StockPosition(new Stock(StockId.INDUSTRY));
                portfolio[StockId.GRAIN] = new StockPosition(new Stock(StockId.GRAIN));
                var player = new Player(playerName, portfolio);
                _players.Add(player);
            }
            else
            {
                throw new InvalidOperationException("Cannot add player while game is in progress");
            }
        }

        /// <summary>
        /// This method simulates rolling the dice in the game for determining
        /// what the market is doing. Each time this method is called, a given
        /// stock will go up, down, or pay out dividends. The players who own
        /// that stock will be affected accordingly.
        /// </summary>
        public void MarketMovement()
        {
            if (_isGameInProgress)
            {
                _stockMarket.MarketMovement();
            }
            else
            {
                throw new InvalidOperationException("Game is not in progress. Start new game first.");
            }
        }

        private IPlayerTO CopyPlayerToPlayerTO(Player player)
        {
            var playerTo = new PlayerTO();

            playerTo.Name = player.GetName();

            var playerPortfolio = player.GetPortfolio();
            var playerToPortfolio = new Dictionary<StockId, IStockPositionTO>();
            foreach (var portfolioKeyValuePair in playerPortfolio)
            {
                var stockOwned = portfolioKeyValuePair.Value.GetStockOwned();
                var stockTo = new StockTO();
                stockTo.Id = stockOwned.Id;
                stockTo.Value = stockOwned.Value;
                var stockPositionTo = new StockPositionTO();
                stockPositionTo.StockOwned = stockTo;
                stockPositionTo.NumberOwned = portfolioKeyValuePair.Value.NumberOwned;
                playerToPortfolio[stockTo.Id] = stockPositionTo;
            }

            playerTo.Cash = player.GetCashValue();

            return playerTo;
        }

        /// <summary>
        /// This returns a list of the players who are currently playing
        /// the game.
        /// </summary>
        /// <returns>List of players in the game</returns>
        public IQueryable<IPlayerTO> GetPlayers()
        {
            var playerTos = new List<IPlayerTO>();
            foreach(var player in _players)
            {
                var playerTo = CopyPlayerToPlayerTO(player);
                playerTos.Add(playerTo);
            }
            return playerTos.AsQueryable();
        }

        /// <summary>
        /// Returns a player given a name
        /// </summary>
        /// <param name="playerName">Name of the player to return</param>
        public IPlayerTO GetPlayer(string playerName)
        {
            IPlayerTO playerTo = null;

            var playersQueryable = _players.AsQueryable();
            var player = playersQueryable.FirstOrDefault(x => x.GetName() == playerName);
            if (player == null)
            {
                throw new ArgumentException("No player with that name exists in the game");
            }
            else
            {
                playerTo = CopyPlayerToPlayerTO(player);
            }
            
            return playerTo;
        }

        public IQueryable<IStockTO> GetStocks()
        {
            return _stockMarket.GetStocks();
        }

        public IStockTO GetStock(StockId stockId)
        {
            return _stockMarket.GetStockById(stockId);
        }

        /// <summary>
        /// This method buys the given number of given stocks for the given
        /// player
        /// </summary>
        /// <param name="playerName">player to buy stocks for</param>
        /// <param name="stockId">stock to buy</param>
        /// <param name="numberOfShares">number of stocks to buy</param>
        public void BuyStock(string playerName, StockId stockId, int numberOfShares)
        {
            Player selectedPlayer = _players.Find(r => r.GetName() == playerName);
            selectedPlayer.BuyPosition(stockId, numberOfShares);
        }

        /// <summary>
        /// This method sells the given number of given stocks for the given
        /// player
        /// </summary>
        /// <param name="playerName">player selling stocks</param>
        /// <param name="stockId">stock to sell</param>
        /// <param name="numberOfShares">number of stocks to sell</param>
        public void SellStock(string playerName, StockId stockId, int numberOfShares)
        {
            Player selectedPlayer = _players.Find(r => r.GetName() == playerName);
            selectedPlayer.SellPosition(stockId, numberOfShares);
        }
    }
}
