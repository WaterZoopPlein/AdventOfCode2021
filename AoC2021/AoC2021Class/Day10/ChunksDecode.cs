namespace AoC2021Class.Day10
{
    public class ChunksDecode
    {
        private static Dictionary<char, char> OpenCloseBracketPair = new Dictionary<char, char>
        {
            {'(', ')' },
            {'[', ']' },
            {'{', '}' },
            {'<', '>' },
        };

        public static DecodeResult DecodeChunks(string input)
        {
            Stack<char> chunkStack = new();

            foreach (var chunk in input)
            {
                if (IsOpenBracket(chunk))
                {
                    chunkStack.Push(chunk);
                }
                else if (IsCloseBracket(chunk))
                {
                    if (chunk == OpenCloseBracketPair[chunkStack.Peek()])
                    {
                        chunkStack.Pop();
                    }
                    else
                    {
                        return new DecodeResult(ChunkTypes.Corrupted, chunk.ToString());
                    }
                }
            }

            var autocomplete = "";
            while (chunkStack.TryPop(out char poppedChunk))
            {
                autocomplete += OpenCloseBracketPair[poppedChunk];
            }
            return new DecodeResult(ChunkTypes.Incomplete, autocomplete);
        }

        private static bool IsOpenBracket(char input)
            => input == '[' || input == '(' || input == '{' || input == '<';

        private static bool IsCloseBracket(char input)
            => input == ']' || input == ')' || input == '}' || input == '>';
    }
}
