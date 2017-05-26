using TDDByExample.MultiCurrencyMoney.App;
using Xunit;
using Expression = TDDByExample.MultiCurrencyMoney.App.Expression;

namespace TDDByExample.MultiCurrencyMoney.UnitTests
{
    public class MoneyTests
    {
        [Fact]
        public void testMultiplication()
        {
            var five = Money.Dollar(5);
            Assert.Equal(Money.Dollar(10), five.Times(2));
            Assert.Equal(Money.Dollar(15), five.Times(3));
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.False(Money.Dollar(5).Equals(Money.Dollar(6)));
            Assert.False(Money.Franc(5).Equals(Money.Dollar(5)));
        }

        [Fact]
        public void testCurrency()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency());
            Assert.Equal("CHF", Money.Franc(1).Currency());
        }

        [Fact]
        public void testSimpleAddition()
        {
            var five = Money.Dollar(5);
            Expression sum = five.Plus(five);
            var bank = new Bank();
            Money reduced = bank.Reduce(sum, "USD");

            Assert.Equal(Money.Dollar(10), reduced);
        }

        [Fact]
        public void testPlusReturnsSum()
        {
            var five = Money.Dollar(5);
            Expression result = five.Plus(five);
            Sum sum = (Sum) result;

            Assert.Equal(five, sum.Augend);
            Assert.Equal(five, sum.Addend);
        }

        [Fact]
        public void testReduceSum()
        {
            
            Expression sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var bank = new Bank();
            var result = bank.Reduce(sum, "USD");
            
            Assert.Equal(Money.Dollar(7), result);
        }
    }
}
