using System.ComponentModel;
using System.Text;

namespace TextFileStatisticProcessor
{
    public class OmitEmptyLines : Operation
    {
        public OmitEmptyLines(string inputFileName, string outputFileName, BackgroundWorker worker) : base(inputFileName, outputFileName, worker)
        {
            Diagnostic = this.Diagnostic;
        }

        public new FileDiagnostic Diagnostic { get; set; }

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
