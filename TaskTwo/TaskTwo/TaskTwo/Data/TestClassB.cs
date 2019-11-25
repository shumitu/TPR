using System;
using System.Runtime.Serialization;

namespace TaskTwoTests.TestClasses
{
    [Serializable]
    public class TestClassB : ISerializable
    {
        public TestClassC AnotherTestClassC { get; set; }
        public float Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }


        public TestClassB(TestClassC anotherTestClassC, float id, DateTime date, string text)
        {
            AnotherTestClassC = anotherTestClassC;
            Id = id;
            Date = date;
            Text = text;          
        }


        public TestClassB(SerializationInfo info, StreamingContext context)
        {
            AnotherTestClassC = (TestClassC)info.GetValue("AnotherTestClass", typeof(TestClassC));
            Id = info.GetSingle("Id");
            Date = info.GetDateTime("Date");
            Text = info.GetString("Text");            
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AnotherTestClass", AnotherTestClassC, typeof(TestClassC));
            info.AddValue("Id", Id);
            info.AddValue("Date", Date);
            info.AddValue("Text", Text);
        }
    }
}