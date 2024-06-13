using Git.Common;
using Git.Error;
using Git.Interfaces;
using Git.Models;
using Newtonsoft.Json;

namespace Git.Clients
{
    public class IOClient : IIOClient
    {
        Either<IError, bool> IIOClient.Export(string filePath, IEnumerable<ImportExportIssue> issues)
        {
            try
            {
                var data = JsonConvert.SerializeObject(issues);
                File.WriteAllText(filePath, data);
                return Either<IError, bool>.Success(true);
            }
            catch(Exception ex)
            {
                return Either<IError, bool>.Error(new IOError(ex.Message));
            }
        }

        Either<IError, IEnumerable<ImportExportIssue>> IIOClient.Import(string filePath)
        {
            try
            {
                var text = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<IEnumerable<ImportExportIssue>>(text);
                return Either<IError, IEnumerable<ImportExportIssue>>.Success(data ?? Enumerable.Empty<ImportExportIssue>());
            }
            catch(Exception ex)
            {
                return Either<IError, IEnumerable<ImportExportIssue>>.Error(new IOError(ex.Message));
            }            
        }
    }
}
