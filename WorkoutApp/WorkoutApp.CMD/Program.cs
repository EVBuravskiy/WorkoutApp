using WorkoutApp.BL.Controllers;
namespace WorkoutApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Workout Application");
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter your gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter your birth day: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime birthDate);
            Console.Write("Enter your weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Enter your height: ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("Enter you email: ");
            string email = Console.ReadLine();
            UserController userController = new UserController(userName, gender, birthDate, weight, height, email);
            bool result = userController.SaveUser();
            Console.WriteLine(result);
        }
    }
}