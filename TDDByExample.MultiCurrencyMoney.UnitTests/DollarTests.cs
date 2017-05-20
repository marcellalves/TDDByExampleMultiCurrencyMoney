using System;
using TDDByExample.MultiCurrencyMoney.App;
using Xunit;

namespace TDDByExample.MultiCurrencyMoney.UnitTests
{
    public class DollarTests
    {
        [Fact]
        public void testMultiplication()
        {
            var five= new Dollar(5);
            five.Times(2);
            Assert.Equal(10, five.Amount);
        }
    }
}
