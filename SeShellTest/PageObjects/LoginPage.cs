using SeShell.Test.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeShell.Test.PageObjects
{
    public class LoginPage
    {
        /// <summary>
        /// Gets the 'ID' property of the User Name text box
        /// </summary>
        /// <returns>String</returns>
        public static String UserNameTextBox()
        {
            return LoginPageResources.UserNameTextBoxID;
        }

        /// <summary>
        /// Gets the 'ID' property of the Password text box
        /// </summary>
        /// <returns>String</returns>
        public static String PasswordTextBox()
        {
            return LoginPageResources.PasswordTextBoxID;
        }

        /// <summary>
        /// Gets the 'XPath' property of the Log In button
        /// </summary>
        /// <returns>String</returns>
        public static String LogInButton()
        {
            return LoginPageResources.LogInButtonXPath;
        }

        /// <summary>
        /// Gets the 'ID' property of the Remember Me check box
        /// </summary>
        /// <returns>String</returns>
        public static String RememberMe()
        {
            return LoginPageResources.RememberMeCheckBoxID;
        }

        /// <summary>
        /// Gets the 'ID' property of the hyperlink to register new user
        /// </summary>
        /// <returns>String</returns>
        public static String RegistHyperlink()
        {
            return LoginPageResources.RegisterLinkID;
        }
    }
}
