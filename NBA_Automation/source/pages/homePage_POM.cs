using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NBA_Automation.source.pages
{
	public class homePage_POM
	{
		private IWebDriver _driver;

		By storeLink = By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/nav/ul/li[14]/a");
		By ticketLink = By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/nav/ul/li[15]/a");
		By gamesMenubtn = By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/nav/ul/li[1]/a");
        By tabSignIn = By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/nav/div/div/ul/li/button");
        By btnSignInWithNBAID = By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/nav/div/div/ul/li/div/div/ul/li[1]/a");

			




        public homePage_POM(IWebDriver driver)
			
		{
            _driver = driver;
        }

		public void NBAstoreLink() {
			_driver.FindElement(storeLink).Click();
		}
		public void NBAticketLink() {
			_driver.FindElement(ticketLink).Click();
		}
		public void SignIn() {

            Actions action = new Actions(_driver);
			action.MoveToElement(_driver.FindElement(tabSignIn));
            action.MoveToElement(_driver.FindElement(btnSignInWithNBAID));
            action.Click().Build().Perform();


        }
	}
}

