using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TaskTwoTests.TestClasses
{
    public class TestSerializer
    {
        public ObjectIDGenerator generator = new ObjectIDGenerator();
        public List<string[]> DeserializedData { get; set; }
        private char DataSeparator = ';';

        public TestSerializer()
        {
            DeserializedData = new List<string[]>();

        }

        public void Serialize(List<TestClass> listOfClasses, Stream inputStream)
        {
            using (StreamWriter writer = new StreamWriter(inputStream))
            {
                string toFile = "";
                foreach (var singleClass in listOfClasses)
                {
                    long firstClassId = generator.GetId(singleClass, out bool firstTime);
                    long otherClassId = generator.GetId(singleClass.AnotherTestClass, out firstTime);
                    toFile += firstClassId;
                    toFile += ";";
                    toFile += otherClassId;
                    toFile += ";";
                    toFile += firstClassId;
                    toFile += "\n";
                }

                toFile.Trim('\n');
                Console.Write(toFile);
                writer.Write(toFile);
            }
        }

        public List<TestClass> deserialize(Stream stream)
        {
            Dictionary<string, TestClass> classes = new Dictionary<string, TestClass>();
            Dictionary<TestClass, string> secondClasses = new Dictionary<TestClass, string>();
            List<TestClass> resultClasses = new List<TestClass>();

            using (StreamReader reader = new StreamReader(stream))
            {
                var fileDataLine = "";
                while ((fileDataLine = reader.ReadLine()) != null)
                {
                    char[] separator = { DataSeparator };
                    DeserializedData.Add(fileDataLine.Split(separator));
                }

                foreach (string[] dataSet in DeserializedData)
                {
                    if (classes.ContainsKey(dataSet[0]))
                    {
                        TestClass deserializedClass = classes[dataSet[0]];
                        resultClasses.Add(deserializedClass);
                    }
                    else
                    {
                        TestClass deserializedClass = new TestClass()
                        {
                            Id = int.Parse(dataSet[2])
                        };
                        if (classes.ContainsKey(dataSet[1]))
                        {
                            deserializedClass.AnotherTestClass = classes[dataSet[1]];
                        }
                        else
                        {
                            secondClasses.Add(deserializedClass, dataSet[1]);
                        }
                        classes.Add(dataSet[0], deserializedClass);
                        resultClasses.Add(deserializedClass);
                    }
                }
            }

            foreach (TestClass resultClass in resultClasses)
            {
                if (resultClass.AnotherTestClass == null)
                    resultClass.AnotherTestClass = classes[secondClasses[resultClass]];
            }

            return resultClasses;
        }
    }
}
