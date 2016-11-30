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
        public class CharitableORganizations
        {       
            OrgName: Boys&GirlsClub,
            Focus: Children,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: BoyScoutsOfAmerica,
            Focus: Children,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: GirlScouts,
            Focus: Children,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: SafeHaven,
            Focus: Women&Children,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: FriendsOfLongHunterStatePark,
            Focus: Environment,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: RoomAtTheInn,
            Focus: Homelessness,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: MagdaleneHouse,
            Focus: Women,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: NashvilleRescueMission,
            Focus: Homelessness,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: HandsOnNashville,
            Focus: Environment,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: MercyMinistries,
            Focus: Women,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: Boys&GirlsClub,
            Focus: Children,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: OasisCenter,
            Focus: Children,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: RedCross,
            Focus: Emergency,
            Location: url{'https://google.com/api/etcetc.'}
        },
        {
            OrgName: SecondHarvestFoodBank,
            Focus: Hunger,
            Location: url{'https://google.com/api/etcetc.'}
        }
    }
}

