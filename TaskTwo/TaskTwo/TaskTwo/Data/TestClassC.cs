using System;
using System.Runtime.Serialization;

namespace TaskTwo.Data
{
    public class TestClassC : ISerializable
    {
        public TestClassA AnotherTestClassA { get; set; }
        public float Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }


        public TestClassC(TestClassA anotherTestClassA, float id, DateTime date, string text)
        {
            AnotherTestClassA = anotherTestClassA;
            Id = id;
            Date = date;
            Text = text;
        }


        public TestClassC(SerializationInfo info, StreamingContext context)
        {
            AnotherTestClassA = (TestClassA)info.GetValue("AnotherTestClassA", typeof(TestClassA));
            Id = info.GetSingle("Id");
            Date = info.GetDateTime("Date");
            Text = info.GetString("Text");
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AnotherTestClassA", AnotherTestClassA, typeof(TestClassA));
            info.AddValue("Id", Id);
            info.AddValue("Date", Date);
            info.AddValue("Text", Text);
        }
    }
}