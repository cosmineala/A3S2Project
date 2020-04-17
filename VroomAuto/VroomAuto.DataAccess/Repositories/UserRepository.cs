using System;
using System.Linq;


using VroomAuto.AppLogic.Abstractions;
using VroomAuto.AppLogic.Models;

namespace VroomAuto.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(VroomAutoDbContext dbContext) : base(dbContext)
        {
        }

        public User GetUserFromIdentity(Guid identityID)
        {
            return dbContext.Users
                .Where(p => p.IdentityID == identityID)
                .SingleOrDefault();
        }
    }
}
