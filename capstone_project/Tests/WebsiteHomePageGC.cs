using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;

namespace GVSU.Tests
{
    [TestClass]
    public class WebsiteHomePageGC
    {

        [TestMethod]
        public void GoogleChromePrintAllLinks()
        {
            AssemblyInitializers.driverGC.Navigate().GoToUrl("https://gvsuciscapstone.azurewebsites.net");

            ReadOnlyCollection<IWebElement> links = AssemblyInitializers.driverGC.FindElements(By.TagName("a"));
            foreach (IWebElement link in links)
            {
                String href = link.GetAttribute("href");
                Console.WriteLine("{0}", href);
            }
        }

    }
}
