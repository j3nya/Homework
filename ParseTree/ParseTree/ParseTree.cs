// <copyright file="ParseTree.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
/// Parse tree of an arithmetic expression.
/// </summary>
public class ParseTree
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParseTree"/> class.
    /// </summary>
    /// <param name="input">Tree's string representation.</param>
    public ParseTree(string input)
    {
        string[] inputToNodes = InputHandler.ToNodes(input);
        string firstElement = inputToNodes[0];
        int firstElementNum;
        if (int.TryParse(firstElement, out firstElementNum))
        {
            this.Root = new Number(firstElementNum);
        }
        else
        {
            this.Root = Operator.GetOperator(firstElement);
            BuildRecursively((Operator)this.Root, inputToNodes);
        }
    }

    /// <summary>
    /// Gets a root of a tree.
    /// </summary>
    public Node Root { get; private set; }

    /// <summary>
    /// For string representation of parse tree builds parse tree, and evaluates and expression.
    /// </summary>
    /// <param name="input">string representation of parse tree.</param>
    /// <returns>Calculation result.</returns>
    /// <exception cref="Exception">Throws if tree remains null after build tree method.</exception>
    public static float EvaluateExpression(string input)
    {
        ParseTree parseTree = new ParseTree(input);
        return parseTree.Root.Evaluate();
    }

    /// <summary>
    /// Auxiliary method which bypasses the tree.
    /// </summary>
    /// <param name="root">Operator for recursive call.</param>
    /// <param name="input">String array representing operator, operand1, operand2.</param>
    private static void BuildRecursively(Operator root, string[] input)
    {
        string operand1 = input[1];
        int operand1Num;
        if (!int.TryParse(operand1, out operand1Num))
        {
            string[] nodes = InputHandler.ToNodes(operand1);
            root.Left = Operator.GetOperator(nodes[0]);
            BuildRecursively((Operator)root.Left, nodes); // call recursively for left branch.
        }
        else
        {
            root.Left = new Number(operand1Num);
        }

        string operand2 = input[2];
        int operand2Num;
        if (!int.TryParse(operand2, out operand2Num))
        {
            string[] nodes = InputHandler.ToNodes(operand2);
            root.Right = Operator.GetOperator(nodes[0]);
            BuildRecursively((Operator)root.Right, nodes); // call recursively for right branch.
        }
        else
        {
            root.Right = new Number(operand2Num);
        }
    }
}