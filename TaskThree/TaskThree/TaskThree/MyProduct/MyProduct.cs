using TaskThree.Files;


namespace TaskThree.MyProduct
{
    public class MyProduct : Product
    {
        public int Modify { get; set; }

        public MyProduct(Product product, int modify)
        {
            foreach (var property in product.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(product));
                }
            }

            this.Modify = modify;
        }
    }
}