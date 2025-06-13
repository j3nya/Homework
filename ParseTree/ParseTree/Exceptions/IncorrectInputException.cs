// <copyright file="IncorrectInputException.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
/// Throws if input is invalid.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="IncorrectInputException"/> class.
/// </remarks>
/// <param name="message">Message.</param>
public class IncorrectInputException() : Exception
{
    /// <inheritdoc/>
    public override string Message => "Please provide file in which each string has such form: ({operator} {operand1} {operand2})";
}