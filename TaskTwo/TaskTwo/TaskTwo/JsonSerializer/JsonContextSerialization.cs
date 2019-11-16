using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Part_1;
using Task_1.Part_2;

namespace TaskTwo.JsonSerializer
{
    public class JsonContextSerialization : IDataFill
    {
        DataContext cont;

        public JsonContextSerialization()
        {

        }

        public JsonContextSerialization(DataRepository rep)
        {
            this.cont = rep.context;
        }

        public void SerializeWhole()
        {
            try
            {
                using (FileStream file = new FileStream("..\\..\\Files\\WholeContext.json", FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(file))
                {
                    string json = JsonConvert.SerializeObject(cont, Formatting.Indented,
                         new JsonSerializerSettings
                         {
                             TypeNameHandling = TypeNameHandling.All,
                             MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                             PreserveReferencesHandling = PreserveReferencesHandling.Objects
                         });
                    writer.WriteLine(json);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }
        }
        public DataContext DeserializeWhole()
        {
            string JsonString = null;
            DataContext deserialized = null;

            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\Files\\WholeContext.json"))
                {
                    JsonString = reader.ReadToEnd();
                    // remove last new line
                    JsonString = JsonString.Remove(JsonString.Length - 2);

                    deserialized = JsonConvert.DeserializeObject<DataContext>(JsonString,
                        new JsonSerializerSettings {
                            TypeNameHandling = TypeNameHandling.All,
                            MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        });
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            return deserialized;
        }

        public void Fill(DataContext context)
        {
            string JsonString = null;
            DataContext deserialized = null;

            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\Files\\WholeContext.json"))
                {
                    JsonString = reader.ReadToEnd();
                    // remove last new line
                    JsonString = JsonString.Remove(JsonString.Length - 2);

                    deserialized = JsonConvert.DeserializeObject<DataContext>(JsonString, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            context.lists = deserialized.lists;
            context.catalogs = deserialized.catalogs;
            context.descriptions = deserialized.descriptions;
            context.events = deserialized.events;

        }
    }
}
