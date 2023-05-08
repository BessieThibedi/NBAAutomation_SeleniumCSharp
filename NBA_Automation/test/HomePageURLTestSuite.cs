using System;
using NBA_Automation.source.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NBA_Automation.test
{
	public class mainTest
	{

		private IWebDriver _driver;


		[SetUp]
		public void InitScript()
		{
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
			_driver.Navigate().GoToUrl("https://www.nba.com/");
        }
        [Test]
			public void Testcase_001_Verify_user_gets_redirected_to_the_nba_store_when_they_click_on_the_store_link()
			{
			homePage_POM home = new homePage_POM(_driver);
			home.NBAstoreLink();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Assert.True(_driver.Url.Contains("https://www.nbastore.eu/en/?CMP=PSC-IGV6HHF6&portal=IGV6HHF6"));
            }

		[Test]
		public void NBATickeTestcase_001_Verify_user_gets_redirected_to_the_nba_store_when_they_click_on_the_store_linktsURLtest()
		{
            homePage_POM home = new homePage_POM(_driver);
			home.NBAticketLink();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Assert.True(_driver.Url.Contains("https://nbatickets.nba.com/?cid=nba:tickets:institutional:nbacom:domsites:rd"));
        }


		[TearDown]
		public void cleanup() {
			_driver.Quit();
		}
		
	}
}

