using SeShell.Test.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeShell.Test.TestData.Data
{
    public class LoginData : AbstractTestData
    {
        public String UserName { get; set; }

        public String Password { get; set; }

        public bool RememberMe { get; set; }

        public String ExpectedResult { get; set; }

        public static List<LoginData> GetLoginData()
        {
            List<LoginData> loginDataList = new List<LoginData>();

            using (FileStream inputStream = new FileStream(
                Configuration.TestDataFilePath + @"\LoginTestData.csv", 
                FileMode.Open, 
                FileAccess.Read))
            {
                string inputLine;
                StreamReader reader = new StreamReader(inputStream);

                while (!string.IsNullOrEmpty(inputLine = reader.ReadLine()))
                {
                    string[] data = inputLine.Split(',');
                    bool rememberMe = false;

                    switch (data[2].ToString().Trim())
                    {
                        case "0":
                            rememberMe = false;
                            break;
                        case "1":
                            rememberMe = true;
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    loginDataList.Add(new LoginData()
                        {
                            UserName = data[0].ToString().Trim(),
                            Password = data[1].ToString().Trim(),
                            RememberMe = rememberMe,
                            ExpectedResult = data[3].ToString().Trim()
                        });
                }

                reader.Close();
            }

            return loginDataList;
        }

        public override string[] GetClassPropertiesAsArray()
        {
            throw new NotImplementedException();
        }
    }
}
