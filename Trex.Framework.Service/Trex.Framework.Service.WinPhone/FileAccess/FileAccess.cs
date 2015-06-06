namespace Trex.Framework.Service.WinPhone.FileAccess
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    
    public class FileAccess : IFileAccess
    {
        public static string GetLocalFilePath(string fileName)
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            string dbPath = Path.Combine(path, fileName);
            CopyDatabaseIfNotExists(fileName, dbPath);
            return dbPath;
        }

        private static void CopyDatabaseIfNotExists(string databaseName, string dbPath)
        {
            var storageFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (!storageFile.FileExists(dbPath))
            {
                using (var resourceStream = System.Windows.Application.GetResourceStream(new Uri(databaseName, UriKind.Relative)).Stream)
                {
                    using (var fileStream = storageFile.CreateFile(dbPath))
                    {
                        byte[] readBuffer = new byte[4096];
                        int bytes = -1;

                        while ((bytes = resourceStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            fileStream.Write(readBuffer, 0, bytes);
                        }
                    }
                }
            }
        }
    }
}
