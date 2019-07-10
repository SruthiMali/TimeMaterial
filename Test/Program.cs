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
    class Program
    {
        static void Main(string[] args)
        {

        }

        [SetUp]
        public void Login()
        {
            //defining driver
            Commondriver.driver = new ChromeDriver();

            //defining driver wait
            CommonWait.Wait = new WebDriverWait(Commondriver.driver, new TimeSpan(0, 0, 10));

            //Login action
            Loginpage loginObj = new Loginpage();
            loginObj.Loginsteps(Commondriver.driver, CommonWait.Wait);

            //navigate to TM 
            HomePage homePageObj = new HomePage();
            homePageObj.navigateTMsteps(Commondriver.driver);
        }

        [Test]
        public void createTMsteps()
        {
            //Create TM
            TMpage TMpageObj = new TMpage();
            TMpageObj.createTMsteps(Commondriver.driver, CommonWait.Wait);
            
        }

        [Test]
        public void EditTMsteps()
        {
            //Edit TM
            TMpage TMpageObj = new TMpage();
            TMpageObj.editTMsteps(Commondriver.driver, CommonWait.Wait);
        }

        [Test]
        public void DeleteTMsteps()
        {
            //Delete TM
            TMpage TMpageObj = new TMpage();
            TMpageObj.deleteTMsteps(Commondriver.driver, CommonWait.Wait);
        }

        [TearDown]
        public void Finish()
        {
            Commondriver.driver.Quit();
        }
    }
}