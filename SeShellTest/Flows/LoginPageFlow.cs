using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeShell.Test.Core;
using SeShell.Test.Enums;
using SeShell.Test.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeShell.Test.Flows
{
    public class LoginPageFlow : BaseClass
    {
        public LoginPageFlow(IWebDriver webDriver)
        {
            base.SetWebDriverInstance(webDriver);
            base.NavigateTo("Account/Login");
        }

        /// <summary>
        /// Logs in as a specific user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        public void LogIn(string userName, string password, bool rememberMe)
        {
            IWebElement userNameTextBox =
                Utilities.FindElement(base.Driver, HtmlElementBy.Id, LoginPage.UserNameTextBox());
            IWebElement passwordTextBox =
                Utilities.FindElement(base.Driver, HtmlElementBy.Id, LoginPage.PasswordTextBox());
            IWebElement logInButton =
                Utilities.FindElement(base.Driver, HtmlElementBy.XPath, LoginPage.LogInButton());
            IWebElement rememberMeCheckBox =
                Utilities.FindElement(base.Driver, HtmlElementBy.Id, LoginPage.RememberMe());

            userNameTextBox.SendKeys(userName);
            passwordTextBox.SendKeys(password);
            
            if (rememberMe)
            {
                rememberMeCheckBox.Click();
            }

            logInButton.Click();
        }

        public bool IsUserLoggedIn(string expectedUserName)
        {
            string xpath = "//*[@id=\"ctl01\"]/div[3]/div/div[2]/ul[2]/li[3]/a";
            WebDriverWait wait = new WebDriverWait(base.Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath(xpath)).Displayed);

            IWebElement helloMessage = Utilities.FindElement(base.Driver, HtmlElementBy.XPath, xpath);

            if (helloMessage.Text == string.Format("Hello, {0} !", expectedUserName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
