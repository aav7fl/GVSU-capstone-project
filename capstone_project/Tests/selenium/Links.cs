using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Tests.selenium
{
    [TestClass]
    public class Links
    {

        List<IWebDriver> drivers = AssemblyInitializers.drivers;


        [TestMethod]
        [TestCategory("Selenium")]
        //Verify that the correct links exist for the homepage header
        public void VerifyHomePageLinks()
        {
            Parallel.ForEach(drivers, driverName =>
            {
                //go to Website homepage
                driverName.Navigate().GoToUrl(AssemblyInitializers.WebsiteAddress);
                //Set a simple 10 second page timeout
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
            

            Parallel.ForEach(drivers, driverName =>
            {
                driverName.Navigate().GoToUrl(AssemblyInitializers.WebsiteAddress);
                List<string> navigationLinks = GetHeaderLinks(driverName);
                Console.WriteLine("Nav Links: {0}", navigationLinks);
                foreach (string linkName in navigationLinks)
                {
                    Console.WriteLine("LinkName: {0}", linkName);
                    driverName.Navigate().GoToUrl(linkName);
                    driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                }                
            });
        }

        [TestMethod]
        [TestCategory("Selenium")]
        //Test each webpage listed in the website header for dead links.
        public void TestForDeadLinks()
        {
            //Iterate through each web driver (currently Google Chrome and Firefox)
            Parallel.ForEach(drivers, driverName =>
            {
                driverName.Navigate().GoToUrl(AssemblyInitializers.WebsiteAddress);

                List<string> navigationLinks = GetHeaderLinks(driverName);

                //Iterate through each link from the website header
                foreach (string headerLink in navigationLinks)
                {
                    driverName.Navigate().GoToUrl(headerLink);
                    
                    ReadOnlyCollection<IWebElement> links = driverName.FindElements(By.TagName("a"));
                    
                    Parallel.ForEach(links, link =>
                    {
                        String href = link.GetAttribute("href");
                        //Ignore Empty, JavaScript, and mailto Responses
                        if (href != null && !href.Contains("javascript") && !href.Contains("mailto"))
                        {
                            Console.WriteLine("Header Links: {0}", href);
                            HttpStatusCode returnedvalue = getHttpStatusCode(href);
                            returnedvalue.Should().Be(HttpStatusCode.OK);
                        }
                    });
                }

            });
        }

        [TestMethod]
        [TestCategory("Selenium")]
        //Test each webpage listed in the website header for dead links.
        public void TestForDeadImages()
        {
            //Iterate through each web driver (currently Google Chrome and Firefox)
            Parallel.ForEach(drivers, driverName =>
            {
                driverName.Navigate().GoToUrl(AssemblyInitializers.WebsiteAddress);

                List<string> navigationLinks = GetHeaderLinks(driverName);
                //Iterate through each link from the website header
                foreach (string headerLink in navigationLinks)
                {
                    ReadOnlyCollection<IWebElement> images = null; 
                    driverName.Navigate().GoToUrl(headerLink);
                    try
                    {
                        images = driverName.FindElements(By.TagName("img"));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: '{0}'", e);
                    }

                    Parallel.ForEach(images, imageLink =>
                    {
                        String href = imageLink.GetAttribute("src");
                        //Ignore Empty, JavaScript, and mailto Responses
                        if (href != null && !href.Contains("javascript"))
                        {
                            HttpStatusCode returnedvalue = getHttpStatusCode(href);
                            try
                            {
                                returnedvalue.Should().Be(HttpStatusCode.OK);
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                        }
                    });
                }

            });
        }

        //Helper method to test HTTP status code from a given URL. Return result as HttpStatusCode.
        private static HttpStatusCode getHttpStatusCode(string href)
        {
            var result = default(HttpStatusCode);
            var request = WebRequest.Create(href);
            request.Method = "HEAD";
            HttpWebResponse response;

            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException)
            {
                return HttpStatusCode.NotFound;
            }

            if (response != null)
            {
                result = response.StatusCode;
                response.Close();
                response.Dispose();
            }

            return result;
        }

        //Helper method to dynamically pull a list<string> of the links contained within the website header
        private List<string> GetHeaderLinks(IWebDriver driverName)
        {
            
            List<string> linkString = new List<string>();

            ReadOnlyCollection<IWebElement> links = driverName.FindElement(By.Name("nav-links")).FindElements(By.TagName("a"));
            Console.Write("Links:{0}",links);
            foreach (IWebElement linkName in links)
            {
                linkString.Add(linkName.GetAttribute("href"));
            }

            return linkString;
        }
    }
}