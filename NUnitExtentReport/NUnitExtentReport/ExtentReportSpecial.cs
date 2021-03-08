using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NUnitExtentReport
{
    class ExtentReportSpecial
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
                Reporter.AddSystemInfo("Environment", " Selenium Automation");
                Reporter.AddSystemInfo("User Name", "Gyanendra");
                Reporter.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        [Test]
        public void FormTest()
        {
            //driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Url = "https://wpforms.com/demo/contest-entry-form-demo/";

            driver.FindElement(By.CssSelector(".wpforms-field-name-first.wpforms-field-required")).SendKeys("Gyanendra");
            driver.FindElement(By.Id("wpforms-254474-field_1-last")).SendKeys("Basnet");
            driver.FindElement(By.Id("wpforms-254474-field_2")).SendKeys("genuine3351@gmail.com");
            //driver.FindElement(By.XPath("//label[text()='Male']")).Click();
            driver.FindElement(By.Id("wpforms-254474-field_3")).SendKeys("4697810601");
            //Thread.Sleep(3000);
            driver.FindElement(By.Id("wpforms-254474-field_4")).SendKeys("917 DEL PASO ST");
            driver.FindElement(By.Id("wpforms-254474-field_4-address2")).SendKeys("APT # 252");
            driver.FindElement(By.Id("wpforms-254474-field_4-city")).SendKeys("Euless");

            //wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath("//div[text()='Select State']")));
            IWebElement stateDropDown = driver.FindElement(By.Id("wpforms-254474-field_4-state"));
            SelectElement selectElement = new SelectElement(stateDropDown);
            selectElement.SelectByIndex(4);
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Select City']")));
            driver.FindElement(By.Id("wpforms-254474-field_4-postal")).SendKeys("76040");

            driver.FindElement(By.Id("wpforms-254474-field_6_1")).Click();
            driver.FindElement(By.Id("wpforms-submit-254474")).Click();
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
        public void FaceBookCreateAccountPageTest()
        {
            driver.Url = "https://www.facebook.com/";
            driver.FindElement(By.CssSelector("_42ft._4jy0._6lti._4jy6._4jy2.selected._51sy")).Click();
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
