using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Task_1.Part_1;

namespace TaskTwo.OurSerializer
{
    public class OurSerializer : ISerializer
    {
        private string serializeddata { get; set; }
        private Dictionary<long, Object> deserializedobjects { get; set; }
        public List<string[]> deserializeddata { get; set; }
        public string Path { get; set; }
        public string deserializedstring { get; set; }
        private Char delimeter = '-';


        public OurSerializer()
        {
            deserializedobjects = new Dictionary<long, Object>();
            deserializeddata = new List<string[]>();
        }
    

        public void Serialize(DataContext context, Stream stream)
        {
            ObjectIDGenerator generator = new ObjectIDGenerator();
            serializeddata = PrepareSerialization(context, generator);
            StreamWriter outputFile = new StreamWriter(stream);
            outputFile.WriteLine(serializeddata);
            outputFile.Flush();
        }


        public DataContext Deserialize(Stream stream)
        {
            DataContext context = new DataContext();
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                deserializedstring = "";
                while ((line = sr.ReadLine()) != null)
                {
                    deserializedstring += line;
                    Char[] separator = { delimeter };
                    deserializeddata.Add(line.Split(separator));
                }
            }

            DeserializeDecision(context);
            return context;
        }


        private void DeserializeDecision(DataContext context)
        {
            string dataType = "";
            foreach (string[] data in this.deserializeddata)
            {
                switch (dataType)
                {
                    case "Task_1.Part_1.Person":
                        Register reg = new Register();
                        reg.Deserialize(data, this.deserializedobjects);
                        context.lists.Add(reg);
                        this.deserializedobjects.Add(long.Parse(data[1]), reg);
                        break;

                    case "Task_1.Part_1.Catalog":
                        Catalog cat = new Catalog();
                        cat.Deserialize(data, this.deserializedobjects);
                        context.catalogs.Add(cat.BookId, cat);
                        this.deserializedobjects.Add(long.Parse(data[1]), cat);
                        break;

                    case "Task_1.Part_1.Event":
                        Event evt = new Event();
                        evt.Deserialize(data, this.deserializedobjects);
                        context.events.Add(evt);
                        this.deserializedobjects.Add(long.Parse(data[1]), evt);
                        break;

                    case "Task_1.Part_1.StatusDescription":
                        StatusDescription desc = new StatusDescription();
                        desc.Deserialize(data, this.deserializedobjects);
                        context.descriptions.Add(desc);
                        this.deserializedobjects.Add(long.Parse(data[1]), desc);
                        break;

                    default:
                        break;
                }

            }
        }


        public string PrepareSerialization(DataContext context, ObjectIDGenerator generator)
        {
            String stringStream = "";

            foreach (Register reg in context.lists)
            {
                stringStream += reg.Serialize(generator) + "\n";
            }

            foreach (KeyValuePair<int, Catalog> cat in context.catalogs)
            {
                stringStream += cat.Value.Serialize(generator) + "\n";
            }

            foreach (StatusDescription desc in context.descriptions)
            {
                stringStream += desc.Serialize(generator) + "\n";
            }

            foreach (Event evt in context.events)
            {
                stringStream += evt.Serialize(generator) + "\n";
            }
            return stringStream;
        }
    }
}
