namespace TextFileStatisticProcessor
{
    interface IOperation
    {
        string InputFileName { get; set; }

        string OutputFileName { get; set; }
        FileDiagnostic Diagnostic { get; set; }

        void EngageOperation();
    }
}
