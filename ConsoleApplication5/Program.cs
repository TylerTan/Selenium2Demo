using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            FirefoxOptions option = new FirefoxOptions();
            ICapabilities cap = option.ToCapabilities();
            
            FirefoxProfileManager mangage = new FirefoxProfileManager();
            FirefoxProfile profile = mangage.GetProfile(mangage.ExistingProfiles[0]);
            
            IWebDriver driver = new FirefoxDriver(profile);

            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.baidu.com/");
            IWebElement input = driver.FindElement(By.Id("kw"));
            input.SendKeys("shinetech");
            IWebElement search = driver.FindElement(By.Id("su"));
            search.Click();
            IWebElement shinetech = driver.FindElement(By.XPath("//div[@id='1']/h3/a"));
            if(shinetech!=null)
            {
                if(shinetech.Text.Contains("盛安德"))
                {
                    Console.WriteLine("Find shinetech, test passed");
                }
                else
                {
                    Console.WriteLine("Cannot find Shinetech, test case failed");
                }
            }
            else
            {
                Console.WriteLine("Cannot find Shinetech, test case failed");
            }
            shinetech.Click();
            driver.Dispose();           
        }
    }
}
