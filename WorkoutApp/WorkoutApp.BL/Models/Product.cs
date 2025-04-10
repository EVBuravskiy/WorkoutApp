namespace WorkoutApp.BL.Models
{
    [Serializable]
    public class Product
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Proteins in product
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Fats in product
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Carbohydrates in product
        /// </summary>
        public double Carbohydrates { get; set; }
        
        /// <summary>
        /// Calories in product
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// Create product default for EntityFramework
        /// </summary>
        public Product() { }

        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbohydrates"></param>
        /// <param name="calories"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Product(string productName, double proteins, double fats, double carbohydrates, double calories)
        {
            //TODO: Реализовать проверку входных данных
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentNullException("Product name cannot be empty or null", nameof(productName));
            }
            ProductName = productName;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        
        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="productName"></param>
        public Product(string productName) : this (productName, 0, 0, 0, 0) { }

        public override string ToString()
        {
            return $"Food: {ProductName}";
        }
    }
}
