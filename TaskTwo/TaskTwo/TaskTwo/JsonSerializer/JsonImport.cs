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

                    List<Register> deserializedRegisters = JsonConvert.DeserializeObject<List<Register>>(JsonString, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                        PreserveReferencesHandling = PreserveReferencesHandling.None
                    });

                    for (int i = 0; i < deserializedRegisters.Count; i++)
                    {
                        context.lists.Add(deserializedRegisters[i]);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\Files\\Catalog.json"))
                {
                    JsonString = reader.ReadToEnd();
                    // remove last new line
                    JsonString = JsonString.Remove(JsonString.Length - 2);

                    List<Catalog> deserializedCatalogs = JsonConvert.DeserializeObject<List<Catalog>>(JsonString, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                        PreserveReferencesHandling = PreserveReferencesHandling.None
                    });

                    for (int i = 0; i < deserializedCatalogs.Count; i++)
                    {
                        context.catalogs.Add(i, deserializedCatalogs[i]);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\Files\\StatusDescription.json"))
                {
                    JsonString = reader.ReadToEnd();
                    // remove last new line
                    JsonString = JsonString.Remove(JsonString.Length - 2);

                    List<StatusDescription> deserializedDescriptions = JsonConvert.DeserializeObject<List<StatusDescription>>(JsonString, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                        PreserveReferencesHandling = PreserveReferencesHandling.None
                    });

                    for (int i = 0; i < deserializedDescriptions.Count; i++)
                    {
                        context.descriptions.Add(deserializedDescriptions[i]);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\Files\\Event.json"))
                {
                    JsonString = reader.ReadToEnd();
                    // remove last new line
                    JsonString = JsonString.Remove(JsonString.Length - 2);

                    List<Event> deserializedEvents = JsonConvert.DeserializeObject<List<Event>>(JsonString, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                        PreserveReferencesHandling = PreserveReferencesHandling.None
                    });

                    foreach (var singleEvent in deserializedEvents)
                    {
                        context.events.Add(singleEvent);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }
        }
    }
}