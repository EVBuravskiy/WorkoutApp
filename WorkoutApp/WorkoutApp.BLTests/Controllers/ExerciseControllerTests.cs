using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkoutApp.BL.Controllers;
using WorkoutApp.BL.Models;

namespace WorkoutApp.BL.Controllers.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddPhysicalActivityTest()
        {
            //Arrange
            string userName = Guid.NewGuid().ToString();
            string activityName = Guid.NewGuid().ToString();
            Random rnd = new Random();
            double calloriesPerMinute = rnd.Next(10, 50);
            UserController userController = new UserController(userName);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);
            PhysicalActivity activity = new PhysicalActivity(activityName, calloriesPerMinute);
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now.AddHours(1);

            //Act
            exerciseController.AddPhysicalActivity(activity, begin, end);
            Exercise loadExersice = exerciseController.ExercisesList.FirstOrDefault(act => act.PhysicalActivity.PhysicalActivityName == activityName);

            //Assert
            Assert.AreEqual(activityName, loadExersice.PhysicalActivity.PhysicalActivityName);
        }
    }
}