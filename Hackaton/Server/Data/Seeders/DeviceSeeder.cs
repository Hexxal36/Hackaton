using Bogus;
using Hackaton.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton.Server.Data.Seeders
{
    public class DeviceSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Devices.Count() > 0)
            {
                return;
            }

            var devices = new List<Device>();

            var faker = new Faker<Device>()
                .RuleFor(x => x.Longtitude, x => x.Address.Longitude())
                .RuleFor(x => x.Latitude, x => x.Address.Latitude())
                .RuleFor(x => x.Name, x => x.Lorem.Word())
                .RuleFor(x => x.Description, x => x.Lorem.Sentence())
                .RuleFor(x => x.Location, x => x.Address.StreetAddress());

            for (int i = 0; i < 20; i++)
            {
                dbContext.Devices.Add(faker.Generate());
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
