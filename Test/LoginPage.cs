using OpenQA.Selenium;

namespace sruthi
{
    internal class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}