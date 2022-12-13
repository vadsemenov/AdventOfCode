using System.Collections.Generic;
using System.Linq;

namespace Days.Day1
{
    public class Day_1_2 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day1\\source1.txt";

        public string GetAnswer()
        {
            var text = FileReader.GetTextFromFile(Path);

            return GetElfesCaloriesFromText(text).Select(x => x.CaloriesList.Sum()).OrderByDescending(x => x).Take(3).Sum().ToString();
        }

        private static List<Elfe> GetElfesCaloriesFromText(string[] text)
        {
            var elfes = new List<Elfe>();

            var elfe = new Elfe();

            foreach (var line in text)
            {
                if (int.TryParse(line, out int value))
                {

                    elfe.CaloriesList.Add(value);

                }
                else
                {
                    elfes.Add(elfe);
                    elfe = new Elfe();
                }
            }
            elfes.Add(elfe);

            return elfes;
        }
    }
}