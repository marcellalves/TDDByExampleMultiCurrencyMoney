namespace TDDByExample.MultiCurrencyMoney.App
{
    public interface Expression
    {
        Money Reduce(string to);
    }
}
