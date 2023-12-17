namespace Smart.Text;

public sealed class InflectorTest
{
    [Fact]
    public void ToUnderscore()
    {
        Assert.Equal("abc_xyz", Inflector.Underscore("AbcXyz"));
        Assert.Equal("ABC_XYZ", Inflector.Underscore("AbcXyz", true));
        Assert.Equal("abc_xyz", Inflector.Underscore("abc_xyz"));
        Assert.Equal("ABC_XYZ", Inflector.Underscore("abc_xyz", true));
    }

    [Fact]
    public void ToPascal()
    {
        Assert.Equal("AbcXyz", Inflector.Pascalize("AbcXyz"));
        Assert.Equal("AbcXyz", Inflector.Pascalize("abcXyz"));
        Assert.Equal("AbcXyz", Inflector.Pascalize("abc_xyz"));
        Assert.Equal("AbcXyz", Inflector.Pascalize("ABC_XYZ"));
    }

    [Fact]
    public void ToCamel()
    {
        Assert.Equal("abcXyz", Inflector.Camelize("AbcXyz"));
        Assert.Equal("abcXyz", Inflector.Camelize("abcXyz"));
        Assert.Equal("abcXyz", Inflector.Camelize("abc_xyz"));
        Assert.Equal("abcXyz", Inflector.Camelize("ABC_XYZ"));
    }
}
