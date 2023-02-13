using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace CuraHealthCare_TestAutomation.Screens
{
    public class Login : CorePage
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        By header = By.XPath("//h1[normalize-space()='CURA Healthcare Service']");
        By togglemenu = By.XPath("//a[@id='menu-toggle']");
        By loginbtn = By.XPath("//a[normalize-space()='Login']");
        By username = By.XPath("//input[@id='txt-username']");
        By password = By.XPath("//input[@id='txt-password']");
        By clickloginbtn = By.XPath("//button[@id='btn-login']");
        By makeappoitmentbtn = By.XPath("//a[@id='btn-make-appointment']");
        By makeappoitmentheading = By.XPath("//h2[normalize-space()='Make Appointment']");
        By unsuccessloggedinmessage = By.XPath("//p[contains(text(),'Login failed! Please ensure the username and passw')]");



        public void LoginWithUser(string url, string enterusername, string enterpassword)
        {
            try
            {
                IJavaScriptExecutor scroll = (IJavaScriptExecutor)driver;
                //Action Actions = new Action(driver);

                //maximize the window
                driver.Manage().Window.Maximize();


                //open application
                driver.Url = url;
                log.Info("url is : " + url);
                //wait screen visible
                var waittoloadpage = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                waittoloadpage.Until(ExpectedConditions.ElementIsVisible(makeappoitmentbtn));

                //print the url
                //  Console.WriteLine("URL of the application:" + " " + url);
                // Console.WriteLine();
                //print the title
                string title = driver.Title;
                log.Info("Title of Page is : " + title);
                //  Console.WriteLine("Title of the page:" + " " + title);
                //Console.WriteLine();

                //print the heading
                string headeroftheapp = driver.FindElement(header).Text;
                log.Info("Header of App is : " + headeroftheapp);
                //  Console.WriteLine("Heading: " + headeroftheapp);
                //  Console.WriteLine();

                //Login to the website
                driver.FindElement(togglemenu).Click();
                log.Info("Click on Toggle Menu  ");
                //wait 
                var loginbuttonwait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                loginbuttonwait.Until(ExpectedConditions.ElementIsVisible(loginbtn));

                driver.FindElement(loginbtn).Click();
                log.Info("Click on Login Button from ToggleMenu  ");

                //wait 
                var usernamevisible = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                usernamevisible.Until(ExpectedConditions.ElementIsVisible(username));

                //Enter username and password
                
                driver.FindElement(username).SendKeys(enterusername);
                log.Info("Entering Username  " + enterusername);
                driver.FindElement(password).SendKeys(enterpassword);
                log.Info("Entering Username  " + enterpassword);

                //wait 
                var waittoclickloginbutton = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                waittoclickloginbutton.Until(ExpectedConditions.ElementIsVisible(clickloginbtn));

                //click login button
                driver.FindElement(clickloginbtn).Click();
                log.Info("Click On Login Button  " );

                //wait 
                var waitafterloggedin = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                waitafterloggedin.Until(ExpectedConditions.ElementIsVisible(makeappoitmentheading));
                Thread.Sleep(6000);
                //taking screenshot
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"D:\Testpass.png", ScreenshotImageFormat.Png);

            }
            catch (Exception ex)
            {
                Thread.Sleep(5000);
                //taking screenshot
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"D:\Testfail.png", ScreenshotImageFormat.Png);
                log.Error("Login Failed " + ex);
                driver.Quit();
            }
        }
    }
}
