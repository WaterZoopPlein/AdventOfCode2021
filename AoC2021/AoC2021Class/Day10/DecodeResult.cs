namespace AoC2021Class.Day10
{
    public class DecodeResult
    {
        internal DecodeResult(ChunkTypes chunkTypes, string info)
        {
            ChunkTypes = chunkTypes;
            Info = info;
        }

        public ChunkTypes ChunkTypes { get; }
        public string Info { get; }
    }
}
