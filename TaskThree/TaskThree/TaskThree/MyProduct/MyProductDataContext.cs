using System.Collections.Generic;
using System.Linq;
using TaskThree.Files;


namespace TaskThree.MyProduct
{
    public class MyProductDataContext
    {
        public static List<MyProduct> myProducts { get; private set; }


        public MyProductDataContext(DataDataContext myDataContext)
        {
            int i = 0;

            myProducts = myDataContext.Product.AsEnumerable().Select(product => new MyProduct(product, i++)).ToList();
        }
    }
}