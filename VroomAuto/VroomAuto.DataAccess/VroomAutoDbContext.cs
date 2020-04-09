using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VroomAuto.DataAccess
{
    public class VroomAutoDbContext : DbContext
    {

        public VroomAutoDbContext(DbContextOptions<VroomAutoDbContext> options)
            : base(options)
        {
        }

    }
}
