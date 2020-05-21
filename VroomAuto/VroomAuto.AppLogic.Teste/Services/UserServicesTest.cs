using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using VroomAuto.AppLogic.Models;
using VroomAuto.AppLogic.Abstractions;
using VroomAuto.AppLogic.Services;
using VroomAuto.DataAccess.Repositories;
using System.Collections.Generic;

namespace VroomAuto.AppLogic.Teste.Services
{
    [TestClass]
    public class UserServicesTest
    {
        [TestMethod]
        public void StringToGuid_Returns_ConvertedStringToGuid()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>() ;

            var input = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
            var expectedOutput = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");


            UserService userService = new UserService(userRepositorMock.Object);

            var testData = userService.StringToGuid(input);

            Assert.AreEqual(expectedOutput, expectedOutput);

        }
        [TestMethod]
        public void StringToGuid_ThrowsException_ConvertedStringToGuid()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();

            var input_1 = "23";
            var input_2 = "sd-232-asdaf-AS23";

            UserService userService = new UserService(userRepositorMock.Object);

            Assert.ThrowsException<Exception>(
                        () => { userService.StringToGuid(input_1); }
                    );
            Assert.ThrowsException<Exception>(
                        () => { userService.StringToGuid(input_2); }
                    );
        }


        [TestMethod]
        public void GetUserFromIdentity_Returns_UserIfExists()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();

            var in_String = "7299FFCC-435E-4A6D-99DF-57A4D6FBA712";
            var in_Guid = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
            Exception exception = null;

            User outUser = null;

            //1980701160000
            var user = new User
            {
                ID = 1,
                Name = "Cosmin",
                IdentityID = in_Guid,
                CNP = "1980251160301",
                Adress = "Craiova Str.Calea Bucuresti nr.17"
            };

            userRepositorMock.Setup( c => c.GetUserFromIdentity( in_Guid ) ).
                    Returns( user );

            UserService userService = new UserService(userRepositorMock.Object);

            try
            {
                outUser = userService.GetUserFromIdentity(in_String);
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.AreEqual(exception, null);
            Assert.IsNotNull(outUser);

        }
        [TestMethod]
        public void GetUserFromIdentity_ReturnsNull_IfUserDoseNotExists()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();

            var in_String = "1111FFCC-435E-4A6D-99DF-57A4D6dBa712";
            var in_Guid = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
            Exception exception = null;

            User outUser = null;

            var user = new User
            {
                ID = 1,
                Name = "Cosmin",
                IdentityID = in_Guid,
                CNP = "1980251160301",
                Adress = "Craiova Str.Calea Bucuresti nr.17"
            };

            userRepositorMock.Setup(c => c.GetUserFromIdentity(in_Guid)).
                    Returns(user);

            UserService userService = new UserService(userRepositorMock.Object);

            try
            {
                outUser = userService.GetUserFromIdentity(in_String);
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.AreEqual(exception, null);
            Assert.IsNull(outUser);

        }
        [TestMethod]
        public void GetUserFromIdentity_ThrowsException_IfGuidIsBad()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();

            var in_String = "sdasd-435E112dA6D-99DF-57A4D6dBa712";
            var in_Guid = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
            Exception exception = null;

            User outUser = null;

            var user = new User
            {
                ID = 1,
                Name = "Cosmin",
                IdentityID = in_Guid,
                CNP = "1980251160301",
                Adress = "Craiova Str.Calea Bucuresti nr.17"
            };

            userRepositorMock.Setup(c => c.GetUserFromIdentity(in_Guid)).
                    Returns(user);

            UserService userService = new UserService(userRepositorMock.Object);

            try
            {
                outUser = userService.GetUserFromIdentity(in_String);
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.ThrowsException<Exception>(
                () => { userService.GetUserFromIdentity(in_String); }
             );
        }

        [TestMethod]
        public void GetAll_Returns_AllUsers()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();

            List<User> users = new List<User>() ;

            users.Add(new User { ID = 1, Name = "Cosmin", IdentityID = Guid.NewGuid(), CNP = "1980251160301", Adress = "Craiova Str.Calea Bucuresti nr.17" } );
            users.Add(new User { ID = 2, Name = "Dan",    IdentityID = Guid.NewGuid(), CNP = "3251251160301", Adress = "Suceava Str.Berii nr.4" });
            users.Add(new User { ID = 3, Name = "Mihai",  IdentityID = Guid.NewGuid(), CNP = "5247251160301", Adress = "Bucuresti Str.Antiaeriana nr.145" });
            users.Add(new User { ID = 4, Name = "Andrei", IdentityID = Guid.NewGuid(), CNP = "2472251160301", Adress = "Calafat Str.Muncii nr.5-7" });
            users.Add(new User { ID = 5, Name = "Florin", IdentityID = Guid.NewGuid(), CNP = "3532251160301", Adress = "Constanta Str.Teiului nr.22" });

            IEnumerable<User> usersEnumerable = users;

            userRepositorMock.Setup( c => c.GetAll() ).
                Returns( usersEnumerable );

            UserService userService = new UserService(userRepositorMock.Object);

            var outputUsers = userService.GetAll();

            Assert.IsNotNull( outputUsers );
            Assert.AreEqual(usersEnumerable, outputUsers);

        }
        [TestMethod]
        public void GetAll_ReturnsNull_NoUserWasFound()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();


            List<User> users = null;


            IEnumerable<User> usersEnumerable = users;

            userRepositorMock.Setup(c => c.GetAll()).
                Returns(usersEnumerable);

            UserService userService = new UserService(userRepositorMock.Object);

            var outputUsers = userService.GetAll();

            Assert.IsNull(outputUsers);

        }

        [TestMethod]
        public void RegisterUser_Successful_UserWasRegistered()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();
            string inputCNP = "1980251160301";
            
            UnwantedUser checkResoult = null;
            User user = new User { ID = 1, Name = "Cosmin", IdentityID = Guid.NewGuid(), CNP = "1980251160301", Adress = "Craiova Str.Calea Bucuresti nr.17" };

            Exception exception = null ;

            userRepositorMock.Setup(c => c.GetUnwantedUserByCNP( inputCNP ) ).
                Returns( checkResoult );



            UserService userService = new UserService(userRepositorMock.Object);

            try
            {
                userService.RegisterUser(user);
            }
            catch(Exception e)
            {
                exception = e;
            }

            Assert.AreEqual(exception, null);

        }
        [TestMethod]
        public void RegisterUser_ThrowsException_UserIsBanedByCNP()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();
            string inputCNP = "1980251160301";


            UnwantedUser checkResoult = new UnwantedUser { ID = 1, CNP = "1980251160301" };
            User user = new User { ID = 1, Name = "Cosmin", IdentityID = Guid.NewGuid(), CNP = "1980251160301", Adress = "Craiova Str.Calea Bucuresti nr.17" };


            userRepositorMock.Setup(c => c.GetUnwantedUserByCNP(inputCNP)).
                Returns( checkResoult );


            UserService userService = new UserService(userRepositorMock.Object);


            Assert.ThrowsException<Exception>(
                       () => { userService.RegisterUser(user); }
                   );
        }
//------------------------------------------------------------------------------------------------------
        [TestMethod]
        public void UpdateUserData_Successful_UserWasUpdated()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();

            User user = new User { ID = 1, Name = "Cosmin", IdentityID = Guid.NewGuid(), CNP = "1980251160301", Adress = "Craiova Str.Calea Bucuresti nr.17" };

            Exception exception = null;

            userRepositorMock.Setup(c => c.UpdateUser(user));



            UserService userService = new UserService(userRepositorMock.Object);

            try
            {
                userService.UpdateUserData(user);
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.AreEqual(exception, null);

        }
        [TestMethod]
        public void UpdateUserData_ThrowsException_UserWasUpdated()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();

            User user = new User { ID = 1, Name = "Cosmin", IdentityID = Guid.NewGuid(), CNP = "1980251160301", Adress = "Craiova Str.Calea Bucuresti nr.17" };

            userRepositorMock.Setup(c => c.UpdateUser(user))
                    .Throws(new Exception("User was not found"));



            UserService userService = new UserService(userRepositorMock.Object);

            Assert.ThrowsException<Exception>(
                    () => { userService.UpdateUserData(user); }
             );
        }


        [TestMethod]
        public void GetUser_Successful_UserIsReturned()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();

            int userID = 1;

            User user = new User { ID = 1, Name = "Cosmin", IdentityID = Guid.NewGuid(), CNP = "1980251160301", Adress = "Craiova Str.Calea Bucuresti nr.17" };

            Exception exception = null;

            userRepositorMock.Setup(c => c.GetUser( userID ))
                .Returns( user );



            UserService userService = new UserService(userRepositorMock.Object);

            User outUser = null ;

            try
            {
                 outUser = userService.GetUser( userID );
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.AreEqual(exception, null);
            Assert.AreEqual(outUser, user);
        }
        [TestMethod]
        public void GetUser_ThrowsException_UserWasNotFound()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();

            int userID = 1;

            User user = new User { ID = 1, Name = "Cosmin", IdentityID = Guid.NewGuid(), CNP = "1980251160301", Adress = "Craiova Str.Calea Bucuresti nr.17" };

            userRepositorMock.Setup(c => c.GetUser(userID))
                .Throws( new Exception("User was not found") );

            UserService userService = new UserService(userRepositorMock.Object);

            Assert.ThrowsException<Exception>(
                    () => { userService.GetUser( userID ); }
             );
        }

        public class BoolCheck
        {
            public BoolCheck( bool value)
            {
                this.value = value;
                this.wasSet = true;
            }

            public bool wasSet = false;
            public bool value;
        }

        public void CheckIfUserIsBaned_ReturnsTrue_IfUserIsBaned()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();
            string inputCNP = "1980251160301";

            //UnwantedUser checkResoult = null;
            User user = new User { ID = 1, Name = "Cosmin", IdentityID = Guid.NewGuid(), CNP = inputCNP, Adress = "Craiova Str.Calea Bucuresti nr.17" };
            UnwantedUser unwantedUser = new UnwantedUser { ID = 1, CNP = inputCNP };
            

            Exception exception = null;

            userRepositorMock.Setup(c => c.GetUnwantedUserByCNP(inputCNP)).
                Returns( unwantedUser );



            UserService userService = new UserService(userRepositorMock.Object);


            BoolCheck boolCheck = null;

            try
            {
                boolCheck = new BoolCheck( userService.CheckIfUserIsBaned(user) );
               
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.AreEqual(exception, null);
            Assert.AreNotEqual(boolCheck, null);
            Assert.AreEqual(boolCheck.value, true);
            Assert.AreEqual(boolCheck.wasSet, true);

        }
        [TestMethod]
        public void CheckIfUserIsBaned_ReturnsFalse_IfUserIsNotBaned()
        {
            Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>();
            string inputCNP = "1980251160301";

            UnwantedUser unwantedUser = null;
            User user = new User { ID = 1, Name = "Cosmin", IdentityID = Guid.NewGuid(), CNP = "1980251160301", Adress = "Craiova Str.Calea Bucuresti nr.17" };

            Exception exception = null;

            userRepositorMock.Setup(c => c.GetUnwantedUserByCNP(inputCNP)).
                Returns( unwantedUser );

            UserService userService = new UserService(userRepositorMock.Object);


            BoolCheck boolCheck = null;

            try
            {
                boolCheck = new BoolCheck(userService.CheckIfUserIsBaned(user));

            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.AreEqual(exception, null);
            Assert.AreNotEqual(boolCheck, null);
            Assert.AreEqual(boolCheck.value, false);
            Assert.AreEqual(boolCheck.wasSet, true);

        }

    }
}
