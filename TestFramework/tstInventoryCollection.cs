using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstInventoryCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //test to see that it exists
            Assert.IsNotNull(AllInventories);
        }

        [TestMethod]
        public void ThisInventoryProperyOK()
        {
            //create the instance of the class we want to create
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //create some test data to assign to the property
            clsInventory TestInventory = new clsInventory();
            //set the properties of the test object
            TestInventory.InventoryId = 1;
            TestInventory.Name = "Samsung OLED TV";
            TestInventory.Price = 3999.99m;
            TestInventory.Quantity = 99;
            TestInventory.Category = "Electronics";
            TestInventory.DateAdded = DateTime.Now.Date;
            TestInventory.Active = true;
            //assign the data to the property
            AllInventories.ThisInventory = TestInventory;
            //test to see that the two values are the same
            Assert.AreEqual(AllInventories.ThisInventory, TestInventory);


        }

        [TestMethod]
        public void AddMethodOK()
        {
            //create an instance of the class we want to create
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //create the item of test data
            clsInventory TestItem = new clsInventory();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set it's properties
            TestItem.InventoryId = 1;
            TestItem.Active = true;
            TestItem.Name = "Samsung OLED TV";
            TestItem.Price = 2999.99m;
            TestItem.Quantity = 100;
            TestItem.Category = "Electronics";
            TestItem.DateAdded = DateTime.Now.Date;
            //set ThisInventory to the test data
            AllInventories.ThisInventory = TestItem;
            //add the record
            PrimaryKey = AllInventories.Add();
            //set the primary key of the test data
            TestItem.InventoryId = PrimaryKey;
            //find the record
            AllInventories.ThisInventory.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllInventories.ThisInventory, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //create an instance of the class we want to create
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //create the item of test data
            clsInventory TestItem = new clsInventory();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set it's properties
            TestItem.InventoryId = 3;
            TestItem.Active = true;
            TestItem.Name = "Samsung OLED TV";
            TestItem.Price = 2999.99m;
            TestItem.Quantity = 100;
            TestItem.Category = "Electronics";
            TestItem.DateAdded = DateTime.Now.Date;
            //set ThisAddress to the test data
            AllInventories.ThisInventory = TestItem;
            //add the record
            PrimaryKey = AllInventories.Add();
            //set the primary key of the test data
            TestItem.InventoryId = PrimaryKey;
            //find the record
            AllInventories.ThisInventory.Find(PrimaryKey);
            //delete the record
            AllInventories.Delete();
            //now find the record
            Boolean Found = AllInventories.ThisInventory.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //create an instance of the class we want to create
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //create the item of test data
            clsInventory TestItem = new clsInventory();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set it's properties       
            TestItem.Active = true;
            TestItem.Name = "Samsung OLED TV";
            TestItem.Price = 2999.99m;
            TestItem.Quantity = 100;
            TestItem.Category = "Electronics";
            TestItem.DateAdded = DateTime.Now.Date;
            //set ThisAddress to the test data
            AllInventories.ThisInventory = TestItem;
            //add the record
            PrimaryKey = AllInventories.Add();
            //set the primary key of the test data
            TestItem.InventoryId = PrimaryKey;
            //modify the test data
            TestItem.Active = false;
            TestItem.Name = "Sony Bravia OLED TV";
            TestItem.Price = 5999.99m;
            TestItem.Quantity = 50;
            TestItem.Category = "Electronics";
            TestItem.DateAdded = DateTime.Now.Date;
            //set the record based on the new test data
            AllInventories.ThisInventory = TestItem;
            //update the record
            AllInventories.Update();
            //find the record
            AllInventories.ThisInventory.Find(PrimaryKey);
            //test to see ThisInventory matches with test data
            Assert.AreEqual(AllInventories.ThisInventory, TestItem);
        }

        [TestMethod]
        public void ReportByCategoryNoneFound()
        {
            //create an instance of the filtered data
            clsInventoryCollection FilteredInventories = new clsInventoryCollection();
            //apply a category that doesn't exist
            FilteredInventories.ReportByCategory("Cosmetics");
            //test to see that there are no records
            Assert.AreEqual(0, FilteredInventories.Count);
        }
    }
}
