using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class InventoryPage
{
    private readonly IPage _page;
    private readonly string _productSortLocator;
    public InventoryPage(IPage page, string productSortLocator = "[data-test=\"product-sort-container\"]")
    {
        _page = page;
        _productSortLocator = productSortLocator;
    }
    public async Task SelectOptionAsync(IEnumerable<string> values)
    {
        await _page.Locator(_productSortLocator).SelectOptionAsync(values);
    }

    public ILocator GetSortContainer()
    {
        return _page.Locator(_productSortLocator);
    }

    public async Task<List<decimal>> GetPriceListAsync()
    {
        var priceElements = await _page.QuerySelectorAllAsync(".inventory_item_price");

        List<decimal> prices = new List<decimal>();
        foreach (var element in priceElements)
        {
            string priceText = await element.InnerTextAsync();
            decimal price = Convert.ToDecimal(priceText.Replace("$", "").Trim(), CultureInfo.InvariantCulture);

            prices.Add(price);
        }

        return prices;
    }
}