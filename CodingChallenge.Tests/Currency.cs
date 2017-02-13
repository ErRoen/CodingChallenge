namespace CodingChallenge.Tests.PaycheckTestContainer
{
    /// <summary>
    /// Exists to provide consistent rounding logic
    /// </summary>
    public class Currency
    {
        private decimal _amount;
        // Could add currency type here too: $, £, €, etc...

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = decimal.Round(value, 2); }
        }

        public Currency(decimal amount)
        {
            Amount = amount;
        }

        public Currency(int amount)
        {
            Amount = amount;
        }
    }
}