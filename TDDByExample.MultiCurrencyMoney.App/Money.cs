﻿namespace TDDByExample.MultiCurrencyMoney.App
{
    public class Money
    {
        protected internal int _amount;
        protected string currency;

        public Money(int amount, string currency)
        {
            _amount = amount;
            this.currency = currency;
        }

        public Money Times(int multiplier)
        {
            return new Money(_amount * multiplier, currency);
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return _amount == money._amount
                    && currency.Equals(money.Currency());
        }

        public override string ToString()
        {
            return _amount + " " + currency;
        }

        public string Currency()
        {
            return currency;
        }
    }
}
