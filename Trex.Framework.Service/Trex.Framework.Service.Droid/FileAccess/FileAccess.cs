
namespace Trex.Framework.Service.Droid.FileAccess
{
    using System;
    using System.IO;
    using Trex.Framework.Service.FileAccess;
    public interface FileAccess : IFileAccess
    {
        public static string GetLocalFilePath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(path, fileName);
            CopyDatabaseIfNotExists(fileName, dbPath);
            return dbPath;
        }
        private static void CopyDatabaseIfNotExists(string databaseName, string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                using (var br = new BinaryReader(Android.App.Application.Context.Assets.Open(databaseName)))
                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }
                }
            }
        }

    }
}
