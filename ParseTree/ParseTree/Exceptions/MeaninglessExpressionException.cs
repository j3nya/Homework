// <copyright file="MeaninglessExpressionException.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
/// Throws if program tries to compute operation without operands.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="MeaninglessExpressionException"/> class.
/// </remarks>
/// <param name="message">Message.</param>
public class MeaninglessExpressionException(string message) : Exception(message)
{
}