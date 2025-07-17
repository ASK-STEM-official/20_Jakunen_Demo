using System;

public readonly struct StockQuantity
{
    public int Value { get; }

    public StockQuantity(int value)  // コンストラクタ
    {
        if (value < 0)
            throw new ArgumentException("在庫数は0以上である必要があります。");
        Value = value;
    }

    public override string ToString() => Value.ToString();

    public static implicit operator int(StockQuantity quantity) => quantity.Value;
    public static explicit operator StockQuantity(int value) => new StockQuantity(value);
}
