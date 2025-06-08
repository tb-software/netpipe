using NetProject;
using Xunit;

public class BrowserTests
{
    private class FakeBrowser : IBrowserService
    {
        public string? Url;
        public void OpenUrl(string url) => Url = url;
    }

    [Fact]
    public void OpenBuildMonitor_OpensExpectedUrl()
    {
        var fake = new FakeBrowser();
        Program.OpenBuildMonitor(fake);
        Assert.Equal("http://t78.ch/apps/netpipe/", fake.Url);
    }
}
