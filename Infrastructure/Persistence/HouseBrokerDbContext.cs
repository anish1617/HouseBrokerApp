using HouseBrokerApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.Persistence
{
    public class HouseBrokerDbContext : IdentityDbContext<IdentityUser>
    {
        public HouseBrokerDbContext(DbContextOptions<HouseBrokerDbContext> options) : base(options) { }

        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
