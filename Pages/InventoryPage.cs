using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class InventoryPage
{
    private readonly IPage _page;
    public InventoryPage(IPage page)
    {
        _page = page;
    }
    public async Task SelectOptionAsync(IEnumerable<string> values)
    {
        await _page.Locator("[data-test=\"product-sort-container\"]").SelectOptionAsync(values);
    }

    public ILocator GetSortContainer()
    {
        return _page.Locator("[data-test=\"product-sort-container\"]");
    }
}