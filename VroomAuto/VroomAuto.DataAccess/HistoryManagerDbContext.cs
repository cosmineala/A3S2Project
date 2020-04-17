using VroomAuto.AppLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VroomAuto.DataAccess
{
    public class HistoryManagerDbContext : DbContext
    {
        public HistoryManagerDbContext(DbContextOptions<HistoryManagerDbContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarStatus> CarStatuses { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<UnwantedUser> UnwantedUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

    }
}
