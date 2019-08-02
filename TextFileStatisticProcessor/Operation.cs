using System;
using System.IO;
using System.Windows.Forms;

namespace TextFileStatisticProcessor
{
    public class Operation : IOperation
    {
        public Operation(string inputFileName, string outputFileName)
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
        }

        public string InputFileName { get; set; }

        public string OutputFileName { get; set; }

        public virtual void EngageOperation()
        { }

        protected string GetFileContents()
        {
            string fileContents = string.Empty;
            using (StreamReader sr = new StreamReader(InputFileName))
            {
                fileContents = sr.ReadToEnd();
            }   
            
            return fileContents;
        }

        protected void WriteProcessedContent(string content)
        {
            using (StreamWriter sw = new StreamWriter(OutputFileName))
            {
                sw.Write(content);
            }
        }
    }
}
