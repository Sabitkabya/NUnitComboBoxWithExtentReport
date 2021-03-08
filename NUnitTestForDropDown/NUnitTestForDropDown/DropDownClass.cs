using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestForDropDown
{
    class DropDownClass
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {
            driver.Url = "http://demo.guru99.com/test/newtours/reservation.php";
            driver.FindElement(By.XPath("//input[@value='roundtrip']")).Click();
            IWebElement element1=driver.FindElement(By.Name("passCount"));
            SelectElement selectElement = new SelectElement(element1);
            selectElement.SelectByIndex(1);
        }
    }
}
