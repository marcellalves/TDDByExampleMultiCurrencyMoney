namespace TDDByExample.MultiCurrencyMoney.App
{
    public interface Expression
    {
        Money Reduce(Bank bank, string to);
        Expression Plus(Expression addend);
    }
}
