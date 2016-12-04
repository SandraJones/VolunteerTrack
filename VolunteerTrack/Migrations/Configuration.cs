namespace VolunteerTrack.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VolunteerTrack.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VolunteerTrack.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
        //    public class CharitableORganizations
        //    {       
        //        OrgName: Boys&GirlsClub,
        //        FocusName: Children,
        //        Location: url{'https://google.com/api/etcetc.??????????'}  another question, can you seed part of a DB table and seed the other part later?
        //    },
        //    {
        //        OrgName: BoyScoutsOfAmerica,
        //        FocusName: Children,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: GirlScouts,
        //        FocusName: Children,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: SafeHaven,
        //        FocusName: Women&Children,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: FriendsOfLongHunterStatePark,
        //        FocusName: Environment,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: RoomAtTheInn,
        //        FocusName: Homelessness,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: MagdaleneHouse,
        //        FocusName: Women,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: NashvilleRescueMission,
        //        FocusName: Homelessness,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: HandsOnNashville,
        //        FocusName: Environment,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: MercyMinistries,
        //        FocusName: Women,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: Boys&GirlsClub,
        //        FocusName: Children,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: OasisCenter,
        //        FocusName: Children,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: RedCross,
        //        FocusName: Emergency,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: SecondHarvestFoodBank,
        //        FocusName: Hunger,
        //        Location: url{'https://google.com/api/etcetc.'}
        //    }
    }
}

