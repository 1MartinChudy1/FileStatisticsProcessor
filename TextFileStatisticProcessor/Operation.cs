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
            double percentage;
            using (StreamWriter sw = new StreamWriter(OutputFileName))
            {
                for (int i = 0; i < content.Length; i++)
                {
                    sw.Write(content[i]);
                    percentage = ((double)(i + 1) / (double)content.Length) * 100;
                    Worker.ReportProgress((int)percentage);
                    Thread.Sleep(1);
                }
            }

            DiagnoseResult();
        }

        public void DiagnoseResult()
        {
            FileDiagnostic diagnostic = new FileDiagnostic();
            diagnostic.DiagnoseFile(OutputFileName);
            Diagnostic = diagnostic;
        }
    }
}
