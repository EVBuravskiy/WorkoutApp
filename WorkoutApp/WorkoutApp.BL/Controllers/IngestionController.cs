using WorkoutApp.BL.Models;

namespace WorkoutApp.BL.Controllers
{
    /// <summary>
    /// IngestionController
    /// </summary>
    public class IngestionController : BaseController
    {
        /// <summary>
        /// Const string file name for Foodstuffs
        /// </summary>
        private const string FOODS_FILE_NAME = "foodstuffs.dat";

        /// <summary>
        /// Const string file name for Ingestions
        /// </summary>
        private const string INGESTIONS_FILE_NAME = "ingestions.dat";

        /// <summary>
        /// User
        /// </summary>
        private readonly User user;

        /// <summary>
        /// List of foodstuffs
        /// </summary>
        public List<Foodstuff> Foodstuffs { get; }

        /// <summary>
        /// Ingestion
        /// </summary>
        public Ingestion Ingestion { get; }

        /// <summary>
        /// List of ingestions
        /// </summary>
        public List<Ingestion> Ingestions { get; }

        /// <summary>
        /// Create IngestionController
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public IngestionController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be null", nameof(user));
            Foodstuffs = GetAllFoodstuffs();
            Ingestion = GetIngestion();
        }
        
        /// <summary>
        /// Binary serialize foodstuffs and ingestions and save to files
        /// </summary>
        /// <returns>bool</returns>
        private bool Save()
        {
            bool resultSaveFoodstuffs = Save(FOODS_FILE_NAME, Foodstuffs);
            bool resultSaveIngestions = Save(INGESTIONS_FILE_NAME, Ingestion);
            return resultSaveFoodstuffs && resultSaveIngestions;
        }

        /// <summary>
        /// Load from file foodstuffs and deserialize
        /// </summary>
        /// <returns>List of foodstuffs</returns>
        public List<Foodstuff> GetAllFoodstuffs()
        {
            return LoadItems<Foodstuff>(FOODS_FILE_NAME) ?? new List<Foodstuff>();
        }

        /// <summary>
        /// Load from file ingestion and deserialize
        /// </summary>
        /// <returns>Ingestion</returns>
        public Ingestion GetIngestion()
        {
            return LoadItem<Ingestion>(INGESTIONS_FILE_NAME) ?? new Ingestion(user);
        }
        
        /// <summary>
        /// Add foodstuff to ingestion
        /// </summary>
        /// <param name="inputFoodstuff"></param>
        /// <param name="weight"></param>
        public void AddFoodstuff(Foodstuff inputFoodstuff, double weight)
        {
            Foodstuff foodstuff = Foodstuffs.SingleOrDefault(food => food.FoodstuffName.Equals(inputFoodstuff.FoodstuffName));
            if(foodstuff == null)
            {
                Foodstuffs.Add(inputFoodstuff);
                Ingestion.AddFoods(inputFoodstuff, weight);
                Save();
                return;
            }
            Ingestion.AddFoods(foodstuff, weight);
            Save();
        }
    }
}
