using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestOnlineSite
{
    class JustPractice
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("http://www.integrationqa.com/");
            IWebElement menu = driver.FindElement(By.Id("hs_menu_wrapper_module_13970568219884"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(menu).Build().Perform();
        }
        [Test]
        public void Test2()
        {
            IList<IWebElement> menuItemsList = menu.FindElements(By.ClassName("hs-menu-item"));

            String[] menuItems = new String[menuItemsList.Count];
            int i = 0;
            foreach (IWebElement menuItem in menuItemsList)
            {
                menuItems[i++] = menuItem.Text;
            }

            //Arrange all the list items in alphabetical order
            IEnumerable<String> orderedMenuList = menuItems.OrderBy(lv_menu => lv_menu).ToList();

            //Display the ordered list
            foreach (var menuItem in orderedMenuList)
            {
                if (menuItem.Length > 0)
                    Console.WriteLine(menuItem);
            }
            Console.ReadKey();
        }
    }
}
