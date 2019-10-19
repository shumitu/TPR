using System;
using System.Collections.Generic;
using System.Text;
using Task_1.Part_2;

namespace Task_1.Part_1
{
    public class DataRepository
    {
        private DataContext context;
        private DataFill fill;

        public DataRepository(DataFill fill, DataContext context)
        {
            this.context = context;
            this.fill = fill;
        }

        public DataContext Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }

        public DataFill Fill
        {
            get
            {
                return fill;
            }
            set
            {
                fill = value;
            }
        }
    }
}