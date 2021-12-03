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

        public static List<string> ConvertInputTextToStringList(string path, char delimiter)
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
    }
}