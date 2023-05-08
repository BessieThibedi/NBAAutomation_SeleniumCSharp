using System;
using NBA_Automation.source.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using excel = Microsoft.Office.Interop.Excel;

namespace NBA_Automation.test
{
	public class LoginTest
	{
        private IWebDriver _driver;
        

        [SetUp]
        public void InitScript()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.nba.com/");
            _driver.Manage().Window.Maximize();
        }



        [Test]
		public void Testcase_001_Verify_User_Can_Login_with_valid_credentials()
		{
            homePage_POM home = new homePage_POM(_driver);
            home.SignIn();
            loginPage_POM login = new loginPage_POM(_driver);
            login.Login("thibedib.bt@gmail.com", "Password@123");
            Thread.Sleep(5000);

            home.SignIn();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            String actualvalue = login.txtEmail();
            Assert.IsTrue(actualvalue.Contains("thibedib.bt@gmail.com"), actualvalue + " doesn't contain 'thibedib.bt@gmail.com'");
        }

        [Test]
        public void Testcase_002_Verify_a_valid_error_displays_when_user_logs_in_with_invalid_username_and_valid_password()
        {
            homePage_POM home = new homePage_POM(_driver);
            home.SignIn();
            loginPage_POM login = new loginPage_POM(_driver);
            login.Login("test@mail.com", "Bessie@123");
            Thread.Sleep(5000);

            home.SignIn();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            String actualvalue = login.txtInvalidError();
            Assert.IsTrue(actualvalue.Contains("Invalid email or password. Please try again."), actualvalue + " doesn't contain 'Invalid email or password. Please try again.'");
        }

        [Test]
        public void Testcase_003_Verify_a_valid_error_displays_when_user_logs_in_with_valid_username_and_invalid_password()
        {
            homePage_POM home = new homePage_POM(_driver);
            home.SignIn();
            loginPage_POM login = new loginPage_POM(_driver);
            login.Login("thibedib.bt@gmail.com", "Test");
            Thread.Sleep(5000);

            home.SignIn();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            String actualvalue = login.txtInvalidError();
            Assert.IsTrue(actualvalue.Contains("Invalid email or password. Please try again."), actualvalue + " doesn't contain 'Invalid email or password. Please try again.'");
        }



        [TearDown]
        public void cleanup()
        {
            _driver.Quit();
        }


    }
}

