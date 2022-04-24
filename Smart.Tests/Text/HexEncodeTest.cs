namespace Smart.Text;

using Xunit;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "Ignore")]
public class HexEncodeTest
{
    private readonly byte[] bytes;

    private readonly string hex;

    public HexEncodeTest()
    {
        bytes = new byte[256];
        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] = (byte)i;
        }

        hex = BitConverter.ToString(bytes).Replace("-", string.Empty, StringComparison.Ordinal);
    }

    [Fact]
    public void Encode()
    {
        Assert.Equal(hex, HexEncoder.Encode(bytes));
    }

    [Fact]
    public void Decode()
    {
        Assert.Equal(bytes, HexEncoder.Decode(hex));
        Assert.Equal(bytes, HexEncoder.Decode(hex.ToLowerInvariant()));
    }

    [Fact]
    public void EncodeToBuffer()
    {
        var buffer = new char[bytes.Length * 2];

        HexEncoder.Encode(bytes, buffer);

        Assert.Equal(hex, new string(buffer));
    }

    [Fact]
    public void DecodeToBuffer()
    {
        var buffer = new byte[bytes.Length];

        HexEncoder.Decode(hex, buffer);

        Assert.Equal(bytes, buffer);

        HexEncoder.Decode(hex.ToLowerInvariant(), buffer);

        Assert.Equal(bytes, buffer);
    }
}
