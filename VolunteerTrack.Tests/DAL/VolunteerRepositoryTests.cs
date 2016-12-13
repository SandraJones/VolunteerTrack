using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VolunteerTrack.Models;
using System.Collections.Generic;
using VolunteerTrack.DAL;
using System.Linq;
using System.Data.Entity;
using System.EnterpriseServices;

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

        private List<VolunteerUser> vol_list_users { get; set; }
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
            mock_context = new Mock<VolunteerContext>();
            mock_users = new Mock<DbSet<VolunteerUser>>();
            mock_activities = new Mock<DbSet<VolunteerActivity>>();
            mock_app_users = new Mock<DbSet<ApplicationUser>>();
            Repo = new VolunteerRepository(mock_context.Object);
             
            ApplicationUser fredj = new ApplicationUser { Email = "fred@example.com", UserName = "fredj", Id = "1234567" };
            ApplicationUser susanm = new ApplicationUser { Email = "susan@example.com", UserName = "susanm", Id = "1234568" };
            //mock users created
            app_users = new List<ApplicationUser>()
            {
                fredj,
                susanm
            };

            vol_list_users = new List<VolunteerUser>
            {
                new VolunteerUser {
                    VolunteerUserId = 1,
                    BaseUser = fredj
                },
                new VolunteerUser {
                    VolunteerUserId = 2,
                    BaseUser = susanm
                }

            };
           //mock activities created to test the methods for adding, etc. to DB
            activities = new List<VolunteerActivity>
            {
                new VolunteerActivity
                {
                    ActivityId = 3,
                    OrgName = "The Nashville Rescue Mission",
                    Date = DateTime.Now,
                    NumberHours = 8,
                    Mileage = 11,
                    DollarsContributed = 20
                },
                new VolunteerActivity
                {
                    ActivityId = 5,
                    OrgName = "Second Harvest",
                    Date = DateTime.Now,
                    NumberHours = 2,
                    Mileage = 3,
                    DollarsContributed = 25
                }
            };


            /* 
             1. Install Identity into Tweeter.Tests (using statement needed)
             2. Create a mock context that uses 'UserManager' instead of 'TweeterContext'
             */

        }
        public void ConnectToDatastore()
        {
            var query_appUsers = app_users.AsQueryable();
            var query_activities = activities.AsQueryable();
           // var query_focus = mock_list_focus.AsQueryable();
           // var query_Appusers = mock_app_users.AsQueryable(); 

            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.Provider).Returns(query_activities.Provider);
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.Expression).Returns(query_activities.Expression);
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.ElementType).Returns(query_activities.ElementType);
            //GetEnumerator iterates thru collection reading; cannot change the underlying collection.
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.GetEnumerator()).Returns(() => query_activities.GetEnumerator());

            mock_context.Setup(a => a.Activities).Returns(mock_activities.Object);
            mock_activities.Setup(u => u.Add(It.IsAny<VolunteerActivity>())).Callback((VolunteerActivity t) => activities.Add(t));
            mock_activities.Setup(r => r.Remove(It.IsAny<VolunteerActivity>())).Callback((VolunteerActivity t) => activities.Remove(t));
            //mock_users.Setup( f => f.).Returns(mock_app_users.Object); // Some list to contain fake users

            /*
             * Below mocks the 'Users' getter that returns a list of ApplicationUsers
             * mock_user_manager_context.Setup(c => c.Users).Returns(mock_users.Object);
             *
             *below section may need to change the section afer Returns due to query_volusers; unsure about this part 
             */
            //mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(query_volusers.Provider);
            //mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(query_volusers.Expression);
            //mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(query_volusers.ElementType);
            //mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(() => query_volusers.GetEnumerator());
            //mock_context.Setup(c => c.Users).Returns(mock_users.Object);

            //need to mock all models 
            //mock focus
            //mock organizations
        }

        //do this feature all the way thru, test, method, and angular then go on to next
        [TestMethod]
        public void EnsureCanAddActivity()
        {
            //Arrange
            ConnectToDatastore();
            //Act
            VolunteerActivity a_activity = new VolunteerActivity
            {
                ActivityId = 1,
                OrgName = "American Red Cross",
                NumberHours = 4,
                Mileage = 14,
                DollarsContributed = 100
            };
            //int actual_activities = 0;
            Repo.AddActivity(a_activity);
            int expected_activities = 3;
            int actual_activities = Repo.Context.Activities.Count();
            //Assert
            Assert.AreEqual(expected_activities, actual_activities);
        }
        
        //in case of incomplete information or for whatever reason user wants to delete an activity
        [TestMethod]
        public void EnsureCanRemoveActivity()
        {
            //Arrange
            ConnectToDatastore();
           
            //Act
            VolunteerActivity a_activity = new VolunteerActivity
            {
                ActivityId = 1,
                OrgName = "American Red Cross",
                NumberHours = 4,
                Mileage = 14,
                DollarsContributed = 100
            };
            Repo.AddActivity(a_activity);
            Repo.RemoveActivity(a_activity);
            int expected_activities = 2;
            int actual_activities = Repo.Context.Activities.Count();
            //Assert
            Assert.AreEqual(expected_activities, actual_activities);
            //Assert

        }
        //Edit activity to add in mileage, hours, dollars
        [TestMethod]
        public void EnsureCanEditActivity()
        {

        }
        //If charity adds/removes an area of focus.
        [TestMethod]
        public void EnsureCanEditFocus()
        {

        }
        //If charity changes name.
        [TestMethod]
        public void EnsureCanEditOrganization()
        {

        }
        [TestMethod]
        public void EnsureCannotAddDuplicateActivity()
        {

        }
        [TestMethod]
        public void EnsureCanGetActivity()
        {

        }

    }
}
