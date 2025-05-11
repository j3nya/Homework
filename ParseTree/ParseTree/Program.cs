// <copyright file="Program.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
if (args.Length == 0)
{
    Console.WriteLine("Provide file with text of the following form: {operand1}{operator}{operand2}");
}
else
{
    string[] inputs = File.ReadAllLines(args[0]);
    for (int i = 0; i < inputs.Length; i++)
    {
        ParseTree.ParseTree parseTree = new ParseTree.ParseTree(inputs[i]);
        ParseTree.Node root = parseTree.Root;
        Console.WriteLine(ParseTree.Operator.Print(root), root.Evaluate());
    }
}
