using NetProject;
using System.Threading.Tasks;
using Xunit;

public class BuildStatusDisplayTests
{
    private class FakeReader : ResultReader
    {
        private readonly string _content;
        public FakeReader(string content) : base(null)
        {
            _content = content;
        }
        public override async Task<string> FetchRemoteResultAsync()
        {
            await Task.CompletedTask;
            return _content;
        }
    }

    private class FakePresenter : IMessagePresenter
    {
        public string? Message;
        public void ShowMessage(string message) => Message = message;
    }

    [Fact]
    public void ShowBuildStatus_DisplaysParsedInfo()
    {
        var content = "Exit code: 1\nFile size: 5";
        var reader = new FakeReader(content);
        var checker = new BuildStatusChecker(reader);
        var presenter = new FakePresenter();

        Program.ShowBuildStatus(presenter, checker);

        Assert.Equal("Exit code: 1, Size: 5", presenter.Message);
    }

    [Fact]
    public void ShowBuildStatus_IncludesPathIfAvailable()
    {
        var content = "Exit code: 1\nFile size: 5\nMapped path: /tmp/test";
        var reader = new FakeReader(content);
        var checker = new BuildStatusChecker(reader);
        var presenter = new FakePresenter();

        Program.ShowBuildStatus(presenter, checker);

        Assert.Equal("Exit code: 1, Size: 5, Path: /tmp/test", presenter.Message);
    }
}
