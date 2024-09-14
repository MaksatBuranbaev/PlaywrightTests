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
    public class LoginWithEmptyFields
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });

            var page = new LoginPage(await browser.NewPageAsync());
            await page.GotoAsync("https://www.saucedemo.com/");
            await page.ClickOnLoginAsync();
            await Expect(page.GetError()).ToContainTextAsync("Epic sadface: Username is required");
        }
    }
}