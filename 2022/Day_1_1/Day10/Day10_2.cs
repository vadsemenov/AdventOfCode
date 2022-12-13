namespace Days.Day10
{
    public class Day10_2:IDay
    {
        public string Path { get; set; } = "..\\..\\Day10\\source.txt";


        public string GetAnswer()
        {
            var text = FileReader.GetTextFromFile(Path);
            return null;
        }
    }
}