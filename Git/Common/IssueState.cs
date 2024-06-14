using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Git.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IssueState
    {
        open,
        closed
    }
}
