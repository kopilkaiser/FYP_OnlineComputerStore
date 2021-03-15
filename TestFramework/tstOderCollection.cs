using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstOderCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsOrderCollection AllOrders = new clsOrderCollection();
            //test to see that it exists
            Assert.IsNotNull(AllOrders);
        }

        [TestMethod]
        public void ThisOrderPropertyOK()
        {
            //create the instance of the class we want to create
            clsOrderCollection AllOrders = new clsOrderCollection();
            //create some test data to assign to the property
            clsOrder TestOrder = new clsOrder();
            //set the properties of the test object
            TestOrder.OrderId = 1;
            TestOrder.AccountNo = 3;
            TestOrder.Email = "Noman Malik";
            TestOrder.AccountNo = 1;
            TestOrder.DateOrdered = DateTime.Now.Date;
            //assign the data to the property
            AllOrders.ThisOrder = TestOrder;
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.ThisOrder, TestOrder);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            //create an instance of the class we want to create
            clsOrderCollection AllOrders = new clsOrderCollection();
            //create the item of test Customer
            clsOrder TestItem = new clsOrder();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set the properties of the test Customer object
            TestItem.OrderId = 2;
            TestItem.AccountNo = 3;
            TestItem.Email = "mashycotton@email.com";
            TestItem.AccountNo = 1;
            TestItem.DateOrdered = DateTime.Now.Date;
            //assign the data to the property
            AllOrders.ThisOrder = TestItem;
            //add the record
            PrimaryKey = AllOrders.Add();
            //set the primary key of the test data
            TestItem.OrderId = PrimaryKey;
            //find the record
            AllOrders.ThisOrder.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.ThisOrder, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //create an instance of the class we want to create
            clsOrderCollection AllOrders = new clsOrderCollection();
            //create the item of test Customer
            clsOrder TestItem = new clsOrder();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set the properties of the test Customer object
            TestItem.OrderId = 2;
            TestItem.AccountNo = 3;
            TestItem.Email = "shourovjaki@outlook.com";
            TestItem.AccountNo = 1;
            TestItem.DateOrdered = DateTime.Now.Date;
            //assign the data to the property
            AllOrders.ThisOrder = TestItem;
            //add the record
            PrimaryKey = AllOrders.Add();
            //set the primary key of the test data
            TestItem.OrderId = PrimaryKey;
            //modify the test data
            TestItem.AccountNo = 3;
            TestItem.Email = "jakishourov@hotmail.com";
            TestItem.AccountNo = 1;
            TestItem.DateOrdered = DateTime.Now.Date;
            //set the record based on the new test data
            AllOrders.ThisOrder = TestItem;
            //update the record
            AllOrders.Update();
            //find the record
            AllOrders.ThisOrder.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllOrders.ThisOrder, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //create an instance of the class we want to create
            clsOrderCollection AllOrders = new clsOrderCollection();
            //create the item of test data
            clsOrder TestItem = new clsOrder();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set it's properties
            TestItem.OrderId = 2;
            TestItem.AccountNo = 3;
            TestItem.Email = "Junnun Malik";
            TestItem.AccountNo = 1;
            TestItem.DateOrdered = DateTime.Now.Date;
            //set ThisAddress to the test data
            AllOrders.ThisOrder = TestItem;
            //add the record
            PrimaryKey = AllOrders.Add();
            //set the primary key of the test data
            TestItem.OrderId = PrimaryKey;
            //find the record
            AllOrders.ThisOrder.Find(PrimaryKey);
            //delete the record
            AllOrders.Delete();
            //now find the record
            Boolean Found = AllOrders.ThisOrder.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByEmailNotFound()
        {
            //create an instance of the filtered data
            clsOrderCollection FilteredOrders = new clsOrderCollection();
            //apply a category that doesn't exist
            FilteredOrders.ReportByEmail("cathleenrose@pai.com");
            //test to see that there are no records
            Assert.AreNotEqual(1, FilteredOrders.Count);
        }
    }
}
