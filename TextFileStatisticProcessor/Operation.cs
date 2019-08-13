using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

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
        /// <returns>task object</returns>
        public virtual Task EngageOperation()
        { return Task.CompletedTask; }

        /// <summary>
        /// Gets the file contents as string from the input file
        /// </summary>
        /// <returns>string content of input file</returns>
        protected string[] GetFileContents()
        {
            string fileContents = string.Empty;
            List<string> stringArray = new List<string>();
            using (StreamReader sr = new StreamReader(InputFileName))
            {
                while ((fileContents = sr.ReadLine()) != null)
                {
                    stringArray.Add(fileContents + "\r\n");
                }
            }
            stringArray[stringArray.Count - 1] = stringArray[stringArray.Count - 1].Replace(Environment.NewLine, string.Empty);
            return stringArray.ToArray();
        }

        /// <summary>
        /// Method writes result string from operation to the desired output text file.
        /// </summary>
        /// <param name="content">Result string from one of the operations</param>
        protected async Task WriteProcessedContent(string[] c)
        {
            double percentage;
            int previousPercentage = 0;
            using (StreamWriter sw = new StreamWriter(OutputFileName))
            {
                await Task.Run((Action)(() =>
                {
                    for (int i = 0; i < c.Length; i++)
                    {
                        sw.Write(c[i]);
                        percentage = ((double)(i + 1) / (double)c.Length) * 100;
                        if ((int)percentage > previousPercentage)
                        {
                            Worker?.ReportProgress((int)percentage);
                            previousPercentage++;
                        }
                    }
                }));
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
