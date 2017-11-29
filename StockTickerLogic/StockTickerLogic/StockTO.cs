using StockTickerLogic.Interfaces;

namespace StockTickerLogic
{
    public class StockTO: IStockTO
    {
        public StockId Id { get; set; }
        public int Value { get; set; }
    }
}
