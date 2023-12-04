namespace Mindbox.Shapes;

public interface IEdges
{
    /// <summary>
    /// Boundaries of the shape. <br/>Each element represents length of each edge. 
    /// </summary>
    IReadOnlyList<double> Edges { get; }
}
