using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GVSU.Tests
{
    using System;
    using Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Serialization.DTO;
    using FluentAssertions;

    [TestClass]
    public class TestVolunteerService : ServiceTestBase<IVolunteerService>
    {
        [TestMethod]
        public void CreateVolunteer()
        {
            var result = this.Service.CreateVolunteer(new Volunteer()
            {
                User = new User {
                     FirstName = "Test",
                     LastName = "Insert"
                }
            });

            result.GetType().ShouldBeEquivalentTo(typeof(int));
        }

        [TestMethod]
        public void GetVolunteer()
        {
            var actual = this.Service.GetAllVolunteers();
            actual.Should().NotBeNullOrEmpty();
        }
    }
}

