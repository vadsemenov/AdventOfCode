using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Days.Day5
{
    public class Day5_1 : IDay
    {
        public string Path { get; set; } = "..\\..\\Day5\\source1.txt";

        public string GetAnswer()
        {
            var text = File.ReadAllLines(Path);

            var content = SplitHeaderAndBody(text);

            var header = content.Item1;

            var body = content.Item2;

            var operationList = GetOperationArray(body);

            var boxesStack = GetBoxesStack(header);

            var destinationStack = GetStackAfterOperation(boxesStack, operationList);

            var upperBoxes = GetStacksUpperBoxes(destinationStack);


            return upperBoxes;
        }

        private List<Stack<char>> GetStackAfterOperation(List<Stack<char>> boxesStack,
            List<(int, int, int)> operationList)
        {
            foreach (var operation in operationList)
            {
                for (int i = 0; i < operation.Item1; i++)
                {
                    boxesStack[operation.Item3 - 1].Push(boxesStack[operation.Item2 - 1].Pop());
                }
            }

            return boxesStack;
        }

        private List<Stack<char>> GetBoxesStack(string[] header)
        {
            var stackNumberString = header[header.Length - 1]
                .Split(' ')
                .Last(x => int.TryParse(x, out _));

            var stackAmount = int.Parse(stackNumberString);

            var boxesStack = new Stack<char>[stackAmount].Select(x => new Stack<char>()).ToList();

            for (var i = header.Length - 2; i >= 0; i--)
            {
                var counter = 1;
                foreach (var boxStack in boxesStack)
                {
                    var boxChar = header[i][counter];

                    if (char.IsLetter(boxChar))
                    {
                        boxStack.Push(boxChar);
                    }

                    counter += 4;
                }
            }

            return boxesStack;
        }

        private List<(int, int, int)> GetOperationArray(string[] body)
        {
            return body
                .Select(x => x.Split(' '))
                .Select(x => (int.Parse(x[1]), int.Parse(x[3]), int.Parse(x[5])))
                .ToList();
        }

        private string GetStacksUpperBoxes(List<Stack<char>> boxesStack)
        {
            var upperChars = boxesStack.Select(x => x.Pop()).ToArray();

            return string.Join("", upperChars);
        }

        private (string[], string[]) SplitHeaderAndBody(string[] text)
        {
            var headerBuilder = new StringBuilder();

            var bodyIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (string.IsNullOrEmpty(text[i]))
                {
                    bodyIndex = i + 1;
                    break;
                }

                headerBuilder.AppendLine(text[i]);
            }

            var header = headerBuilder.ToString().Split(new[] {Environment.NewLine}, StringSplitOptions.None)
                .Where(x => !string.IsNullOrEmpty(x)).ToArray();

            var body = text.Skip(bodyIndex).ToArray();

            return (header, body);
        }
    }
}