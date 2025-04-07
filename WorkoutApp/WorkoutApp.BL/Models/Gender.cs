using System.Globalization;

namespace WorkoutApp.BL.Models
{
    /// <summary>
    /// Gender
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// GenderID
        /// </summary>
        public int GenderID { get; set; }
        /// <summary>
        /// GenderName
        /// </summary>
        public string GenderName { get; set; }

        /// <summary>
        /// Create gender default for EntityFramework
        /// </summary>
        public Gender() { }

        /// <summary>
        /// Create new Gender
        /// </summary>
        /// <param name="genderName">Gender name</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string genderName)
        {
            if (string.IsNullOrWhiteSpace(genderName))
            {
                throw new ArgumentNullException("Gender can't be null or empty", nameof(genderName));
            }
            genderName = genderName.Trim().ToLower();
            //TextInfo myTI = new CultureInfo("ru-RU", false).TextInfo;
            //myTI.ToTitleCase(name);
            //Name = myTI.ToString();
            GenderName = genderName;
        }

        public override string ToString()
        {
            return GenderName;
        }
    }
}
