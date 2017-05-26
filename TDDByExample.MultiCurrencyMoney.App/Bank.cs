namespace TDDByExample.MultiCurrencyMoney.App
{
    public class Bank
    {
        public Money Reduce(Expression source, string to)
        {
            var sum = (Sum) source;
            var amount = sum.Augend._amount + sum.Addend._amount;
            return new Money(amount, to);
        }
    }
}
