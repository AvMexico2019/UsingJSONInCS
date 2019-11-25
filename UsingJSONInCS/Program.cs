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

            Console.WriteLine("Ejemplo E1: JsonConverter string a objeto");
            Console.WriteLine("String >" + jsonData + "<");
            MyDetail myDetails = JsonConvert.DeserializeObject<MyDetail>(jsonData);
            Console.WriteLine(string.Concat("Objeto: " + myDetails.ToString()));
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Ejemplo E2: JObject Parse objetos dinámicos string a objeto");
            Console.WriteLine("String >" + jsonData + "<");
            dynamic data = JObject.Parse(jsonData);
            Console.WriteLine(string.Concat("Objeto ", data.FirstName, " " + data.LastName));
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Ejemplo E3 JObject Parse");
            Console.WriteLine("String >" + jsonData + "<");
            var details = JObject.Parse(jsonData);
            Console.WriteLine(string.Concat("Objeto ", details["FirstName"], " " + details["LastName"]));
            Console.WriteLine("------------------------------------");

            // Convert BlogSites object to JOSN string format 
            Console.WriteLine("Ejemplo E6 JsonConvert \nobjeto a string ");
            BlogSite bsObjE6 = new BlogSite("Ejemplo E6", "contenido E6");
            Console.WriteLine(bsObjE6.ToString());
            string jsonDataE6 = JsonConvert.SerializeObject(bsObjE6);
            Console.WriteLine(jsonDataE6);
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Ejemplo E7 JsonConvert\nstring to Objeto ");
            string jsonE7 = @"{'Name': 'C-sharpcorner', 'Description': 'Share Knowledge'}";
            Console.WriteLine("String >" + jsonE7 + "<");
            BlogSite bsObjE7 = JsonConvert.DeserializeObject<BlogSite>(jsonE7);
            Console.WriteLine(bsObjE7.ToString());
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Ejemplo E8 DataContractJsonSerializer objeto a  string");
            ISerializer jsonSerializer;
            jsonSerializer = new JsonSerializer();
            MyDetail sampleEntity = new MyDetail
            {
                FirstName = "esto es un nombre",
                LastName = "esto es un apellido"
            };
            Console.WriteLine("Objeto >" + sampleEntity.ToString() + "<");
            string actualJsonData = jsonSerializer.Serialize<MyDetail>(sampleEntity);
            Console.WriteLine("string >" + actualJsonData + "<");
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Ejemplo E8 DataContractJsonSerializer string a objeto");
            Console.WriteLine("string >" + actualJsonData + "<");
            MyDetail actualSampleEntity = jsonSerializer.Deserialize<MyDetail>(actualJsonData);
            Console.WriteLine("Objeto >" + actualSampleEntity.ToString() + "<");
            Console.WriteLine("------------------------------------");

            Console.WriteLine("fin");
            Console.ReadKey();
        }
    }
}
