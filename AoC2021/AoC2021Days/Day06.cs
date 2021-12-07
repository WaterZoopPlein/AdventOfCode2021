using AoC2021Core;

namespace AoC2021Days
{
    public class Day06 : IDay
    {
        private const int MaxAge = 8;
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day06.txt", "\n");

        public void SolvePartOne()
        {
            List<int> schoolOfFish = ReadInput.ConvertStringToIntIEnum(InputList[0], ',').ToList();
            for (int i = 0; i < 80; i++)
            {
                int zeroAgeFish = CountZeroAgeFish(schoolOfFish);
                CycleOneDay(schoolOfFish);
                SpawnMoreFish(schoolOfFish, zeroAgeFish);
            }

            Console.WriteLine(schoolOfFish.Count);
        }

        public void SolvePartTwo()
        {
            List<int> schoolOfFish = ReadInput.ConvertStringToIntIEnum(InputList[0], ',').ToList();

            long[] fishCountByAgeArray = CreateArrayFromSchoolOfFish(schoolOfFish);

            for (int i = 0; i < 256; i++)
            {
                long yesterdayZeroAgeFish = fishCountByAgeArray[0];
                CycleOneDay(fishCountByAgeArray);
                SpawnMoreFish(fishCountByAgeArray, yesterdayZeroAgeFish);
            }

            long fishCount = CountFishInArray(fishCountByAgeArray);
            Console.WriteLine(fishCount);
        }

        private static int CountZeroAgeFish(List<int> schoolOfFish) => (from fish in schoolOfFish
                                                                        where fish == 0
                                                                        select fish).Count();

        private static void CycleOneDay(List<int> schoolOfFish)
        {
            for (int i = 0; i < schoolOfFish.Count; i++)
            {
                switch (schoolOfFish[i])
                {
                    case 0:
                        schoolOfFish[i] = 6;
                        break;
                    default:
                        schoolOfFish[i] -= 1;
                        break;
                }
            }
        }

        private static void SpawnMoreFish(List<int> schoolOfFish, int numberToSpawn)
        {
            for (int fishSpawnIndex = 0; fishSpawnIndex < numberToSpawn; fishSpawnIndex++)
            {
                schoolOfFish.Add(MaxAge);
            }
        }

        private static long[] CreateArrayFromSchoolOfFish(List<int> schoolOfFish)
        {
            long[] fishCountByAgeArray = new long[MaxAge + 1];

            foreach (var fish in schoolOfFish)
            {
                fishCountByAgeArray[fish] += 1;
            }

            return fishCountByAgeArray;
        }

        private void CycleOneDay(long[] fishCountByAgeArray)
        {
            long yesterdayZeroDayFish = fishCountByAgeArray[0];
            for (int i = 0; i < MaxAge; i++)
            {
                fishCountByAgeArray[i] = fishCountByAgeArray[i + 1];
            }
            fishCountByAgeArray[6] += yesterdayZeroDayFish;
        }

        private void SpawnMoreFish(long[] fishCountByAgeArray, long numberOfFishToSpawn)
            => fishCountByAgeArray[MaxAge] = numberOfFishToSpawn;

        private static long CountFishInArray(long[] fishCountByAgeArray)
        {
            long fishCount = 0;
            foreach (var value in fishCountByAgeArray)
            {
                fishCount += value;
            }
            return fishCount;
        }
    }
}
