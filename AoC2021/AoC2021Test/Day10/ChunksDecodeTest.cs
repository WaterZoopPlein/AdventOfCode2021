using Microsoft.VisualStudio.TestTools.UnitTesting;
using AoC2021Class.Day10;

namespace AoC2021Test.Day10
{
    [TestClass]
    public class ChunksDecodeTest
    {
        [TestMethod]
        [DataRow("[({(<(())[]>[[{[]{<()<>>", "}}]])})]")]
        [DataRow("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
        [DataRow("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))")]
        [DataRow("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
        [DataRow("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
        public void Incomplete_chunks(string testData, string expectedInfo)
        {
            // act
            var actual = ChunksDecode.DecodeChunks(testData);

            // assert
            Assert.AreEqual(actual.ChunkTypes, ChunkTypes.Incomplete);
            Assert.AreEqual(expectedInfo, actual.Info);
        }


        [TestMethod]
        [DataRow("{([(<{}[<>[]}>{[]{[(<()>", "}")]
        [DataRow("[[<[([]))<([[{}[[()]]]", ")")]
        [DataRow("[{[{({}]{}}([{[{{{}}([]", "]")]
        [DataRow("[<(<(<(<{}))><([]([]()", ")")]
        [DataRow("<{([([[(<>()){}]>(<<{{", ">")]
        public void Corrupted_chunks(string testData, string expectedInfo)
        {
            // act
            var actual = ChunksDecode.DecodeChunks(testData);

            // assert
            Assert.AreEqual(ChunkTypes.Corrupted, actual.ChunkTypes);
            Assert.AreEqual(expectedInfo, actual.Info);
        }

    }
}
