using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TextFileStatisticProcessor
{
    public class Operation : IOperation
    {
        public Operation(string inputFileName, string outputFileName, BackgroundWorker worker)
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
            Worker = worker;
        }

        public string InputFileName { get; set; }

        public string OutputFileName { get; set; }

        public BackgroundWorker Worker { get; set; }

        public FileDiagnostic Diagnostic { get; set; }

        /// <summary>
        /// Method that is being overriden depending on the operation of choice
        /// </summary>
        public virtual void EngageOperation()
        { }

        /// <summary>
        /// Gets the file contents as string from the input file
        /// </summary>
        /// <returns>string content of input file</returns>
        protected string GetFileContents()
        {
            string fileContents = string.Empty;
            using (StreamReader sr = new StreamReader(InputFileName))
            {
                fileContents = sr.ReadToEnd();
            }
            return fileContents;
        }

        /// <summary>
        /// Method writes result string from operation to the desired output text file.
        /// </summary>
        /// <param name="content">Result string from one of the operations</param>
        protected void WriteProcessedContent(string content)
        {
            double percentage;
            using (StreamWriter sw = new StreamWriter(OutputFileName))
            {
                for (int i = 0; i < content.Length; i++)
                {
                    sw.Write(content[i]);
                    percentage = ((double)(i + 1) / (double)content.Length) * 100;
                    Worker?.ReportProgress((int)percentage);
                    Thread.Sleep(1);
                }
            }

            DiagnoseResult();
        }

        /// <summary>
        /// Method calls diagnostic operation on the chosen operation and fills out
        /// the object for writing down the result of diagnostic operations.
        /// </summary>
        private void DiagnoseResult()
        {
            FileDiagnostic diagnostic = new FileDiagnostic();
            diagnostic.DiagnoseFile(OutputFileName);
            Diagnostic = diagnostic;
        }
    }
}
