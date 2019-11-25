using Newtonsoft.Json;
using System;
using System.IO;

namespace TaskTwo.JsonSerializer
{
    public class JsonContextSerialization
    {
        //DataContext cont;

        public JsonContextSerialization()
        {

        }

        //public JsonContextSerialization(DataRepository rep)
        //{
        //    this.cont = rep.context;
        //}

        //public void SerializeWhole()
        //{
        //    try
        //    {
        //        using (FileStream file = new FileStream("..\\..\\Files\\WholeContext.json", FileMode.Create, FileAccess.Write))
        //        using (StreamWriter writer = new StreamWriter(file))
        //        {
        //            string json = JsonConvert.SerializeObject(cont, Formatting.Indented,
        //                 new JsonSerializerSettings
        //                 {
        //                     TypeNameHandling = TypeNameHandling.Auto,
        //                     MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
        //                     PreserveReferencesHandling = PreserveReferencesHandling.None

        //                 });
        //            writer.WriteLine(json);
        //        }
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine("The file could not be read: " + e.Message);
        //    }
        //}
        //public DataContext DeserializeWhole()
        //{
        //    DataContext deserialized = null;

        //    try
        //    {
        //        using (StreamReader reader = new StreamReader("..\\..\\Files\\WholeContext.json"))
        //        {
        //            var JsonString = reader.ReadToEnd();
        //            // remove last new line
        //            JsonString = JsonString.Remove(JsonString.Length - 2);

        //            deserialized = JsonConvert.DeserializeObject<DataContext>(JsonString,
        //                new JsonSerializerSettings {
        //                    TypeNameHandling = TypeNameHandling.Auto,
        //                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
        //                    PreserveReferencesHandling = PreserveReferencesHandling.None
        //                });
        //        }
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine("The file could not be read: " + e.Message);
        //    }

        //    return deserialized;
        //}

        //public void Fill(DataContext context)
        //{
        //    string JsonString = null;
        //    DataContext deserialized = null;

        //    try
        //    {
        //        using (StreamReader reader = new StreamReader("..\\..\\Files\\WholeContext.json"))
        //        {
        //            JsonString = reader.ReadToEnd();
        //            // remove last new line
        //            JsonString = JsonString.Remove(JsonString.Length - 2);

        //            deserialized = JsonConvert.DeserializeObject<DataContext>(JsonString, new JsonSerializerSettings
        //            {
        //                TypeNameHandling = TypeNameHandling.All,
        //                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
        //                PreserveReferencesHandling = PreserveReferencesHandling.None
        //            });
        //        }
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine("The file could not be read: " + e.Message);
        //    }

        //    try
        //    {
        //        context.lists = deserialized.lists;
        //        context.catalogs = deserialized.catalogs;
        //        context.descriptions = deserialized.descriptions;
        //        context.events = deserialized.events;
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
    }
}