using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GVSU.Tests.selenium
{
    [TestClass]
    public class Register
    {
        List<IWebDriver> drivers = AssemblyInitializers.drivers;
        string RegistrationUrl = AssemblyInitializers.WebsiteAddress + "/Account/Register";

        [TestMethod]
        [TestCategory("Selenium")]
        public void VerifyRegistrationRequiredFields()
        {
            Parallel.ForEach(drivers, driverName =>
            {
                //go to Website Login page. Must assume relative link is correct
                driverName.Navigate().GoToUrl(RegistrationUrl);
                //Set a simple 10 second page timeout
                driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                //Empty form
                driverName.FindElement(By.XPath("//input[@value='Register']")).Click();

                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The First Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Last Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Email field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Password field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Zip Code field is required.");
            });
        }

        [TestMethod]
        [TestCategory("Selenium")]
        public void VerifyRegistrationInvalidEmail()
        {
            Parallel.ForEach(drivers, driverName =>
            {
                //go to Website Login page. Must assume relative link is correct
                driverName.Navigate().GoToUrl(RegistrationUrl);
                //Set a simple 10 second page timeout
                driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                driverName.FindElement(By.Id("Email")).SendKeys("ThisIsNotAnEmail");
                driverName.FindElement(By.XPath("//input[@value='Register']")).Click();

                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The First Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Last Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Email field is not a valid e-mail address.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Password field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Zip Code field is required.");
            });
        }

        [TestMethod]
        [TestCategory("Selenium")]
        public void VerifyRegistrationPasswordTooShort()
        {
            Parallel.ForEach(drivers, driverName =>
            {
                //go to Website Login page. Must assume relative link is correct
                driverName.Navigate().GoToUrl(RegistrationUrl);
                //Set a simple 10 second page timeout
                driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                //Empty form
                driverName.FindElement(By.Id("Password")).SendKeys("pass");
                driverName.FindElement(By.Id("ConfirmPassword")).SendKeys("pass");
                driverName.FindElement(By.XPath("//input[@value='Register']")).Click();

                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The First Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Last Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Email field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Password must be at least 6 characters long.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Zip Code field is required.");
            });
        }

        [TestMethod]
        [TestCategory("Selenium")]
        public void VerifyRegistrationMismatchingPasswordConfirmation()
        {
            Parallel.ForEach(drivers, driverName =>
            {
                //go to Website Login page. Must assume relative link is correct
                driverName.Navigate().GoToUrl(RegistrationUrl);
                //Set a simple 10 second page timeout
                driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                //Empty form
                driverName.FindElement(By.Id("Password")).SendKeys("pass");
                driverName.FindElement(By.Id("ConfirmPassword")).SendKeys("passWrong");
                driverName.FindElement(By.XPath("//input[@value='Register']")).Click();

                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The First Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Last Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Email field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The password and confirmation password do not match.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Zip Code field is required.");
            });
        }

        [TestMethod]
        [TestCategory("Selenium")]
        public void VerifyRegistrationZipCodeMustBeNumber()
        {
            Parallel.ForEach(drivers, driverName =>
            {
                //go to Website Login page. Must assume relative link is correct
                driverName.Navigate().GoToUrl(RegistrationUrl);
                //Set a simple 10 second page timeout
                driverName.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                //Empty form
                driverName.FindElement(By.Id("ZipCode")).SendKeys("NaN");
                driverName.FindElement(By.XPath("//input[@value='Register']")).Click();


                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The First Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Last Name field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Email field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The Password field is required.");
                driverName.FindElement(By.ClassName("validation-summary-errors")).Text.Should().ContainEquivalentOf("The field Zip Code must be a number.");
            });
        }
    }
}
