using NetProject;
using Xunit;

public class BuildStatusParserTests
{
    [Fact]
    public void ParseExitCode_ReturnsNumber()
    {
        var parser = new BuildStatusParser();
        int code = parser.ParseExitCode("some text\nExit code: 1\nnext");
        Assert.Equal(1, code);
    }

    [Fact]
    public void ParseExitCode_ThrowsWhenPatternMissing()
    {
        var parser = new BuildStatusParser();
        var ex = Assert.Throws<FormatException>(() => parser.ParseExitCode("no exit info"));
        Assert.Contains("pattern not found", ex.Message);
    }

    [Fact]
    public void ParseExitCode_ThrowsWhenValueInvalid()
    {
        var parser = new BuildStatusParser();
        var ex = Assert.Throws<FormatException>(() => parser.ParseExitCode("Exit code: NaN"));
        Assert.Contains("Failed to parse", ex.Message);
    }
}
