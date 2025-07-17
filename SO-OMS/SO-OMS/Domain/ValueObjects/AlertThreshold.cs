using System;

public readonly struct Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("金額は0以上である必要があります。");
        Value = value;
    }

    public override string ToString() => Value.ToString();

    public static implicit operator decimal(Money money) => money.Value;
    public static explicit operator Money(decimal value) => new Money(value);
}
