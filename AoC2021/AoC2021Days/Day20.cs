using AoC2021Core;

namespace AoC2021Days
{
    public class Day20 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day20.txt", "\n");
        private static readonly string EnhanceAlg = InputList[0].Trim();
        private static bool[,] Image = new bool[InputList.Count - 1, InputList[1].Length];
        private static bool InfinitePixel = false;

        public void SolvePartOne()
        {
            Initialise();
            for (int i = 0; i < 2; i++)
            {
                PadImage();
                bool[,] newImage = CreateNewImage();
                Image = newImage;
                UpdateInfPixel();
            }
            int countLightPixel = CountLightPixel();
            Console.WriteLine(countLightPixel);
        }

        public void SolvePartTwo()
        {
            for (int i = 0; i < 48; i++)
            {
                PadImage();
                bool[,] newImage = CreateNewImage();
                Image = newImage;
                UpdateInfPixel();
            }
            int countLightPixel = CountLightPixel();
            Console.WriteLine(countLightPixel);
        }

        private void Initialise()
        {
            for (int lineNo = 0; lineNo < InputList.Count - 1; lineNo++)
            {
                for (int rowNo = 0; rowNo < InputList[1].Length; rowNo++)
                {
                    Image[lineNo, rowNo] = InputList[lineNo + 1][rowNo] == '#' ? true : false;
                }
            }
        }

        private void PadImage()
        {
            var lineNo = Image.GetLength(0);
            var rowNo = Image.GetLength(1);
            var expandedImage = new bool[lineNo + 2, rowNo + 2];

            if (InfinitePixel)
            {
                for (int i = 0; i < expandedImage.GetLength(0); i++)
                {
                    for (int j = 0; j < expandedImage.GetLength(1); j++)
                    {
                        expandedImage[i, j] = true;
                    }
                }
            }

            for (int i = 1; i < lineNo + 1; i++)
            {
                for (int j = 1; j < rowNo + 1; j++)
                {
                    expandedImage[i, j] = Image[i - 1, j - 1];
                }
            }

            Image = expandedImage;
        }

        private bool[,] CreateNewImage()
        {
            var lineNo = Image.GetLength(0);
            var rowNo = Image.GetLength(1);
            var newImage = new bool[lineNo, rowNo];
            for (int currentLine = 0; currentLine < lineNo; currentLine++)
            {
                for (int currentCol = 0; currentCol < rowNo; currentCol++)
                {
                    int binaryInt = GetEnhancementIndex(currentLine, currentCol);

                    newImage[currentLine, currentCol] = EnhanceAlg[binaryInt] == '#';
                }
            }

            return newImage;
        }

        private static int GetEnhancementIndex(int currentLine, int currentCol)
        {
            var lineNo = Image.GetLength(0);
            var rowNo = Image.GetLength(1);
            string binaryString = "";
            for (int lineOffset = -1; lineOffset < 2; lineOffset++)
            {
                for (int colOffset = -1; colOffset < 2; colOffset++)
                {
                    if (currentLine + lineOffset < 0 || currentLine + lineOffset >= lineNo
                        || currentCol + colOffset < 0 || currentCol + colOffset >= rowNo)
                    {
                        binaryString += InfinitePixel ? '1' : '0';
                        continue;
                    }
                    binaryString += Image[currentLine + lineOffset, currentCol + colOffset] ? '1' : '0';
                }
            }
            int binaryInt = Convert.ToInt32(binaryString, 2);
            return binaryInt;
        }

        private void UpdateInfPixel()
        {
            if (!InfinitePixel)
            {
                InfinitePixel = EnhanceAlg[0] == '#';
            }
            else
            {
                InfinitePixel = EnhanceAlg[511] == '#';
            }
        }

        private int CountLightPixel()
        {
            int count = 0;
            var lineNo = Image.GetLength(0);
            var rowNo = Image.GetLength(1);
            for (int i = 0; i < lineNo; i++)
            {
                for (int j = 0; j < rowNo; j++)
                {
                    count += Image[i, j] ? 1 : 0;
                }
            }
            return count;
        }

    }
}