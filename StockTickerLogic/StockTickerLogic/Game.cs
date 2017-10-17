using System;
using System.Collections.Generic;

namespace StockTickerLogic
{
    class Game
    {
        private List<Player> _players;
        private StockMarket _stockMarket;
        private bool _isGameInProgress;
        private bool _isNewGame;
        private static Game _instance = null;

        private Game()
        {
            _stockMarket = StockMarket.GetStockBoard();
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

        public void NewGame()
        {
            _players.Clear();
            _stockMarket.Reset();
            _isNewGame = true;
            _isGameInProgress = false;
        }

        public void StartGame()
        {
            _isGameInProgress = true;
            _isNewGame = false;
        }

        public void StopGame()
        {
            _isGameInProgress = false;
            NewGame();
        }

        public void AddPlayer(Player player)
        {
            if (!_isGameInProgress)
            {
                _players.Add(player);
            }
            else
            {
                throw new InvalidOperationException("Cannot add player while game is in progress");
            }
        }

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

        public List<Player> GetPlayers()
        {
            return _players;
        }

        public void BuyStock(string playerName, StockId stockId, int numberOfShares)
        {
            Player selectedPlayer = _players.Find(r => r.GetName() == playerName);
            selectedPlayer.BuyPosition(stockId, numberOfShares);
        }

        public void SellStock(string playerName, StockId stockId, int numberOfShares)
        {
            Player selectedPlayer = _players.Find(r => r.GetName() == playerName);
            selectedPlayer.SellPosition(stockId, numberOfShares);
        }
    }
}
