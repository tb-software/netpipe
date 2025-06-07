using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NetProject;
using Xunit;

public class RemoteResultTests
{
    private class FakeHttpHandler : HttpMessageHandler
    {
        private readonly string _content;
        public FakeHttpHandler(string content) => _content = content;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_content)
            });
        }
    }

    private class FakePresenter : IMessagePresenter
    {
        public string? Message;
        public void ShowMessage(string message) => Message = message;
    }

    [Fact]
    public void ShowRemoteResult_DisplaysFetchedContent()
    {
        var handler = new FakeHttpHandler("expected result");
        var httpClient = new HttpClient(handler);
        var reader = new ResultReader(httpClient);
        var presenter = new FakePresenter();

        Program.ShowRemoteResult(presenter, reader);

        Assert.Equal("expected result", presenter.Message);
    }
}
