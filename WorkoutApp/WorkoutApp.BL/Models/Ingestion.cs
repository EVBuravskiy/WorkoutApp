using System;

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
        public int IngestionID { get; }

        /// <summary>
        /// Time of ingestion
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Dictionary of foods and weight
        /// </summary>
        public Dictionary<Foodstuff, double> FoodstuffsList { get; }

        /// <summary>
        /// User
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Create ingestion
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Ingestion(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be null", nameof(user));
            Moment = DateTime.Now;
            FoodstuffsList = new Dictionary<Foodstuff, double>();
        }

        /// <summary>
        /// Add eating foods
        /// </summary>
        /// <param name="foodstuff"></param>
        /// <param name="weight"></param>
        public void AddFoods(Foodstuff foodstuff, double weight)
        {
            var meal = FoodstuffsList.Keys.FirstOrDefault(food => food.FoodstuffName.Equals(foodstuff.FoodstuffName)); 
            if (meal == null)
            {
                FoodstuffsList.Add(foodstuff, weight);
                return;
            }
            var element = FoodstuffsList[meal];
            FoodstuffsList[meal] += weight;
        }
    }
}
