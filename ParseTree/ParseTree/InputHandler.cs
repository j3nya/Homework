// <copyright file="InputHandler.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
/// Works with strings and brings them to the desired form.
/// </summary>
public class InputHandler
{
    /// <summary>
    /// Checks input for validity.
    /// </summary>
    /// <param name="input">String to check.</param>
    /// <returns>A value indicating whether the string is valid.</returns>
    public static bool CheckInput(string input)
    {
        if (input.Length < 3 || input[0] != '(' || input[^1] != ')')
        {
            return false;
        }

        int charPosition = 1;
        if (!IsOperator(input[charPosition]))
        {
            string number = string.Empty;
            for (; input[charPosition] != ')'; charPosition++)
            {
                number += input[charPosition];
            }

            int intNumber;
            return int.TryParse(number, out intNumber) && charPosition == input.Length - 1;
        }
        else
        {
            charPosition++;
            if (input[charPosition] != ' ')
            {
                return false;
            }

            charPosition++; // getting to the operand1
            if (!CheckInputRecursively(input, ref charPosition))
            {
                return false;
            }

            charPosition++;
            if (input[charPosition] != ' ')
            {
                return false;
            }

            charPosition++; // getting to the operand2
            if (!CheckInputRecursively(input, ref charPosition))
            {
                return false;
            }

            return input[charPosition] == ')' && charPosition == input.Length - 1;
        }
    }

    /// <summary>
    /// Bypasses string and returns string array of 3 elements in which each string represents operator, operand1 or operand2.
    /// </summary>
    /// <param name="input">String to convert to nodes.</param>
    /// <returns>String array representation of nodes.</returns>
    /// <exception cref="Exception">Throws if input is incorrect.</exception>
    public static string[] ToNodes(string input)
    {
        if (!CheckInput(input))
        {
            throw new IncorrectInputException("Please provide file in which each string has such form: ({operator} {operand1} {operand2})");
        }

        string[] result = new string[3];

        // Starting at second char skipping opening brace.
        int charPosition = 1;
        while (input[charPosition] != ' ')
        {
            // Case when tree has one node.
            if (input[charPosition] == ')')
            {
                return result;
            }

            result[0] += input[charPosition];
            charPosition++;
        }

        // Skip space.
        charPosition++;

        if (input[charPosition] == '(')
        {
            result[1] += input[charPosition];

            // Skip opening brace.
            charPosition++;
            int braceCount = 1;
            for (; braceCount != 0; charPosition++)
            {
                if (input[charPosition] == '(')
                {
                    braceCount++;
                }

                if (input[charPosition] == ')')
                {
                    braceCount--;
                }

                result[1] += input[charPosition];
            }
        }
        else
        {
            while (input[charPosition] != ' ')
            {
                result[1] += input[charPosition];
                charPosition++;
            }
        }

        // Skip space.
        charPosition++;

        if (input[charPosition] == '(')
        {
            result[2] += input[charPosition];
            charPosition++;
            int braceCount = 1;
            for (; braceCount != 0; charPosition++)
            {
                if (input[charPosition] == '(')
                {
                    braceCount++;
                }

                if (input[charPosition] == ')')
                {
                    braceCount--;
                }

                result[2] += input[charPosition];
            }
        }
        else
        {
            while (input[charPosition] != ')')
            {
                result[2] += input[charPosition];
                charPosition++;
            }
        }

        return result;
    }

    private static bool CheckInputRecursively(string input, ref int charPosition)
    {
        if (input[charPosition] == '(')
        {
            // Getting to the operator.
            charPosition++;
            if (!IsOperator(input[charPosition]))
            {
                return false;
            }

            charPosition++;
            if (input[charPosition] != ' ')
            {
                return false;
            }

            // Getting to the operand1.
            charPosition++;
            if (!CheckInputRecursively(input, ref charPosition))
            {
                return false;
            }

            charPosition++;
            if (input[charPosition] != ' ')
            {
                return false;
            }

            // Getting to the operand2.
            charPosition++;
            if (!CheckInputRecursively(input, ref charPosition))
            {
                return false;
            }

            if (charPosition + 1 <= input.Length - 1 && input[charPosition] == ')' && input[charPosition + 1] == ')')
            {
                charPosition++;
            }

            return input[charPosition] == ')';
        }
        else
        {
            string number = string.Empty;
            for (; input[charPosition] != ')'; charPosition++)
            {
                if (input[charPosition] == ' ')
                {
                    // After leaving CheckInputRecursively charPosition always points at last character of the node.
                    charPosition--;
                    break;
                }

                number += input[charPosition];
            }

            return int.TryParse(number, out int intNumber);
        }
    }

    private static bool IsOperator(char c) =>
        c == '/' || c == '*' || c == '-' || c == '+';
}

/// <summary>
/// Throws if input is invalid.
/// </summary>
public class IncorrectInputException : Exception
{
        /// <summary>
        /// Initializes a new instance of the <see cref="IncorrectInputException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
    public IncorrectInputException(string message)
    : base(message)
    {
    }
}