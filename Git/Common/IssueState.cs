using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Git.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IssueState
    {
        [JsonPropertyName("open")]
        open,
        [JsonPropertyName("closed")]
        closed
    }
}
