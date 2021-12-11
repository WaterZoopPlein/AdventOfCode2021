namespace AoC2021Core
{
    public class ReadInput
    {
        public static List<int> ConvertInputTextToIntList(string path)
        {
            List<int> outputList = new();

            try
            {
                var sr = new StreamReader(path);

                string? line;

                while ((line = sr.ReadLine()) != null) outputList.Add(int.Parse(line));
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred whilst loading {Path.GetFullPath(path)}.");
                Console.WriteLine(e.Message);
            }

            return outputList;
        }

        public static List<long> ConvertInputTextToLongIntList(string path)
        {
            List<long> outputList = new();

            try
            {
                var sr = new StreamReader(path);

                string? line;

                while ((line = sr.ReadLine()) != null)
                {
                    outputList.Add(long.Parse(line));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred whilst loading {Path.GetFullPath(path)}.");
                Console.WriteLine(e.Message);
            }

            return outputList;
        }

        public static List<string> ConvertInputTextToStringList(string path, string delimiter)
        {
            List<string> outputList = new();

            try
            {
                using var sr = new StreamReader(path);
                outputList = new List<string>();

                var textOutput = sr.ReadToEnd();

                outputList = textOutput.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred whilst loading {Path.GetFullPath(path)}.");
                Console.WriteLine(e.Message);
            }

            return outputList;
        }

        public static IEnumerable<int> ConvertStringToIntIEnum(string str, char delimiter)
        {
            if (string.IsNullOrEmpty(str))
                yield break;

            foreach (var s in str.Split(delimiter))
            {
                if (int.TryParse(s, out int num))
                    yield return num;
            }
        }

        public static int[,] ConvertInputStringListTo2DArray(List<string> input)
        {
            int[,] output2DArray = new int[input.Count, input[0].Length];
            for (int lineNumber = 0; lineNumber < input.Count; lineNumber++)
            {
                string line = input[lineNumber];
                for (int rowNumber = 0; rowNumber < line.Length; rowNumber++)
                {
                    char digitChar = line[rowNumber];
                    output2DArray[lineNumber, rowNumber] = (int)char.GetNumericValue(digitChar);
                }
            }
            return output2DArray;
        }

    }
}