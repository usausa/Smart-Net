namespace Smart;

public sealed class BinarySearchTest
{
    private static void AssertIndex(List<int> expects, List<int> actuals)
    {
        for (var i = 0; i < actuals.Count; i++)
        {
            if (expects[i] >= 0)
            {
                Assert.Equal(expects[i], actuals[i]);
            }
            else
            {
                Assert.True(actuals[i] < 0);
            }
        }
    }

    [Fact]
    public void TestFindFirst()
    {
        var array = new[] { 1, 1, 3, 3, 3, 5, 5, 5, 5 };    // 9個
        var list = array.ToList();
        var keys = Enumerable.Range(0, 7);                  // 0-6

        var expects = new List<int>();
        var actuals = new List<int>();

        foreach (var i in keys)
        {
            var key = i;
            expects.Add(list.IndexOf(key));
            actuals.Add(BinarySearch.FindFirst(array, x => x - key));
        }

        AssertIndex(expects, actuals);
    }

    [Fact]
    public void TestFindLast()
    {
        var array = new[] { 1, 1, 3, 3, 3, 5, 5, 5, 5 };    // 9個
        var list = array.ToList();
        var keys = Enumerable.Range(0, 7);                  // 0-6

        var expects = new List<int>();
        var actuals = new List<int>();

        foreach (var i in keys)
        {
            var key = i;
            expects.Add(list.LastIndexOf(key));
            actuals.Add(BinarySearch.FindLast(array, x => x - key));
        }

        AssertIndex(expects, actuals);
    }

    [Fact]
    public void TestFindInsertIndex()
    {
        var array = new[] { 1, 1, 3, 3, 3, 5, 5, 5, 5 };    // 9個

        Assert.Equal(-1, BinarySearch.Find(array, static x => x - 0));
        Assert.Equal(-3, BinarySearch.Find(array, static x => x - 2));
        Assert.Equal(-6, BinarySearch.Find(array, static x => x - 4));
        Assert.Equal(-10, BinarySearch.Find(array, static x => x - 6));
    }
}
