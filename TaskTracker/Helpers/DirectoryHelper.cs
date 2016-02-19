using System.IO;

namespace TaskTracker.Helpers
{
    public class DirectoryHelper
    {
        public static string GetUploadDirectoryLocation(string mapPath)
        {
            if (!Directory.Exists(mapPath))
            {
                Directory.CreateDirectory(mapPath);
            }
            return mapPath;
        }
    }
}