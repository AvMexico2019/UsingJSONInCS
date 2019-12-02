using System.Runtime.Serialization;

[DataContract]
public class Regex
{
    [DataMember(Name = "RegexDef", Order = 0)]
    public string RegexDef { get; set; }

    public string ToCadena()
    {
        return "RegexDef: " + RegexDef;
    }
}
