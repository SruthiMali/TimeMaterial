using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sruthi.Pages
{
    class CreateTMpage
    {
        public void createTMsteps(IWebDriver driver)
        {
        // Create new record

         // Click on Create New button
        IWebElement CreateNew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
        CreateNew.Click();

        // enter TypeCode
        IWebElement TypeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
        TypeCode.Click();
         
        //wait
        Thread.Sleep(1000);

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

        if (TimeMaterialUrl == "http://horse-dev.azurewebsites.net/TimeMaterial")
        {
            Console.WriteLine("Passed - save button takes user to TimeMaterial page succesfully");
        }
        else
        {
            Console.WriteLine("Failed - save button not taken user to TimeMaterial page");
        }

        // Validate existance of new record
        // wait 
        Thread.Sleep(1000);

         // Navigate to lastpage
        IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
        lastpage.Click();

         // Verify if the last record is newly created
         IWebElement lastrecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[7]/td[1]"));

        if (lastrecord.Text == "BS00VP")
        {
            Console.WriteLine("Passed - user created record");
        }
        else
        {
            Console.WriteLine("Failed - record not created");
        }

    }

}
}
