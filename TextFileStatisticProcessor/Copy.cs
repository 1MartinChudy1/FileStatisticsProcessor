namespace TextFileStatisticProcessor
{
    public class Copy : Operation
    {
        public Copy(string inputFileName, string outputFileName) : base(inputFileName, outputFileName)
        {

        }

        public override void EngageOperation()
        {
            var content = GetFileContents();
            WriteProcessedContent(content);
        }
    }
}
