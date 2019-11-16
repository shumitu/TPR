using Newtonsoft.Json;
using System;

namespace TaskTwoTests.TestClasses
{
    [Serializable]
    public class ClassC
    {
        [JsonProperty]
        public ClassA ClassA { get; set; }

        public ClassC()
        {

        }

        public ClassC(ClassA cls)
        {
            ClassA = cls;
        }
    }
}
