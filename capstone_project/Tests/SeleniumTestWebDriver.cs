using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace GVSU.Tests
{
    [TestClass]
    public class SeleniumTestWebDriver
    {
        List<IWebDriver> drivers = AssemblyInitializers.drivers;

        [TestMethod]
        public void TestWebDrivers()
        {
            foreach (IWebDriver driverName in drivers)
            {
                driverName.Navigate().GoToUrl("https://www.google.com/");
                driverName.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
                driverName.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
            }
        }

    }
}
