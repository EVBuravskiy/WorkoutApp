using WorkoutApp.BL.Controllers;
using WorkoutApp.BL.Models;

namespace WorkoutApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Workout Application");
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            UserController userController = new UserController(userName);
            IngestionController ingestionController = new IngestionController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                string gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");
                Console.Write("Enter you email: ");
                string email = Console.ReadLine();
                userController.SetNewUserData(gender, birthDate, weight, height, email);
            }
            Console.WriteLine($"Hello, { userController.CurrentUser}");
            //List<User> users = userController.GetAllUsersData();
            //foreach(var user in users)
            //{
            //    Console.WriteLine(user);
            //}


            Console.WriteLine("What you want to do? ");
            Console.WriteLine("E - enter meal");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.E)
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
                Console.Write($"Enter {inputName}: ");
                if (double.TryParse(Console.ReadLine(), out double result))
                {
                    return result;
                }
                Console.WriteLine($"Wrong format of {inputName}. Please try again");
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
                Console.Write("Enter your birth day (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                Console.WriteLine("Wrong format of birth date. Please try again");
            }
        }

        private static (Foodstuff foodstuff, double weight) EnterIngestion(User user)
        {
            Console.Write("\nEnter food name: ");
            string foodName = Console.ReadLine();
            double foodWeight = ParseDouble("serving weight");
            Console.WriteLine("Enter values ​per 100 grams of product");
            double proteins = ParseDouble("proteins");
            double fats = ParseDouble("fats");
            double carbohydrates = ParseDouble("carbohydrates");
            double callories = ParseDouble("callories");
            Foodstuff foodstuff = new Foodstuff(foodName, proteins, fats, carbohydrates, callories);
            return (foodstuff, foodWeight);
        }
    }
}