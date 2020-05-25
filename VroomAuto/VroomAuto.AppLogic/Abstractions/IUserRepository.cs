using System;

using VroomAuto.AppLogic.Models;

namespace VroomAuto.AppLogic.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(int id);
        User GetUserFromIdentity(Guid identityID);
        void UpdateUser(User user);
        UnwantedUser GetUnwantedUserByCNP(string CNP);
    }
}
