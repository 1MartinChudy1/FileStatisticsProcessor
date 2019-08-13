using System.Threading.Tasks;

namespace TextFileStatisticProcessor
{
    public interface IOperation
    {
        string InputFileName { get; set; }

        string OutputFileName { get; set; }
        FileDiagnostic Diagnostic { get; set; }

        Task EngageOperation();
    }
}
