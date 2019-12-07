using System.Collections.Generic;
using System.Linq;
using TaskThree.Files;


namespace TaskThree.MyProduct
{
    class MyProductDataContext
    {
        public List<MyProduct> myProducts { get; private set; }

        public MyProductDataContext(DataDataContext myDataContext)
        {
            int i = 0;

            this.myProducts = myDataContext.Product.AsEnumerable().Select(product => new MyProduct(product, i++)).ToList();
        }      
    }
}