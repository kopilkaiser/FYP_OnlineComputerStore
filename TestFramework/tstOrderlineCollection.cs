using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstOrderlineCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            clsOrderlineCollection AllOrderline = new clsOrderlineCollection();
            // teat to see tha t it exist
            Assert.IsNotNull(AllOrderline);
        }
        [TestMethod]
        public void ThisOrderlinePropertyOK()
        {
            // create an instance of the class we want to create
            clsOrderlineCollection AllOrderline = new clsOrderlineCollection();
            // create some test data to assign the property
            clsOrderline TestOrderline = new clsOrderline();
            // set the properties of the object
            TestOrderline.OrderlineId = 1;
            TestOrderline.OrderId = 5;
            TestOrderline.Quantity = 1;
            TestOrderline.InventoryId = 1;
            // assign the data to the property
            AllOrderline.ThisOrderline = TestOrderline;
            // test to see that the two values are the same
            Assert.AreEqual(AllOrderline.ThisOrderline, TestOrderline);

        }
        [TestMethod]
        public void AddMethodOK()
        {
            // create an instance for the class we want to create
            clsOrderlineCollection AllOrderline = new clsOrderlineCollection();

            // create the item of the test data
            clsOrderline TestItem = new clsOrderline();

            // var to store the primary key
            Int32 PrimaryKey = 0;
            // set it properties
            TestItem.OrderlineId = 2;
            TestItem.OrderId = 1;
            TestItem.Quantity = 1;
            TestItem.InventoryId = 1;


            // set thisAdress to the test data
            AllOrderline.ThisOrderline = TestItem;
            // add the record
            PrimaryKey = AllOrderline.Add();
            // set the primary key TestI data
            TestItem.OrderlineId = PrimaryKey;
            // find the record
            AllOrderline.ThisOrderline.Find(PrimaryKey);

            // test to see that the two values are the same
            Assert.AreEqual(AllOrderline.ThisOrderline, TestItem);

        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            // create an instance for the class we want to create
            clsOrderlineCollection AllOrderline = new clsOrderlineCollection();

            // create the item of the test data
            clsOrderline TestItem = new clsOrderline();
            // var to store the primary key
            Int32 PrimaryKey = 0;
            // set it properties
            TestItem.OrderlineId = 2;
            TestItem.OrderId = 4;
            TestItem.Quantity = 1;
            TestItem.InventoryId = 1;


            // set thisAdress to the test data
            AllOrderline.ThisOrderline = TestItem;
            // add the record
            PrimaryKey = AllOrderline.Add();
            // set the primary key TestI data
            TestItem.OrderlineId = PrimaryKey;
            // find the record
            AllOrderline.ThisOrderline.Find(PrimaryKey);
            // delete the record
            AllOrderline.Delete();
            //now find the record
            Boolean Found = AllOrderline.ThisOrderline.Find(PrimaryKey);

            // test to see that the record was not found
            Assert.IsFalse(Found);

        }

        [TestMethod]

        public void UpdateMethodOK()
        {
            // create an instance for the class we want to create
            clsOrderlineCollection AllOrderline = new clsOrderlineCollection();

            // create the item of the test data
            clsOrderline TestItem = new clsOrderline();
            // var to store the primary key
            Int32 PrimaryKey = 0;
            // set it properties
            //TestItem.OrderlineId = 2;
            TestItem.OrderId = 1;
            TestItem.Quantity = 1;
            TestItem.InventoryId = 1;
            // set thisAdress to the test data
            AllOrderline.ThisOrderline = TestItem;
            // add the record
            PrimaryKey = AllOrderline.Add();
            // set the primary key TestI data
            TestItem.OrderlineId = PrimaryKey;
            // modify the test data
            TestItem.OrderId = 2;
            TestItem.Quantity = 2;
            TestItem.InventoryId = 1;
            // set the record based on the new test data
            AllOrderline.ThisOrderline = TestItem;
            // Update the record
            AllOrderline.Update();
            // find the record
            AllOrderline.ThisOrderline.Find(PrimaryKey);
            // test to see that the record was not found
            Assert.AreEqual(AllOrderline.ThisOrderline, TestItem);

        }
    }
}