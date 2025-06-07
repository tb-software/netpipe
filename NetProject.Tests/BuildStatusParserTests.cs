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
}
