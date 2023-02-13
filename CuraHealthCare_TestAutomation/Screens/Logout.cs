using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CuraHealthCare_TestAutomation.Screens
{
    public class Logout : CorePage
    {
      
        By togglemenu = By.XPath("//a[@id='menu-toggle']");
        By logoutbtn = By.XPath("//a[normalize-space()='Logout']");
        By header = By.XPath("//h1[normalize-space()='CURA Healthcare Service']");
        By scrolltoup = By.XPath("//a[@id='to-top']//i");





        public void LogoutWeb()
        {
            //wait togglemenu button
            var togglemenubtnwait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            togglemenubtnwait.Until(ExpectedConditions.ElementIsVisible(togglemenu));

            driver.FindElement(togglemenu).Click();

            //wait logout button
            var logoutbtnwait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            logoutbtnwait.Until(ExpectedConditions.ElementIsVisible(logoutbtn));
            //click logout
            driver.FindElement(logoutbtn).Click();

            //print the heading
            string headeroftheapp = driver.FindElement(header).Text;
            Console.WriteLine("Logout: " + headeroftheapp);
            Console.WriteLine();
        }

    }
}
