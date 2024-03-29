﻿using System.ComponentModel;
using System.Threading.Tasks;

namespace TextFileStatisticProcessor
{
    public class Copy : Operation
    {
        /// <summary>
        /// Copy operation constructor which inherits from Operation base class.
        /// </summary>
        /// <param name="inputFileName">Input file path</param>
        /// <param name="outputFileName">Output file path</param>
        /// <param name="worker">Background worker object</param>
        public Copy(string inputFileName, string outputFileName, BackgroundWorker worker) : base(inputFileName, outputFileName, worker)
        {

        }

        /// <summary>
        /// Overriden method which gets the data from GetFileContents method and passes them
        /// to WriteProcessedContent method
        /// </summary>
        /// <returns>task object</returns>
        public override Task EngageOperation()
        {
            var content = GetFileContents();
            return WriteProcessedContent(content);
        }
    }
}
