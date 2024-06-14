using Git.Common;
using Git.Error;
using Git.Models;

namespace Git.Interfaces
{
    public interface IIOClient
    {
        Either<IError, bool> Export(string filePath, IEnumerable<ImportExportIssue> issues);
        Either<IError, IEnumerable<ImportExportIssue>> Import(string filePath);
    }
}