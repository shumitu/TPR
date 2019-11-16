using Newtonsoft.Json;
using System;

namespace TaskTwoTests.TestClasses
{
    [Serializable]
    public class ClassB
    {
        [JsonProperty]
        public ClassC ClassC { get; set; }

        public ClassB()
        {

        }

        public ClassB(ClassC cls)
        {
            ClassC = cls;
        }
    }
}