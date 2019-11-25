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
            Console.WriteLine(jsonData);
            MyDetail myDetails = JsonConvert.DeserializeObject<MyDetail>(jsonData);
            Console.WriteLine(string.Concat("Objeto: " + myDetails.ToString()));
            
            Console.WriteLine("Ejemplo E2: JObject Parse objetos dinámicos string a objeto");
            dynamic data = JObject.Parse(jsonData);
            Console.WriteLine(string.Concat("Hi ", data.FirstName, " " + data.LastName));
            
            Console.WriteLine("Ejemplo E3 JObject Parse");
            var details = JObject.Parse(jsonData);
            Console.WriteLine(string.Concat("Hi ", details["FirstName"], " " + details["LastName"]));

            // Convert BlogSites object to JOSN string format 
            Console.WriteLine("Ejemplo E6 JsonConvert \nobjeto a string ");
            BlogSite bsObjE6 = new BlogSite("Ejemplo E6", "contenido E6");
            string jsonDataE6 = JsonConvert.SerializeObject(bsObjE6);
            Console.WriteLine(jsonDataE6);

            Console.WriteLine("Ejemplo E7 JsonConvert\nstring to Objeto ");
            string jsonE7 = @"{'Name': 'C-sharpcorner', 'Description': 'Share Knowledge'}";
            BlogSite bsObjE7 = JsonConvert.DeserializeObject<BlogSite>(jsonE7);
            Console.WriteLine(bsObjE7.ToString());

            Console.ReadKey();
        }
    }
}
