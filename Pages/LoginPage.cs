using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class LoginPage
{
    private readonly IPage _page;
    private readonly string _usernameLocator;
    private readonly string _passwordLocator;
    private readonly string _loginButtonLocator;
    private readonly string _errorLocator;
    public LoginPage(IPage page, string usernameLocator = "[data-test=\"username\"]", string passwordLocator = "[data-test=\"password\"]", 
    string loginButtonLocator = "[data-test=\"login-button\"]", string errorLocator = "[data-test=\"error\"]")
    {
        _page = page;
        _usernameLocator = usernameLocator;
        _passwordLocator = passwordLocator;
        _loginButtonLocator = loginButtonLocator;
        _errorLocator = errorLocator;
    }
        public async Task GotoAsync(string url)
    {
        await _page.GotoAsync(url);
    }

    public async Task EnteringNameAsync(string name)
    {
        await _page.Locator(_usernameLocator).ClickAsync();
        await _page.Locator(_usernameLocator).FillAsync(name);
    }

    public async Task EnteringPasswordAsync(string password)
    {
        await _page.Locator(_passwordLocator).ClickAsync();
        await _page.Locator(_passwordLocator).FillAsync(password);
    }

    public async Task ClickOnLoginAsync()
    {
        await _page.Locator(_loginButtonLocator).ClickAsync();
    }

    public ILocator GetError()
    {
        return _page.Locator(_errorLocator);
    }
}