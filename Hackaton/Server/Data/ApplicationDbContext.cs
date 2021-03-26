using Microsoft.EntityFrameworkCore;
using System;
using Hackaton.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) {
        }
        public DbSet<Information> Information{ get; set; }
        public DbSet<Device> Devices{ get; set; }
    }
}
