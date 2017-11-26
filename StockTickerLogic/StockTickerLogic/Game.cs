using System;
using System.Collections.Generic;

namespace StockTickerLogic
{
    /// <summary>
    /// We need to update this so that we can get the necessary information
    /// for seeing players to determine who is winning, what each person's
    /// net worth is, and to see the stock market. We want the game
    /// to be the facade, so we don't want the user to be able to
    /// see any of the components that the game is using to play.
    /// However, to return data, we might create POCO's that clearly
    /// define everything so that the user can clearly see what is
    /// going on at any point in the game. The integration tests for this
    /// should be updated accordingly.
    /// </summary>
    class Game
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

        /// <summary>
        /// This returns a list of the players who are currently playing
        /// the game.
        /// </summary>
        /// <returns>List of players in the game</returns>
        public List<string> GetPlayers()
        {
            var playerNames = new List<string>();
            foreach(var player in _players)
            {
                playerNames.Add(player.GetName());
            }
            return playerNames;
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
