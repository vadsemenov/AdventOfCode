using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days.Day10
{
    public class Day10_1 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day10\\source1.txt";


        public string GetAnswer()
        {
            var text = File.ReadAllLines(Path);

            var instructions = GetInstructions(text);

            var cyclesSum = GetCyclesSum(instructions);

            var sum = cyclesSum.Sum();

            return sum.ToString();
        }

        private int _cycleSum;

        private List<int> GetCyclesSum(List<(string, int, int)> instructions)
        {
            var cyclesSum = new List<int>();

            int i = 0;

            var limit = new List<int>() {20, 60, 100, 140, 180, 220};

            int j = 0;

            while (i < _cycleSum)
            {
                if (j < 6 && i+1 == limit[j])
                {
                    var element = instructions.Where(x => x.Item3 <= i).ToList();
                    var sum = element.Select(x => x.Item2).ToList();
                    var iSum = (sum.Sum() + 1);
                    var intermediateSum = iSum * (i+1);
                    cyclesSum.Add(intermediateSum);
                    j++;
                }

                i++;
            }

            return cyclesSum;
        }

        private List<(string, int, int)> GetInstructions(string[] text)
        {
            var instructions = new List<(string, int, int)>();

            _cycleSum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].StartsWith("add"))
                {
                    _cycleSum += 2;
                    var instruction = text[i].Split(' ');
                    instructions.Add((instruction[0], int.Parse(instruction[1]), _cycleSum));
                }
                else
                {
                    _cycleSum += 1;
                    instructions.Add((text[i], 0, _cycleSum));
                }
            }


            return instructions;
        }
    }
}