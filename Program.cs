using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


             // administration dropdown

             IWebElement Administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
             Administration.Click();

             IWebElement TimeMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
             TimeMaterial.Click(); 

            
            // create new record
            IWebElement CreateNew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            CreateNew.Click();

            IWebElement TypeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            TypeCode.Click();

            Thread.Sleep(1000);

            IWebElement Material = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            Material.Click();

            IWebElement Code = driver.FindElement(By.Id("Code"));
            Code.SendKeys("BS00VP");

            IWebElement Description = driver.FindElement(By.Id("Description"));
            Description.SendKeys("The material is furniture ");

            IWebElement Priceperunit = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            Priceperunit.SendKeys("4000");

            // Save button 
            IWebElement Save = driver.FindElement(By.Id("SaveButton"));
            Save.Click();

            // validate save button by verifying Url
            Thread.Sleep(1000);
            String TimeMaterialUrl = driver.Url;

            if (TimeMaterialUrl == "http://horse-dev.azurewebsites.net/TimeMaterial")
            {
                Console.WriteLine("Passed - record saved succesfully");
            }
            else
            {
                Console.WriteLine("Failed - record not saved ");
            }


            // validate create new record
            Thread.Sleep(1000);
            IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastpage.Click();

            IWebElement lastrecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
            if (lastrecord.Text == "BS00VP")
            {
                Console.WriteLine("Passed - Record saved succesfully ");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            // Goto firstpage 
            IWebElement firstpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[1]/span"));
            firstpage.Click();
            Thread.Sleep(1000);

            //clicking  Edit Button for first record
            IWebElement Edit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
            Edit.Click();

            // enter code and click 
            driver.FindElement(By.XPath("//*[@id='Code']")).Clear();
            driver.FindElement(By.XPath("//*[@id='Code']")).SendKeys("sruthi");
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

            // validate edit
            Thread.Sleep(1000);
            if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text == "sruthi")
            {
                Console.WriteLine("Passed - Record edited succesfully");
            }
            else
            {
                Console.WriteLine("Failed - recors is not edited");
            }






        }
    }
}
