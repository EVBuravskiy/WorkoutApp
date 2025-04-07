namespace WorkoutApp.BL.Controllers
{
    public abstract class  BaseController
    {
        private readonly IDataSaver manager = new SerializeDataSaver();

        /// <summary>
        /// Save list of data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns>bool</returns>
        protected bool Save<T>(List<T> items) where T: class 
        {
            return manager.Save(items);
        }

        /// <summary>
        /// Load list of data from source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>List of data </returns>
        protected List<T> LoadItems<T>() where T : class
        {
            return manager.LoadItems<T>();
        }
    }
}
