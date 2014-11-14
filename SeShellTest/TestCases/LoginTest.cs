using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeShell.Test.Core;
using SeShell.Test.TestData.Data;
using SeShell.Test.Flows;

namespace SeShell.Test.TestCases
{
    public class LoginTest : AbstractTest
    {
        [Test]
        public void TestSuccessfulLogin()
        {
            string currentExecutingMethod = Utilities.GetCurrentMethod();
            var resultsWriter = 
                new ResultsWriter(Constants.ParameterizedTest, currentExecutingMethod, true);
            List<LoginData> loginTestData = LoginData.GetLoginData();

            Parallel.ForEach(base.WebDrivers, (driver, loopState) =>
            {
                TestCaseAsserts asserts = new TestCaseAsserts();
                string currentWebBrowserString = Utilities.GetWebBrowser(driver);

                foreach(LoginData data in loginTestData)
                {
                    ResultReport testResultReport = new ResultReport();

                    string testFixtureName = 
                        Utilities.GenerateTestFixtureName(this.GetType(), currentExecutingMethod,
                    currentWebBrowserString);
                    testResultReport.StartMethodTimerAndInitiateCurrentTestCase(testFixtureName, true);

                    try
                    {

                        LoginPageFlow pageFlow = new LoginPageFlow(driver);
                        bool assertionFlag;

                        pageFlow.LogIn(data.UserName, data.Password, data.RememberMe);
                        assertionFlag = pageFlow.IsUserLoggedIn(data.ExpectedResult);
                        asserts.AddBooleanAssert(
                            new Action<bool, string>(Assert.IsTrue),
                            pageFlow.Driver.PageSource.Contains(data.ExpectedResult),
                            Utilities.CombineTestOutcomeString(Constants.SuccessfulUserLogin, data.UserName));
                        testResultReport.SetCurrentTestCaseOutcome(true, asserts.AssertionCount.ToString());
                    }
                    catch (Exception ex)
                    {
                        ScreenShotImage.CaptureScreenShot(driver, Utilities.CombineTestOutcomeString(Constants.ScreenshotError, data.UserName));
                        testResultReport.SetCurrentTestCaseOutcome(false, asserts.AssertionCount.ToString(), ex.Message, ex.StackTrace);
                        Assert.Fail(ex.Message);
                    }
                    finally
                    {
                        testResultReport.StopMethodTimerAndFinishCurrentTestCase();
                        base.TestCases.Add(testResultReport.currentTestCase);
                    }
                }
            });

            resultsWriter.WriteResultsToFile(this.GetType().Name, TestCases);
        }
    }
}
