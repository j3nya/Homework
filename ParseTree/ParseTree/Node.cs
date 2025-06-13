// <copyright file="Node.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
///  Node of a parse tree.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Prints an expression composed of a subtree where this node takes the place of the operator or if root is number prints number.
    /// </summary>
    /// <param name="root">Number or operator to print.</param>
    /// <returns>Text that output contains.</returns>
    public static string Print(Node root)
    {
        var stringToPrint = string.Empty;

        // case for tree containing one number.
        if (root is Number)
        {
            // For number evaluate method returns number.
            stringToPrint += "( " + root.Evaluate() + " ) ";
        }
        else
        {
            CallPrintRecursively(root, ref stringToPrint);
        }

        Console.WriteLine(stringToPrint);

        // Remove space.
        return stringToPrint.Remove(stringToPrint.Length - 1);
    }

    /// <summary>
    /// Counts an expression composed of a subtree with a top at this node or if the node is a number returns a number.
    /// </summary>
    /// <returns>Result of calculation or number.</returns>
    public abstract float Evaluate();

    /// <summary>
    /// Auxiliary method for method Print which bypasess the tree.
    /// </summary>
    /// <param name="root">Operator for recursive call.</param>
    /// <param name="stringToPrint">String to print.</param>
    private static void PrintRecursively(Operator root, ref string stringToPrint)
    {
        if (root.Left == null || root.Right == null)
        {
            throw new MeaninglessExpressionException("Operands are not there");
        }

        Node operand1 = root.Left;
        if (operand1 is Operator)
        {
            CallPrintRecursively(operand1, ref stringToPrint);
        }
        else
        {
            stringToPrint += operand1.Evaluate() + " ";
        }

        Node operand2 = root.Right;
        if (operand2 is Operator)
        {
            CallPrintRecursively(operand2, ref stringToPrint);
        }
        else
        {
            stringToPrint += operand2.Evaluate() + " ";
        }

        // After every second operand add closing brace.
        stringToPrint += ") ";
    }

    private static void CallPrintRecursively(Node @operator, ref string stringToPrint)
    {
        var operator_ = (Operator)@operator;
        stringToPrint += "( " + operator_.OperationChar + " ";
        PrintRecursively(operator_, ref stringToPrint);
    }
}