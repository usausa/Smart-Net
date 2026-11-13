namespace Smart.Text.Json;

public sealed class JsonKeyCamelCaseNamingPolicyTests
{
    [Theory]
    [InlineData("Name", "name")]
    [InlineData("NAME", "nAME")]
    [InlineData("Section.Key", "section.key")]
    [InlineData("section.Key", "section.key")]
    [InlineData("Section.key", "section.key")]
    [InlineData("A..B", "a..B")]
    [InlineData(".X", ".X")]
    [InlineData("ǅx", "ǆx")]
    public void ConvertName(string name, string expected)
    {
        Assert.Equal(expected, JsonKeyCamelCaseNamingPolicy.Instance.ConvertName(name));
    }

    [Theory]
    [InlineData("")]
    [InlineData("name")]
    [InlineData("section.key")]
    [InlineData("a..B")]
    [InlineData(".X")]
    public void ConvertNameReturnsSameInstanceWhenUnchanged(string name)
    {
        Assert.Same(name, JsonKeyCamelCaseNamingPolicy.Instance.ConvertName(name));
    }

    [Fact]
    public void ConvertNameDoesNotAllocateWhenUnchanged()
    {
        var policy = JsonKeyCamelCaseNamingPolicy.Instance;
        _ = policy.ConvertName("section.key");

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 100; i++)
        {
            _ = policy.ConvertName("section.key");
        }

        Assert.InRange(GC.GetAllocatedBytesForCurrentThread() - before, 0, 99);
    }
}
