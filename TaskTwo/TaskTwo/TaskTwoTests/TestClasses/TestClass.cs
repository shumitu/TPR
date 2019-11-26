using System;
using System.Runtime.Serialization;

namespace TaskTwoTests.TestClasses
{
    [Serializable]
    public class TestClass
    {
        public TestClass AnotherTestClass { get; set; }
        public float Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }


        public TestClass(TestClass anotherTestClass, float id, DateTime date, string text)
        {
            AnotherTestClass = anotherTestClass;
            Id = id;
            Date = date;
            Text = text;          
        }


        public TestClass(SerializationInfo info, StreamingContext context)
        {
            AnotherTestClass = (TestClass)info.GetValue("AnotherTestClass", typeof(TestClass));
            Id = info.GetSingle("Id");
            Date = info.GetDateTime("Date");
            Text = info.GetString("Text");            
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AnotherTestClass", AnotherTestClass, typeof(TestClass));
            info.AddValue("Id", Id);
            info.AddValue("Date", Date);
            info.AddValue("Text", Text);
        }
    }
}