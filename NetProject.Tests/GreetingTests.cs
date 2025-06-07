using NetProject;
using Xunit;

public class GreetingTests
{
    private class FakePresenter : IMessagePresenter
    {
        public string? Message;
        public void ShowMessage(string message) => Message = message;
    }

    [Fact]
    public void ShowGreeting_UsesPresenterToDisplayMessage()
    {
        var fake = new FakePresenter();
        Program.ShowGreeting(fake);
        Assert.Equal("Hallo von Timo 3l!", fake.Message);
    }
}
