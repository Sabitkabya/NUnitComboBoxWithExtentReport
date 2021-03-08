using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NUnitDotNetCoreExtentReport
{
    class NewFeature
    {
        IWebDriver driver;
        WebDriverWait wait;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test]
        public void UtilityTest()
        {
            //Killing Process
            foreach (var process in Process.GetProcessesByName("Chrome"))
            {
                process.Kill();
            }
        }
        [Test]
        public void getRandomDigits(int length)
        {
            Random ran = new Random();
            StringBuilder digits = new StringBuilder("");
            for (int i = 1; i <= length; i++)
            {
                digits.Append(ran.Next(0, 9).ToString());
            }
           Console.WriteLine( digits.ToString());
        }
       
    }
}
