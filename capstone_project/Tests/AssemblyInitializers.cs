using System.Collections.Generic;
using GVSU.BusinessLogic;
using GVSU.Contracts;
using GVSU.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using GVSU.Tests.selenium;

namespace GVSU.Tests
{

    [TestClass]
    public class AssemblyInitializers
    {
        public static IWebDriver driverFF { get; set; }
        public static IWebDriver driverGC { get; set; }
        public static List<IWebDriver> drivers = new List<IWebDriver>();

        public static string WebsiteAddress
        {
            get
            {
                var url = "";
#if DEBUG
                url = ConfigurationManager.AppSettings["LocalUrl"];
#else
                url = ConfigurationManager.AppSettings["RemoteUrl"];
#endif
                return url;
            }
        }

        [AssemblyInitialize]
        public static void Init(TestContext context)
        {

            Factory.Register<IVolunteerService>(() => new VolunteerServiceSimulator());

#if DEBUG
            //Start IIS serverFor hosting local project
            WebServer.StartIis();

            driverFF = new FirefoxDriver();
            driverGC = new ChromeDriver(@".\chromedriver_win32\");

            //Add drivers to the list to be used in a for-each method for browser testing.
            drivers.Add(driverFF);
            drivers.Add(driverGC);
#endif
        }


        [AssemblyCleanup]
        public static void TearDown()
        {
#if DEBUG
            driverFF.Quit(); //exit Firefox selenium driver at the end of the test
            driverGC.Quit(); //exit Google Chrome selenium driver at the end of the test

            WebServer.StopIis();
#endif
        }
    }
}