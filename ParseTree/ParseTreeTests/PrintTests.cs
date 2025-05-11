namespace ParseTree;

public class PrintTests
{
    private string longInput;
    private string input;
    private string shortInput;
    private ParseTree bigTree;
    private ParseTree tree;
    private ParseTree smallTree;

    [SetUp]
    public void Setup()
    {
        longInput = "(* (- 1 2) (/ (+ (- 3 (+ 1 9)) 4) 2))";
        input = "(* (- 1 2) 3)";
        shortInput = "(- 5 3)";
        bigTree = new ParseTree(longInput);
        tree = new ParseTree(input);
        smallTree = new ParseTree(shortInput);
    }

    [Test]
    public void CheckIfTreePrintIsCorrect()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Node.Print(bigTree.Root), Is.EqualTo("( * ( - 1 2 ) ( / ( + ( - 3 ( + 1 9 ) ) 4 ) 2 ) )"));
            Assert.That(Node.Print(tree.Root), Is.EqualTo("( * ( - 1 2 ) 3 )"));
            Assert.That(Node.Print(smallTree.Root), Is.EqualTo("( - 5 3 )"));
        });
    }

    [Test]
    public void CheckIfSubtreePrintIsCorrect()
    {
        Operator bigTreeRoot = (Operator)bigTree.Root;
        Operator treeRoot = (Operator)tree.Root;
        if (bigTreeRoot.Left != null && bigTreeRoot.Right != null && treeRoot.Left != null)
        {
            Operator bigTreeLeftSubtreeRoot = (Operator)bigTreeRoot.Left;
            Operator bigTreeRightSubtreeRoot = (Operator)bigTreeRoot.Right;
            Operator treeLeftSubtreeRoot = (Operator)treeRoot.Left;
            Assert.Multiple(() =>
            {
                Assert.That(Node.Print(bigTreeLeftSubtreeRoot), Is.EqualTo("( - 1 2 )"));
                Assert.That(Node.Print(bigTreeRightSubtreeRoot), Is.EqualTo("( / ( + ( - 3 ( + 1 9 ) ) 4 ) 2 )"));
                Assert.That(Node.Print(treeLeftSubtreeRoot), Is.EqualTo("( - 1 2 )"));
            });
        }
    }

    [Test]
    public void CheckIfNumberPrintsCorrect()
    {
        Operator treeRoot = (Operator)tree.Root;
        Operator smallTreeRoot = (Operator)smallTree.Root;
        if (smallTreeRoot.Left != null && treeRoot.Right != null)
        {
            Node smallTreeRootLeftNumber = smallTreeRoot.Left;
            Node treeRightNumber = treeRoot.Right;
            Assert.Multiple(() =>
            {
                Assert.That(Node.Print(smallTreeRootLeftNumber), Is.EqualTo("( 5 )"));
                Assert.That(Node.Print(treeRightNumber), Is.EqualTo("( 3 )"));
            });
        }
    }
}