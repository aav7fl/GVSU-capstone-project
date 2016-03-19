using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;
using System.Net;

namespace GVSU.Tests
{
    [TestClass]
    public class WebsiteHomePageFF
    {

        [TestMethod]
        public void FirefoxPrintAllLinks()
        {
            AssemblyInitializers.driverFF.Navigate().GoToUrl("https://gvsuciscapstone.azurewebsites.net");

            ReadOnlyCollection<IWebElement> links = AssemblyInitializers.driverFF.FindElements(By.TagName("a"));
            foreach (IWebElement link in links)
            {
                String href = link.GetAttribute("href");
                Console.WriteLine("{0}", href);
            }
        }
        
    }
}
