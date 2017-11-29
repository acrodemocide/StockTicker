using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerLogic.Interfaces
{
    public interface IStockTO
    {
        StockId Id { get; set; }
        int Value { get; set; }
    }
}
