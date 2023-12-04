namespace Mindbox.Shapes;

public interface ITyped<TEnum>
{
    /// <summary>
    /// Type of the shape.
    /// </summary>
    TEnum Type { get; }
    
    /// <summary>
    /// Is this type of shape is <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    bool Is(TEnum type);
}
