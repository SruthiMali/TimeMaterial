using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sruthi.Pages
{
    class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void navigateTMsteps()
        {
            // Click on administration dropdown
            IWebElement Administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            Administration.Click();

            // Select Time & Material from administration dropdown
            IWebElement TimeMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TimeMaterial.Click();
        }
        
            
    }
}
