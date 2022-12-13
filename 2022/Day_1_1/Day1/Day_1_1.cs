using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day1
{
    public class Day_1_1: IDay
    {
        public string Path { get; set; } = "..\\..\\Day1\\source1.txt";

        public string GetAnswer()
        {
            var text = FileReader.GetTextFromFile(Path);

            return GetElfesCaloriesFromText(text).Select(x => x.CaloriesList.Sum()).Max().ToString();
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
