using Newtonsoft.Json;
using System;

namespace TaskTwoTests.TestClasses
{
    [Serializable]
    public class ClassA
    {
        [JsonProperty]
        public ClassB ClassB { get; set; }

        public ClassA()
        {

        }

        public ClassA(ClassB cls)
        {
            ClassB = cls;
        }
    }
}