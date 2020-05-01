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

        public void RegisterUser( User user )
        {
            userRepository.Add(user);
        }

        public void UpdateUserData( User user)
        {
            //Console.Write("Not Implemented : UserServices.UpdateUserData()");//NOT IMPLEMENTED
            userRepository.UpdateUser(user);

        }

        public Guid StringToGuid( string user)
        {

            Guid userGuid = Guid.Empty;
            Guid.TryParse(user, out userGuid);

            return userGuid;
        }
    }
}
