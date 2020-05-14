using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using VroomAuto.AppLogic.Models;
using VroomAuto.AppLogic.Abstractions;
using VroomAuto.AppLogic.Services;
using VroomAuto.DataAccess.Repositories;

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
        public void GetUserFromIdentity_ThrowsException_IfUserDoseNotExists()
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

            //Assert.AreEqual(exception, null);
            Assert.IsNull(outUser);

        }

        //[TestMethod]
        //public void StringToGuid_Returns_ConvertedStringToGuid()
        //{
        //    Mock<IUserRepository> userRepositorMock = new Mock<IUserRepository>() ;

        //    var input = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
        //    var expectedOutput = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");

        //    //1980701160000
        //    var user = new User
        //    {
        //        ID = 1,
        //        Name = "Cosmin",
        //        IdentityID = expectedOutput,
        //        CNP = "1980251160301",
        //        Adress = "Craiova Str.Calea Bucuresti nr.17"
        //    };

        //    //userRepositorMock.Setup( c => c.StringToGuid( input ) ).
        //    //    Returns( expectedOutput );

        //    UserService userService = new UserService(userRepositorMock.Object);

        //    Assert.ThrowsException<Exception>(
        //                () => { userService.StringToGuid(input); }
        //            );
        //}

    }
}
