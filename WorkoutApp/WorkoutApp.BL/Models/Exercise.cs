namespace WorkoutApp.BL.Models
{
    [Serializable]
    public class Exercise
    {
        /// <summary>
        /// Exercise ID
        /// </summary>
        public int ExerciseID { get; set; }

        /// <summary>
        /// Exercise start time
        /// </summary>
        public DateTime ExerciseStart { get; set; }

        /// <summary>
        /// Exercise end time
        /// </summary>
        public DateTime ExerciseFinish { get; set; }

        /// <summary>
        /// Physical activity
        /// </summary>
        public virtual PhysicalActivity PhysicalActivity { get; set; }

        /// <summary>
        /// Physical activity ID
        /// </summary>
        public int PhysicalActivityID { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }

                
        /// <summary>
        /// Create Exercise
        /// </summary>
        public Exercise() { }

        /// <summary>
        /// Create Exercise
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <param name="activity"></param>
        /// <param name="user"></param>
        public Exercise(DateTime start, DateTime finish, PhysicalActivity activity, User user)
        {
            //TODO: Реализовать проверку входящих данных
            ExerciseStart = start;
            ExerciseFinish = finish;
            PhysicalActivity = activity;
            PhysicalActivityID = activity.PhysicalActivityID;
            User = user;
            UserID = user.UserID;
        }
    }
}
