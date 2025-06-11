using NetProject;
using System;
using System.IO;
using Xunit;

public class ConsoleOutputPresenterTests
{
    [Fact]
    public void ShowMessage_WritesToConsole()
    {
        var presenter = new ConsoleOutputPresenter();
        using var sw = new StringWriter();
        Console.SetOut(sw);

        presenter.ShowMessage("hello");

        Assert.Equal("hello" + Environment.NewLine, sw.ToString());
    }
}
