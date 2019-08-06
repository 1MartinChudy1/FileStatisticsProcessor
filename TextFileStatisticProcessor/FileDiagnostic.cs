using System.IO;

namespace TextFileStatisticProcessor
{
    public class FileDiagnostic
    {
        public int SentenceCount { get; set; }

        public int WordCount { get; set; }

        public int CharacterCount { get; set; }

        public int RowCount { get; set; }

        public void DiagnoseFile(string filePath)
        {
            string content;
            using (StreamReader sr = new StreamReader(filePath))
            {
                content = sr.ReadToEnd();
            }

            SentenceCount = GetSentenceCount(content);
            RowCount = GetRowCount(filePath);
            CharacterCount = GetCharacterCount(content);
            WordCount = GetWordCount(content);
        }

        private int GetSentenceCount(string content)
        {
            int counter = 0;
            char previousCharacter = 'S';
            foreach (char c in content)
            {
                if (IsSentenceEnding(c) && char.IsLetterOrDigit(previousCharacter))
                    counter++;

                previousCharacter = c;
            }

            return counter;
        }

        private int GetRowCount(string filePath)
        {
            var lineCount = File.ReadAllLines(filePath);
            return lineCount.Length;
        }

        private int GetCharacterCount(string content)
            => content.Length;
        

        public int GetWordCount(string content)
        {
            int wordCount = 0, index = 0;

            // skip whitespace until first word
            while (index < content.Length && char.IsWhiteSpace(content[index]))
                index++;

            while (index < content.Length)
            {
                // check if current char is part of a word
                while (index < content.Length && !char.IsWhiteSpace(content[index]))
                    index++;

                wordCount++;

                // skip whitespace until next word
                while (index < content.Length && char.IsWhiteSpace(content[index]))
                    index++;
            }

            return wordCount;
        }

        private bool IsSentenceEnding(char c)
            => (c == '.' || c == '?' || c == '!');
    }
}
