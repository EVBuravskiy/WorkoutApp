using System.Runtime.Serialization.Formatters.Binary;
using WorkoutApp.BL.Models;
namespace WorkoutApp.BL.Controllers
{
    /// <summary>
    /// Controller for User model
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User
        /// </summary>
        internal User User { get; }

        /// <summary>
        /// Create User Controller with deserialize user from file
        /// </summary>
        public UserController()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(binaryFormatter.Deserialize(file) is User user)
                {
                    User = user;
                }
                else
                {
                    //TODO: Что делать если не удалось?
                    User = null;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="genderName"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="email"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height, string email)
        {
            //TODO: Проверка входных данных
            Gender gender = new Gender(genderName);
            User user = new User(userName, gender, birthDate, weight, height, email);
            if (user == null)
            {
                throw new ArgumentNullException("User can't be null", nameof(user));
            }
            User = user;
        } 
        /// <summary>
        /// Binary serialize user and save to file
        /// </summary>
        /// <returns>bool</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool SaveUser()
        {
            if (User == null)
            {
                throw new ArgumentNullException("User can't be null", nameof(User));
            }
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream file = new FileStream("users.dat", FileMode.OpenOrCreate))
                {
                    binaryFormatter.Serialize(file, User);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
