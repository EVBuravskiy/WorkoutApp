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
            if(userController.IsNewUser)
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
            Console.WriteLine(userController.CurrentUser);
            List<User> users = userController.GetAllUsersData();
            foreach(var user in users)
            {
                Console.WriteLine(user);
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
                Console.Write($"Enter your {inputName}: ");
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
    }
}