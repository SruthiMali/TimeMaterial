using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace sruthi.Pages
{
    class TMpage
    {
            public void createTMsteps(IWebDriver driver, WebDriverWait wait)
        {
            // Create new record
            // Click on Create New button
            IWebElement CreateNew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            CreateNew.Click();

            // enter TypeCode
            IWebElement TypeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            TypeCode.Click();

            //wait
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TypeCode_listbox']/li[1]")));

            // select Material
            IWebElement Material = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            Material.Click();

            //enter Code
            IWebElement Code = driver.FindElement(By.Id("Code"));
            Code.SendKeys("BS00VP");

            //enter Description
            IWebElement Description = driver.FindElement(By.Id("Description"));
            Description.SendKeys("The material is furniture ");

            //enter priceperunit
            IWebElement Priceperunit = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            Priceperunit.SendKeys("4000");

            // Click Save button 
            IWebElement Save = driver.FindElement(By.Id("SaveButton"));
            Save.Click();

            // Validate if clicking Save button takes user to TimeMaterial page
            Thread.Sleep(1000);

            String TimeMaterialUrl = driver.Url;

            /* if (TimeMaterialUrl == "http://horse-dev.azurewebsites.net/TimeMaterial")
            {
                Console.WriteLine("Passed - save button takes user to TimeMaterial page succesfully");
            }
            else
            {
                Console.WriteLine("Failed - save button not taken user to TimeMaterial page");
            }*/
            Assert.That(TimeMaterialUrl, Is.EqualTo("http://horse-dev.azurewebsites.net/TimeMaterial"));

            // Validate existance of new record
            // wait 
            //Thread.Sleep(1000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")));

            // Navigate to lastpage
            IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastpage.Click();

            // Verify if the last record is newly created
            IWebElement lastrecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[5]/td[1]"));

            /*if (lastrecord.Text == "BS00VP")
            {
                Console.WriteLine("Passed - user created record");
            }
            else
            {
                Console.WriteLine("Failed - record not created");
            }*/

            Assert.That(lastrecord.Text, Is.EqualTo("BS00VP"));
        }
            public void editTMsteps(IWebDriver driver, WebDriverWait wait)
            {
                // to edit 
                // Navigate to firstpage 
                IWebElement firstpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[1]/span"));
                firstpage.Click();
                Thread.Sleep(1000);

                //Click on Edit Button for first record in first page.
                IWebElement Edit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
                Edit.Click();

                // Enter code and click 
                driver.FindElement(By.XPath("//*[@id='Code']")).Clear();
                driver.FindElement(By.XPath("//*[@id='Code']")).SendKeys("hi");
                driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

                //wait 
                //Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")));

                // Validate if record had edited successfully
                /* if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text == "hi")
                {
                    Console.WriteLine("Passed - Record edited succesfully");
                }
                else
                {
                    Console.WriteLine("Failed - record is not edited");
                } */
                Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text, Is.EqualTo("hi"));
            }

        public void deleteTMsteps(IWebDriver driver, WebDriverWait wait)
        {
            // to delete record
            // count the no of rows in table
            IList<IWebElement> noOfRows = driver.FindElements(By.TagName("tr"));
            int rowscount = noOfRows.Count();


            if (rowscount > 1)
            {
                //click on delete 
                IWebElement Delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]"));
                Delete.Click();

                // Assert condition for delete alert
                Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Are you sure you want to delete this record?"));

                //click ok button on delete alert
                driver.SwitchTo().Alert().Accept();
            }
            else
            {
                Console.WriteLine("There are no records available to delete, creating a record first");
               
                //to create record
                createTMsteps(driver, wait);

                //to delete record
                deleteTMsteps(driver, wait);

            }

            // Verify if record had successfully deleted
            /*if(driver.SwitchTo().Alert().Text == "Are you sure you want to delete this record?")
             {
                 driver.SwitchTo().Alert().Accept();
                 Console.WriteLine("Passed - Record deleted successfully");
             }
             else
             {
                 driver.SwitchTo().Alert().Dismiss();
                 Console.WriteLine("Failed - unable to delete the record");
             }  
             */

        }
    }
}
