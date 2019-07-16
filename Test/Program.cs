using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using sruthi.Helpers;
using sruthi.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sruthi
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class Program
    {
        IWebDriver driver;
        WebDriverWait wait;
        static void Main(string[] args)
        {

        }

        //[SetUp]
        public void Login()
        {
            /* //defining driver
            driver = new ChromeDriver();

            //defining driver wait
            CommonWait.Wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

            //Login action
            Loginpage loginObj = new Loginpage();
            loginObj.Loginsteps(driver, CommonWait.Wait);

            //navigate to TM 
            HomePage homePageObj = new HomePage();
            homePageObj.navigateTMsteps(driver); */
        }
        [SetUp]
        public void ReusableElements()
        {
            //defining driver
            driver = new ChromeDriver();

            //defining driver wait
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

            //Login action
            Loginpage loginObj = new Loginpage(driver);
            loginObj.Loginsuccessfull();

            //navigate to TM 
            HomePage homePageObj = new HomePage(driver);
            homePageObj.navigateTMsteps();
        }

        [Test]
        public void createTMsteps()
        {
            //Create TM
            TMpage TMpageObj = new TMpage(driver);
            TMpageObj.createTMsteps();
            //TMpageObj.ValidateCreateTM();
            
        }

        [Test]
        public void EditTMsteps()
        {
            //Edit TM
            TMpage TMpageObj = new TMpage(driver);
            TMpageObj.editTMsteps();
        }

        [Test]
        public void DeleteTMsteps()
        {
            //Delete TM
            TMpage TMpageObj = new TMpage(driver);
            TMpageObj.deleteTMsteps();
        }

        [TearDown]
        public void Finish()
        {
            driver.Quit();
        }
    }

    
}