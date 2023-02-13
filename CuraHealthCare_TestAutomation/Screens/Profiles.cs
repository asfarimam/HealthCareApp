using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuraHealthCare_TestAutomation.Screens
{
    public class Profiles : CorePage
    {
        By togglemenu = By.XPath("//a[@id='menu-toggle']");
        By profilebtn = By.XPath("//a[normalize-space()='Profile']");
        By profilemessage = By.XPath("//p[normalize-space()='Under construction.']");



        public void ProfilesTab()
        {

            //wait 
            var clicktogglemenu = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            clicktogglemenu.Until(ExpectedConditions.ElementIsVisible(togglemenu));

            driver.FindElement(togglemenu).Click();


            //wait 
            var clickprofilebbutton = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            clickprofilebbutton.Until(ExpectedConditions.ElementIsVisible(profilebtn));

            driver.FindElement(profilebtn).Click();

            //Profile message
            string profilescreenmessage = driver.FindElement(profilemessage).Text;
            Console.WriteLine("Profile: " + profilescreenmessage);
            Console.WriteLine();




        }
    }
}
