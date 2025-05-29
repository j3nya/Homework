namespace Map_Filter_FoldTests;
using Map_Filter_Fold;
public class Map_Filter_FoldTests
{
    [Test]
    public void CheckIfMapWorks()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Map_Filter_Fold.Map([1, 2, 3], x => x * 2), Is.EqualTo(new List<int> { 2, 4, 6 }));
            Assert.That(Map_Filter_Fold.Map([-1, -6, -12], x => x * 2), Is.EqualTo(new List<int> { -2, -12, -24 }));
            Assert.That(Map_Filter_Fold.Map([-1, -6, -12], x => x * 0), Is.EqualTo(new List<int> { 0, 0, 0 }));
            Assert.That(Map_Filter_Fold.Map([], x => x * 2), Is.EqualTo(new List<int> { }));
        });
    }

    [Test]
    public void CheckIfFilterWorks()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Map_Filter_Fold.Filter([1, 2, 3], x => x < 3), Is.EqualTo(new List<int> { 1, 2 }));
            Assert.That(Map_Filter_Fold.Filter([1, 2, 3], x => x == 3), Is.EqualTo(new List<int> { 3 }));
            Assert.That(Map_Filter_Fold.Filter([], x => x < 3), Is.EqualTo(new List<int> { }));
        });
    }

    [Test]
    public void CheckIfFoldWorks()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Map_Filter_Fold.Fold([1, 2, 3], 1, (acc, elem) => acc * elem), Is.EqualTo(6));
            Assert.That(Map_Filter_Fold.Fold([1, 2, 3], 2, (acc, elem) => acc * elem), !Is.EqualTo(6));
            Assert.That(Map_Filter_Fold.Fold([1, 2, 3], 2, (acc, elem) => acc * elem), Is.EqualTo(12));
            Assert.That(Map_Filter_Fold.Fold([], 2, (acc, elem) => acc * elem), Is.EqualTo(2));
        });
    }
}
