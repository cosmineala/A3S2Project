using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using VroomAuto.AppLogic.Models;

namespace VroomAuto.DataAccess
{
    public class VroomAutoDbContext : DbContext
    {
        public VroomAutoDbContext(DbContextOptions<VroomAutoDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UnwantedUser> UnwantedUsers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<History> Histories { get; set; }

    }
}
