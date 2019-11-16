using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
