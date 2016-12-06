using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VolunteerTrack.Models;
using System.Collections.Generic;
using VolunteerTrack.DAL;

namespace VolunteerTrack.Tests.DAL
{
    [TestClass]
    public class VolunteerRepositoryTests
    {
        private Mock<DbSet<VolunteerUser>> mock_users { get; set; }
        private Mock<DbSet<VolunteerActivity>> mock_activities { get; set; }
        private Mock<DbSet<ApplicationUser>> mock_app_users { get; set; }
        private Mock<VolunteerContext> mock_context { get; set; }
        private VolunteerRepository Repo { get; set; }
        private List<VolunteerUser> users { get; set; }
        private List<VolunteerActivity> activities { get; set; }
        private List<CharitableOrganization> orgs { get; set; }
        private List<ApplicationUser> app_users { get; set; }

       
        [TestMethod]
        public void EnsureICanGetInstanceOfRepo()
        {
            //Arrange //Act
            VolunteerRepository repo = new VolunteerRepository();
            //Assert
            Assert.IsNotNull(repo);
        }
        [TestInitialize]
        public void Initialize()
        {

        }

        private class DbSet<T>
        {
        }
    }
}
