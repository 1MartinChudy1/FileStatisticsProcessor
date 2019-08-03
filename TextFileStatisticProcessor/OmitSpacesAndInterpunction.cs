using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileStatisticProcessor
{
    public class OmitSpacesAndInterpunction : Operation
    {
        public OmitSpacesAndInterpunction(string inputFileName, string outputFileName, BackgroundWorker worker) : base(inputFileName, outputFileName, worker)
        {
        }

        public override void EngageOperation()
        {
            string content = GetFileContents();
            string result = EngageOmitSpacesAndInterpunction(content);
            WriteProcessedContent(result);
        }

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

        private bool IsValidCharacter(char c)
            => (c != ' ' && c != '.' && c != ',' && c != '?' && c != '!') ? true : false;
        
    }
}
