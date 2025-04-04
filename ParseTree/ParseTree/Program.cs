// <copyright file="Program.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
string[] inputs = File.ReadAllLines(args[0]);
for (int i = 0; i < inputs.Length; i++)
{
    ParseTree.ParseTree parseTree = new ParseTree.ParseTree(inputs[i]);
    ParseTree.Node root = parseTree.Root;
    Console.WriteLine(ParseTree.Operator.Print(root), root.Evaluate());
}
