namespace Map_Filter_FoldTests;
using Map_Filter_Fold;
public class Map_Filter_FoldTests
{
    [Test]
    public void CheckIfMapWorks()
    {
        Assert.That(Map_Filter_Fold.Map([1, 2, 3], x => x * 2), Is.EqualTo(new List<int> { 2, 4, 6 }));
        Assert.That(Map_Filter_Fold.Map([1, 2, 3], x => x * 2), !Is.EqualTo(new List<int> { 1, 4, 6 }));
    }

    [Test]
    public void CheckIfFilterWorks()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Map_Filter_Fold.Filter([1, 2, 3], x => x < 3), Is.EqualTo(new List<int> { 1, 2 }));
            Assert.That(Map_Filter_Fold.Filter([1, 2, 3], x => x == 3), Is.EqualTo(new List<int> { 3 }));
        });
    }

    [Test]
    public void CheckIfFoldWorks()
    {
        Assert.That(Map_Filter_Fold.Fold([1, 2, 3], 1, (acc, elem) => acc * elem), Is.EqualTo(6));
        Assert.That(Map_Filter_Fold.Fold([1, 2, 3], 1, (acc, elem) => acc * elem), !Is.EqualTo(1));
        Assert.That(Map_Filter_Fold.Fold([1, 2, 3], 2, (acc, elem) => acc * elem), !Is.EqualTo(6));
        Assert.That(Map_Filter_Fold.Fold([1, 2, 3], 2, (acc, elem) => acc * elem), Is.EqualTo(12));
    }
}
