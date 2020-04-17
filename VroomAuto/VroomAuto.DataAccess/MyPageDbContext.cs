using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VroomAuto.AppLogic.Models;

namespace VroomAuto.DataAccess
{
    public class MyPageDbContext : DbContext
    {
        public MyPageDbContext(DbContextOptions<MyPageDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarBrand> CarBrands { get; set; }

        public DbSet<CarClass> CarClasses { get; set; }

        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<CarStatus> CarStatuses { get; set; }

        public DbSet<History> Histories { get; set; }

        public DbSet<MyPageDbContext> MyPages { get; set; }


    }
}
