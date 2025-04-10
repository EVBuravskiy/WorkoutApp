namespace WorkoutApp.BL.Models
{
    [Serializable]

    public class Ingestion
    {
        /// <summary>
        /// Ingestion ID
        /// </summary>
        public int IngestionID { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Product ID
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Weight of product
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Create ingestion default for EntityFramework
        /// </summary>
        public Ingestion() { }

        /// <summary>
        /// Create ingestion
        /// </summary>
        /// <param name="product"></param>
        /// <param name="weight"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Ingestion(Product product, double weight)
        {
            Product = product ?? throw new ArgumentNullException("User can't be null", nameof(product));
            //TODO: Проверить входные данные
            Weight = weight;
        }
    }
}
