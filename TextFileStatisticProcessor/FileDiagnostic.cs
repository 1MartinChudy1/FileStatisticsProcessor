using System.IO;

namespace TextFileStatisticProcessor
{
    public class FileDiagnostic
    {
        public int SentenceCount { get; set; }

        public int WordCount { get; set; }

        public int CharacterCount { get; set; }

        public int RowCount { get; set; }

        /// <summary>
        /// Method engages the diagnostic operations on the chosen output file after the operation is done.
        /// </summary>
        /// <param name="filePath">path of chosen output file</param>
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

        /// <summary>
        /// Method provides the number of sentences in output file.
        /// </summary>
        /// <param name="content">content from output file</param>
        /// <returns>int value of the sentence count</returns>
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

        /// <summary>
        /// Method provides the number of lines in output file.
        /// </summary>
        /// <param name="filePath">path to output file</param>
        /// <returns>int value of the line count</returns>
        private int GetRowCount(string filePath)
        {
            var lineCount = File.ReadAllLines(filePath);
            return lineCount.Length;
        }

        /// <summary>
        /// Method provides the number of characters(letters) in output file.
        /// </summary>
        /// <param name="content">content from output file</param>
        /// <returns>int value of the character count</returns>
        private int GetCharacterCount(string content)
            => content.Length;
        
        /// <summary>
        /// Method provides the number of words in output file.
        /// </summary>
        /// <param name="content">content from output file</param>
        /// <returns>int value of the word count</returns>
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

        /// <summary>
        /// Method checks whether the character is a sentence ending or not.
        /// </summary>
        /// <param name="c">character from output file string</param>
        /// <returns>True or false value</returns>
        private bool IsSentenceEnding(char c)
            => (c == '.' || c == '?' || c == '!');
    }
}
