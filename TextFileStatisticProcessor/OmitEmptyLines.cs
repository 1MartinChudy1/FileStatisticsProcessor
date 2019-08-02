using System;
using System.Text;

namespace TextFileStatisticProcessor
{
    public class OmitEmptyLines : Operation
    {
        public OmitEmptyLines(string inputFileName, string outputFileName) : base(inputFileName, outputFileName)
        {
        }

        public override void EngageOperation()
        {
            string content = GetFileContents();
            string result = EngageOmitEmptyLines(content);
            WriteProcessedContent(result);
        }

        private string EngageOmitEmptyLines(string content)
        {
            var splittedShit = content.Split('\n');

            StringBuilder sb = new StringBuilder();

            foreach (string item in splittedShit)
            {
                if (item != "\r")
                    sb.Append(item);
            }

            return sb.ToString();
        }
    }
}
