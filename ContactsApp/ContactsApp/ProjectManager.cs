using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// A class that implements saving data to a file and loading data from a file.
    /// </summary>
    public static class ProjectManager
    {
        #region Constants

        /// <summary>
        /// Contains the name of the file to be saved and loaded.
        /// </summary>
        private const string _name = @"\ContactsApp.notes";

        #endregion

        #region Static fields

        /// <summary>
        /// Contains the path to the documents folder.
        /// </summary>
        private static readonly string _path =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Contains the full path to the file.
        /// </summary>
        private static readonly string _file = _path + _name;

        #endregion

        #region Public methods

        /// <summary>
        /// The method saves data in a file.
        /// </summary>
        /// <param name="data">Data to be saved.</param>
        public static void SaveToFile(Project data)
        {
            var serializer = new JsonSerializer {Formatting = Formatting.Indented};
            using (var sw = new StreamWriter(_file))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Method that loads data from a file.
        /// </summary>
        /// <returns>Returns processed data from a file.</returns>
        public static Project LoadFromFile()
        {
            Project project = null;
            var serializer = new JsonSerializer {Formatting = Formatting.Indented};
            using (var sr = new StreamReader(_file))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = serializer.Deserialize<Project>(reader);
            }

            return project;
        }

        #endregion
    }
}