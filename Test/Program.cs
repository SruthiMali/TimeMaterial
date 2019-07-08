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
    class Program
    {
        static void Main(string[] args)
        {
            //defining driver
            Commondriver.driver = new ChromeDriver();

            //Login action
            Loginpage loginObj = new Loginpage();
            loginObj.Loginsteps(Commondriver.driver);

            //navigate to TM 
            HomePage homePageObj = new HomePage();
            homePageObj.navigateTMsteps(Commondriver.driver);

            //Create TM
            CreateTMpage TMpageObj = new CreateTMpage();
            TMpageObj.createTMsteps(Commondriver.driver);

            //Edit TM
            EditTMpage editTMpageObj = new EditTMpage();
            editTMpageObj.editTMsteps(Commondriver.driver);

            //Delete TM
            DeleteTMpage deleteTMpageObj = new DeleteTMpage();
            deleteTMpageObj.deleteTMsteps(Commondriver.driver);

        }
    }
}
