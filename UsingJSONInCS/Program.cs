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
            Console.WriteLine(">>>> REGEX");
            Regex rx = new Regex { RegexDef = @"\d+" };
            Regex ry = new Regex { RegexDef = @"\w+" };
            string r1;
            Console.WriteLine(">>----");
            Console.WriteLine(r1 = rx.ToCadena());
            Console.WriteLine(">" + r1 + "<");
            Console.WriteLine(">>----");
            Console.WriteLine(r1 = ry.ToCadena());
            Console.WriteLine(r1);
            Console.WriteLine(">>----");
            Regex[] DefiniciosnesRegex = new Regex[]
                {
                    rx,
                    ry
                };
            Console.WriteLine(DefiniciosnesRegex[0].ToCadena());
            Console.WriteLine(DefiniciosnesRegex[1].ToCadena());
            string ArregloRegex = JsonConvert.SerializeObject(DefiniciosnesRegex);
            Console.WriteLine("Regex serializado >" + ArregloRegex + "<");

            Regex[] RegexSettings = JsonConvert.DeserializeObject<Regex[]>(ArregloRegex);
            Console.WriteLine(RegexSettings[0].ToCadena());
            Console.WriteLine(RegexSettings[1].ToCadena());

            Console.WriteLine("------------------------------------");
            Console.ReadKey();

            Console.WriteLine("Ejemplo de Clave de Sello Digital");
            string FechaDeFirma = DateTime.Today.ToString("yyyy-MM-dd");
            RetrieveKey rkey = new RetrieveKey();
            Console.WriteLine(rkey.TraeClaveSelloDigital(FechaDeFirma));
            Console.WriteLine(">" + rkey.TraeClaveSelloDigital(new DateTime(2010, 1, 3).ToString("yyyy-MM-dd")) + "<");
            Console.WriteLine(">" + rkey.TraeClaveSelloDigital(new DateTime(2010, 1, 4).ToString("yyyy-MM-dd")) + "<");
            Console.WriteLine(">" + rkey.TraeClaveSelloDigital(new DateTime(2010, 1, 5).ToString("yyyy-MM-dd")) + "<");

            Console.WriteLine("----------------_________________----------------");


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

            Console.WriteLine(">>>> Claves");
            DateTime viejo = new DateTime(2010, 1, 4);
            DateTime ultimo = new DateTime(2019, 11, 25);
            string v1;
            Console.WriteLine(">>----");
            Console.WriteLine(v1 = viejo.ToString("yyyy-MM-dd"));
            Console.WriteLine(Convert.ToDateTime(v1));
            Console.WriteLine(">>----");
            Console.WriteLine(v1 = ultimo.ToString("yyyy-MM-dd"));
            Console.WriteLine(Convert.ToDateTime(v1));
            Console.WriteLine(">>----");
            Console.WriteLine(DateTime.Today.ToString("yyyy-MM-dd"));
            ClaveSelloDigital[] ArregloClaves = new ClaveSelloDigital[]
                {
                    new ClaveSelloDigital{FechaAlta = viejo.ToString("yyyy-MM-dd"), Clave ="Ejemplo para ver como introducir otra clave"},
                    new ClaveSelloDigital{FechaAlta = ultimo.ToString("yyyy-MM-dd"), Clave ="Esta cadena debe ser secreta y administrada por operación del sistema, para evitar que los programadores puedan modificar la base de sellos historica de producción"}
                };
            Console.WriteLine(ArregloClaves[0].ToCadena());
            Console.WriteLine(ArregloClaves[1].ToCadena());
            string claves = JsonConvert.SerializeObject(ArregloClaves);
            Console.WriteLine("Claves serializado >" + claves + "<");
            
            ClaveSelloDigital[] clavesWebConfig = JsonConvert.DeserializeObject<ClaveSelloDigital[]>(claves);
            Console.WriteLine(clavesWebConfig[0].ToCadena());
            Console.WriteLine(clavesWebConfig[1].ToCadena());

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
