using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sruthi.Pages
{
    class EditTMpage
    {
        public void editTMsteps(IWebDriver driver)
        {
            // to edit 
            // Navigate to firstpage 
            IWebElement firstpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[1]/span"));
            firstpage.Click();
            Thread.Sleep(1000);

            //Click on Edit Button for first record in first page
            IWebElement Edit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
            Edit.Click();

            // Enter code and click 
            driver.FindElement(By.XPath("//*[@id='Code']")).Clear();
            driver.FindElement(By.XPath("//*[@id='Code']")).SendKeys("hi");
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

            //wait 
            Thread.Sleep(2000);

            // Validate if record had edited successfully
            if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text == "hi")
            {
                Console.WriteLine("Passed - Record edited succesfully");
            }
            else
            {
                Console.WriteLine("Failed - record is not edited");
            }
        }
    }
}
