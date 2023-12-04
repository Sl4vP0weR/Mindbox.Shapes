namespace Mindbox.Shapes;

public interface IVertices<TVertex>
{
    /// <summary>
    /// Boundaries of the shape. <br/>Each element represents vertex of the shape. 
    /// </summary>
    IReadOnlyList<TVertex> Vertices { get; }
}
