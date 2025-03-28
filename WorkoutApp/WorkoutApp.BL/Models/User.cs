namespace WorkoutApp.BL.Models
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    internal class User
    {
        #region User properties
        /// <summary>
        /// UserID
        /// </summary>
        public int UserID { get; }
        /// <summary>
        /// Name of user
        /// </summary>
        public string UserName { get; }
        /// <summary>
        /// User's gender
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// User's birth date
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// User's weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// User's height
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// User's email
        /// </summary>
        public string Email { get; set; }
        #endregion
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="email"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string userName, 
            Gender gender, 
            DateTime birthDate, 
            double weight, 
            double height, 
            string email)
        {
            #region Check inputs
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException("Name can't be null or empty", nameof(userName));
            if(gender == null) throw new ArgumentNullException("Gender can't be null or empty", nameof(gender));
            if(birthDate < DateTime.Parse("01.01.1900") && birthDate >= DateTime.Now) throw new ArgumentNullException("Imposible birth date", nameof(birthDate));
            if(weight <= 0) throw new ArgumentNullException("Wrong weigth", nameof(weight));
            if(height <= 0) throw new ArgumentNullException("Wrong heigth", nameof(height));
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("Email can't be null or empty", nameof(email));
            //TODO: сделать проверку email с помощью регулярного выражения
            #endregion
            UserName = userName;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
            Email = email;
        }

        public override string ToString()
        {
            return UserName;
        }
    }
}
