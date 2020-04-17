using System;

using VroomAuto.AppLogic.Models;

namespace VroomAuto.AppLogic.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserFromIdentity(Guid identityID);
    }
}
