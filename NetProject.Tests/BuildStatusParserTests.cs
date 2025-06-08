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
    public void ParseFileSize_ReturnsNumber()
    {
        var parser = new BuildStatusParser();
        long size = parser.ParseFileSize("info\nFile size: 99 bytes\nend");
        Assert.Equal(99, size);
    }

    [Fact]
    public void ParseMappedPath_ReturnsString()
    {
        var parser = new BuildStatusParser();
        string path = parser.ParseMappedPath("info\nMapped path: C:/tmp/foo\nend");
        Assert.Equal("C:/tmp/foo", path);
    }

    [Fact]
    public void ParseFileContent_ReturnsRestOfText()
    {
        var parser = new BuildStatusParser();
        string data = parser.ParseFileContent("some\nContent: hello world\n");
        Assert.Equal("hello world", data);
    }
}
