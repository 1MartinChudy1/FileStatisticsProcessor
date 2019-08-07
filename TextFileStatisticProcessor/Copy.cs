using System.ComponentModel;

namespace TextFileStatisticProcessor
{
    public class Copy : Operation
    {
        /// <summary>
        /// Copy operation constructor which inherits from Operation base class.
        /// </summary>
        /// <param name="inputFileName">Input file path</param>
        /// <param name="outputFileName">Output file path</param>
        /// <param name="worker">Background worker object</param>
        public Copy(string inputFileName, string outputFileName, BackgroundWorker worker) : base(inputFileName, outputFileName, worker)
        {

        }

        /// <summary>
        /// Overriden method which gets the data from GetFileContents method and passes them
        /// to WriteProcessedContent method
        /// </summary>
        public override void EngageOperation()
        {
            var content = GetFileContents();
            WriteProcessedContent(content);
        }
    }
}
