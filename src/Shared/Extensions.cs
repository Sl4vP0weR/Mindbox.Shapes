namespace Mindbox;

public static class Extensions
{
    public static double Sqr(this double value) => 
        Math.Pow(value, 2);
    public static double Sqrt(this double value) => 
        Math.Sqrt(value);

    public static double Round(this double value,
        int digits = DoublePrecisionDigits,
        MidpointRounding method = MidpointRounding.ToEven)
    {
        value = Math.Round(value, digits, method);

        // sometimes round operation is just not enough
        var floor = Math.Floor(value);
        if (Math.Abs(floor - value) < DoublePrecision)
            return floor;
        
        var ceil = Math.Ceiling(value);
        if (Math.Abs(ceil - value) < DoublePrecision)
            return ceil;

        return value;
    }
    
    public const int DoublePrecisionDigits = 15;
    public static readonly double DoublePrecision = Math.Pow(0.1, DoublePrecisionDigits-1);

    public static IEnumerable<T> Except<T>(
        this IEnumerable<T> enumerable, 
        T exceptedValue, 
        int count = int.MaxValue, 
        IEqualityComparer<T> comparer = null)
    {
        comparer ??= EqualityComparer<T>.Default;
        
        foreach (var value in enumerable)
        {
            if (count > 0)
            {
                if (comparer.Equals(value, exceptedValue))
                {
                    count--;
                    continue;
                }
            }

            yield return value;
        }
    }
}