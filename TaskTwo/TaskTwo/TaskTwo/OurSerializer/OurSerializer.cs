using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Task_1.Part_1;

namespace TaskTwo.OurSerializer
{
    public class OurSerializer : IOurSerializer
    {
        private string SerializedData { get; set; }
        private Dictionary<long, Object> DeserializedObj { get; set; }
        public List<string[]> DeserializedData { get; set; }
        public string Path { get; set; }
        public string DeserializedString { get; set; }
        private Char DataSeparator = ';';


        public OurSerializer()
        {
            DeserializedObj = new Dictionary<long, Object>();
            DeserializedData = new List<string[]>();
        }
    

        public void Serialize(DataContext context, Stream stream)
        {
            ObjectIDGenerator generator = new ObjectIDGenerator();
            SerializedData = PrepareSerialization(context, generator);
            StreamWriter outputFile = new StreamWriter(stream);
            outputFile.WriteLine(SerializedData);
            outputFile.Flush();
        }


        public DataContext Deserialize(Stream stream)
        {
            DataContext context = new DataContext();
            StreamReader sr = new StreamReader(stream);
            var fileDataLine = "";
            while ((fileDataLine = sr.ReadLine()) != null)
            {
                DeserializedString = "";
                while ((fileDataLine = sr.ReadLine()) != null)
                {
                    DeserializedString += fileDataLine;
                    char[] separator = { DataSeparator };
                    DeserializedData.Add(fileDataLine.Split(separator));
                }
            }

            DeserializeDecision(context);
            return context;
        }


        private void DeserializeDecision(DataContext context)
        {
            foreach (string[] data in DeserializedData)
            {
                var dataType = data[0];

                switch (dataType)
                {
                    case "Task_1.Part_1.Register":
                        Register reg = new Register();
                        reg.Deserialize(data, DeserializedObj);
                        context.lists.Add(reg);
                        DeserializedObj.Add(long.Parse(data[1]), reg);
                        break;

                    case "Task_1.Part_1.Catalog":
                        Catalog cat = new Catalog();
                        cat.Deserialize(data, DeserializedObj);
                        context.catalogs.Add(cat.BookId, cat);
                        DeserializedObj.Add(long.Parse(data[1]), cat);
                        break;

                    case "Task_1.Part_1.Event":
                        Event evt = new Event();
                        evt.Deserialize(data, DeserializedObj);
                        context.events.Add(evt);
                        DeserializedObj.Add(long.Parse(data[1]), evt);
                        break;

                    case "Task_1.Part_1.StatusDescription":
                        StatusDescription desc = new StatusDescription();
                        desc.Deserialize(data, DeserializedObj);
                        context.descriptions.Add(desc);
                        DeserializedObj.Add(long.Parse(data[1]), desc);
                        break;
                }
            }
        }


        public string PrepareSerialization(DataContext context, ObjectIDGenerator generator)
        {
            string stringStream = "";

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
