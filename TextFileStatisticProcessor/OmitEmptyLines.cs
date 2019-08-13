using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace TextFileStatisticProcessor
{
    public class OmitEmptyLines : Operation
    {
        /// <summary>
        /// Omit empty lines operation constructor which inherits from Operation base class.
        /// </summary>
        /// <param name="inputFileName">Input file path</param>
        /// <param name="outputFileName">Output file path</param>
        /// <param name="worker">Background worker object</param>
        public OmitEmptyLines(string inputFileName, string outputFileName, BackgroundWorker worker) : base(inputFileName, outputFileName, worker)
        {
        }

        /// <summary>
        /// Overriden method which gets the data from GetFileContents method and passes them
        /// to EngageOmitEmptyLines method and the result to WriteProcessedContent method
        /// </summary>
        /// <returns>task object</returns>
        public override Task EngageOperation()
        {
            string[] content = GetFileContents();
            string[] result = EngageOmitEmptyLines(content);
            return WriteProcessedContent(result);
        }
        
        /// <summary>
        /// Method omits empty lines from the data from input file. 
        /// </summary>
        /// <param name="content">Content of the input file</param>
        /// <returns>content from input file empty lines</returns>
        private string[] EngageOmitEmptyLines(string[] content)
        {
            List<string> result = new List<string>();
            foreach (string line in content)
            {
                if (line == "\r\n")
                    continue;
                result.Add(line);
            }
            return result.ToArray();
        }
    }
}
