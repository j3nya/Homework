namespace ParseTree;

/// <summary>
///  Node of a parse tree.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Counts an expression composed of a subtree with a top at this node or if the node is a number returns a number.
    /// </summary>
    /// <returns>Result of calculation.</returns>
    public abstract float Evaluate();

    /// <summary>
    /// Prints the node.
    /// </summary>
    /// <returns>The text that contains the output.</returns>
    public abstract string Print();
}