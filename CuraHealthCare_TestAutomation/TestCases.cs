using CuraHealthCare_TestAutomation.Screens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;


namespace CuraHealthCare_TestAutomation
{
    [TestClass]
    public class TestCases : CorePage
    {


        #region Setups and Cleanups
        public TestContext instance;

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        //Before every class
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {


        }

        //The TestInitialize attribute is needed when we want to run a function before executing a test.
        [TestInitialize]
        public void TestInit()
        {
            //The driver should always be called in the Test Initialize method
            CorePage.SeleniumInit();
        }

        //The TestCleanup will run after every test execution.
        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
        }

        #endregion





        Login login = new Login();
        MakeAppointment appointment = new MakeAppointment();
        Logout logout = new Logout();
        History history = new History();
        Profiles profiles = new Profiles();



        [TestMethod]
        
        public void TC01LogintoWebsite()
        {
            login.LoginWithUser("https://katalon-demo-cura.herokuapp.com/", "John Doe1", "ThisIsNotAPassword");
            appointment.AppointmentForm();
            history.HistoryScreen();
            profiles.ProfilesTab();
            logout.LogoutWeb();
        }

        //DATA DRIVEN 
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginTestCase", DataAccessMethod.Sequential)]
        public void TC02LogintoWebsite()
        {
            string enterUN = TestContext.DataRow["enterUsername"].ToString();
            string enterPW = TestContext.DataRow["enterPassword"].ToString();


            login.LoginWithUser("https://katalon-demo-cura.herokuapp.com/", enterUN, enterPW);
            appointment.AppointmentForm();
            history.HistoryScreen();
            profiles.ProfilesTab();
            logout.LogoutWeb();

        }



    }
}
