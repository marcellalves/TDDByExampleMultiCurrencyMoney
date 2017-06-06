using System.Collections.Generic;

namespace TDDByExample.MultiCurrencyMoney.App
{
    public class Bank
    {
        private readonly Dictionary<Pair, int> _rates = new Dictionary<Pair, int>();

        public Money Reduce(Expression source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string from, string to, int rate)
        {
            _rates.Add(new Pair(from, to), rate);
        }

        public int Rate(string from, string to)
        {
            if (from.Equals(to)) return 1;

            return _rates[new Pair(from, to)];
        }

        private class Pair
        {
            private readonly string _from;
            private readonly string _to;

            public Pair(string from, string to)
            {
                _from = from;
                _to = to;
            }

            public override bool Equals(object obj)
            {
                var pair = (Pair)obj;
                return _from.Equals(pair._from) && _to.Equals(pair._to);
            }

            public override int GetHashCode()
            {
                return 0;
            }
        }
    }
}
