using System.ComponentModel;
using System.Text;
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
        public override Task EngageOperation()
        {
            string[] content = GetFileContents();
            //string[] result = EngageOmitEmptyLines(content);
            //return WriteProcessedContent(result);
            return Task.CompletedTask;
        }
        
        /// <summary>
        /// Method omits empty lines from the data from input file. 
        /// </summary>
        /// <param name="content">Content of the input file</param>
        /// <returns>content from input file empty lines</returns>
        private string EngageOmitEmptyLines(string[] content)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string item in content)
            {
                if (item != "\r")
                    sb.Append(item.Contains("\r") ? $"{item}\n" : item);
            }

            return sb.ToString();
        }
    }
}
