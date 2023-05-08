using System;
using OpenQA.Selenium;

namespace NBA_Automation.source.pages
{
	public class loginPage_POM
	{
        private IWebDriver _driver;


        By usernametxt = By.Name("email");
        By passwordtxt = By.Id("password");
        By submitbtn = By.Id("submit");
        By invalidtxt = By.XPath("/html/body/div[1]/div[2]/div[2]/div/div/div[1]/form/div/p");
        By userEmailtxt = By.XPath("/html/body/div[1]/div[2]/div[2]/div/div/div[1]/div[1]/div[2]/div/div[1]/span[2]");


        public loginPage_POM(IWebDriver driver)
		{
            _driver = driver;
        }

      

        public void Login(String username, String password) {
            _driver.FindElement(usernametxt).SendKeys(username);
            _driver.FindElement(passwordtxt).SendKeys(password);
            _driver.FindElement(submitbtn).Click();
        }
        public String txtEmail()
        {
            String email = _driver.FindElement(userEmailtxt).Text;
            return email;
        }
        public String txtInvalidError() {
            String invalid = _driver.FindElement(invalidtxt).Text;
            return invalid;
        }
       
    }
}

