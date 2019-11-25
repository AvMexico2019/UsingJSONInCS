using System;
using System.Runtime.Serialization;

namespace JsonSerializationTest
{
    [DataContract]
    public class SampleClass
    {
        [DataMember(Name = "description", Order = 0)]
        public string Description { get; set; }

        public SampleEnum EnumVal { get; set; }

        [DataMember(Name = "enumVal", Order = 1)]
        private string EnumValString
        {
            get { return Enum.GetName(typeof(SampleEnum), this.EnumVal); }
            set { this.EnumVal = (SampleEnum)Enum.Parse(typeof(SampleEnum), value, true); }
        }
    }
}
