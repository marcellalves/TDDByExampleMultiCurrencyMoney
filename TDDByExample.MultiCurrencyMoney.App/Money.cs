namespace TDDByExample.MultiCurrencyMoney.App
{
    public abstract class Money
    {
        protected internal int _amount;

        public abstract Money Times(int multiplier);

        public static Money Dollar(int amount)
        {
            return new Dollar(amount);
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount);
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return _amount == money._amount
                    && GetType() == money.GetType();
        }
    }
}
