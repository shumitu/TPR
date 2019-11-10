using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Part_1;

namespace TaskTwo.Data
{
    public class FillWithDefinedData
    {
        public FillWithDefinedData()
        {

        }

        DataContext context = new DataContext();
        public DataRepository data = new DataRepository(new DefinedData());

    }
}
