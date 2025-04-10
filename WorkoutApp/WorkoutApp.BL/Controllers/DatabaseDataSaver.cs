namespace WorkoutApp.BL.Controllers
{
    internal class DatabaseDataSaver : IDataSaver 
    {
        /// <summary>
        /// Load elements of class from DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>list of elements</returns>
        public List<T> LoadItems<T>() where T : class
        {
            try
            {
                using (WorkoutAppContext appContext = new WorkoutAppContext())
                {
                    return appContext.Set<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<T>();
            }
        }

        /// <summary>
        /// Save elements of class into DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns>bool</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Save<T>(List<T> items) where T : class
        {
            if (items == null)
            {
                throw new ArgumentNullException("Input element is null", nameof(items));
            }
            try
            {
                using (WorkoutAppContext appContext = new WorkoutAppContext())
                {
                    List<T> itemsInDb = LoadItems<T>(); //
                    items.RemoveRange(0, itemsInDb.Count); //
                    appContext.Set<T>().AddRange(items);
                    appContext.SaveChanges();
                    return true;
                }
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
