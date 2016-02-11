namespace GVSU.Tests
{
    using System;
    using Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Serialization;
    using FluentAssertions;

    [TestClass]
    public class TestVolunteerService : SerivceTestBase<IVolunteerService>
    {
        [TestMethod]
        public void CreateVolunteer()
        {
            var result = this.Service.CreateVolunteer(new Volunteer()
            {
                User = new User()
                {
                    ContactInfo = new ContactInfo()
                    {
                        Email = "dontusthis@gvsu.edu"
                    }
                }
            });

            result.Should().NotBeNullOrEmpty();
        }
    }
}


//repository = information storage

//irepository = layer that abstracts data storage 

//implement irepository => physically store/delete/add data


//tests directly on the irepository (running simulator in the background)
//tests directly on the service layer (pass your already tested simulator to create a new service)

//web api is tested
//go and build a ui

//test with manual testing
//build automated tests with selenium 

