using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Task_1.Part_1;
using Task_1.Part_2;

namespace TaskTwo.OurSerializer
{
    public class OurSerializer : IOurSerializer, IDataFill
    {
        private string SerializedData { get; set; }
        private Dictionary<long, object> DeserializedObj { get; set; }
        public List<string[]> DeserializedData { get; set; }
        public string Path { get; set; }
        public string DeserializedString { get; set; }
        private char DataSeparator = ';';
        private Stream InputStream { get; set; }


        public OurSerializer(Stream stream)
        {
            DeserializedObj = new Dictionary<long, object>();
            DeserializedData = new List<string[]>();
            InputStream = stream;
        }

        public OurSerializer()
        {
            DeserializedObj = new Dictionary<long, object>();
            DeserializedData = new List<string[]>();
        }


        public void Serialize(DataContext context, Stream stream)
        {
            ObjectIDGenerator generator = new ObjectIDGenerator();
            SerializedData = GetSerializedStringStream(context, generator);
            using (StreamWriter outputFile = new StreamWriter(stream))
            {
                outputFile.WriteLine(SerializedData);
            }
        }


        public DataContext Deserialize(Stream stream)
        {
            DataContext context = new DataContext();
            StreamReader sr = new StreamReader(stream);
            var fileDataLine = "";
            while ((fileDataLine = sr.ReadLine()) != null)
            {
                char[] separator = { DataSeparator };
                DeserializedData.Add(fileDataLine.Split(separator));
            }

            DeserializeDecision(context);
            return context;
        }

        public void Fill(DataContext context)
        {
            DataContext deserialized = Deserialize(InputStream);
            try
            {
                context.lists = deserialized.lists;
                context.catalogs = deserialized.catalogs;
                context.descriptions = deserialized.descriptions;
                context.events = deserialized.events;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
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

                    case "Task_1.Part_1.BookBought":
                        Event evt1 = new BookBought();
                        evt1.Deserialize(data, DeserializedObj);
                        context.events.Add(evt1);
                        DeserializedObj.Add(long.Parse(data[1]), evt1);
                        break;

                    case "Task_1.Part_1.BookDestroy":
                        Event evt2 = new BookDestroy();
                        evt2.Deserialize(data, DeserializedObj);
                        context.events.Add(evt2);
                        DeserializedObj.Add(long.Parse(data[1]), evt2);
                        break;

                    case "Task_1.Part_1.BookBorrow":
                        Event evt3 = new BookBorrow();
                        evt3.Deserialize(data, DeserializedObj);
                        context.events.Add(evt3);
                        DeserializedObj.Add(long.Parse(data[1]), evt3);
                        break;

                    case "Task_1.Part_1.BookReturn":
                        Event evt4 = new BookReturn();
                        evt4.Deserialize(data, DeserializedObj);
                        context.events.Add(evt4);
                        DeserializedObj.Add(long.Parse(data[1]), evt4);
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


        public string GetSerializedStringStream(DataContext context, ObjectIDGenerator generator)
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
