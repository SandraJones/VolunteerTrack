namespace VolunteerTrack.Migrations
{
    using CsvHelper;
    using DAL;
    using Microsoft.Ajax.Utilities;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<VolunteerTrack.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VolunteerTrack.Models.ApplicationDbContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "SeedingDataFromCSV.Domain.SeedData.CharitableOrganizations.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    var orgs = csvReader.GetRecords<CharitableOrganization>().ToArray();
                    Context.CharitableOrganizations.AddOrUpdate(c => c.Code, CharitableOrganizations);
                }
            }
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
        //        FocusName: Children,   36.166,-86.802 and -36.158,-86.799
        //        Location: url{'https://google.com/api/etcetc.??????????'}  another question, can you seed part of a DB table and seed the other part later?
        //    },
        //    {
        //        OrgName: BoyScoutsOfAmerica,
        //        FocusName: Children,  36.114,-86.812
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: GirlScouts,
        //        FocusName: Children,   36.090,-86.804
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: SafeHaven,
        //        FocusName: Women&Children,   36.147,-86.766
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: FriendsOfLongHunterStatePark,
        //        FocusName: Environment,  36.094,-86.560
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: RoomInTheInn,
        //        FocusName: Homelessness,   36.152,-86.781
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: Thistle Farms,
        //        FocusName: Women,   36.152,-86.851
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: NashvilleRescueMission,
        //        FocusName: Homelessness,  36.154,-86.848
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: HandsOnNashville,
        //        FocusName: Community,   36.158,-86.769
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: The Branch Food Pantry,
        //        FocusName: Hunger,  36.059,-86.672
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: Nashville Zoo at Grassmere,
        //        FocusName: Animals,  36.090,-86.736
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: Alive Hospice,
        //        FocusName: Elderly,  36.158,-86.801
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: RedCross,
        //        FocusName: Emergency,  36.156,-86.810
        //        Location: url{'https://google.com/api/etcetc.'}
        //    },
        //    {
        //        OrgName: SecondHarvestFoodBank,
        //        FocusName: Hunger,  36.199,-86.797
        //        Location: url{'https://google.com/api/etcetc.'}
        //    }
    }
}

