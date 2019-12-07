using System.Collections.Generic;
using System.Linq;
using TaskThree.Files;


namespace TaskThree.MyProduct
{
    public class MyProductDataContext
    {
        public static List<MyProduct> MyProducts { get; private set; }


        public MyProductDataContext(DataDataContext myDataContext)
        {
            int i = 0;

            MyProducts = myDataContext.Product.AsEnumerable().Select(product => new MyProduct(product, i++)).ToList();
        }
    }
}