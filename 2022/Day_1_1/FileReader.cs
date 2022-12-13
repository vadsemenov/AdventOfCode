using System.IO;

namespace Days
{
    public static class FileReader
    {
        public static string[] GetTextFromFile(string path)
        {
            var sourceStrings = File.ReadAllLines(path);

            return sourceStrings;
        }
    }
}