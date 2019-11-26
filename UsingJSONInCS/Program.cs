using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UsingJSONInCS
{
    class Program
    {
        // Es necesario instalar en el package manager console 
        // Install-Package Newtonsoft.Json
        // ref: https://www.c-sharpcorner.com/article/working-with-json-string-in-C-Sharp/
        // ref: https://www.c-sharpcorner.com/article/json-serialization-and-deserialization-in-c-sharp/
        // ref: https://bytefish.de/blog/enum_datacontractjsonserializer/
        static void Main(string[] args)
        {
            string jsonData = @"{'FirstName': 'Jignesh', 'LastName': 'Trivedi'}";

            // Convert BlogSites object to JOSN string format 
            Console.WriteLine("Ejemplo E1 JsonConvert objeto a string ");
            BlogSite bsObjE1 = new BlogSite("Ejemplo E1", "contenido E1");
            Console.WriteLine(bsObjE1.ToString());
            string jsonDataE1 = JsonConvert.SerializeObject(bsObjE1);
            Console.WriteLine(jsonDataE1);
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Ejemplo E2 JsonConvert string to Objeto ");
            string jsonE2 = @"{'Name': 'C-sharpcorner', 'Description': 'Share Knowledge'}";
            Console.WriteLine("String >" + jsonE2 + "<");
            BlogSite bsObjE2 = JsonConvert.DeserializeObject<BlogSite>(jsonE2);
            Console.WriteLine(bsObjE2.ToString());
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Ejemplo E3 DataContractJsonSerializer objeto a  string");
            ISerializer jsonSerializer;
            jsonSerializer = new JsonSerializer();
            MyDetail sampleEntity = new MyDetail
            {
                FirstName = "esto es un nombre E3",
                LastName = "esto es un apellido E3"
            };
            Console.WriteLine("Objeto >" + sampleEntity.ToString() + "<");
            string actualJsonData = jsonSerializer.Serialize<MyDetail>(sampleEntity);
            Console.WriteLine("string >" + actualJsonData + "<");
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Ejemplo E4 DataContractJsonSerializer string a objeto");
            Console.WriteLine("string >" + actualJsonData + "<");
            MyDetail actualSampleEntity = jsonSerializer.Deserialize<MyDetail>(actualJsonData);
            Console.WriteLine("Objeto >" + actualSampleEntity.ToString() + "<");
            Console.WriteLine("------------------------------------");

            Console.WriteLine("fin");
            Console.ReadKey();
        }
    }
}
