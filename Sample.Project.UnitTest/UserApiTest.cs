using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Project.Api;

namespace Sample.Project.UnitTest
{
    [TestClass]
    public class UserApiTest
    {
        [TestMethod]
        public void Test_GetAllUsers()
        {
            //Arrange
            UserManager userMngr = new UserManager();
            //Act
            Api.Objects.UserProfileData[] userProfileList = userMngr.GetAllUsers();
            //Assert
            Assert.IsNull(userProfileList); //NUll as expected, no sql connection in place
        }

        [TestMethod]
        public void Test_CreateNewUser()
        {
            //Arrange
            UserManager userMngr = new UserManager();
            Api.Objects.UserProfileData userData = new Api.Objects.UserProfileData();
            userData.FirstName = "FIRSTNAME";
            userData.LastName = "LASTNAME";
            userData.EmailAddress = "TEST@TEST.COM";

            //Act
            bool status = userMngr.CreateNewUser(userData);
            //Assert
            Assert.IsFalse(status); //false as expected, no sql connection in place
        }
    }
}
