using System.Runtime.Serialization.Formatters.Binary;

namespace WorkoutApp.BL.Controllers
{
    public class SerializeDataSaver : IDataSaver
    {

        /// <summary>
        /// Serialize list of data and save into file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool Save<T>(List<T> items) where T : class
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                var fileName = typeof(T).Name;
                using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    binaryFormatter.Serialize(file, items);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Load and deserialize data from file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>List of data</returns>
        public List<T> LoadItems<T>() where T : class
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                var fileName = typeof(T).Name;

                using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    if (file.Length > 0 && binaryFormatter.Deserialize(file) is List<T> elements)
                    {
                        return elements;
                    }
                    else
                    {
                        return new List<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<T>();
            }
        }
    }
}
