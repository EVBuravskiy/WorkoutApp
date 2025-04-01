using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkoutApp.BL.Controllers;
using WorkoutApp.BL.Models;

namespace WorkoutApp.BL.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void UserControllerTest()
        {
            var userName = Guid.NewGuid().ToString();
            UserController controller = new UserController(userName);
            Assert.AreEqual(userName, controller.CurrentUser.UserName);
        }
        [TestMethod()]
        public void GetAllUsersDataTest()
        {
            string userName = "Alex";
            string gender = "man";
            DateTime birthDay = DateTime.Parse("01.01.2001");
            double weight = 90;
            double height = 190;
            string email = "test@test.com";
            UserController controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDay, weight, height, email);
            List<User> users = controller.GetAllUsersData();
            User checkUser = users.SingleOrDefault(x => x.UserName == userName) as User;
            Assert.IsNotNull(checkUser);
            Assert.AreEqual(userName, checkUser.UserName);
            Assert.AreEqual(gender, checkUser.Gender.GenderName);
            Assert.AreEqual(birthDay, checkUser.BirthDate);
            Assert.AreEqual(weight, checkUser.Weight);
            Assert.AreEqual(height, checkUser.Height);
            Assert.AreEqual(email, checkUser.Email);
        }
        [TestMethod()]
        public void SaveUserTest()
        {
            string userName = "Alex";
            UserController controller = new UserController(userName);
            Assert.AreEqual(userName, controller.CurrentUser.UserName);
        }
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            string userName = "Alex";
            string gender = "man";
            DateTime birthDay = DateTime.Parse("01.01.2001");
            double weight = 90;
            double height = 190;
            string email = "test@test.com";
            UserController controller1 = new UserController(userName);
            controller1.SetNewUserData(gender, birthDay, weight, height, email);
            var controller2 = new UserController(userName);
            Assert.AreEqual(userName, controller2.CurrentUser.UserName);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.GenderName);
            Assert.AreEqual(birthDay, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(email, controller2.CurrentUser.Email);
        }
    }
}