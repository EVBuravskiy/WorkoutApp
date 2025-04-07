namespace WorkoutApp.BL.Models
{
    [Serializable]
    public class Foodstuff
    {
        #region Property
        /// <summary>
        /// Food identification number
        /// </summary>
        public int FoodstuffID { get; set; }
        /// <summary>
        /// Food name
        /// </summary>
        public string FoodstuffName { get; set; }
        /// <summary>
        /// Proteins in 100 grams of product
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Fats in 100 grams of product
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Carbohydrates in 100 grams of product 
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Caloric content of 100 grams of product
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// Dictionary of ingestions
        /// </summary>
        public virtual ICollection<Ingestion> Ingestions { get; set; }
        
        #endregion
        /// <summary>
        /// Create foodstuff default for EntityFramework
        /// </summary>
        public Foodstuff() { }

        /// <summary>
        /// Create foodstuff
        /// </summary>
        /// <param name="foodName"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbohydrates"></param>
        /// <param name="calories"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Foodstuff(string foodName, double proteins, double fats, double carbohydrates, double calories)
        {
            //TODO: Реализовать проверку входных данных
            if (string.IsNullOrWhiteSpace(foodName))
            {
                throw new ArgumentNullException("Product name cannot be empty or null", nameof(foodName));
            }
            FoodstuffName = foodName;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        
        /// <summary>
        /// Create foodstuff
        /// </summary>
        /// <param name="foodName"></param>
        public Foodstuff(string foodName) : this (foodName, 0, 0, 0, 0) { }

        public override string ToString()
        {
            return $"Food: {FoodstuffName}";
        }
    }
}
