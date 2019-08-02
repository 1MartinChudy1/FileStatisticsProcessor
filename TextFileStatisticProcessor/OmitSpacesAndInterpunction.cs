using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileStatisticProcessor
{
    public class OmitSpacesAndInterpunction : Operation
    {
        public OmitSpacesAndInterpunction(string inputFileName, string outputFileName) : base(inputFileName, outputFileName)
        {
        }

        public override void EngageOperation()
        {
            string content = GetFileContents();
            string result = EngageOmitSpacesAndInterpunction();
            WriteProcessedContent(result);
        }

        private string EngageOmitSpacesAndInterpunction()
        {
            throw new NotImplementedException();
        }
    }
}
