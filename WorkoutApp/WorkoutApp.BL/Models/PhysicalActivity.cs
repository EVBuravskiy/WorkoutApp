namespace WorkoutApp.BL.Models
{
    [Serializable]
    /// <summary>
    /// PhysicalActivity
    /// </summary>
    public class PhysicalActivity
    {
        /// <summary>
        /// Physical activity ID
        /// </summary>
        public int PhysicalActivityID { get; set; }

        /// <summary>
        /// Physical activity name
        /// </summary>
        public string PhysicalActivityName { get; set; }

        /// <summary>
        /// Number of calories per minute
        /// </summary>
        public double CaloriesPerMinute { get; set; }

        /// <summary>
        /// Exercise that includes activity
        /// </summary>
        public virtual ICollection<Exercise> Exercises { get; set;}

        /// <summary>
        /// Create physical activity
        /// </summary>
        public PhysicalActivity() { }

        /// <summary>
        /// Create physical activity
        /// </summary>
        /// <param name="physicalActivityname"></param>
        /// <param name="caloriesPerMinute"></param>
        public PhysicalActivity(string physicalActivityname, double caloriesPerMinute) 
        {
            //TODO: Добавить проверку входных данных
            PhysicalActivityName = physicalActivityname;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return $"{PhysicalActivityName}: {CaloriesPerMinute}";
        }
    }
}
