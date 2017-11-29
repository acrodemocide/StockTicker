using StockTickerLogic.Interfaces;

namespace StockTickerLogic
{
    public class StockPositionTO: IStockPositionTO
    {
        public IStockTO StockOwned { get; set; }
        public int NumberOwned { get; set; }
    }
}
