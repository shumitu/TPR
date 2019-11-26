using System;
using System.Runtime.Serialization;

namespace TaskTwo.Data
{
    public class TestClassA : ISerializable
    {
        public TestClassB AnotherTestClassB { get; set; }
        public float Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }        


        public TestClassA(TestClassB anotherTestClassB, float id, DateTime date, string text)
        {
            AnotherTestClassB = anotherTestClassB;
            Id = id;
            Date = date;
            Text = text;           
        }


        public TestClassA(SerializationInfo info, StreamingContext context)
        {
            AnotherTestClassB = (TestClassB)info.GetValue("AnotherTestClassB", typeof(TestClassB));
            Id = info.GetSingle("Id");
            Date = info.GetDateTime("Date");
            Text = info.GetString("Text");           
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AnotherTestClassB", AnotherTestClassB, typeof(TestClassB));
            info.AddValue("Id", Id);
            info.AddValue("Date", Date);
            info.AddValue("Text", Text);
        }
    }
}