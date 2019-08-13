using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace TextFileStatisticProcessor
{
    public class OmitDiacritics : Operation
    {
        /// <summary>
        /// Omit diacritics operation constructor which inherits from Operation base class.
        /// </summary>
        /// <param name="inputFileName">Input file path</param>
        /// <param name="outputFileName">Output file path</param>
        /// <param name="worker">Background worker object</param>
        public OmitDiacritics(string inputFileName, string outputFileName, BackgroundWorker worker) : base(inputFileName, outputFileName, worker)
        {
        }

        /// <summary>
        /// Overriden method which gets the data from GetFileContents method and passes them
        /// to EngageOmitDiacritics method and the result to WriteProcessedContent method
        /// </summary>
        /// <returns>task object</returns>
        public override Task EngageOperation()
        {
            string[] content = GetFileContents();
            string[] result = EngageOmitDiacritics(content);
            return WriteProcessedContent(result);
        }

        /// <summary>
        /// Method omits diacritics from the data from input file. 
        /// </summary>
        /// <param name="content">Content of the input file</param>
        /// <returns>content from input file without diacritics</returns>
        private string[] EngageOmitDiacritics(string[] content)
        {
            List<string> result = new List<string>();
            List<string> changedFormat = new List<string>();
            foreach (string line in content)
            {
                changedFormat.Add(line.Normalize(NormalizationForm.FormD));
            }

            foreach (string line in changedFormat.ToArray())
            {
                StringBuilder sb = new StringBuilder();
                foreach (char character in line)
                {

                    if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(character);
                    }
                }
                result.Add(sb.ToString());
            }

            return result.ToArray();
        }
    }
}
