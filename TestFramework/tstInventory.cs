using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestFramework
{
    //Module Title & Code: Database Management & Programming, IMAT3104
    //Testing Framework for my project, Online Computer Store
    //Developer: Kopil Kaiser
    //Supervisor: Hakeem Ibrahim
    //References: Modification done from code provided by Matthew Dean, contact:mjdean@dmu.ac.uk

    //Testing for the class Inventory
    [TestClass]
    public class tstInventory
    {
        //some good test data
        int InventoryId = 1;
        string Name = "Cadbury";
        string Price = "6.99";
        string Quantity = "10000";
        string Category = "Electronics";
        string DateAdded = DateTime.Now.Date.ToString();

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class
            clsInventory AnInventory = new clsInventory();
            Assert.IsNotNull(AnInventory);
        }

        [TestMethod]
        public void ActivePropertyOK()
        {
            //create an instance of the class we want to create
            clsInventory AnInventory = new clsInventory();
            //create some test data to assign to the property
            Boolean TestData = true;
            //assign the data to the property
            AnInventory.Active = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AnInventory.Active, TestData);
        }

        [TestMethod]
        public void NamePropertyOK()
        {
            clsInventory AnInventory = new clsInventory();
            string Name = "Cadbury";
            AnInventory.Name = Name;
            Assert.AreEqual(Name, AnInventory.Name);
        }

        [TestMethod]
        public void PricePropertyOK()
        {
            clsInventory AnInventory = new clsInventory();
            decimal Price = 5.99m;
            AnInventory.Price = Price;
            Assert.AreEqual(Price, AnInventory.Price);
        }

        [TestMethod]
        public void QuantityPropertyOK()
        {
            clsInventory AnInventory = new clsInventory();
            Int32 Quantity = 100;
            AnInventory.Quantity = Quantity;
            Assert.AreEqual(Quantity, AnInventory.Quantity);
        }

        [TestMethod]
        public void CategoryPropertyOK()
        {
            clsInventory AnInventory = new clsInventory();
            string Category = "Electronics";
            AnInventory.Category = Category;
            Assert.AreEqual(Category, AnInventory.Category);
        }

        [TestMethod]
        public void DateAddedPropertyOK()
        {
            clsInventory AnInventory = new clsInventory();
            DateTime DateAdded = DateTime.Now.Date;
            AnInventory.DateAdded = DateAdded;
            Assert.AreEqual(DateAdded, AnInventory.DateAdded);
        }

        [TestMethod]
        public void ValidMethodOK()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class we want to create
            clsInventory AnInventory = new clsInventory();
            //boolean variable to store the result of the validation
            Boolean Found = false;
            //create some test data to use with the method
            int InventoryId = 3;
            //invoke the method
            Found = AnInventory.Find(InventoryId);
            //test to see that the result is correct
            Assert.IsFalse(Found);
        }

        //TestMethods for DateAdded property by different test types and test data

        [TestMethod]
        public void DateAddedExtremeMin()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddYears(-100);
            string DateAdded = TestDate.ToString();
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateAddedMinMinusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddDays(-1);
            string DateAdded = TestDate.ToString();
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DateAddedMinBoundary()
        {
            clsInventory AnInventory = new clsInventory();
            string DateAdded = DateTime.Now.Date.ToString();
            string Error = "";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DateAddedExtremeMax()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddYears(100);
            string DateAdded = TestDate.ToString();
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DateAddedInvalidDataType()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string DateAdded = "a";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        //TestMethods for Name property by different test types and test data

        [TestMethod]
        public void NameExtremeMin()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Name = "";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void NameMinMinusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Name = "";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void NameMinBoundary()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Name = "a";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void NameMinPlusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Name = "aa";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void NameMaxMinusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(39, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMaxBoundary()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(40, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMaxPlusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(41, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void NameMid()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(20, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameExtremeMax()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(500, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        //TestMethods for Category property by different test types and test data

        [TestMethod]
        public void CategoryExtremeMin()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Category = "";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMinMinusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Category = "";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void CategoryMinBoundary()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Category = "a";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void CategoryMinPlusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Category = "aa";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void CategoryMaxMinusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Category = "";
            Category = Category.PadRight(19, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMaxBoundary()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Category = "";
            Category = Category.PadRight(20, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMaxPlusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Category = "";
            Category = Category.PadRight(101, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMid()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Category = "";
            Category = Category.PadRight(10, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryExtremeMax()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Category = "";
            Category = Category.PadRight(500, 'a');
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        //TestMethods for Price property by different Test Types and Test Data

        [TestMethod]
        public void PriceExtremeMin()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Price = "-1";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PriceMinMinusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Price = "-1";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void PriceMinBoundary()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Price = "0";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void PriceMinPlusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Price = "2";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void PriceMaxMinusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Price = "9999";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PriceMaxBoundary()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Price = "100000";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PriceMaxPlusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Price = "100001";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PriceMid()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Price = "50000";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PriceExtremeMax()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Price = "1000000";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        //TestMethods for Quantity property with different test types and test data

        [TestMethod]
        public void QuantityExtremeMin()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Quantity = "-1";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void QuantityMinMinusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Quantity = "-1";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void QuantityMinBoundary()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Quantity = "0";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void QuantityMinPlusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Quantity = "1";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void QuantityMaxMinusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Quantity = "9999";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void QuantityMaxBoundary()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Quantity = "10000";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void QuantityMaxPlusOne()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Quantity = "10001";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void QuantityMid()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Quantity = "5000";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void QuantityExtremeMax()
        {
            clsInventory AnInventory = new clsInventory();
            string Error = "";
            string Quantity = "99999999";
            Error = AnInventory.Valid(Name, Price, Quantity, Category, DateAdded);
            Assert.AreNotEqual(Error, "");
        }


    }
}
