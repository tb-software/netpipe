using NetProject;
using System.Windows.Controls;
using Xunit;

public class WpfOutputPresenterTests
{
    [Fact]
    public void ShowMessage_SetsTextBoxText()
    {
        var box = new TextBox();
        var presenter = new WpfOutputPresenter(box);

        presenter.ShowMessage("hi");

        Assert.Equal("hi", box.Text);
    }
}
