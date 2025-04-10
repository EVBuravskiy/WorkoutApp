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
            
            string productName = Guid.NewGuid().ToString();
            Random rnd = new Random();
            double proteins = (double)rnd.Next(50, 500);
            double fats = (double)rnd.Next(50, 500);
            double carbohydrates = (double)rnd.Next(50, 500);
            double calories = (double)rnd.Next(50, 500);

            //Act
            ingestionController.AddProductToBd(productName, proteins, fats, carbohydrates, calories);
            var list = ingestionController.Products;
            Product element = null;
            foreach(var item in list)
            {
                if (item.ProductName == productName)
                {
                    element = item;
                    break;
                }
            }
            //Assert
            if (element == null)
            {
                Assert.Fail();
            }
            Assert.AreEqual(productName, element.ProductName);
        }
    }
}