using System;
using System.Configuration;
using Newtonsoft.Json;

namespace UsingJSONInCS
{
    class RetrieveKey
    {
        public string TraeClaveSelloDigital(string FechaDeFirma)
        {
            string JSONclavesWebConfig;
            // traemos la clave de firma de sellos digitales
            // Get the key from config file
            try
            {
                JSONclavesWebConfig = ConfigurationSettings.AppSettings["SecretoParaSelloDigital"];
            }
            catch
            {
                return String.Empty;
            }
            ClaveSelloDigital[] clavesWebConfig = JsonConvert.DeserializeObject<ClaveSelloDigital[]>(JSONclavesWebConfig);
            DateTime DateTimeFechaDeFirma = Convert.ToDateTime(FechaDeFirma);
            for (int i = clavesWebConfig.Length - 1; i >= 0 ; i--)
            {
                DateTime DateTimeFechaDeRegistro = Convert.ToDateTime(clavesWebConfig[i].FechaAlta);

                //public static int Compare(DateTime t1, DateTime t2);
                //Parameters:
                //            t1: The first object to compare.
                //            t2: The second object to compare.
                //Return Value: This method returns a signed number indicating the relative values of t1 and t2.
                //Less than zero: If t1 is earlier than t2.
                //Zero : If t1 is the same as t2.
                //Greater than zero : If t1 is later than t2.

                switch (DateTime.Compare(DateTimeFechaDeRegistro, DateTimeFechaDeFirma))
                {
                    case -1:
                    case 0:
                        return clavesWebConfig[i].Clave;

                    case 1:
                        break;
                }
            }
            return String.Empty;
        }
    }
}
