namespace WorkoutApp.BL.Models
{
    [Serializable]

    /// <summary>
    /// Ingestion - eating food
    /// </summary>
    public class Ingestion
    {

        /// <summary>
        /// Ingestion number
        /// </summary>
        public int IngestionID { get; set; }

        /// <summary>
        /// Time of ingestion
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Dictionary of foods and weight
        /// </summary>
        public Dictionary<Foodstuff, double> FoodstuffsDict { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Create ingestion
        /// </summary>
        public Ingestion() { }

        /// <summary>
        /// Create ingestion
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Ingestion(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be null", nameof(user));
            Moment = DateTime.Now;
            FoodstuffsDict = new Dictionary<Foodstuff, double>();
            UserID = user.UserID;
        }

        /// <summary>
        /// Add eating foods
        /// </summary>
        /// <param name="foodstuff"></param>
        /// <param name="weight"></param>
        public void AddFoods(Foodstuff foodstuff, double weight)
        {
            Foodstuff meal = null;
            if (FoodstuffsDict == null)
            {
                FoodstuffsDict = new Dictionary<Foodstuff, double>();
            }
            if (FoodstuffsDict.Count > 0)
            {
                meal = FoodstuffsDict.Keys.FirstOrDefault(food => food.FoodstuffName.Equals(foodstuff.FoodstuffName));
            }
            if (meal == null)
            {
                FoodstuffsDict.Add(foodstuff, weight);
                return;
            }
            FoodstuffsDict[meal] += weight;
        }
    }
}
