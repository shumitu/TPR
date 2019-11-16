using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTwoTests.TestClasses
{
    [Serializable]
    public class ClassA
    {
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
