using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton.Server.Data.Seeders
{

    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
