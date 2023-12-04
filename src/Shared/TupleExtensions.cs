using System.Runtime.CompilerServices;

namespace Mindbox;

public static class TupleExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T GetNext<T>(this IEnumerator<T> enumerator)
    {
        if(!enumerator.MoveNext())
            return default;
        
        return enumerator.Current;
    }

    public static void Deconstruct<T>(this IEnumerable<T> items,
        out T t0)
    {
        using var enumerator = items.GetEnumerator();
        t0 = enumerator.GetNext();
    }

    public static void Deconstruct<T>(this IEnumerable<T> items, 
        out T t0, out T t1)
    {
        using var enumerator = items.GetEnumerator();
        t0 = enumerator.GetNext();
        t1 = enumerator.GetNext();
    }

    public static void Deconstruct<T>(this IEnumerable<T> items, 
        out T t0, out T t1, out T t2)
    {
        using var enumerator = items.GetEnumerator();
        t0 = enumerator.GetNext();
        t1 = enumerator.GetNext();
        t2 = enumerator.GetNext();
    }
    
    public static void Deconstruct<T>(this IEnumerable<T> items, 
        out T t0, out T t1, out T t2, out T t3)
    {
        using var enumerator = items.GetEnumerator();
        t0 = enumerator.GetNext();
        t1 = enumerator.GetNext();
        t2 = enumerator.GetNext();
        t3 = enumerator.GetNext();
    }
    
    public static void Deconstruct<T>(this IEnumerable<T> items, 
        out T t0, out T t1, out T t2, out T t3, out T t4)
    {
        using var enumerator = items.GetEnumerator();
        t0 = enumerator.GetNext();
        t1 = enumerator.GetNext();
        t2 = enumerator.GetNext();
        t3 = enumerator.GetNext();
        t4 = enumerator.GetNext();
    }

    public static void Deconstruct<T>(this IEnumerable<T> items, 
        out T t0, out T t1, out T t2, out T t3, out T t4, out T t5)
    {
        using var enumerator = items.GetEnumerator();
        t0 = enumerator.GetNext();
        t1 = enumerator.GetNext();
        t2 = enumerator.GetNext();
        t3 = enumerator.GetNext();
        t4 = enumerator.GetNext();
        t5 = enumerator.GetNext();
    }

    public static T[] ToArray<T>(this (T t0, T t1) tuple) => 
        [tuple.t0, tuple.t1];
    
    public static T[] ToArray<T>(this (T t0, T t1, T t2) tuple) => 
        [tuple.t0, tuple.t1, tuple.t2];
    
    public static T[] ToArray<T>(this (T t0, T t1, T t2, T t3) tuple) => 
        [tuple.t0, tuple.t1, tuple.t2, tuple.t3];
    
    public static T[] ToArray<T>(this (T t0, T t1, T t2, T t3, T t4) tuple) => 
        [tuple.t0, tuple.t1, tuple.t2, tuple.t3, tuple.t4];
    
    public static T[] ToArray<T>(this (T t0, T t1, T t2, T t3, T t4, T t5) tuple) => 
        [tuple.t0, tuple.t1, tuple.t2, tuple.t3, tuple.t4, tuple.t5];

    public static (T t0, T t1, T t2) 
        With<T>((T t0, T t1) tuple, T t2) => 
            (tuple.t0, tuple.t1, t2);
    
    public static (T t0, T t1, T t2, T t3) 
        With<T>((T t0, T t1, T t2) tuple, T t3) => 
            (tuple.t0, tuple.t1, tuple.t2, t3);
    
    public static (T t0, T t1, T t2, T t3, T t4) 
        With<T>((T t0, T t1, T t2, T t3) tuple, T t4) => 
            (tuple.t0, tuple.t1, tuple.t2, tuple.t3, t4);
    
    public static (T t0, T t1, T t2, T t3, T t4, T t5) 
        With<T>((T t0, T t1, T t2, T t3, T t4) tuple, T t5) => 
        (tuple.t0, tuple.t1, tuple.t2, tuple.t3, tuple.t4, t5);
}