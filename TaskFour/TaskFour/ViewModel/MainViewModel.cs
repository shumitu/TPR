using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TaskThree.Classes;
using TaskThree.Files;
using ViewModel.Interfaces;


namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Product product;
        private List<Product> products;
        public event PropertyChangedEventHandler PropertyChanged;
        public DataRepository DataRepository { get; set; }


        public ICommand AddProductCommand { get; private set; }
        public ICommand UpdateProductCommand { get; private set; }
        public ICommand RemoveProductCommand { get; private set; }
        public ICommand ChangeSelectedProduct { get; private set; }
        public IWindow MainWindow { get; set; }
        public IWindow AddWindow { get; set; }


        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                RaisePropertyChanged("Product");
                ChangeSelectedProduct.Execute(null);
            }
        }


        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                RaisePropertyChanged("Products");

            }
        }


        public List<bool> Flags { get; set; }
        public List<string> Colors { get; set; }
        public List<string> SizeUnitMeasureCodes { get; set; }
        public List<string> WeightUnitMeasureCodes { get; set; }
        public List<string> ProductLines { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Styles { get; set; }
        public List<string> ProductSubcategories { get; set; }
        public List<string> ProductModels { get; set; }


        private string name;
        private string productNumber;
        private bool makeFlag;
        private bool finishedGoodsFlag;
        private string color;
        private short safetyStockLevel;
        private short reorderPoint;
        private decimal standardCost;
        private decimal listPrice;
        private string size;
        private string sizeUnitMeasureCode;
        private string weightUnitMeasureCode;
        private decimal? weight;
        private int daysToManufacture;
        private string productLine;
        private string class1;
        private string style;
        private string productSubcategoryId;
        private string productModelId;
        private DateTime sellStartDate;
        private DateTime? sellEndDate;
        private DateTime? discontinuedDate;
        private DateTime modifiedDate;


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }


        public string ProductNumber
        {
            get
            {
                return productNumber;
            }
            set
            {
                productNumber = value;
                RaisePropertyChanged("ProductNumber");
            }
        }


        public bool MakeFlag
        {
            get
            {
                return makeFlag;
            }
            set
            {
                makeFlag = value;
                RaisePropertyChanged("MakeFlag");
            }
        }


        public bool FinishedGoodsFlag
        {
            get
            {
                return finishedGoodsFlag;
            }
            set
            {
                finishedGoodsFlag = value;
                RaisePropertyChanged("FinishedGoodsFlag");
            }
        }


        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                RaisePropertyChanged("Color");
            }
        }


        public short SafetyStockLevel
        {
            get
            {
                return safetyStockLevel;
            }
            set
            {
                safetyStockLevel = value;
                RaisePropertyChanged("SafetyStockLevel");
            }
        }


        public short ReorderPoint
        {
            get
            {
                return reorderPoint;
            }
            set
            {
                reorderPoint = value;
                RaisePropertyChanged("ReorderPoint");
            }
        }


        public decimal StandardCost
        {
            get
            {
                return standardCost;
            }
            set
            {
                standardCost = value;
                RaisePropertyChanged("StandardCost");
            }
        }


        public decimal ListPrice
        {
            get
            {
                return listPrice;
            }
            set
            {
                listPrice = value;
                RaisePropertyChanged("ListPrice");
            }
        }


        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                RaisePropertyChanged("Size");
            }
        }


        public string SizeUnitMeasureCode
        {
            get
            {
                return sizeUnitMeasureCode;
            }
            set
            {
                sizeUnitMeasureCode = value;
                RaisePropertyChanged("SizeUnitMeasureCode");
            }
        }


        public string WeightUnitMeasureCode
        {
            get
            {
                return weightUnitMeasureCode;
            }
            set
            {
                weightUnitMeasureCode = value;
                RaisePropertyChanged("WeightUnitMeasureCode");
            }
        }


        public decimal? Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                RaisePropertyChanged("Weight");
            }
        }


        public int DaysToManufacture
        {
            get
            {
                return daysToManufacture;
            }
            set
            {
                daysToManufacture = value;
                RaisePropertyChanged("DaysToManufacture");
            }
        }


        public string ProductLine
        {
            get
            {
                return productLine;
            }
            set
            {
                productLine = value;
                RaisePropertyChanged("ProductLine");
            }
        }


        public string Class
        {
            get
            {
                return class1;
            }
            set
            {
                class1 = value;
                RaisePropertyChanged("Class");
            }
        }


        public string Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
                RaisePropertyChanged("Style");
            }
        }


        public string ProductSubcategory
        {
            get
            {
                return productSubcategoryId;
            }
            set
            {
                productSubcategoryId = value;
                RaisePropertyChanged("ProductSubcategory");
            }
        }


        public string ProductModel
        {
            get
            {
                return productModelId;
            }
            set
            {
                productModelId = value;
                RaisePropertyChanged("ProductModel");
            }
        }


        public DateTime SellStartDate
        {
            get
            {
                return sellStartDate;
            }
            set
            {
                sellStartDate = value;
                RaisePropertyChanged("SellStartDate");
            }
        }


        public DateTime? SellEndDate
        {
            get
            {
                return sellEndDate;
            }
            set
            {
                sellEndDate = value;
                RaisePropertyChanged("SellEndDate");
            }
        }


        public DateTime? DiscontinuedDate
        {
            get
            {
                return discontinuedDate;
            }
            set
            {
                discontinuedDate = value;
                RaisePropertyChanged("DiscontinuedDate");
            }
        }


        public DateTime ModifiedDate
        {
            get
            {
                return modifiedDate;
            }
            set
            {
                modifiedDate = value;
                RaisePropertyChanged("ModifiedDate");
            }
        }


        private bool colorCheck;
        private bool sizeCheck;
        private bool sizeUnitMeasureCodeCheck;
        private bool weightUnitMeasureCodeCheck;
        private bool weightCheck;
        private bool productLineCheck;
        private bool classCheck;
        private bool styleCheck;
        private bool productSubcategoryCheck;
        private bool productModelCheck;
        private bool sellEndDateCheck;
        private bool discontinuedDateCheck;


        public bool ColorCheck
        {
            get
            {
                return colorCheck;
            }
            set
            {
                colorCheck = value;
                RaisePropertyChanged("ColorCheck");
            }
        }


        public bool SizeCheck
        {
            get { return sizeCheck; }
            set
            {
                sizeCheck = value;
                RaisePropertyChanged("SizeCheck");
            }
        }


        public bool SizeUnitMeasureCodeCheck
        {
            get
            {
                return sizeUnitMeasureCodeCheck;
            }
            set
            {
                sizeUnitMeasureCodeCheck = value;
                RaisePropertyChanged("SizeUnitMeasureCodeCheck");
            }
        }


        public bool WeightUnitMeasureCodeCheck
        {
            get
            {
                return weightUnitMeasureCodeCheck;
            }
            set
            {
               weightUnitMeasureCodeCheck = value;
                RaisePropertyChanged("WeightUnitMeasureCodeCheck");
            }
        }


        public bool WeightCheck
        {
            get
            {
                return weightCheck;
            }
            set
            {
                weightCheck = value;
                RaisePropertyChanged("WeightCheck");
            }
        }


        public bool ProductLineCheck
        {
            get
            {
                return productLineCheck;
            }
            set
            {
                productLineCheck = value;
                RaisePropertyChanged("ProductLineCheck");
            }
        }


        public bool ClassCheck
        {
            get
            {
                return classCheck;
            }
            set
            {
                classCheck = value;
                RaisePropertyChanged("ClassCheck");
            }
        }


        public bool StyleCheck
        {
            get
            {
                return styleCheck;
            }
            set
            {
                styleCheck = value;
                RaisePropertyChanged("StyleCheck");
            }
        }


        public bool ProductSubcategoryCheck
        {
            get
            {
                return productSubcategoryCheck;
            }
            set
            {
                productSubcategoryCheck = value;
                RaisePropertyChanged("ProductSubcategoryCheck");
            }
        }


        public bool ProductModelCheck
        {
            get
            {
                return productModelCheck;
            }
            set
            {
                productModelCheck = value;
                RaisePropertyChanged("ProductModelCheck");
            }
        }


        public bool SellEndDateCheck
        {
            get
            {
                return sellEndDateCheck;
            }
            set
            {
                sellEndDateCheck = value;
                RaisePropertyChanged("SellEndDateCheck");
            }
        }


        public bool DiscontinuedDateCheck
        {
            get
            {
                return discontinuedDateCheck;
            }
            set
            {
                discontinuedDateCheck = value;
                RaisePropertyChanged("DiscontinuedDateCheck");
            }
        }


        private void CheckProduct(Product product)
        {
            if (ColorCheck == false)
            {
                product.Color = null;
            }
            else
            {
                product.Color = Color;
            }


            if (SizeCheck == false)
            {
                product.Size = null;
            }
            else
            {
                product.Size = Size;
            }


            if (ProductLineCheck == false)
            {
                product.ProductLine = null;
            }
            else
            {
                product.ProductLine = ProductLine;
            }


            if (ClassCheck == false)
            {
                product.Class = null;
            }
            else
            {
                product.Class = Class;
            }


            if (StyleCheck == false)
            {
                product.Style = null;
            }
            else
            {
                product.Style = Style;
            }


            if (ProductSubcategoryCheck == false)
            {
                ProductSubcategory = null;
            }
            else
            {
                List<Product> allProducts = DataRepository.GetAllProducts();
                int subcategory = (from product2 in allProducts
                                   where product2.ProductSubcategoryID != null && product2.ProductSubcategory.Name.Equals(ProductSubcategory)
                                   select product2.ProductSubcategory.ProductSubcategoryID).First();

                product.ProductSubcategoryID = subcategory;
            }


            if (ProductModelCheck == false)
            {
                ProductModel = null;
            }
            else
            {
                List<Product> allProducts = DataRepository.GetAllProducts();
                int model = (from product2 in allProducts
                             where product2.ProductModelID != null && product2.ProductModel.Name.Equals(ProductModel)
                             select product2.ProductModel.ProductModelID).First();

                product.ProductModelID = model;
            }
        }


        private void SaveData(Product product, out string message)
        {
            message = "";

            CheckProduct(product);

            if (Name != null && Name != "")
            {
                product.Name = Name;
            }
            else
            {
                message += "Name is empty\n";
            }

            if (ProductNumber != null)
            {
                product.ProductNumber = ProductNumber;
            }
            else
            {
                message += "Product number is empty\n";
            }

            product.MakeFlag = MakeFlag;
            product.FinishedGoodsFlag = FinishedGoodsFlag;
            product.SafetyStockLevel = SafetyStockLevel;
            product.ReorderPoint = ReorderPoint;
            product.StandardCost = StandardCost;
            product.ListPrice = ListPrice;
            product.DaysToManufacture = DaysToManufacture;
            product.ModifiedDate = DateTime.Now;
            product.SellStartDate = SellStartDate;

            if (SellEndDateCheck == true)
            {
                if (SellEndDate > SellStartDate)
                {
                    product.SellEndDate = SellEndDate;
                }
                else
                {
                    message += "Sell enddate cannot be after sell startdate\n";
                }
            }

            if (DiscontinuedDateCheck == true)
            {
                product.DiscontinuedDate = DiscontinuedDate;
            }
        }


        private void AddProduct()
        {
            Product productToAdd = new Product();
            SaveData(productToAdd, out string message);
            if (message != "")
            {
                MainWindow.ShowPopup(message);
            }
            else if (DataRepository.Add(productToAdd))
            {
                MainWindow.ShowPopup("Add success");
            }
            else
            {
                MainWindow.ShowPopup("Add failed");
            }
        }


        private void DeleteProduct()
        {
            if (Product.ProductID != 0)
            {
                if (DataRepository.Remove(Product.ProductID))
                {
                    MainWindow.ShowPopup("Delete success");
                }
                else
                {
                    MainWindow.ShowPopup("Delete failed");
                }
            }
            else
            {
                MainWindow.ShowPopup("Select a product");
            }
        }


        private void UpdateProduct()
        {
            SaveData(Product, out string message);
            if (message != "")
            {
                MainWindow.ShowPopup(message);
            }
            else if (DataRepository.Update(Product))
            {
                MainWindow.ShowPopup("Product modified succefully");
            }
            else
            {
                MainWindow.ShowPopup("Product modification failed");
            }
        }


        private void InitUpdateProduct()
        {
            Name = Product.Name;


            ProductNumber = Product.ProductNumber;


            MakeFlag = Product.MakeFlag;


            FinishedGoodsFlag = Product.FinishedGoodsFlag;


            if (Product.Color != null)
            {
                Color = Product.Color;
                ColorCheck = true;
            }
            else
            {
                Color = null;
                ColorCheck = false;
            }


            SafetyStockLevel = Product.SafetyStockLevel;


            ReorderPoint = Product.ReorderPoint;


            StandardCost = Product.StandardCost;


            ListPrice = Product.ListPrice;


            if (Product.Size != null)
            {
                Size = Product.Size;
                SizeCheck = true;
            }
            else
            {
                Size = null;
                SizeCheck = false;
            }


            if (Product.SizeUnitMeasureCode != null)
            {
                SizeUnitMeasureCode = Product.SizeUnitMeasureCode;
                SizeUnitMeasureCodeCheck = true;
            }
            else
            {
                SizeUnitMeasureCode = null;
                SizeUnitMeasureCodeCheck = false;
            }


            if (Product.WeightUnitMeasureCode != null)
            {
                WeightUnitMeasureCode = Product.WeightUnitMeasureCode;
                WeightUnitMeasureCodeCheck = true;
            }
            else
            {
                WeightUnitMeasureCode = null;
                WeightUnitMeasureCodeCheck = false;
            }


            if (Product.Weight != null)
            {
                Weight = Product.Weight.Value;
                WeightCheck = true;
            }
            else
            {
                Weight = null;
                WeightCheck = false;
            }


            DaysToManufacture = Product.DaysToManufacture;


            if (Product.ProductLine != null)
            {
                ProductLine = Product.ProductLine;
                ProductLineCheck = true;
            }
            else
            {
                ProductLine = null;
                ProductLineCheck = false;
            }


            if (Product.Class != null)
            {
                Class = Product.Class;
                ClassCheck = true;
            }
            else
            {
                Class = null;
                ClassCheck = false;
            }


            if (Product.Style != null)
            {
                Style = Product.Style;
                StyleCheck = true;
            }
            else
            {
                Style = null;
                StyleCheck = false;
            }


            if (Product.ProductSubcategoryID != null)
            {
                ProductSubcategory = GetProductSubcategoryName(Product.ProductSubcategoryID.Value);
                ProductSubcategoryCheck = true;
            }
            else
            {
                ProductSubcategory = null;
                ProductSubcategoryCheck = false;
            }


            if (Product.ProductModelID != null)
            {
                ProductModel = GetProductModelName(Product.ProductModelID.Value);
                ProductModelCheck = true;
            }
            else
            {
                ProductModel = null;
                ProductModelCheck = false;
            }


            SellStartDate = Product.SellStartDate;


            if (Product.SellEndDate != null)
            {
                SellEndDate = Product.SellEndDate.Value;
                SellEndDateCheck = true;
            }
            else
            {
                SellEndDate = null;
                SellEndDateCheck = false;
            }


            if (Product.DiscontinuedDate != null)
            {
                DiscontinuedDate = Product.DiscontinuedDate.Value;
                DiscontinuedDateCheck = true;
            }
            else
            {
                DiscontinuedDate = null;
                DiscontinuedDateCheck = false;
            }
        }


        private string GetProductSubcategoryName(int index)
        {
            List<Product> products = DataRepository.GetAllProducts();
            return (from product in products
                    where product.ProductSubcategoryID != null && product.ProductSubcategoryID == index
                    select product.ProductSubcategory.Name).First();
        }


        private string GetProductModelName(int index)
        {
            List<Product> products = DataRepository.GetAllProducts();
            return (from product in products
                    where product.ProductModelID != null && product.ProductModelID == index
                    select product.ProductModel.Name).First();
        }


        private void InitComboBox()
        {
            List<Product> products = DataRepository.GetAllProducts();

            this.Flags = new List<bool> { true, false };
            this.Colors = (from product in products
                           select product.Color).Distinct().ToList();

            this.SizeUnitMeasureCodes = (from product in products
                                         where product.SizeUnitMeasureCode != null
                                         select product.SizeUnitMeasureCode).Distinct().ToList();

            this.WeightUnitMeasureCodes = (from product in products
                                           where product.WeightUnitMeasureCode != null
                                           select product.WeightUnitMeasureCode).Distinct().ToList();

            this.ProductLines = (from product in products
                                 where product.ProductLine != null
                                 select product.ProductLine).Distinct().ToList();

            this.Classes = (from product in products
                            where product.Class != null
                            select product.Class).Distinct().ToList();

            this.Styles = (from product in products
                           where product.Style != null
                           select product.Style).Distinct().ToList();

            this.ProductSubcategories = (from product in products
                                         where product.ProductSubcategory != null
                                         select product.ProductSubcategory.Name).Distinct().ToList();

            this.ProductModels = (from product in products
                                  where product.ProductModel != null
                                  select product.ProductModel.Name).Distinct().ToList();
        }


        private void OnProductChanged()
        {
            if (Product != null)
            {
                InitUpdateProduct();
            }
        }


        public void OnProductsChanged()
        {
            this.Products = DataRepository.GetAllProducts();
        }


        public MainViewModel()
        {
            AddProductCommand = new Command(AddProduct);
            UpdateProductCommand = new Command(UpdateProduct);
            RemoveProductCommand = new Command(DeleteProduct);
            ChangeSelectedProduct = new Command(OnProductChanged);

            DataRepository = new DataRepository();
            DataRepository.ChangeInCollection += OnProductsChanged;

            Products = DataRepository.GetAllProducts();
            Product = new Product();
            Product.SellStartDate = DateTime.Now;


            InitComboBox();


            if (Product != null)
            {
                InitUpdateProduct();
            }
        }
    }
}