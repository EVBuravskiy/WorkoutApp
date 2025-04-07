namespace WorkoutApp.BL.Controllers
{
    public interface IDataSaver
    {
        /// <summary>
        /// Save data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns>bool</returns>
        bool Save<T>(List<T> items) where T: class;

        /// <summary>
        /// Load list of data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>List of data </returns>
        List<T> LoadItems<T>() where T: class;

    }
}
