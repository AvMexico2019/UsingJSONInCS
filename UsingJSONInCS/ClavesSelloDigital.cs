using System.Runtime.Serialization;

namespace UsingJSONInCS
{
    [DataContract]
    public class ClaveSelloDigital
    {
        [DataMember]
        public string FechaAlta;  // formato YYYY-mm-dd

        [DataMember]
        public string Clave;

        public string ToCadena()
        {
            return FechaAlta + ":" + Clave;
        }
    }
}
