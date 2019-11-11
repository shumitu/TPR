using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task_1.Part_1;

    public class JsonExport
    {

        static public void SerializeRegister(DataRepository data)
        {
        JsonSerializer serializer = new JsonSerializer();
        FileStream file = new FileStream("..\\..\\Files\\Register.json", FileMode.Create, FileAccess.Write);
        IEnumerable<Register> constant = data.GetAllRegisters();
        string json = JsonConvert.SerializeObject(constant, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
        StreamWriter writer = new StreamWriter(file);
        //JsonWriter jsonWriter = new JsonTextWriter(writer);
        //serializer.Serialize(jsonWriter, constant, typeof(DataContext));
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
        file.Close();
    }


        static public void SerializeCatalog(DataRepository data)
        {
            JsonSerializer serializer = new JsonSerializer();
            FileStream file = new FileStream("..\\..\\Files\\Catalog.json", FileMode.Create, FileAccess.Write);
            IEnumerable<Catalog> constant = data.GetAllFromCatalog();
            string json = JsonConvert.SerializeObject(constant, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            StreamWriter writer = new StreamWriter(file);
            //JsonWriter jsonWriter = new JsonTextWriter(writer);
            //serializer.Serialize(jsonWriter, constant, typeof(DataContext));
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
            file.Close();
        }


        static public void SerializeStatusDescription(DataRepository data)
        {
            JsonSerializer serializer = new JsonSerializer();
            FileStream file = new FileStream("..\\..\\Files\\StatusDescription.json", FileMode.Create, FileAccess.Write);
            IEnumerable<StatusDescription> constant = data.GetAllStatusDescriptions();
            string json = JsonConvert.SerializeObject(constant, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            StreamWriter writer = new StreamWriter(file);
            //JsonWriter jsonWriter = new JsonTextWriter(writer);
            //serializer.Serialize(jsonWriter, constant, typeof(DataContext));
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
            file.Close();
    }


        static public void SerializeEvent(DataRepository data)
        {
            JsonSerializer serializer = new JsonSerializer();
            FileStream file = new FileStream("..\\..\\Files\\Event.json", FileMode.Create, FileAccess.Write);
            IEnumerable<Event> constant = data.GetAllEvents();
            string json = JsonConvert.SerializeObject(constant, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            StreamWriter writer = new StreamWriter(file);
            //JsonWriter jsonWriter = new JsonTextWriter(writer);
            //serializer.Serialize(jsonWriter, constant, typeof(DataContext));
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
            file.Close();
        }


    }
