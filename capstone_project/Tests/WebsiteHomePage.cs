using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GVSU.Tests
{
    [TestClass]
    public class WebsiteHomePage
    {
        List<IWebDriver> drivers = AssemblyInitializers.drivers;

        [TestMethod] 
        [TestCategory("Selenium")]
        public void VerifyHomeLinks()
        {
            Parallel.ForEach(drivers, driverName =>
            {
                driverName.Navigate().GoToUrl(AssemblyInitializers.WebsiteAddress);
                driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                ReadOnlyCollection<IWebElement> links = driverName.FindElements(By.TagName("a"));

                string href = "";

                foreach (IWebElement link in links)
                {
                    href += link.GetAttribute("href") + "\n";
                }

                Console.WriteLine("{0}", href);

                href.Should().NotContain("Supercalifragilisticexpialidocious");

                href.Should().Contain("/About");
                href.Should().Contain("/Contact");
                href.Should().Contain("/Volunteer");
                href.Should().Contain("/Charity");
                href.Should().Contain("/Account/Register");
                href.Should().Contain("/Account/Login");
            });

        }
        
        [TestMethod]
        [TestCategory("Selenium")]
        public void TestMenuNavigation()
        {
            //TODO Add Volunteer once firstnam/lastname fixed.
            var navigationLinks = new List<string> { "Home", "About", "Contact", "Charity", "Register", "Log in" };

            Parallel.ForEach(drivers, driverName =>
            {
                driverName.Navigate().GoToUrl(AssemblyInitializers.WebsiteAddress);

                IWebElement link;

                foreach (string linkName in navigationLinks)
                {
                    link = driverName.FindElement(By.LinkText(linkName));
                    link.Click();
                    driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                }
            });
        }
    }
}
