namespace StockTickerLogic.Interfaces
{
    public interface IStockPositionTO
    {
        IStockTO StockOwned { get; set; }
        int NumberOwned { get; set; }
    }
}
