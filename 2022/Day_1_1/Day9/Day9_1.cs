using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days.Day9
{
    public class Day9_1 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day9\\source1.txt";

        public static HashSet<(int, int)> visitedPoint = new HashSet<(int, int)>();

        public static (int, int) tailPosition = (0, 0);

        public static (int, int) headPosition = (0, 0);

        public string GetAnswer()
        {
            var commands = File.ReadAllLines(Path).Select(x =>
            {
                var array = x.Split(' ');
                return (array[0], int.Parse(array[1]));
            });

            MoveHeadAndTail(commands);

            return visitedPoint.Count.ToString();
        }

        private void MoveHeadAndTail(IEnumerable<(string, int)> commands)
        {
            visitedPoint.Add(tailPosition);

            foreach (var command in commands)
            {
                if (command.Item1 == "R")
                {
                    Move(command.Item2, 0, 0, 0);
                }
                else if (command.Item1 == "L")
                {
                    Move(0, command.Item2, 0, 0);
                }
                else if (command.Item1 == "U")
                {
                    Move(0, 0, command.Item2, 0);
                }
                else if (command.Item1 == "D")
                {
                    Move(0, 0, 0, command.Item2);
                }
            }
        }

        private void Move(int right, int left, int up, int down)
        {
            if (right != 0)
            {
                for (int i = 0; i < right; i++)
                {
                    headPosition = (headPosition.Item1 + 1, headPosition.Item2);

                    if ((headPosition.Item1 - tailPosition.Item1) > 1)
                    {
                        tailPosition = (headPosition.Item1 - 1, headPosition.Item2);
                        visitedPoint.Add(tailPosition);
                    }
                }
            }

            if (left != 0)
            {
                for (int i = 0; i < left; i++)
                {
                    headPosition = (headPosition.Item1 - 1, headPosition.Item2);

                    if ((tailPosition.Item1 - headPosition.Item1) > 1)
                    {
                        tailPosition = (headPosition.Item1 + 1, headPosition.Item2);
                        visitedPoint.Add(tailPosition);
                    }
                }
            }

            if (up != 0)
            {
                for (int i = 0; i < up; i++)
                {
                    headPosition = (headPosition.Item1, headPosition.Item2 + 1);

                    if ((headPosition.Item2 - tailPosition.Item2) > 1)
                    {
                        tailPosition = (headPosition.Item1, headPosition.Item2 - 1);
                        visitedPoint.Add(tailPosition);
                    }
                }
            }

            if (down != 0)
            {
                for (int i = 0; i < down; i++)
                {
                    headPosition = (headPosition.Item1, headPosition.Item2 - 1);

                    if ((tailPosition.Item2 - headPosition.Item2) > 1)
                    {
                        tailPosition = (headPosition.Item1, headPosition.Item2 + 1);
                        visitedPoint.Add(tailPosition);
                    }
                }
            }
        }
    }
}