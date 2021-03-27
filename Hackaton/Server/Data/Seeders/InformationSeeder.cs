using Bogus;
using Hackaton.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton.Server.Data.Seeders
{
    public class InformationSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Information.Count() > 0)
            {
                return;
            }

            var info = new List<Information>();

            var faker = new Faker<Information>()
                .RuleFor(x => x.DeviceId, x => x.Random.Int(1, 20))
                .RuleFor(x => x.DissolvedOxygen, x => x.Random.Double())
                .RuleFor(x => x.IsSeen, x => false)
                .RuleFor(x => x.ORP, x => x.Random.Double(-1000, 1000))
                .RuleFor(x => x.PH, x => x.Random.Double(0, 14))
                .RuleFor(x => x.WaterPressure, x => x.Random.Double(0, 10000));


            for (int i = 0; i < 10000; i++)
            {
                dbContext.Information.Add(faker.Generate());
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
