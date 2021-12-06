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

            Dictionary<int, long> fishCountByAgeDictionary = CreateDictionaryFromSchoolOfFish(schoolOfFish);

            for (int i = 0; i < 256; i++)
            {
                long yesterdayZeroAgeFish = fishCountByAgeDictionary[0];
                CycleOneDay(fishCountByAgeDictionary);
                SpawnMoreFish(fishCountByAgeDictionary, yesterdayZeroAgeFish);
            }

            long fishCount = CountFishInDictionary(fishCountByAgeDictionary);
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

        private static Dictionary<int, long> CreateDictionaryFromSchoolOfFish(List<int> schoolOfFish)
        {
            Dictionary<int, long> fishCountByAgeDictionary = new();
            for (int i = 0; i < MaxAge + 1; i++)
            {
                fishCountByAgeDictionary.Add(i, 0);
            }

            foreach (var fish in schoolOfFish)
            {
                fishCountByAgeDictionary[fish] += 1;
            }

            return fishCountByAgeDictionary;
        }

        private void CycleOneDay(Dictionary<int, long> fishCountByAgeDictionary)
        {
            long yesterdayZeroDayFish = fishCountByAgeDictionary[0];
            for (int i = 0; i < MaxAge; i++)
            {
                fishCountByAgeDictionary[i] = fishCountByAgeDictionary[i + 1];
            }
            fishCountByAgeDictionary[6] += yesterdayZeroDayFish;
        }

        private void SpawnMoreFish(Dictionary<int, long> fishCountByAgeDictionary, long numberOfFishToSpawn)
            => fishCountByAgeDictionary[MaxAge] = numberOfFishToSpawn;

        private static long CountFishInDictionary(Dictionary<int, long> fishCountByAgeDictionary)
        {
            long fishCount = 0;
            foreach (var keyValuePair in fishCountByAgeDictionary)
            {
                fishCount += keyValuePair.Value;
            }

            return fishCount;
        }
    }
}
