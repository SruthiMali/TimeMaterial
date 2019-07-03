using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sruthi
{
    class Program
    {
        static void Main(string[] args)
        {

            //launching browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net");

            // validate browser url
            String CurrentUrl = driver.Url;
            Console.WriteLine(CurrentUrl);
            if (CurrentUrl == "http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f")
            {
                Console.WriteLine("Passed - Browser navigated to Turnup login page ");
            }
            else
            {
                Console.WriteLine("Failed - Browser navigated to wrong url");
            }

            //enter username
            IWebElement Username = driver.FindElement(By.Id("UserName"));
            Username.SendKeys("Hari");

            //enter password
            IWebElement Password = driver.FindElement(By.Id("Password"));
            Password.SendKeys("123123");

            //click on login button
            IWebElement Login = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            Login.Click();

            //validate the login button
            IWebElement Hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (Hellohari.Text == "Hello hari!")
            {
                Console.WriteLine("Passed - user login successfully  ");
            }
            else
            {
                Console.WriteLine("Failed - unable to logged in  ");
            }







        }
    }
}
