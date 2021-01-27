using System.Collections.Generic;
using System.Text.Json.Serialization;
public class YeelightCommand
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("method")]
    public string Method { get; set; }
    [JsonPropertyName("params")]
    public IList<object> MethodParams { get; set; } = new List<object>();
}