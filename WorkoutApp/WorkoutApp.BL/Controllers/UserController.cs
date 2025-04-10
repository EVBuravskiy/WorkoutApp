using WorkoutApp.BL.Models;
namespace WorkoutApp.BL.Controllers
{
    /// <summary>
    /// Controller for User model
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// Const string filename for user
        /// </summary>
        private const string USER_FILE_NAME = "users.dat";
        /// <summary>
        /// User
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// List of users
        /// </summary>
        public List<User> Users { get; }


        /// <summary>
        /// Flag for identificate new user
        /// </summary>
        public bool IsNewUser { get; } = false;

        //TODO: Delete
        //public UserController() { }


        /// <summary>
        /// Create new user controller
        /// </summary>
        /// <param name="userName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string inputUserName)
        {
            if (string.IsNullOrWhiteSpace(inputUserName))
            {
                throw new ArgumentNullException("User name can't be null or empty", nameof(inputUserName));
            }
            Users = GetAllUsersData();
            CurrentUser = Users.SingleOrDefault(user => user.UserName == inputUserName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(inputUserName);
                IsNewUser = true;
            }
        }


        /// <summary>
        /// Get saved users from file and deserialize
        /// </summary>
        /// <returns>List of users </returns>
        public List<User> GetAllUsersData()
        {
            return LoadItems<User>();
        }


        /// <summary>
        /// Binary serialize list of users and save to file
        /// </summary>
        /// <returns>bool</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool SaveUsers()
        {
            return Save(Users);
        }

        /// <summary>
        /// Set data to new user
        /// </summary>
        /// <param name="genderName"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="email"></param>
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1, string email = "example@example.com")
        {
            //TODO: Реализовать проверку входных данных
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            CurrentUser.Email = email;
            Users.Add(CurrentUser);
            SaveUsers();
        }
    }
}
