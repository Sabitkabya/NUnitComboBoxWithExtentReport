using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        
       
        [TestMethod]
        public void SearchTest()
        {
            IWebDriver driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.wikipedia.org/";
            driver.FindElement(By.Id("searchInput")).SendKeys("LUMBINI");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.Close();
        }
        [TestMethod]
        public void SearchTest1()
        {
            IWebDriver driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.wikipedia.org/";
            driver.FindElement(By.Id("searchInput")).SendKeys("NEPAL");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.Close();
        }
        [TestMethod]
        public void FacebookTest()
        {
            IWebDriver driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com/";
            driver.FindElement(By.XPath("//a[text()='Create New Account']")).Click();
            driver.Close();
        }
        [TestMethod]
        public void PopUpTest()
        {
            IWebDriver driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Manage().Window.Maximize();
            driver.Url = "http://w2ui.com/web/demo/popup";
            IWebElement showPopupButton = driver.FindElement(By.XPath("//input[@class='btn btn-info' and @value='Show Popup']"));
            showPopupButton.Click();

            bool isPopupDisplayed = driver.FindElement(By.Id("w2ui-popup")).Displayed;
            Assert.IsTrue(isPopupDisplayed);
            Thread.Sleep(2000);

            IWebElement popupTitle = driver.FindElement(By.XPath("//div[@class='w2ui-popup-title']/descendant::div[@rel='title']"));
            string actualPopupTitle = popupTitle.Text;
            Assert.AreEqual("Popup #1 Title", actualPopupTitle);
            Thread.Sleep(2000);

            IWebElement closePopupButton = driver.FindElement(By.CssSelector(".w2ui-popup-button.w2ui-popup-close"));
            closePopupButton.Click();
            driver.Close();
        }
    }
}
