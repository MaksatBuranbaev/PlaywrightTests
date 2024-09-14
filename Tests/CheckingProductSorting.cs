using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests
{
    [TestClass]
    public class CheckingProductSorting
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            var loginPage = new LoginPage(page);
            await loginPage.GotoAsync("https://www.saucedemo.com/");
            await loginPage.EnteringNameAsync("standard_user");
            await loginPage.EnteringPasswordAsync("secret_sauce");
            await loginPage.ClickOnLoginAsync();
            var inventoryPage = new InventoryPage(page);
            await inventoryPage.SelectOptionAsync(["lohi"]); 
            await Expect(inventoryPage.GetSortContainer()).ToHaveValueAsync("lohi");
        }
    }
}
