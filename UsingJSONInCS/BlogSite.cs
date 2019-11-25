using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingJSONInCS
{
    [System.Runtime.Serialization.DataContract]
    public class BlogSite
    {
        [System.Runtime.Serialization.DataMember]
        public string Name { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Description { get; set; }

        public BlogSite(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }

        public string ToString()
        {
            return "Name: " + Name + ", Description: " + Description;
        }
    }
}
