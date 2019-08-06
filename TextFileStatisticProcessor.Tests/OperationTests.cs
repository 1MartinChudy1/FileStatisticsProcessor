using System.ComponentModel;
using System.IO;
using Xunit;

namespace TextFileStatisticProcessor.Tests
{
    public class OperationIntegrationTests
    {
        private BackgroundWorker _worker = null;
        private readonly string _inputFile = Path.GetFullPath("..\\..\\..\\TestFiles\\input.txt");
        private readonly string _outputFile = Path.GetFullPath("..\\..\\..\\TestFiles\\output.txt");
        private readonly string _diagnosticFile = Path.GetFullPath("..\\..\\..\\TestFiles\\diagnosticTest.txt");
        private readonly string _omitDiacriticsResult = Path.GetFullPath("..\\..\\..\\TestFiles\\omitDiacriticsResult.txt");
        private readonly string _omitEmptyLinesResult = Path.GetFullPath("..\\..\\..\\TestFiles\\omitEmptyLinesResult.txt");
        private readonly string _omitSpacesAndInterpunctionResult = Path.GetFullPath("..\\..\\..\\TestFiles\\omitSpacesAndInterpunctionResult.txt");

        [Fact]
        public void CopyTest()
        {
            // Arrange
            IOperation operation = new Copy(_inputFile, _outputFile, _worker);
            
            // Act
            operation.EngageOperation();

            // Assert
            string input = GetFileContent(_inputFile);
            string output = GetFileContent(_outputFile);
            Assert.Equal(input, output);
        }

        [Fact]
        public void OmitDiacriticsTest()
        {
            // Arrange
            IOperation operation = new OmitDiacritics(_inputFile, _outputFile, _worker);

            // Act
            operation.EngageOperation();

            // Assert
            string output = GetFileContent(_outputFile);
            string result = GetFileContent(_omitDiacriticsResult);
            Assert.Equal(result, output);
        }

        [Fact]
        public void OmitEmptyLines()
        {
            // Arrange
            IOperation operation = new OmitEmptyLines(_inputFile, _outputFile, _worker);

            // Act
            operation.EngageOperation();

            // Assert
            string output = GetFileContent(_outputFile);
            string result = GetFileContent(_omitEmptyLinesResult);
            Assert.Equal(result, output);
        }

        [Fact]
        public void OmitSpacesAndInterpunction()
        {
            // Arrange
            IOperation operation = new OmitSpacesAndInterpunction(_inputFile, _outputFile, _worker);
            
            // Act
            operation.EngageOperation();

            // Assert
            string output = GetFileContent(_outputFile);
            string result = GetFileContent(_omitSpacesAndInterpunctionResult);
            Assert.Equal(result, output);
        }

        [Fact]
        public void DiagnosticsTest()
        {
            // Arrange
            const int wordCount = 12;
            const int rowCount = 2;
            const int sentenceCount = 3;
            const int characterCount = 63;
            FileDiagnostic diagnostic = new FileDiagnostic();

            // Act
            diagnostic.DiagnoseFile(_diagnosticFile);

            // Assert
            Assert.NotNull(diagnostic);
            Assert.Equal(wordCount, diagnostic.WordCount);
            Assert.Equal(sentenceCount, diagnostic.SentenceCount);
            Assert.Equal(rowCount, diagnostic.RowCount);
            Assert.Equal(characterCount, diagnostic.CharacterCount);
        }


        private string GetFileContent(string path)
        {
            string input = string.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                input = sr.ReadToEnd();
            }

            return input;
        }
    }
}
