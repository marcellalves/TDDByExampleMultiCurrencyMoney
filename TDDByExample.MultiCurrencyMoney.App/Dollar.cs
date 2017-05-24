﻿namespace TDDByExample.MultiCurrencyMoney.App
{
    public class Dollar : Money
    {
        public Dollar(int amount)
        {
            _amount= amount;
        }

        public override Money Times(int multiplier)
        {
            return new Dollar(_amount * multiplier);
        }
    }
}
