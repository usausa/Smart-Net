namespace Smart.Collections.Generic;

public sealed class DictionaryExtensionsTests
{
    //--------------------------------------------------------------------------------
    // CopyTo
    //--------------------------------------------------------------------------------

    [Fact]
    public void CopyToKeepsExistingValues()
    {
        var src = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
        var dst = new Dictionary<string, int> { ["a"] = 100 };

        src.CopyTo(dst);

        Assert.Equal(100, dst["a"]);
        Assert.Equal(2, dst["b"]);
    }

    [Fact]
    public void CopyToReplacesValues()
    {
        var src = new SortedDictionary<string, int>(StringComparer.Ordinal) { ["a"] = 1, ["b"] = 2 };
        var dst = new Dictionary<string, int> { ["a"] = 100 };

        src.CopyTo(dst, true);

        Assert.Equal(1, dst["a"]);
        Assert.Equal(2, dst["b"]);
    }

    [Fact]
    public void CopyToFromDictionaryReplacesValues()
    {
        var src = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
        var dst = new Dictionary<string, int> { ["a"] = 100 };

        src.CopyTo(dst, true);

        Assert.Equal(1, dst["a"]);
        Assert.Equal(2, dst["b"]);
    }

    [Fact]
    public void CopyToFromDictionaryKeepsExistingValuesOfOtherDictionary()
    {
        var src = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
        var dst = new SortedDictionary<string, int>(StringComparer.Ordinal) { ["a"] = 100 };

        src.CopyTo(dst);

        Assert.Equal(100, dst["a"]);
        Assert.Equal(2, dst["b"]);
    }

    [Fact]
    public void CopyToFromDictionaryDoesNotAllocate()
    {
        var src = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
        var dst = new Dictionary<string, int>(4);
        Copy(src, dst);

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 100; i++)
        {
            Copy(src, dst);
        }

        Assert.InRange(GC.GetAllocatedBytesForCurrentThread() - before, 0, 99);

        static void Copy(Dictionary<string, int> src, Dictionary<string, int> dst)
        {
            dst.Clear();
            src.CopyTo(dst, false);
        }
    }
}
