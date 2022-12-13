using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days.Day9
{
    public class Day9_2 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day9\\source1.txt";

        public static HashSet<(int, int)> visitedPoint = new HashSet<(int, int)>();

        // public static (int, int) tailPosition = (0, 0);

        public static (int, int) headPosition = (0, 0);

        public static List<(int, int)> rope = new List<(int, int)>();

        public string GetAnswer()
        {
            var commands = File.ReadAllLines(Path).Select(x =>
            {
                var array = x.Split(' ');
                return (array[0], int.Parse(array[1]));
            });

            MoveBody(commands);

            return visitedPoint.Count.ToString();
        }

        private void MoveBody(IEnumerable<(string, int)> commands)
        {
            for (int i = 0; i < 10; i++)
            {
                rope.Add((0, 0));
            }

            visitedPoint.Add(rope[8]);

            foreach (var command in commands)
            {
                if (command.Item1 == "R")
                {
                    MoveRight(command.Item2);
                }
                else if (command.Item1 == "L")
                {
                    MoveLeft(command.Item2);
                }
                else if (command.Item1 == "U")
                {
                    MoveUp(command.Item2);
                }
                else if (command.Item1 == "D")
                {
                    MoveDown(command.Item2);
                }
            }
        }

        private void MoveRight(int moveAmount)
        {
            for (int i = 0; i < moveAmount; i++)
            {
                rope[0] = (rope[0].Item1 + 1, rope[0].Item2);

                for (int j = 1; j < rope.Count; j++)
                {
                    var verticalRange = rope[j - 1].Item2 - rope[j].Item2;
                    var horizontalRange = rope[j - 1].Item1 - rope[j].Item1;

                    rope[j] = GetNodeNewPosition(horizontalRange, verticalRange, rope[j - 1], rope[j]);


                    if (j == 9)
                    {
                        visitedPoint.Add(rope[j]);
                    }
                }
            }
        }

        private void MoveUp(int moveAmount)
        {
            for (int i = 0; i < moveAmount; i++)
            {
                rope[0] = (rope[0].Item1, rope[0].Item2 + 1);

                for (int j = 1; j < rope.Count; j++)
                {
                    var verticalRange = rope[j - 1].Item2 - rope[j].Item2;
                    var horizontalRange = rope[j - 1].Item1 - rope[j].Item1;

                    rope[j] = GetNodeNewPosition(horizontalRange, verticalRange, rope[j - 1], rope[j]);

                    if (j == 9)
                    {
                        visitedPoint.Add(rope[j]);
                    }
                }
            }
        }

        private void MoveLeft(int moveAmount)
        {
            for (int i = 0; i < moveAmount; i++)
            {
                rope[0] = (rope[0].Item1 - 1, rope[0].Item2);

                for (int j = 1; j < rope.Count; j++)
                {
                    var verticalRange = rope[j - 1].Item2 - rope[j].Item2;
                    var horizontalRange = rope[j - 1].Item1 - rope[j].Item1;

                    rope[j] = GetNodeNewPosition(horizontalRange, verticalRange, rope[j - 1], rope[j]);

                    if (j == 9)
                    {
                        visitedPoint.Add(rope[j]);
                    }
                }
            }
        }

        private void MoveDown(int moveAmount)
        {
            for (int i = 0; i < moveAmount; i++)
            {
                rope[0] = (rope[0].Item1, rope[0].Item2 - 1);

                for (int j = 1; j < rope.Count; j++)
                {
                    var verticalRange = rope[j - 1].Item2 - rope[j].Item2;
                    var horizontalRange = rope[j - 1].Item1 - rope[j].Item1;

                    rope[j] = GetNodeNewPosition(horizontalRange, verticalRange, rope[j - 1], rope[j]);

                    if (j == 9)
                    {
                        visitedPoint.Add(rope[j]);
                    }
                }
            }
        }

        private static (int, int) GetNodeNewPosition(int horizontalRange, int verticalRange, (int, int) previousNode,
            (int, int) nextNode)
        {
            if (verticalRange > 1 && horizontalRange > 1)
            {
                nextNode = (nextNode.Item1 + 1, nextNode.Item2 + 1);
            }
            else if (verticalRange > 1 && horizontalRange < -1)
            {
                nextNode = (nextNode.Item1 - 1, nextNode.Item2 + 1);
            }
            else if (verticalRange < -1 && horizontalRange > 1)
            {
                nextNode = (nextNode.Item1 + 1, nextNode.Item2 - 1);
            }
            else if (verticalRange < -1 && horizontalRange < -1)
            {
                nextNode = (nextNode.Item1 - 1, nextNode.Item2 - 1);
            }
            else if (horizontalRange > 1)
            {
                nextNode = (previousNode.Item1 - 1, previousNode.Item2);
            }
            else if (horizontalRange < -1)
            {
                nextNode = (previousNode.Item1 + 1, previousNode.Item2);
            }
            else if (verticalRange > 1)
            {
                nextNode = (previousNode.Item1, previousNode.Item2 - 1);
            }
            else if (verticalRange < -1)
            {
                nextNode = (previousNode.Item1, previousNode.Item2 + 1);
            }

            return nextNode;
        }


        private static void DrawRope()
        {
            var coord = rope.OrderBy(x => x.Item1).ThenBy(x => x.Item2);
            var maxCoord = coord.Last();
            var minCoord = coord.First();

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 16; i >= -8; i--)
            {
                for (int j = -15; j <= 15; j++)
                {
                    if (rope.Contains((j, i)))
                    {
                        Console.Write(" *");
                    }
                    else if (i == 0 && j == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" @");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(" .");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}