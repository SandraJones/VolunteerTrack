using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VolunteerTrack.Models;
using System.Collections.Generic;
using VolunteerTrack.DAL;
using System.Linq;
using System.Data.Entity;

namespace VolunteerTrack.Tests.DAL
{
    [TestClass]
    public class VolunteerRepositoryTests
    {
        private Mock<DbSet<VolunteerUser>> mock_users { get; set; }
        private Mock<DbSet<VolunteerActivity>> mock_activities { get; set; }
        private Mock<DbSet<ApplicationUser>> mock_app_users { get; set; }
        private Mock<VolunteerContext> mock_context { get; set; }
        private Mock<CharityFocus> mock_focus { get; set; }
        private VolunteerRepository Repo { get; set; }

       // private List<VolunteerUser> mock_users { get; set; }
        private List<VolunteerActivity> activities { get; set; }
        private List<CharitableOrganization> orgs { get; set; }
        private List<ApplicationUser> app_users { get; set; }
        private List<CharityFocus> mock_list_focus { get; set; }
            

       
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
            //Arrange
            
            //Act

            //Assert

        }
        public void ConnectToDatastore()
        {
            var query_volusers = app_users.AsQueryable();
            var query_activities = activities.AsQueryable();
            var query_focus = mock_list_focus.AsQueryable();
            var query_Applusers = mock_app_users.AsQueryable(); 

            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.Provider).Returns(query_volusers.Provider);
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.Expression).Returns(query_volusers.Expression);
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.ElementType).Returns(query_volusers.ElementType);
            //GetEnumerator iterates thru collection reading; cannot change the underlying collection.
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.GetEnumerator()).Returns(() => query_activities.GetEnumerator());

            mock_context.Setup(c => c.Activities).Returns(mock_activities.Object);
            mock_app_users.Setup(u => u.Add(It.IsAny<ApplicationUser>())).Callback((ApplicationUser t) => query_volusers.Add(t));

            //mock_users.Setup( f => f.).Returns(mock_follow_users.Object); // Some list to contain fake users

            /*
             * Below mocks the 'Users' getter that returns a list of ApplicationUsers
             * mock_user_manager_context.Setup(c => c.Users).Returns(mock_users.Object);
             *
             *below section may need to change the section afer Returns due to query_volusers; unsure about this part 
             */
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(query_volusers.Provider);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(query_volusers.Expression);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(query_volusers.ElementType);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(() => query_volusers.GetEnumerator());
            mock_context.Setup(c => c.Users).Returns(mock_users.Object);  
         }

    }
}
