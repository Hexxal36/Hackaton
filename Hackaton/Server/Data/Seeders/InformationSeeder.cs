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

            var fakerStartDate = new DateTime(2021, 1, 1);
            var fakerEndDate = new DateTime(2021, 3, 27);

            var faker = new Faker<Information>()
                .RuleFor(x => x.DeviceId, x => x.Random.Int(1, 20))
                .RuleFor(x => x.DissolvedOxygen, x => Math.Round(x.Random.Double(), 4))
                .RuleFor(x => x.IsSeen, x => false)
                .RuleFor(x => x.ORP, x => Math.Round(x.Random.Double(-1000, 1000), 4))
                .RuleFor(x => x.PH, x => Math.Round(x.Random.Double(0, 14), 2))
                .RuleFor(x => x.WaterPressure, x => Math.Round(x.Random.Double(0, 10000), 4))
                .RuleFor(x => x.CreatedAt, x => x.Date.Between(fakerStartDate, fakerEndDate));


            for (int i = 0; i < 10000; i++)
            {
                dbContext.Information.Add(faker.Generate());
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
