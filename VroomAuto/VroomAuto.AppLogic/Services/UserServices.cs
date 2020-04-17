using System;

using VroomAuto.AppLogic.Models;
using VroomAuto.AppLogic.Abstractions;

namespace VroomAuto.AppLogic.Services
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetUserFromIdentity(string identityID)
        {
            Guid identityIdGuid = Guid.Empty;
            Guid.TryParse(identityID, out identityIdGuid);

            return userRepository.GetUserFromIdentity(identityIdGuid);

        }

    }
}
