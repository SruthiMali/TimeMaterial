using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sruthi.Pages
{
    class DeleteTMpage
    {
        public void deleteTMsteps(IWebDriver driver)
        {
            // to delete record
            // Click on Delete button
            IWebElement Delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[2]/td[5]/a[2]"));
            Delete.Click();

            // Verify if record had successfully deleted
           if(driver.SwitchTo().Alert().Text == "Are you sure you want to delete this record?")
            {
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine("Passed - Record deleted successfully");
            }
            else
            {
                driver.SwitchTo().Alert().Dismiss();
                Console.WriteLine("Failed - unable to delete the record");
            }  
            
        }
    }
}
