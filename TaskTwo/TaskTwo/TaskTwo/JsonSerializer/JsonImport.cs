using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Task_1.Part_1;
using Task_1.Part_2;

namespace TaskTwo.Data
{
    public class JsonImport : IDataFill
    {
        public JsonImport()
        {

        }


        public void Fill(DataContext context)
        {
            string JsonString = null;

            try
            { 
                using (StreamReader reader = new StreamReader("..\\..\\Files\\Register.json"))
                {
                    JsonString = reader.ReadToEnd();
                    // remove last new line
                    JsonString = JsonString.Remove(JsonString.Length - 2);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            List<Register> deserializedRegisters = JsonConvert.DeserializeObject<List<Register>>(JsonString, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            for(int i = 0; i < deserializedRegisters.Count; i++)
            {
                context.lists.Add(deserializedRegisters[i]);
            }

            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\Files\\Catalog.json"))
                {
                    // Read the stream to a string, and write the string to the console.
                    JsonString = reader.ReadToEnd();
                    // remove last new line
                    JsonString = JsonString.Remove(JsonString.Length - 2);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            List<Catalog> deserializedCatalogs = JsonConvert.DeserializeObject<List<Catalog>>(JsonString, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            for (int i = 0; i < deserializedCatalogs.Count; i++)
            {
                context.catalogs.Add(i, deserializedCatalogs[i]);
            }

            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\Files\\StatusDescription.json"))
                {
                    // Read the stream to a string, and write the string to the console.
                    JsonString = reader.ReadToEnd();
                    // remove last new line
                    JsonString = JsonString.Remove(JsonString.Length - 2);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            List<StatusDescription> deserializedDescriptions = JsonConvert.DeserializeObject<List<StatusDescription>>(JsonString, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            for (int i = 0; i < deserializedDescriptions.Count; i++)
            {
                context.descriptions.Add(deserializedDescriptions[i]);
            }

            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\Files\\Event.json"))
                {
                    // Read the stream to a string, and write the string to the console.
                    JsonString = reader.ReadToEnd();
                    // remove last new line
                    JsonString = JsonString.Remove(JsonString.Length - 2);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            List<Event> deserializedEvents = JsonConvert.DeserializeObject<List<Event>>(JsonString, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            for (int i = 0; i < deserializedEvents.Count; i++)
            {
                context.events.Add(deserializedEvents[i]);
            }

        }
    }
}
