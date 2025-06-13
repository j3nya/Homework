// <copyright file="Program.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using ParseTree;

if (args.Length == 0 || args.Length > 1 || !File.Exists(args[0]))
{
    throw new IncorrectInputException();
}

string[] inputs = File.ReadAllLines(args[0]);
for (int i = 0; i < inputs.Length; i++)
{
    if (inputs[i] == string.Empty)
    {
        continue;
    }

    ParseTree.ParseTree parseTree = new(inputs[i]);
    ParseTree.Node root = parseTree.Root;
    Node.Print(root);
    Console.WriteLine($"{root.Evaluate()}");
}