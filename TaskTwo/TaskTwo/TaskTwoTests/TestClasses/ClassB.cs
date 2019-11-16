using System;

namespace TaskTwoTests.TestClasses
{
    [Serializable]
    public class ClassB
    {
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