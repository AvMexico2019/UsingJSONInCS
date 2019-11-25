using System.Runtime.Serialization;

namespace UsingJSONInCS
{
    [DataContract]
    public class MyDetail
    {
        [DataMember(Name = "FirstName", Order = 0)]
        public string FirstName { get; set; }

        [DataMember(Name = "LastName", Order = 0)]
        public string LastName { get; set; }

        public string ToString()
        {
            return "Name: " + FirstName + ", Description: " + LastName;
        }
    }
}
