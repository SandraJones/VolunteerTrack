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
            //Arrange
            
            //Act

            //Assert

        }
        public void ConnectToDatastore()
        {
            var query_volusers = users.AsQueryable();
            var query_activities = activities.AsQueryable();
            var query_focus = CharityFocus.AsQueryable();



            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.Provider).Returns(query_volusers.Provider);
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.Expression).Returns(query_volusers.Expression);
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.ElementType).Returns(query_volusers.ElementType);
            mock_activities.As<IQueryable<VolunteerActivity>>().Setup(m => m.GetEnumerator()).Returns(() => query_volusers.GetEnumerator());

            mock_context.Setup(c => c.Activities).Returns(mock_activities.Object);
            mock_users.Setup(u => u.Add(It.IsAny<ApplicationUser>())).Callback((ApplicationUser t) => users.Add(t));

            //mock_users.Setup( f => f.).Returns(mock_follow_users.Object); // Some list to contain fake users

            /*
             * Below mocks the 'Users' getter that returns a list of ApplicationUsers
             * mock_user_manager_context.Setup(c => c.Users).Returns(mock_users.Object);
             * 
             */
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(query_app_users.Provider);
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(query_app_users.Expression);
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(query_app_users.ElementType);
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(() => query_app_users.GetEnumerator());
            mock_context.Setup(c => c.Users).Returns(mock_app_users.Object);




            /* IF we just add a Username field to the Twit model
             * mock_context.Setup(c => c.TweeterUsers).Returns(mock_users.Object); Assuming mock_users is List<Twit>
             */

            mock_tweets.As<IQueryable<Tweet>>().Setup(m => m.Provider).Returns(query_tweets.Provider);
            mock_tweets.As<IQueryable<Tweet>>().Setup(m => m.Expression).Returns(query_tweets.Expression);
            mock_tweets.As<IQueryable<Tweet>>().Setup(m => m.ElementType).Returns(query_tweets.ElementType);
            mock_tweets.As<IQueryable<Tweet>>().Setup(m => m.GetEnumerator()).Returns(() => query_tweets.GetEnumerator());

            mock_context.Setup(c => c.Tweets).Returns(mock_tweets.Object);
            mock_tweets.Setup(u => u.Add(It.IsAny<Tweet>())).Callback((Tweet t) => tweets.Add(t));
            mock_tweets.Setup(u => u.Remove(It.IsAny<Tweet>())).Callback((Tweet t) => tweets.Remove(t));

            mock_follows.As<IQueryable<Follow>>().Setup(m => m.Provider).Returns(query_follows.Provider);
            mock_follows.As<IQueryable<Follow>>().Setup(m => m.Expression).Returns(query_follows.Expression);
            mock_follows.As<IQueryable<Follow>>().Setup(m => m.ElementType).Returns(query_follows.ElementType);
            mock_follows.As<IQueryable<Follow>>().Setup(m => m.GetEnumerator()).Returns(() => query_follows.GetEnumerator());

            mock_context.Setup(c => c.AllFollows).Returns(mock_follows.Object);
            mock_follows.Setup(u => u.Add(It.IsAny<Follow>())).Callback((Follow t) => follows.Add(t));
            mock_follows.Setup(u => u.Remove(It.IsAny<Follow>())).Callback((Follow t) => follows.Remove(t));


        }

    }
}
