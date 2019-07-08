using OpenQA.Selenium;
using sruthi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sruthi.Pages
{
    class Loginpage
    {
        public void Loginsteps(IWebDriver driver)
        {
            //Maximize the window
            driver.Manage().Window.Maximize();

            //Navigate to Turn up login page URL
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net");

            //Get current url and store it in a variable
            String CurrentUrl = driver.Url;

            //Validate if user had navigated to Turnup login page successfully
            if (CurrentUrl == "http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f")
            {
                Console.WriteLine("Passed - Browser navigated to Turnup login page ");
            }
            else
            {
                Console.WriteLine("Failed - Browser navigated to wrong url");
            }
            
            //Enter username
            IWebElement Username = driver.FindElement(By.Id("UserName"));
            Username.SendKeys("Hari");

            //Enter password
            IWebElement Password = driver.FindElement(By.Id("Password"));
            Password.SendKeys("123123");

            //Click on login button
            IWebElement Login = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            Login.Click();

            //Validate if user had logged in successfully
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
