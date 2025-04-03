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
        public int PhysicalActivityID { get; }

        /// <summary>
        /// Physical activity name
        /// </summary>
        public string PhysicalActivityName { get; }

        /// <summary>
        /// Number of calories per minute
        /// </summary>
        public double CaloriesPerMinute { get; }

        /// <summary>
        /// Create physical activity
        /// </summary>
        /// <param name="physicalActivityname"></param>
        /// <param name="caloriesPerMinute"></param>
        public PhysicalActivity(string physicalActivityname, double caloriesPerMinute) 
        {
            PhysicalActivityName = physicalActivityname;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return $"{PhysicalActivityName}: {CaloriesPerMinute}";
        }
    }
}
