using System.ComponentModel;

namespace TextFileStatisticProcessor
{
    public class Copy : Operation
    {
        public Copy(string inputFileName, string outputFileName, BackgroundWorker worker) : base(inputFileName, outputFileName, worker)
        {

        }

        public override void EngageOperation()
        {
            var content = GetFileContents();
            WriteProcessedContent(content);
        }
    }
}
