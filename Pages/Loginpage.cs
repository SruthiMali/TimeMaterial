using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using sruthi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sruthi 
{
    class Loginpage
    {
        IWebDriver driver;
        WebDriverWait wait;
        public Loginpage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //[FindBy(How = How.xpath, using = "dfdsf")]
        //Iwebelemnt element; 

        IWebElement Username => driver.FindElement(By.Id("UserName"));
        IWebElement Password => driver.FindElement(By.Id("Password"));
        IWebElement Login => driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
        IWebElement Hellohari => driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

        public void Loginsteps()
        {
            
            //Maximize the window
            driver.Manage().Window.Maximize();

            //Navigate to Turn up login page URL
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net");

            wait.Until(ExpectedConditions.TitleContains("Log In - Dispatching System"));

            //Get current url and store it in a variable
            String CurrentUrl = driver.Url;

            //Validate if user had navigated to Turnup login page successfully
            /* if (CurrentUrl == "http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f")
             {
                 Console.WriteLine("Passed - Browser navigated to Turnup login page ");
             }
             else
             {
                 Console.WriteLine("Failed - Browser navigated to wrong url");
             }*/
            Assert.That(CurrentUrl, Is.EqualTo("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f"));

            
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
            /*if (Hellohari.Text == "Hello hari!")
            {
                Console.WriteLine("Passed - user login successfully  ");
            }
            else
            {
                Console.WriteLine("Failed - unable to logged in  ");
            }
            */
            Assert.That(Hellohari.Text, Is.EqualTo("Hello hari!"));

        } 

        public void Loginsuccessfull()
        {
            //Maximize the browser
            driver.Manage().Window.Maximize();

            //Navigate to login page
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");

            Username.SendKeys("Hari");
            Password.SendKeys("123123");
            Login.Click();

            Assert.That(Hellohari.Text, Is.EqualTo("Hello hari!"));
        }
        public void LoginUnsuccessfull()
        {
            //Maximize the browser
            driver.Manage().Window.Maximize();

            //Navigate to login page
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");

            Username.SendKeys("Sruthi");
            Password.SendKeys("wrong password");
            Login.Click();

        }
    }
}
