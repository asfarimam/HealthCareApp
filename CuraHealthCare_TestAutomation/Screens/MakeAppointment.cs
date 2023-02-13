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
    public class MakeAppointment : CorePage
    {
        By makeappointmentheader = By.XPath("//h2[normalize-space()='Make Appointment']");
        By clickfacility = By.XPath("//select[@id='combo_facility']");
        By selectfacilityvalue = By.XPath("//option[@value='Hongkong CURA Healthcare Center']");
        By selecthealthprogram = By.XPath("//input[@id='radio_program_none']");
        By clickdate = By.XPath("//input[@id='txt_visit_date']");
        By selectdate = By.XPath("//tbody/tr[6]/td[2]");
        By addcoments = By.XPath("//textarea[@id='txt_comment']");
        By clickbookappointment = By.XPath("//button[@id='btn-book-appointment']");
        By confirmationmessage = By.XPath("//h2[contains(text(),'Appointment Confirmation')]");



        public void AppointmentForm()
        {
            //print the make appointment heading
            string appointmentheading = driver.FindElement(makeappointmentheader).Text;
            Console.WriteLine("Heading: " + appointmentheading);
            Console.WriteLine();

            //Fill appointment 
            driver.FindElement(clickfacility).Click();
            driver.FindElement(selectfacilityvalue).Click();
            driver.FindElement(selecthealthprogram).Click();
            driver.FindElement(clickdate).Click();
            driver.FindElement(selectdate).Click();
            driver.FindElement(addcoments).Click();
            driver.FindElement(addcoments).SendKeys("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");


            //wait 
            var clickbookingappoitment = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            clickbookingappoitment.Until(ExpectedConditions.ElementIsVisible(clickbookappointment));

            driver.FindElement(clickbookappointment).Click();

            //Confirnmation Message
            string appointmentconfirmationmessage = driver.FindElement(confirmationmessage).Text;
            Console.WriteLine("Confirmation Message: " + appointmentconfirmationmessage);
            Console.WriteLine();
        }
    }
}
