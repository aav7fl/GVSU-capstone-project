using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.BusinessLogic;
using GVSU.Contracts;
using GVSU.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GVSU.Tests
{
    [TestClass]
    public class AssemblyInitializers
    {
        public static IWebDriver driverFF { get; set; }
        public static IWebDriver driverGC { get; set; }

        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            Factory.Register<IVolunteerService>(() => new VolunteerServiceSimulator());
            driverFF = new FirefoxDriver();
            driverGC = new ChromeDriver(@".\chromedriver_win32\");
        }
    }
}
