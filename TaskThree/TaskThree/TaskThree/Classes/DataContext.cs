using System;
using System.Data.Linq;
using System.Linq;
using TaskThree.Files;


namespace TaskThree.Classes
{
    public class DataContext
    {
        private DataDataContext dataContext;


        public DataContext()
        {
            this.dataContext = new DataDataContext();
        }


        public bool AddProduct(Product product)
        {
            try
            {
                dataContext.Product.InsertOnSubmit(product);
                dataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public Product GetProduct(int productId)
        {
            IQueryable<Product> find = (from product in dataContext.GetTable<Product>()
                                        where product.ProductID == productId
                                        select product);

            if (find.Count() == 0)
            {
                return null;
            }
            else
            {
                return find.First();
            }
        }


        public bool RemoveProduct(Product product)
        {
            try
            {
                dataContext.Product.DeleteOnSubmit(product);
                dataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateProduct(Product product)
        {
            try
            {
                Product productToUpdate = GetProduct(product.ProductID);
                productToUpdate.Name = product.Name;
                productToUpdate.ProductNumber = product.ProductNumber;
                productToUpdate.MakeFlag = product.MakeFlag;
                productToUpdate.FinishedGoodsFlag = product.FinishedGoodsFlag;
                productToUpdate.Color = product.Color;
                productToUpdate.SafetyStockLevel = product.SafetyStockLevel;
                productToUpdate.ReorderPoint = product.ReorderPoint;
                productToUpdate.StandardCost = product.StandardCost;
                productToUpdate.ListPrice = product.ListPrice;
                productToUpdate.Size = product.Size;
                productToUpdate.SizeUnitMeasureCode = product.SizeUnitMeasureCode;
                productToUpdate.WeightUnitMeasureCode = product.WeightUnitMeasureCode;
                productToUpdate.Weight = product.Weight;
                productToUpdate.DaysToManufacture = product.DaysToManufacture;
                productToUpdate.ProductLine = product.ProductLine;
                productToUpdate.Class = product.Class;
                productToUpdate.Style = product.Style;
                productToUpdate.ProductSubcategoryID = product.ProductSubcategoryID;
                productToUpdate.ProductModelID = product.ProductModelID;
                productToUpdate.SellStartDate = product.SellStartDate;
                productToUpdate.SellEndDate = product.SellEndDate;
                productToUpdate.DiscontinuedDate = product.DiscontinuedDate;
                productToUpdate.rowguid = product.rowguid;
                productToUpdate.ModifiedDate = DateTime.Today;
                dataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public IQueryable<P> GetItems<P>() where P : class
        {
            return dataContext.GetTable<P>();
        }


        public IQueryable<Product> GetItems()
        {
            return dataContext.GetTable<Product>();
        }
    }
}