using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;

namespace GVSU.Tests
{
    [TestClass]
    public class VerifyWebDriver
    {
        List<IWebDriver> drivers = AssemblyInitializers.drivers;

        [TestMethod]
        [TestCategory("Selenium")]
        public void TestWebDrivers()
        {
            Parallel.ForEach(drivers, driverName =>
            {
                driverName.Manage().Window.Maximize();
                driverName.Navigate().GoToUrl("https://www.python.org/");
                driverName.FindElement(By.Name("q")).SendKeys("pycon");
                driverName.FindElement(By.Name("q")).Submit();
                driverName.PageSource.Should().NotContain("No results found.");
            });
        }

    }
}
