using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace TextFileStatisticProcessor
{
    public class OmitSpacesAndInterpunction : Operation
    {
        /// <summary>
        /// Omit spaces and interpunction operation constructor which inherits from Operation base class.
        /// </summary>
        /// <param name="inputFileName">Input file path</param>
        /// <param name="outputFileName">Output file path</param>
        /// <param name="worker">Background worker object</param>
        public OmitSpacesAndInterpunction(string inputFileName, string outputFileName, BackgroundWorker worker) : base(inputFileName, outputFileName, worker)
        {
        }

        /// <summary>
        /// Overriden method which gets the data from GetFileContents method and passes them
        /// to EngageOmitSpacesAndInterpunction method and the result to WriteProcessedContent
        /// method
        /// </summary>
        public override Task EngageOperation()
        {
            string[] content = GetFileContents();
            string[] result = EngageOmitSpacesAndInterpunction(content);
            return WriteProcessedContent(result);
        }

        /// <summary>
        /// Method omits empty spaces and interpunction from the data from input file
        /// and sets camel case syntax to the output. 
        /// </summary>
        /// <param name="content">Content of the input file</param>
        /// <returns>content from input file without empty spaces and interpuction in camel case format</returns>
        private string[] EngageOmitSpacesAndInterpunction(string[] content)
        {
            List<string> resultList = new List<string>();

            foreach (string line in content)
            {
                string tmp;
                StringBuilder result = new StringBuilder();
                tmp = line.ToLower();
                tmp = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(line);
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (IsValidCharacter(tmp[i]))
                        result.Append(tmp[i]);
                }
                resultList.Add(result.ToString());
            }

            return resultList.ToArray();
        }

        /// <summary>
        /// Checks if character is not empty space or interpunction.
        /// </summary>
        /// <param name="c">character from input file</param>
        /// <returns>True or false value</returns>
        private bool IsValidCharacter(char c)
            => (c != ' ' && c != '.' && c != ',' && c != '?' && c != '!') ? true : false;
        
    }
}
