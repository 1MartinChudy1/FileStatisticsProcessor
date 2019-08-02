namespace TextFileStatisticProcessor
{
    interface IOperation
    {
        string InputFileName { get; set; }

        string OutputFileName { get; set; }

        void EngageOperation();
    }
}
