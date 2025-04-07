using WorkoutApp.BL.Models;

namespace WorkoutApp.BL.Controllers
{
    public class ExerciseController : BaseController
    {
        /// <summary>
        /// User
        /// </summary>
        private readonly User user;

        /// <summary>
        /// List of exercises list
        /// </summary>
        public List<Exercise> ExercisesList { get; set; }

        /// <summary>
        /// List of physical activity
        /// </summary>
        public List<PhysicalActivity> PhysicalActivities { get; set; }

        /// <summary>
        /// Exercise
        /// </summary>
        public Exercise Exercise { get; set; }

        /// <summary>
        /// Create Exercise controller
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be null", nameof(user));
            ExercisesList = GetAllExercises();
            PhysicalActivities = GetAllPhysicalActivities();
        }

        /// <summary>
        /// Add physical activity into exercise
        /// </summary>
        /// <param name="activityName"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        public void AddPhysicalActivity(PhysicalActivity activity, DateTime begin, DateTime end)
        {
            var loadActivity = PhysicalActivities.SingleOrDefault(act => act.PhysicalActivityName.Equals(activity.PhysicalActivityName));
            if (loadActivity == null)
            {
                PhysicalActivities.Add(activity);
                Exercise exercise = new Exercise(end, begin, activity, user);
                ExercisesList.Add(exercise);
            }
            else
            {
                Exercise exercise = new Exercise(end, begin, loadActivity, user);
                ExercisesList.Add(exercise);
            }
            SaveActivities();
            SaveExercises();
        }

        /// <summary>
        /// Get list of all exercises from file
        /// </summary>
        /// <returns>List of exercises</returns>
        private List<Exercise> GetAllExercises()
        {
            return LoadItems<Exercise>() ?? new List<Exercise>();
        }

        /// <summary>
        /// Save exercises into file
        /// </summary>
        /// <returns>bool</returns>
        private bool SaveExercises()
        {
            return Save(ExercisesList);
        }

        /// <summary>
        /// Get list of all physical activities from file
        /// </summary>
        /// <returns>List of physical activities</returns>
        private List<PhysicalActivity> GetAllPhysicalActivities()
        {
            return LoadItems<PhysicalActivity>() ?? new List<PhysicalActivity>();

        }

        /// <summary>
        /// Save physical activities into file
        /// </summary>
        /// <returns>bool</returns>
        private bool SaveActivities()
        {
            return Save(PhysicalActivities);
        }
    }
}
