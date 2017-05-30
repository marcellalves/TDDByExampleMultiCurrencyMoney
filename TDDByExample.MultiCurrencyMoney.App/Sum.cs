namespace TDDByExample.MultiCurrencyMoney.App
{
    public class Sum : Expression
    {
        public Money Augend;
        public Money Addend;

        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(string to)
        {
            var amount = Augend._amount + Addend._amount;
            return new Money(amount, to);
        }
    }
}
