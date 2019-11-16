using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTwoTests.TestClasses
{
    [Serializable]
    public class ClassC
    {
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
