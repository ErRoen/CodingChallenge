namespace CodingChallenge.Common
{
    /// <summary>
    /// Exists to provide consistent money logic (ex: rounding, formatting)
    /// https://martinfowler.com/eaaCatalog/money.html
    /// </summary>
    public class Money
    {
        private decimal _amount;
        // Could add currency type here too: $, £, €, etc...

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = decimal.Round(value, 2); }
        }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public Money(int amount)
        {
            Amount = amount;
        }

        public override string ToString()
        {
            return _amount.ToString("C");
        }
    }
}