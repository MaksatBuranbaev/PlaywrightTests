using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class LoginPage
{
    private readonly IPage _page;
    public LoginPage(IPage page)
    {
        _page = page;
    }
        public async Task GotoAsync(string url)
    {
        await _page.GotoAsync(url);
    }

    public async Task EnteringNameAsync(string name)
    {
        await _page.Locator("[data-test=\"username\"]").ClickAsync();
        await _page.Locator("[data-test=\"username\"]").FillAsync(name);
    }

    public async Task EnteringPasswordAsync(string password)
    {
        await _page.Locator("[data-test=\"password\"]").ClickAsync();
        await _page.Locator("[data-test=\"password\"]").FillAsync(password);
    }

    public async Task ClickOnLoginAsync()
    {
        await _page.Locator("[data-test=\"login-button\"]").ClickAsync();
    }

    public ILocator GetError()
    {
        return _page.Locator("[data-test=\"error\"]");
    }
}