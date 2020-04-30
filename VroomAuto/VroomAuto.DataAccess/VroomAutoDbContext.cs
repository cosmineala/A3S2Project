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

        //---------------------------------------------------------User
        public DbSet<User> Users { get; set; }
        public DbSet<UnwantedUser> UnwantedUsers { get; set; }
        //public DbSet<UserType> UserTypes { get; set; }
        //--------------------------------------------------------Car
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarClass> CarClasses  { get; set; }
        public DbSet<CarStatus> CarStatuses { get; set; }
        public DbSet<Car> Cars { get; set; }
        //--------------------------------------------------------History
        public DbSet<History> Histories { get; set; }


    }
}
