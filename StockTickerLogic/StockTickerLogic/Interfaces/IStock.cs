using StockTickerLogic.Interfaces;

namespace StockTickerLogic
{
    internal interface IStock
    {
        /// <summary>
        /// Resets the stock to its initial value for
        /// the start of the game.
        /// </summary>
        void Reset();
        StockId Id { get; }
        int Value { get; set; }
        IStockTO GetStockData();
    }
}
