using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace UsingJSONInCS
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize<TEntity>(TEntity entity)  // objeto a string
            where TEntity : class, new()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TEntity));
                ser.WriteObject(ms, entity);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public TEntity Deserialize<TEntity>(string entity)  // string a objeto
            where TEntity : class, new()
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TEntity));
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(entity)))
            {
                return ser.ReadObject(stream) as TEntity;
            }
        }
    }
}
