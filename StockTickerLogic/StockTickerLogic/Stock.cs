namespace StockTickerLogic
{
    internal class Stock: IStock
    {
        private const int START_VALUE = 1000;
        private StockId _id;
        private int _value;

        public Stock(StockId id)
        {
            _id = id;
            _value = START_VALUE;
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public StockId Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Resets the stock to its initial value for the start
        /// of the game.
        /// </summary>
        public void Reset()
        {
            _value = START_VALUE;
        }
    }
}
