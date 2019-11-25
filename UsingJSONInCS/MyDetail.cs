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

        public MyDetail(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public string ToString()
        {
            return "Name: " + FirstName + ", Description: " + LastName;
        }
    }
}
