using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace NUnitDragAndDrop
{
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();

        }
            [Test]
         public void DragAndDropImageTest()
         {
                //Navigate to Website
                driver.Url = "https://www.globalsqa.com/demo-site/draganddrop/";

                //Finding iframe as WebElement
                IWebElement iframe = driver.FindElement(By.XPath("//iframe[@class='demo-frame lazyloaded']"));
                //Switching to iFrame
                driver.SwitchTo().Frame(iframe);

                //Finding the Source WebElement to be draged
                IWebElement sourceWebElement = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']"));

                //Finding the Source WebElement's ul parent tag before Drag and Drop operation
                IWebElement sourceWebElementBeforeDragAndDropClass = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']/ancestor::ul"));

                //Finding the Source WebElement's ul parent tag class before Drag and Drop operation
                string actualSourceWebElementClassBeforeDragAndDrop = sourceWebElementBeforeDragAndDropClass.GetAttribute("class");
                Console.WriteLine("Before moving img : " + actualSourceWebElementClassBeforeDragAndDrop);

                //Finding the Target WebElement where Source Web Element need to be dropped
                IWebElement targetWebElement = driver.FindElement(By.Id("trash"));

                //Source WebElement X cordinates
                int sourceWebElementBeforeDragAndDropXOffset = sourceWebElement.Location.X;
            Console.WriteLine("Before moving img x offset : " + sourceWebElementBeforeDragAndDropXOffset);
            //Creating object of Actions class by passing driver object to constructor of Actions class
            Actions actions = new Actions(driver);
            //Actual Drag and Drop Operation
            actions.DragAndDrop(sourceWebElement, targetWebElement).Perform();

            //Hardcoded wait for changes to get applied
            Thread.Sleep(2000);

            //Finding Source WebElement after Drag And Drop operation
            IWebElement sourceWebElementAfterDragAndDrop = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']"));

            //Source WebElement X cordinates after Drag And Drop operation
            int sourceWebElementAfterDragAndDropXOffset = sourceWebElementAfterDragAndDrop.Location.X;
            Console.WriteLine("After moving img x offset : " + sourceWebElementAfterDragAndDropXOffset);

            //Finding the Source WebElement's ul parent tag after Drag and Drop operation
            IWebElement newSourceWebElement = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']/ancestor::ul"));

            //Finding the Source WebElement's ul parent tag class after Drag and Drop operation
            string actualClass = newSourceWebElement.GetAttribute("class");
            string expectedClass = "gallery ui-helper-reset";
            Console.WriteLine("After moving img : " + actualClass);

            Assert.AreEqual(expectedClass, actualClass);

            //Asserting that x offest before and after drag and drop operation are not equal
            Assert.AreNotEqual(sourceWebElementBeforeDragAndDropXOffset, sourceWebElementAfterDragAndDropXOffset);
         }
    }
    
}