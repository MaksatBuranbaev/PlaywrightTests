using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using PlaywrightTests.Pages;
using NUnit.Framework;

namespace PlaywrightTests.Tests
{
    [TestClass]
    public class LoginWithIncorrectCredentials
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
            await loginPage.EnteringPasswordAsync("wrong_password");
            await loginPage.ClickOnLoginAsync();
            await Expect(loginPage.GetError()).ToContainTextAsync("Epic sadface: Username and password do not match any user in this service");

            await context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = "C:/Users/zenfo/Desktop/1/vs code/Practicum/3/PlaywrightTests/traces/LoginWithIncorrect.zip"
            });
        }
    }
}
