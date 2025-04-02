using System.Runtime.Serialization.Formatters.Binary;

namespace WorkoutApp.BL.Controllers
{
    public abstract class  BaseController
    {
        /// <summary>
        /// Binary serialize and save in file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        protected bool Save(string fileName, object element)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    binaryFormatter.Serialize(file, element);
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
        /// Load from file and deserialize data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns>List of deserialize data </returns>
        protected List<T> LoadItems<T>(string fileName)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
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

        /// <summary>
        /// Load from file and deserialize data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns>deserialize data</returns>
        protected T LoadItem<T>(string fileName)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    if (file.Length > 0 && binaryFormatter.Deserialize(file) is T item)
                    {
                        return item;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }
    }
}
