using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Task_1.Part_1;


public class JsonExport
{

    public JsonExport()
        {

        }

        public void SerializeRegister(DataRepository data)
        {

            try
            {
                using (FileStream file = new FileStream("..\\..\\Files\\Register.json", FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(file))
                {
                    IEnumerable<Register> constant = data.GetAllRegisters();
                    string json = JsonConvert.SerializeObject(constant, Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All,
                            MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        });
                    writer.WriteLine(json);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }
    }


        public void SerializeCatalog(DataRepository data)
        {
            try
            {
                using (FileStream file = new FileStream("..\\..\\Files\\Catalog.json", FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(file))
                {
                IEnumerable<Catalog> constant = data.GetAllFromCatalog();
                string json = JsonConvert.SerializeObject(constant, Formatting.Indented, new JsonSerializerSettings
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


        public void SerializeStatusDescription(DataRepository data)
        {
            try
            {
                using (FileStream file = new FileStream("..\\..\\Files\\StatusDescription.json", FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(file))
                {
                    IEnumerable<StatusDescription> constant = data.GetAllStatusDescriptions();
                    string json = JsonConvert.SerializeObject(constant, Formatting.Indented, new JsonSerializerSettings
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


        public void SerializeEvent(DataRepository data)
        {
            try
            {
                using (FileStream file = new FileStream("..\\..\\Files\\Event.json", FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(file))
                {
                    IEnumerable<Event> constant = data.GetAllEvents();
                    string json = JsonConvert.SerializeObject(constant, Formatting.Indented, new JsonSerializerSettings
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
    

    }
