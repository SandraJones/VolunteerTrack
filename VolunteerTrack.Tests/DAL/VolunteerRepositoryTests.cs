using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VolunteerTrack.Models;
using System.Collections.Generic;
using VolunteerTrack.DAL;
using System.Linq;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Activities;

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

        private List<VolunteerUser> vol_list_users { get; set; }
        private List<VolunteerActivity> activities { get; set; }
        private List<CharitableOrganization> orgs { get; set; }
        private List<ApplicationUser> app_users { get; set; }
        public int activity_Id { get; private set; }

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

            {
                new VolunteerUser {
                    VolunteerUserId = 1,
                    BaseUser = fredj
                };
                new VolunteerUser
                {
                    VolunteerUserId = 2,
                    BaseUser = susanm
                };

            };
            //mock activities created to test the methods for adding, etc. to DB
            mock_activities = new List<VolunteerActivity>
            {
                new VolunteerActivity
                {
                    mock_users = "susanm",
                    ActivityId = 3,
                    OrgName = "The Nashville Rescue Mission",
                    Date = DateTime.Now,
                    NumberHours = 8,
                    Mileage = 11,
                    DollarsContributed = 20
                    
                },
                new VolunteerActivity
                {
                    mock_users = "fredj",
                    ActivityId = 5,
                    OrgName = "Second Harvest",
                    Date = DateTime.Now,
                    NumberHours = 2,
                    Mileage = 3,
                    DollarsContributed = 25
                }
            };
        }
        public void ConnectToDatastore()
        {
            var query_appUsers = app_users.AsQueryable();
            var query_activities = activities.AsQueryable();
            var query_volUsers = vol_list_users.AsQueryable(); 

            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.Provider).Returns(query_activities.Provider);
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.Expression).Returns(query_activities.Expression);
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.ElementType).Returns(query_activities.ElementType);
            //GetEnumerator iterates thru collection reading; cannot change the underlying collection.
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.GetEnumerator()).Returns(() => query_activities.GetEnumerator());
            //mock_activities Setup
            mock_context.Setup(a => a.Activities).Returns(mock_activities.Object);
            mock_activities.Setup(u => u.Add(It.IsAny<VolunteerActivity>())).Callback((VolunteerActivity t) => activities.Add(t));
            mock_activities.Setup(r => r.Remove(It.IsAny<VolunteerActivity>())).Callback((VolunteerActivity t) => activities.Remove(t));
           
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(query_appUsers.Provider);
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(query_appUsers.Expression);
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(query_appUsers.ElementType);
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(() => query_appUsers.GetEnumerator());
        //    mock_context.Setup(c => c.Users).Returns(app_users);
            mock_app_users.Setup(u => u.Add(It.IsAny<ApplicationUser>())).Callback((ApplicationUser a) => app_users.Add(a));
            mock_app_users.Setup(u => u.Remove(It.IsAny<ApplicationUser>())).Callback((ApplicationUser a) => app_users.Remove(a));


            mock_users.As<IQueryable<VolunteerUser>>().Setup(m => m.Provider).Returns(query_volUsers.Provider);
            mock_users.As<IQueryable<VolunteerUser>>().Setup(m => m.Expression).Returns(query_volUsers.Expression);
            mock_users.As<IQueryable<VolunteerUser>>().Setup(m => m.ElementType).Returns(query_volUsers.ElementType);
            //mock_users Setup
            mock_users.As<IQueryable<VolunteerUser>>().Setup(m => m.GetEnumerator()).Returns(() => query_volUsers.GetEnumerator());
         //   mock_users.Setup( f => f.Users).Returns(mock_users.Name); // Some list to contain fake users
            mock_users.Setup(u => u.Add(It.IsAny<VolunteerUser>())).Callback((VolunteerUser v) => app_users.Add(v));
            mock_users.Setup(u => u.Remove(It.IsAny<VolunteerUser>())).Callback((VolunteerUser v) => app_users.Remove(v));

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
            Repo.RemoveActivity(a_activity.ActivityId);
            int expected_activities = 2;
            int actual_activities = Repo.Context.Activities.Count();
            //Assert
            Assert.AreEqual(expected_activities, actual_activities);
            //Assert

        }
        //Edit activity to add in mileage, hours, dollars
        [TestMethod]
        public void EnsureCanEditActivity(string UserName)
        {
            ConnectToDatastore();
            Repo.GetAllActivitiesForCurrentUser(UserName).ToList();
          
        }   
 
        [TestMethod]
        public void EnsureCanGetActivityById()
        {
            //Arrange
            ConnectToDatastore();
            //Act
            Repo.GetActivityById(activity_Id);
            //Assert
            Assert.IsNotNull(activity_Id);   
        }
        [TestMethod]
        public void EnsureCanGetAllActivitiesForCurrentUser()
        {
            //Arrange
            ConnectToDatastore();
            //Act
            Repo.Context.Activities.ToList();
            //Assert

        }
        [TestMethod]
        public void RepoEnsureUsernameExists()
        {
            // Arrange
            ConnectToDatastore();


            // Act
            bool exists = Repo.UsernameExists("susanm"); 


            // Assert 
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void EnsureCanCalculateNumberHours()
        {
            //Arrange
            var currentUser = "susanm"; //this is a mock user
            var AllActivities = Repo.GetAllActivitiesForCurrentUser(currentUser);
            //Act
            var totalHours = AllActivities.Sum(activity => activity.NumberHours);
            var actualValue = totalHours;
            var expectedValue = 10;
            //Assert
            Assert.IsTrue(expectedValue == actualValue);
        }
        
    }
}
