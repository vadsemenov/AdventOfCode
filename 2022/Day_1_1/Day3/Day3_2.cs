using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Days.Day3
{
    public class Day3_2 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day3\\source1.txt";

        public string GetAnswer()
        {
            var text = File.ReadAllLines(Path);

            int score = 0;

            for (int i = 0; i < text.Length; i += 3)
            {
                var firstElf = ConvertLineToIntArray(text[i], 0, text[i].Length);
                var secondElf = ConvertLineToIntArray(text[i + 1], 0, text[i + 1].Length);
                var thirdElf = ConvertLineToIntArray(text[i + 2], 0, text[i + 2].Length);

                score += firstElf.FirstOrDefault(x => secondElf.Contains(x) && thirdElf.Contains(x));
            }

            return score.ToString();
        }

        public int[] ConvertLineToIntArray(string line, int startIndex, int substringLength)
        {
            var charDic = GetCharDictionary();

            return line.Trim().Substring(startIndex, substringLength).ToCharArray()
                .Select(x => charDic.ElementAt(charDic.IndexOfKey(x)).Value)
                .OrderBy(x => x)
                .Distinct()
                .ToArray();
        }

        public SortedList<char, int> GetCharDictionary()
        {
            var dictionary = new SortedList<char, int>();

            for (int i = 97; i < 97 + 26; i++)
            {
                dictionary.Add((char) i, i - 96);
            }

            for (int i = 65; i < 65 + 26; i++)
            {
                dictionary.Add((char) i, i - 38);
            }

            return dictionary;
        }
    }
}