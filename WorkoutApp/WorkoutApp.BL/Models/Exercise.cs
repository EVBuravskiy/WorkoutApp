namespace WorkoutApp.BL.Models
{
    [Serializable]
    public class Exercise
    {
        /// <summary>
        /// Exercise ID
        /// </summary>
        public int ExerciseID { get; }

        /// <summary>
        /// Exercise start time
        /// </summary>
        public DateTime ExerciseStart { get; }

        /// <summary>
        /// Exercise end time
        /// </summary>
        public DateTime ExerciseFinish { get; }

        /// <summary>
        /// Physical activity
        /// </summary>
        public PhysicalActivity PhysicalActivity { get; }

        /// <summary>
        /// User
        /// </summary>
        public User User { get; }

        public Exercise(DateTime start, DateTime finish, PhysicalActivity activity, User user)
        {
            //TODO: Реализовать проверку входящих данных
            ExerciseStart = start;
            ExerciseFinish = finish;
            PhysicalActivity = activity;
            User = user;
        }
    }
}
