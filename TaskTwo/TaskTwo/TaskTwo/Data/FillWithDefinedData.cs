using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Part_1;

namespace TaskTwo.Data
{
    class FillWithDefinedData
    {
        DataContext context = new DataContext();
        DataRepository data = new DataRepository(new DefinedData());

    }
}
