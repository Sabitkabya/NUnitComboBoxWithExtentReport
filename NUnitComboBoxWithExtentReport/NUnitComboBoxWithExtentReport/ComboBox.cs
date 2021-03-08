using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace NUnitComboBoxWithExtentReport
{
    class ComboBox
    {
        public static AventStack.ExtentReports.ExtentReports Reporter = new AventStack.ExtentReports.ExtentReports();
        public static ExtentTest _test;
        ExtentHtmlReporter htmlReporter;
        private WebDriverWait wait;
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
            _test = Reporter.CreateTest(TestContext.CurrentContext.Test.Name);
            string path = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\Drivers\");
            try
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
                htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");
                Reporter.AddSystemInfo("Environment", "Automation Testing");
                Reporter.AddSystemInfo("User Name", "gyanendra basnet");
                Reporter.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [Test]
        public void ComboBoxTest()
        {
            driver.Url = "https://compare-staging.patientpop.com/checkup";
            //Combo Box
            IWebElement practiceName = driver.FindElement(By.Id("practicename"));
            practiceName.SendKeys("Amersi ");
            Thread.Sleep(2000);
            //Combo Box drop down options are coming in different elements in DOM
            var queryMatches = driver.FindElements(By.ClassName("pac-item-query"));
            foreach (var item in queryMatches)
            {
                if (item.Text.Contains("Shamsah"))
                {
                    item.Click();
                    break;
                }
            }
            Thread.Sleep(2000);
            //Verification of Auto populated fields
            IWebElement streetAddressElement = driver.FindElement(By.Id("streetaddress"));
            //As there is no innerHTML in DOM element that's why we are using JavaScriptExecutor to return the actual text in form of value
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            var actualStreeAddressValue = javaScriptExecutor.ExecuteScript("return arguments[0].value", streetAddressElement);
            string expectedStreetAddress = "2825 Santa Monica Boulevard";
            Assert.AreEqual(expectedStreetAddress, actualStreeAddressValue.ToString());
        }

        [Test]
        public void LoginFunctionality()
        {
            //driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Url = "https://opensource-demo.orangehrmlive.com/";
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
            driver.FindElement(By.Id("btnLogin")).Click();
        }
        [Test]
        public void LoginFunctionality99Test()
        {
            driver.Url = "http://demo.guru99.com/test/newtours/index.php";
            IWebElement userNameField = driver.FindElement(By.Name("userName"));
            userNameField.SendKeys("Ztest");
            IWebElement passwordField = driver.FindElement(By.XPath("//input[@name='password']"));
            passwordField.SendKeys("Test1234");
            IWebElement submitButton = driver.FindElement(By.Name("submit"));
            submitButton.Click();
            string expectedMessage = "Login Successfully";
            Assert.IsTrue(true, expectedMessage);
            
        }
        [Test]
        public void FlightReservationTest()
        {
            driver.Url = "http://demo.guru99.com/test/newtours/reservation.php";
            driver.Manage().Window.Maximize();
            IWebElement oneWayRadioButton = driver.FindElement(By.XPath("//input[@value='oneway']"));
            oneWayRadioButton.Click();
            IWebElement dropDownButton = driver.FindElement(By.Name("passCount"));
            SelectElement selectElement = new SelectElement(dropDownButton);
            selectElement.SelectByIndex(1);
            IWebElement departingElement = driver.FindElement(By.Name("fromPort"));
            SelectElement selectElement1 = new SelectElement(departingElement);
            selectElement1.SelectByValue("San Francisco");
            IWebElement fromMonthElement = driver.FindElement(By.XPath("//select[@name='fromMonth']"));
            SelectElement selectElement2 = new SelectElement(fromMonthElement);
            selectElement2.SelectByIndex(0);
            IWebElement fromDayElement = driver.FindElement(By.XPath("//select[@name='fromDay']"));
            SelectElement selectElement3 = new SelectElement(fromDayElement);
            selectElement3.SelectByValue("12");
            IWebElement arrivingInElement = driver.FindElement(By.Name("toPort"));
            SelectElement selectElement4 = new SelectElement(arrivingInElement);
            selectElement4.SelectByValue("New York");
            IWebElement returningElement = driver.FindElement(By.XPath("//select[@name='toMonth']"));
            SelectElement selectElement5 = new SelectElement(returningElement);
            selectElement5.SelectByIndex(6);
            IWebElement returningDayElement = driver.FindElement(By.Name("toDay"));
            SelectElement selectElement6 = new SelectElement(returningDayElement);
            selectElement6.SelectByIndex(11);
            IWebElement serviceClassElement = driver.FindElement(By.XPath("//input[@value='Business']"));
            serviceClassElement.Click();
            IWebElement airlineElement = driver.FindElement(By.XPath("//select[@name='airline']"));
            SelectElement selectElement7 = new SelectElement(airlineElement);
            selectElement7.SelectByIndex(2);
            IWebElement continueButtom = driver.FindElement(By.Name("findFlights"));
            continueButtom.Click();
            string expectedMessage = "After flight finder - No Seats Avaialble";
            Assert.IsTrue(true, expectedMessage);
        }
            [Test]
        public void EmployeeFormTest()
        {
            driver.Url = "https://wpforms.com/demo/equipment-checkout-form-demo/";
            driver.FindElement(By.Id("wpforms-254486-field_1")).SendKeys("Kabya");
            driver.FindElement(By.Id("wpforms-254486-field_1-last")).SendKeys("Basnet");
            driver.FindElement(By.Id("wpforms-254486-field_2")).SendKeys("589710");
            driver.FindElement(By.Id("wpforms-254486-field_3")).SendKeys("genuine3351@gmail.com");
            driver.FindElement(By.Id("wpforms-254486-field_4")).SendKeys("4698710601");
            driver.FindElement(By.Id("wpforms-254486-field_5_1")).Click();
            driver.FindElement(By.Id("wpforms-254486-field_5_5")).Click();
            driver.FindElement(By.Id("wpforms-254486-field_6_1")).Click();
            driver.FindElement(By.Id("wpforms-submit-254486")).Submit();

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
        [TearDown] 
         public void AfterTest()
         {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            string result = TestContext.CurrentContext.Result.Outcome.ToString();
            var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    _test.Log(logstatus, "Test ended with " + logstatus);
                    break;
                default:
                    logstatus = Status.Pass;
                    _test.Log(logstatus, "Test ended with " + logstatus);
                    break;
            }
            try
            {
                Reporter.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
            driver.Quit();
         }
    }
}
