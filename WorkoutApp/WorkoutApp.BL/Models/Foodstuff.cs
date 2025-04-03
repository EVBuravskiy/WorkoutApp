using System;

namespace WorkoutApp.BL.Models
{
    [Serializable]
    public class Foodstuff
    {
        #region Property
        /// <summary>
        /// Food identification number
        /// </summary>
        public int FoodstuffID { get; }
        /// <summary>
        /// Food name
        /// </summary>
        public string FoodstuffName { get; }
        /// <summary>
        /// Proteins in 100 grams of product
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Fats in 100 grams of product
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Carbohydrates in 100 grams of product 
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Caloric content of 100 grams of product
        /// </summary>
        public double Calories { get; }
        #endregion

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
        public Foodstuff(string foodName) : this (foodName, 0, 0, 0, 0) { }

        public override string ToString()
        {
            return $"Food: {FoodstuffName}";
        }
    }
}
