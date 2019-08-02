using System.Globalization;
using System.Text;

namespace TextFileStatisticProcessor
{
    public class OmitDiacritics : Operation
    {
        public OmitDiacritics(string inputFileName, string outputFileName) : base(inputFileName, outputFileName)
        {
        }

        public override void EngageOperation()
        {
            string content = GetFileContents();
            string result = EngageOmitDiacritics(content);
            WriteProcessedContent(result);
        }

        public string EngageOmitDiacritics(string content)
        {
            content = content.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char character in content)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(character);
                }
            }

            return sb.ToString();
        }
    }
}
