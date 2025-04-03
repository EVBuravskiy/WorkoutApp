using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using WorkoutApp.BL.Controllers;
using WorkoutApp.BL.Models;


namespace WorkoutApp.CMD
{
    internal class Program
    {
        static string cultureChoose;
        static CultureInfo culture;
        static ResourceManager resourceManager;
        static void Main(string[] args)
        {
            culture = CultureInfo.CurrentCulture;
            resourceManager = new ResourceManager("WorkoutApp.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("ChangeLanguage", culture));
            var inputKey = Console.ReadKey();
            if (inputKey.Key == ConsoleKey.Y)
            {
                Console.Clear();
                Console.WriteLine("For english enter E");
                Console.WriteLine("Для выбора русского языка введите R");
                inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.E)
                {
                    cultureChoose = "en-us";
                }
                else
                {
                    cultureChoose = "ru-ru";
                }
            }
            Console.Clear();
            culture = CultureInfo.CreateSpecificCulture(cultureChoose);
            resourceManager = new ResourceManager("WorkoutApp.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Greating", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            string userName = Console.ReadLine();
            UserController userController = new UserController(userName);
            IngestionController ingestionController = new IngestionController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                string gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble(resourceManager.GetString("Weight", culture));
                double height = ParseDouble(resourceManager.GetString("Height", culture));
                Console.Write(resourceManager.GetString("EnterEmail", culture));
                string email = Console.ReadLine();
                userController.SetNewUserData(gender, birthDate, weight, height, email);
            }
            Console.Clear();
            Console.WriteLine($"{resourceManager.GetString("HelloUser", culture)}{ userController.CurrentUser}");
            Console.WriteLine(resourceManager.GetString("WhatDo", culture));
            Console.WriteLine();
            Console.WriteLine($"\t{resourceManager.GetString("EnterMeal", culture)}");
            var key = Console.ReadKey();
            Console.Clear();
            if(key.Key == ConsoleKey.E || key.Key == ConsoleKey.T)
            {
                var tuplefood = EnterIngestion(userController.CurrentUser);
                ingestionController.AddFoodstuff(tuplefood.foodstuff, tuplefood.weight);
                var ingestions = ingestionController.GetIngestion();
                Console.WriteLine(ingestions.User.ToString());
                Console.WriteLine(ingestions.Moment.ToString());
                Console.WriteLine(ingestions.FoodstuffsList.First().Key.FoodName);
                Console.WriteLine(ingestions.FoodstuffsList.First().Key.Calories);
                foreach(var item in ingestionController.Ingestion.FoodstuffsList)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

        }

        /// <summary>
        /// Parse double from string
        /// </summary>
        /// <param name="inputName"></param>
        /// <returns>double</returns>
        private static double ParseDouble(string inputName)
        {
            while (true)
            {
                Console.Write($"{resourceManager.GetString("Enter", culture)} {inputName}: ");
                if (double.TryParse(Console.ReadLine(), out double result))
                {
                    return result;
                }
                Console.WriteLine($"{Languages.WrongInput.WrongFormat} {inputName}. {Languages.WrongInput.TryAgain}");
            }
        }
        /// <summary>
        /// Parse date of birthday from string
        /// </summary>
        /// <returns>DateTime</returns>
        private static DateTime ParseDateTime()
        {
            while (true)
            {
                Console.Write(resourceManager.GetString("EnterBirhtDay", culture));
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                Console.WriteLine(Languages.WrongInput.WrongBirthDate);
            }
        }
        /// <summary>
        /// Entering food information into a meal
        /// </summary>
        /// <param name="user"></param>
        /// <returns>tuple(Foodstuff, weight)</returns>
        private static (Foodstuff foodstuff, double weight) EnterIngestion(User user)
        {
            Console.Write(resourceManager.GetString("EnterFoodName", culture));
            string foodName = Console.ReadLine();
            double foodWeight = ParseDouble(resourceManager.GetString("ServingWeight", culture));
            Console.WriteLine(resourceManager.GetString("EnterValues", culture));
            double proteins = ParseDouble(resourceManager.GetString("Proteins", culture));
            double fats = ParseDouble(resourceManager.GetString("Fats", culture));
            double carbohydrates = ParseDouble(resourceManager.GetString("Carbohydrates", culture));
            double calories = ParseDouble(resourceManager.GetString("Calories", culture));
            Foodstuff foodstuff = new Foodstuff(foodName, proteins, fats, carbohydrates, calories);
            return (foodstuff, foodWeight);
        }
    }
}