namespace GVSU.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestVolunteerService
    {
        [TestMethod]
        public void TestMethod1()
        {

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

