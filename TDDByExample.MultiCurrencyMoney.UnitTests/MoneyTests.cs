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
            var sum = five.Plus(five);
            var bank = new Bank();
            var reduced = bank.Reduce(sum, "USD");

            Assert.Equal(Money.Dollar(10), reduced);
        }

        [Fact]
        public void testPlusReturnsSum()
        {
            var five = Money.Dollar(5);
            var result = five.Plus(five);
            var sum = (Sum) result;

            Assert.Equal(five, sum.Augend);
            Assert.Equal(five, sum.Addend);
        }

        [Fact]
        public void testReduceSum()
        {
            
            var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var bank = new Bank();
            var result = bank.Reduce(sum, "USD");
            
            Assert.Equal(Money.Dollar(7), result);
        }

        [Fact]
        public void testReduceMoney()
        {
            var bank = new Bank();
            var result = bank.Reduce(Money.Dollar(1), "USD");

            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void testReduceMoneyDifferentCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var result = bank.Reduce(Money.Franc(2), "USD");

            Assert.Equal(Money.Dollar(1), result);
        }
    }
}
