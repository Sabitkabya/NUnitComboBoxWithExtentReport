using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace NUnitTestProject1
{
    public class Form
    {
       // protected BrowserType _browserType;
        public static AventStack.ExtentReports.ExtentReports Reporter = new AventStack.ExtentReports.ExtentReports();
        public static ExtentTest _test;
        ExtentHtmlReporter htmlReporter;
        private WebDriverWait wait;
        private IWebDriver driver;

        [OneTimeSetUp]
         public void OneTimeSetUp()
         {
            driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
           /* try
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
                htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");
                Reporter.AddSystemInfo("Environment", "Automation Practice");
                Reporter.AddSystemInfo("User Name", "Gyanendra");
                Reporter.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }*/
        }

        [SetUp]
        public void BeforeTest()
        {

            _test = Reporter.CreateTest(TestContext.CurrentContext.Test.Name);
            string path = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\Drivers\");
            try
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
                htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");
                Reporter.AddSystemInfo("Environment", "Automation Practice");
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
            driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
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
            driver = new ChromeDriver(@"D:\Drivers\chromedriver_win32");
            driver.Url = "https://opensource-demo.orangehrmlive.com/";
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin");
            driver.FindElement(By.Id("btnLogin")).Click();
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
            driver.Quit();
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            try
            {
                Reporter.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }   
    }

}
