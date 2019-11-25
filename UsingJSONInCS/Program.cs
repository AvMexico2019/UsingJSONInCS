using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
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
        static void Main(string[] args)
        {
            string jsonData = @"{'FirstName': 'Jignesh', 'LastName': 'Trivedi'}";

            Console.WriteLine("Ejemplo JsonConverter");
            MyDetail myDetails = JsonConvert.DeserializeObject<MyDetail>(jsonData);
            Console.WriteLine(string.Concat("Hi ", myDetails.FirstName, " " + myDetails.LastName));
            
            Console.WriteLine("Ejemplo JsonConverter");
            dynamic data = JObject.Parse(jsonData);
            Console.WriteLine(string.Concat("Hi ", data.FirstName, " " + data.LastName));
            
            Console.WriteLine("Ejemplo JsonParse");
            var details = JObject.Parse(jsonData);
            Console.WriteLine(string.Concat("Hi ", details["FirstName"], " " + details["LastName"]));

            Console.WriteLine("Ejemplo usando objetos dynamicos");
            dynamic data1 = JObject.Parse(jsonData);
            Console.WriteLine(string.Concat("Hi ", data1.FirstName, " " + data1.LastName));

            Console.WriteLine("Ejemplo usando serialización");
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(MyDetail));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData));
            stream.Position = 0;
            MyDetail dataContractDetail = (MyDetail)jsonSerializer.ReadObject(stream);
            Console.WriteLine(string.Concat("Hi ", dataContractDetail.FirstName, " " + dataContractDetail.LastName));


            Console.WriteLine("Ejemplo usando de serialización");
            DataContractJsonSerializer jsonSerializer1 = new DataContractJsonSerializer(typeof(MyDetail));
            MemoryStream stream1 = new MemoryStream(Encoding.UTF8.GetBytes(jsonData));
            stream.Position = 0;
            MyDetail dataContractDetail = (MyDetail)jsonSerializer.ReadObject(stream);
            Console.WriteLine(string.Concat("Hi ", dataContractDetail.FirstName, " " + dataContractDetail.LastName));

            Console.ReadKey();
        }
    }

    public class MyDetail
    {
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
    }
}
