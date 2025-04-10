using System.Globalization;
using System.Resources;
using WorkoutApp.BL.Controllers;
using WorkoutApp.BL.Models;


namespace WorkoutApp.CMD
{
    internal class Program
    {
        static string cultureChoose = "";
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
            if (!string.IsNullOrEmpty(cultureChoose))
            {
                culture = CultureInfo.CreateSpecificCulture(cultureChoose);
            }
            Console.Clear();

            resourceManager = new ResourceManager("WorkoutApp.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Greating", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));

            string userName = Console.ReadLine();
            //TODO: Добавить проверку на входящие данные (userName)
            UserController userController = new UserController(userName);
            IngestionController ingestionController = new IngestionController(userController.CurrentUser);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);


            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                string gender = Console.ReadLine();
                //TODO: Вынести сообщение в локализацию
                DateTime birthDate = ParseDateTime("date of birthday");
                double weight = ParseDouble(resourceManager.GetString("Weight", culture));
                double height = ParseDouble(resourceManager.GetString("Height", culture));
                Console.Write(resourceManager.GetString("EnterEmail", culture));
                string email = Console.ReadLine();
                //TODO: Добавить проверку на входящие данные (email) через регулярное выражение
                userController.SetNewUserData(gender, birthDate, weight, height, email);
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{resourceManager.GetString("HelloUser", culture)}{userController.CurrentUser}");
                Console.WriteLine(resourceManager.GetString("WhatDo", culture));
                Console.WriteLine($"\t{resourceManager.GetString("EnterMeal", culture)}");
                //TODO: Вынести сообщение в локализацию
                Console.WriteLine($"\tA - enter exercise");
                Console.WriteLine("Q - exit application");
                var key = Console.ReadKey();
                
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                    case ConsoleKey.T:
                        EnterIngestion(ingestionController);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.F:
                        var activities = EnterExersice();
                        exerciseController.AddPhysicalActivity(activities.physicalActivity, activities.start, activities.end);
                        foreach (var item in exerciseController.ExercisesList)
                        {
                            Console.WriteLine($"\t{item.PhysicalActivity.PhysicalActivityName} {item.ExerciseStart.ToShortDateString()} from {item.ExerciseStart.ToShortTimeString()} to {item.ExerciseFinish.ToShortTimeString()}");
                        };
                        break;
                    case ConsoleKey.Q:
                        Console.WriteLine("Goodbye! See you later");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong command. Try again");
                        break;

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
        /// Parse date from string
        /// </summary>
        /// <returns>DateTime</returns>
        private static DateTime ParseDateTime(string message)
        {
            while (true)
            {
                //TODO: Внести сообщение в локализацию
                Console.Write($"Введите {message} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    return date;
                }
                //TODO: Внести сообщение в локализацию
                Console.WriteLine($"Неверный формат {message}");
            }
        }
        
        /// <summary>
        /// Entering food information into a meal
        /// </summary>
        /// <param name="ingestionController"></param>
        private static void EnterIngestion(IngestionController ingestionController)
        {
            Console.Write(resourceManager.GetString("EnterFoodName", culture));
            string productName = Console.ReadLine();
            if (!ingestionController.CheckProductInBd(productName))
            {
                //TODO: Добавить проверку на входящие данные (productName)
                Console.WriteLine(resourceManager.GetString("EnterValues", culture));
                double proteins = ParseDouble(resourceManager.GetString("Proteins", culture));
                double fats = ParseDouble(resourceManager.GetString("Fats", culture));
                double carbohydrates = ParseDouble(resourceManager.GetString("Carbohydrates", culture));
                double calories = ParseDouble(resourceManager.GetString("Calories", culture));
                ingestionController.AddProductToBd(productName, proteins, fats, carbohydrates, calories);
            }
            Console.Write("Введите вес продукта: ");
            double.TryParse(Console.ReadLine(), out double weight);
            ingestionController.AddIngestionToBd(weight);
        }

        /// <summary>
        /// Set activity and times of begin and end
        /// </summary>
        /// <returns></returns>
        private static (PhysicalActivity physicalActivity, DateTime start, DateTime end) EnterExersice()
        {
            //TODO: Внести сообщение в локализацию
            Console.Write("Введите название упражения: ");
            string exerciseName = Console.ReadLine();
            //TODO: Реализовать проверку входящей строки
            DateTime exerciseStart = ParseDateTime("exercise begin");
            DateTime exerciseEnd = ParseDateTime("exercise end");
            var energy = ParseDouble("расход энергии в минуту");
            //TODL: Вынести создание активности в контроллер
            var activity = new PhysicalActivity(exerciseName, energy);
            return (activity, exerciseStart, exerciseEnd);
        }
    }
}