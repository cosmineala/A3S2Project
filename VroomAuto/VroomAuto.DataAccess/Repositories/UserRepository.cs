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

        public void UpdateUser( User user )
        {
            var result = dbContext.Users
                                  .Where( p => p.ID == user.ID )
                                  .SingleOrDefault();

            if( result != null)
            {
                if( user.Name != null)
                {
                    result.Name = user.Name;
                }
                if( user.Phone != null)
                {
                    result.Phone = user.Phone;
                }
                if( user.Adress != null)
                {
                    result.Adress = user.Adress;
                }
            }

            dbContext.SaveChanges();
        }
    }
}
