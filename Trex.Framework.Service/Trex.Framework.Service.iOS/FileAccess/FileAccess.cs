
namespace Trex.Framework.Service.iOS.FileAccess
{
    using Foundation;
    using System;
    using System.IO;
        public class FileAccess : IFileAccess
    {
        public   string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            string dbPath = Path.Combine(libFolder, fileName);
            CopyDatabaseIfNotExists(fileName, dbPath);
            return dbPath;
        }

        private static void CopyDatabaseIfNotExists(string databaseName, string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                var existingDb = NSBundle.MainBundle.PathForResource(databaseName, "db3");
                File.Copy(existingDb, dbPath);
            }
        }
    }
}
