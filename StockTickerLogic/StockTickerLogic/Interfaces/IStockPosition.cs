using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace StockTickerLogic
{
    interface IStockPosition
    {
        int GetShareValue();
        int GetTotalValue();
        int GetDividenPayout(int dividendAmount);
        IStock GetStockOwned();
        int NumberOwned { get; set; }
    }
}
