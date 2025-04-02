using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkoutApp.BL.Controllers;
using WorkoutApp.BL.Models;

namespace WorkoutApp.BL.Controllers.Tests
{
    [TestClass()]
    public class IngestionControllerTests
    {
        UserController userController;

        [TestMethod()]
        public void AddFoodstuffTest()
        {
            //Arrange
            string userName = Guid.NewGuid().ToString();
            userController = new UserController(userName);
            IngestionController ingestionController = new IngestionController(userController.CurrentUser);
            
            string foodName = Guid.NewGuid().ToString();
            Random rnd = new Random();
            double proteins = (double)rnd.Next(50, 500);
            double fats = (double)rnd.Next(50, 500);
            double carbohydrates = (double)rnd.Next(50, 500);
            double calories = (double)rnd.Next(50, 500);
            Foodstuff foodstuff = new Foodstuff(foodName, proteins, fats, carbohydrates, calories);

            //Act
            ingestionController.AddFoodstuff(foodstuff, 100);

            //Asserts
            Assert.AreEqual(foodstuff.FoodName, ingestionController.Ingestion.FoodstuffsList.First().Key.FoodName);

        }
    }
}