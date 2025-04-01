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
            //Arrange   - объявление входных данных
            //генерируем случайное имя
            var userName = Guid.NewGuid().ToString();
            //Act       - выполнение действия - вызов проверяемого метода
            //создаем контроллер и передаем в него сгенерированное имя
            UserController controller = new UserController(userName);
            //Assert    - сравнение предполагаемого и фактического результатов, содержит набор утверждений 
            //т.е. сравниваем сгенерированное имя и то, которое было записано
            Assert.AreEqual(userName, controller.CurrentUser.UserName);
        }
        [TestMethod()]
        public void GetAllUsersDataTest()
        {
            //Arrange   - объявление входных данных
            //задаем входные данные
            string userName = "Alex";
            string gender = "man";
            DateTime birthDay = DateTime.Parse("01.01.2001");
            double weight = 90;
            double height = 190;
            string email = "test@test.com";
            
            //Act
            UserController controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDay, weight, height, email);
            List<User> users = controller.GetAllUsersData();
            User checkUser = users.SingleOrDefault(x => x.UserName == userName) as User;

            //Assert
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
            //Arrange   - объявление входных данных
            //задаем входные данные
            string userName = "Alex";
            //Act       - выполнение действия - вызов проверяемого метода
            //создаем контроллер и передаем в него сгенерированное имя
            UserController controller = new UserController(userName);
            //Assert    - сравнение предполагаемого и фактического результатов, содержит набор утверждений 
            //т.е. сравниваем сгенерированное имя и то, которое было записано
            Assert.AreEqual(userName, controller.CurrentUser.UserName);
        }

        //метод проверки сохранения добавленных данных
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange   - объявление входных данных
            //генерируем случайное имя
            string userName = "Alex";
            string gender = "man";
            DateTime birthDay = DateTime.Parse("01.01.2001");
            double weight = 90;
            double height = 190;
            string email = "test@test.com";
            //Act       - выполнение действия - вызов проверяемого метода
            //создаем контроллер и передаем в него сгенерированное имя
            UserController controller1 = new UserController(userName);
            controller1.SetNewUserData(gender, birthDay, weight, height, email);
            var controller2 = new UserController(userName);
            //Assert    - сравнение предполагаемого и фактического результатов, содержит набор утверждений 
            //т.е. сравниваем сгенерированное имя и то, которое было записано
            Assert.AreEqual(userName, controller2.CurrentUser.UserName);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.GenderName);
            Assert.AreEqual(birthDay, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(email, controller2.CurrentUser.Email);
        }
    }
}