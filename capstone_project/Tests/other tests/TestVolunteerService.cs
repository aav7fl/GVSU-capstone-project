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
        public void CreateEmptyVolunteer()
        {
            var result = this.Service.CreateVolunteer(new Volunteer()
            {
            });

            result.GetType().ShouldBeEquivalentTo(typeof(int));
        }

        [TestMethod]
        public void CreateVolunteerWithBadId()
        {
            var result = this.Service.CreateVolunteer(new Volunteer()
            {
                Id = 200011
            });
        }

        [TestMethod]
        public void GetVolunteer()
        {
            var actual = this.Service.GetAllVolunteers();
            actual.Should().NotBeNullOrEmpty();
        }
    }
}

