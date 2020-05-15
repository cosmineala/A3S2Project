using System;

using VroomAuto.AppLogic.Models;
using VroomAuto.AppLogic.Abstractions;
using System.Collections.Generic;

namespace VroomAuto.AppLogic.Services
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetUserFromIdentity(string identityID)
        {
            Guid identityIdGuid = Guid.Empty;

            if( Guid.TryParse(identityID, out identityIdGuid) == false)
            {
                throw new Exception("Invalid Guid format");
            }

            return userRepository.GetUserFromIdentity(identityIdGuid);

        }

        public void RegisterUser( User user )
        {
            if( CheckIfUserIsBaned( user ))
            {
                throw new Exception("User is baned bu CNP");
            }
            else
            {
                userRepository.Add(user);
            }
            
        }

        public void UpdateUserData( User user)
        {
            userRepository.UpdateUser(user);

        }

        public Guid StringToGuid( string user)
        {

            Guid userGuid = Guid.Empty;

            if( Guid.TryParse(user, out userGuid) == false)
            {
                throw new Exception("Invalid Guid format");
            }

            return userGuid;
        }

        public bool CheckIfUserIsBaned( User user)
        {
            var result = userRepository.GetUnwantedUserByCNP( user.CNP );

            if( result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
