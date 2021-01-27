using System.Collections.Generic;

public class YeelightInfo
{
    public YeelightInfo()
    {
        Result = new List<string>();
        Params = new Dictionary<string, object>();
    }
    public int? Id { get; set; }
    public IEnumerable<string> Result { get; set; }

    public string Method { get; set; }
    public IDictionary<string, object> Params { get; set; }

}