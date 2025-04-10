using WorkoutApp.BL.Models;

namespace WorkoutApp.BL.Controllers
{
    /// <summary>
    /// IngestionController
    /// </summary>
    public class IngestionController : BaseController
    {
        /// <summary>
        /// User
        /// </summary>
        private readonly User user;

        /// <summary>
        /// List of products
        /// </summary>
        public List<Product> Products { get; set; }

        //List of ingestions
        public List<Ingestion> Ingestions { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        private Product Product { get; set; }

        /// <summary>
        /// Create ingestion controller
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public IngestionController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be null", nameof(user));
            GetAllIngestions();
            GetAllProducts();
        }

        /// <summary>
        /// Get ingestions to list of ingestions
        /// </summary>
        public void GetAllIngestions()
        {
            using (WorkoutAppContext appContext = new WorkoutAppContext())
            {
                Ingestions = appContext.Ingestions.ToList();
            }
        }

        /// <summary>
        /// Get products to list of products
        /// </summary>
        public void GetAllProducts()
        {
            using (WorkoutAppContext appContext = new WorkoutAppContext())
            {
                Products = appContext.Products.ToList();
            }
        }

        /// <summary>
        /// Check product in DB by product name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns>bool</returns>
        public bool CheckProductInBd(string productName)
        {
            Product = Products.SingleOrDefault(x => x.ProductName == productName);
            if (Product == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Add product into DB
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbohydrates"></param>
        /// <param name="calories"></param>
        public void AddProductToBd(string productName, double proteins, double fats, double carbohydrates, double calories)
        {
            Product = new Product { ProductName = productName, Proteins = proteins, Fats = fats, Carbohydrates = carbohydrates, Calories = calories};
            using (WorkoutAppContext appContext = new WorkoutAppContext())
            {
                appContext.Products.Add(Product);
                appContext.SaveChanges();
            }
            GetAllProducts();
        }

        /// <summary>
        /// Add ingestion into DB
        /// </summary>
        /// <param name="weight"></param>
        public void AddIngestionToBd(double weight)
        {
            using (WorkoutAppContext appContext = new WorkoutAppContext())
            {
                Ingestion ingestion = appContext.Ingestions.FirstOrDefault(x => x.ProductID == Product.ProductId);
                if (ingestion == null)
                {
                    Product product = appContext.Products.SingleOrDefault(x => x.ProductName.Equals(Product.ProductName));
                    ingestion = new Ingestion(product, weight);
                    ingestion.UserID = user.UserID;
                    appContext.Ingestions.Add(ingestion);
                    appContext.SaveChanges();
                }
                else
                {
                    ingestion.Weight += weight;
                    appContext.Update(ingestion);
                    appContext.SaveChanges();
                }
            }
            GetAllIngestions();
            GetAllProducts();
        }
    }
}
