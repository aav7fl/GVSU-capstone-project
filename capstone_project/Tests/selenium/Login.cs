using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GVSU.Tests.selenium
{
    [TestClass]
    public class Login
    {
        List<IWebDriver> drivers = AssemblyInitializers.drivers;

        [TestMethod]
        [TestCategory("Selenium")]
        //
        public void VerifyBadLoginAttempt()
        {
            Parallel.ForEach(drivers, driverName =>
            {
                //go to Website Login page. Must assume relative link is correct
                driverName.Navigate().GoToUrl(AssemblyInitializers.WebsiteAddress + "/Account/Login");
                //Set a simple 10 second page timeout
                driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                driverName.FindElement(By.Id("RememberMe")).Click();
                driverName.FindElement(By.Id("Email")).SendKeys("admin@example.org");
                driverName.FindElement(By.Id("Password")).SendKeys("password");
                driverName.FindElement(By.Id("Password")).Submit();

                driverName.PageSource.Should().Contain("Invalid login attempt.");
            });

        }
    }
}
