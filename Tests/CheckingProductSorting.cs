using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using PlaywrightTests.Pages;
using NUnit.Framework;
using System.Globalization;

namespace PlaywrightTests.Tests
{
    [TestClass]
    public class CheckingProductSorting
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var context = await browser.NewContextAsync();

            await context.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            var page = await context.NewPageAsync();

            var loginPage = new LoginPage(page);
            await loginPage.GotoAsync("https://www.saucedemo.com/");
            await loginPage.EnteringNameAsync("standard_user");
            await loginPage.EnteringPasswordAsync("secret_sauce");
            await loginPage.ClickOnLoginAsync();
            var inventoryPage = new InventoryPage(page);
            await inventoryPage.SelectOptionAsync(["lohi"]);
            await Expect(inventoryPage.GetSortContainer()).ToHaveValueAsync("lohi");

            List<decimal> prices = await inventoryPage.GetPriceListAsync();
            List<decimal> sortedPrices = prices.OrderBy(price => price).ToList();        
            CollectionAssert.AreEqual(prices, sortedPrices, "Цены продуктов не отсортированы по возрастанию");

            await context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = "C:/Users/zenfo/Desktop/1/vs code/Practicum/3/PlaywrightTests/traces/ProductSorting.zip"
            });
        }
    }
}
