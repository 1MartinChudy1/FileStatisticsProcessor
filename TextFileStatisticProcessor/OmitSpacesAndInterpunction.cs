using System.ComponentModel;
using System.Globalization;
using System.Text;

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
        public override void EngageOperation()
        {
            string content = GetFileContents();
            string result = EngageOmitSpacesAndInterpunction(content);
            WriteProcessedContent(result);
        }

        /// <summary>
        /// Method omits empty spaces and interpunction from the data from input file
        /// and sets camel case syntax to the output. 
        /// </summary>
        /// <param name="content">Content of the input file</param>
        /// <returns>content from input file without empty spaces and interpuction in camel case format</returns>
        private string EngageOmitSpacesAndInterpunction(string content)
        {
            StringBuilder result = new StringBuilder();
            _ = content.ToLower();
            content = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(content);

            for (int i = 0; i < content.Length; i++)
            {
                if (IsValidCharacter(content[i]))
                    result.Append(content[i]);
            }

            return result.ToString();
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
