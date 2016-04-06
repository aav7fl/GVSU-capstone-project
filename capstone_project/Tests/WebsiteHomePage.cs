using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;
using FluentAssertions;
using System.Collections.Generic;

namespace GVSU.Tests
{
    [TestClass]
    public class WebsiteHomePage
    {
        List<IWebDriver> drivers = AssemblyInitializers.drivers;

        [TestMethod]
        public void VerifyHomeLinks()
        {

            foreach (IWebDriver driverName in drivers)
            {
                driverName.Navigate().GoToUrl(AssemblyInitializers.projectUrl);

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
            }

           
        }

        [TestMethod]
        public void TestMenuNavigation()
        {
            foreach (IWebDriver driverName in drivers)
            {
                driverName.Navigate().GoToUrl(AssemblyInitializers.projectUrl);

                IWebElement link;

                //TODO Add Volunteer once firstnam/lastname fixed.
                var navigationLinks = new List<string> { "Home", "About", "Contact", "Charity", "Register", "Log in" };

                foreach (string linkName in navigationLinks)
                {
                    link = driverName.FindElement(By.LinkText(linkName));
                    link.Click();
                    driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                }
            }
        }

    }
}
