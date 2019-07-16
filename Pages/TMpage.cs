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
        IWebDriver driver;
        WebDriverWait wait;
        public TMpage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement CreateNew => driver.FindElement(By.XPath("//*[@id='container']/p/a"));
        IWebElement TypeCode => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
        IWebElement Material => driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
        IWebElement Code => driver.FindElement(By.Id("Code"));
        IWebElement Description => driver.FindElement(By.Id("Description"));
        IWebElement Priceperunit => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
        IWebElement Save => driver.FindElement(By.Id("SaveButton"));

        public void createTMsteps()
        {    
            // Create new record
            // Click on Create New button
            CreateNew.Click();

            // Select TypeCode
            TypeCode.Click();

            //wait
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TypeCode_listbox']/li[1]")));
            Thread.Sleep(2000);

            // select Material
            Material.Click();

            //enter Code
            Code.SendKeys("BS00VP");

            //enter Description
            Description.SendKeys("The material is furniture ");

            //enter priceperunit
            Priceperunit.SendKeys("4000");

            // Click Save button 
            Save.Click();

            // Validate if clicking Save button takes user to TimeMaterial page
            Thread.Sleep(1000);

            String TimeMaterialUrl = driver.Url;

            Assert.That(TimeMaterialUrl, Is.EqualTo("http://horse-dev.azurewebsites.net/TimeMaterial"));

            /*if (TimeMaterialUrl == "http://horse-dev.azurewebsites.net/TimeMaterial")
            {
                Console.WriteLine("Passed - save button takes user to TimeMaterial page succesfully");
            }
            else
            {
                Console.WriteLine("Failed - save button not taken user to TimeMaterial page");
            }*/

        }

        internal void ValidateCreateTM()
        {
            Thread.Sleep(3000);
            try
            {
                while (true)
                {
                    for (var i = 1; i <= 10; i++)
                    {
                        var rowText = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
                        if (rowText == "Test1234")
                        {
                            Console.WriteLine("Passed - Record created successfully");
                            return;
                        }
                    }
                    
                    driver.FindElement(By.XPath("//a[@title='Go to the next page']")).Click();
                }

            }
            catch(Exception)
            {
                Console.WriteLine("Failed - Record not created");
            }


        }

        public void editTMsteps()
            {
            // to edit
                Thread.Sleep(2000);
                //Click on Edit Button for first record in first page.
                IWebElement Edit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
                Edit.Click();

                // Enter code and click 
                Code.Clear();
                Code.SendKeys("hi");
                Code.Click();

                Save.Click();

                //wait 
                Thread.Sleep(2000);
                Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text, Is.EqualTo("hi"));

            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")));

            // Validate if record had edited successfully
            /* if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text == "hi")
            {
                Console.WriteLine("Passed - Record edited succesfully");
            }
            else
            {
                Console.WriteLine("Failed - record is not edited");
            } */

        }

        public void deleteTMsteps()
        {
            // to delete record
            // count the no of rows in table
            IList<IWebElement> noOfRows = driver.FindElements(By.TagName("tr"));
            int rowscount = noOfRows.Count();
            
            if (rowscount >= 1)
            {
                Thread.Sleep(2000);

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
                createTMsteps();

                //to delete record
                deleteTMsteps();

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
