using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NUnitTestJavaScript
{
    class JavaScript
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void JavaScriptTest()
        {
            driver.Url = "https://www.wikipedia.org/";
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor) driver;
            javaScriptExecutor.ExecuteScript("document.getElementsByName('search')[0].value='Lumbini'");
            javaScriptExecutor.ExecuteScript("document.getElementsByTagName('button')[0].click()");
            Thread.Sleep(3000);
        }
        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
