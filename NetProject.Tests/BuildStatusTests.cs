using NetProject;
using System.Threading.Tasks;
using Xunit;

public class BuildStatusTests
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

    [Fact]
    public async Task GetCurrentStatusAsync_ReturnsSuccessWhenExitCodeZero()
    {
        var content = "something\nExit code: 0\nmore";
        var reader = new FakeReader(content);
        var checker = new BuildStatusChecker(reader);
        BuildStatus status = await checker.GetCurrentStatusAsync();
        Assert.True(status.IsSuccess);
        Assert.Equal(0, status.ExitCode);
    }
}
