using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GVSU.Tests
{
    [TestClass]
    public class SeleniumTestWebDriver
    {

        [TestMethod]
        public void TestFirefoxDriver()
        {
            AssemblyInitializers.driverFF.Navigate().GoToUrl("https://www.google.com/");
            AssemblyInitializers.driverFF.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            AssemblyInitializers.driverFF.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }

        [TestMethod]
        public void TestChromeDriver()
        {
            AssemblyInitializers.driverGC.Navigate().GoToUrl("https://www.google.com/");
            AssemblyInitializers.driverGC.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            AssemblyInitializers.driverGC.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }

    }
}
