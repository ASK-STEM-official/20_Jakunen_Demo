using System;
using System.Globalization;

namespace SO_OMS.Domain.ValueObjects
{
    public readonly struct Money : IComparable<Money>
    {
        public decimal Value { get; }

        public Money(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("金額は0以上である必要があります。");
            Value = value;
        }

        public Money Add(Money other) => new Money(Value + other.Value);
        public Money Subtract(Money other) => new Money(Math.Max(0, Value - other.Value));

        public int CompareTo(Money other) => Value.CompareTo(other.Value);
        public override string ToString() => Value.ToString("C", CultureInfo.CurrentCulture);

        public static implicit operator decimal(Money money) => money.Value;
        public static explicit operator Money(decimal value) => new Money(value);
    }
}
