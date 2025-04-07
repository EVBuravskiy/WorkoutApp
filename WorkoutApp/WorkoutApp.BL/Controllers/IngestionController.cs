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
            Ingestion = new Ingestion();
            Foodstuffs = GetAllFoodstuffs();
            Ingestions = GetAllIngestions();
        }
        
        /// <summary>
        /// Binary serialize foodstuffs and ingestions and save to files
        /// </summary>
        /// <returns>bool</returns>
        private bool Save()
        {
            bool resultSaveFoodstuffs = Save<Foodstuff>(Foodstuffs);
            bool resultSaveIngestions = Save<Ingestion>(Ingestions);
            return resultSaveFoodstuffs && resultSaveIngestions;
        }

        /// <summary>
        /// Load from file foodstuffs and deserialize
        /// </summary>
        /// <returns>List of foodstuffs</returns>
        public List<Foodstuff> GetAllFoodstuffs()
        {
            return LoadItems<Foodstuff>() ?? new List<Foodstuff>();
        }

        /// <summary>
        /// Load from file ingestion and deserialize
        /// </summary>
        /// <returns>Ingestion</returns>
        public List<Ingestion> GetAllIngestions()
        {
            return LoadItems<Ingestion>();
        }
        
        /// <summary>
        /// Add foodstuff to ingestion
        /// </summary>
        /// <param name="inputFoodstuff"></param>
        /// <param name="weight"></param>
        public void AddFoodstuff(Foodstuff inputFoodstuff, double weight)
        {
            Foodstuff foodstuff = null;
            if (Foodstuffs.Count > 0)
            {
                foodstuff = Foodstuffs.SingleOrDefault(food => food.FoodstuffName.Equals(inputFoodstuff.FoodstuffName));
            }
            if(foodstuff == null)
            {
                Foodstuffs.Add(inputFoodstuff);
                Ingestion.AddFoods(inputFoodstuff, weight);
                Save();
                return;
            }
            Ingestion.AddFoods(foodstuff, weight);
            Ingestions.Add(Ingestion);
            Save();
        }
    }
}
