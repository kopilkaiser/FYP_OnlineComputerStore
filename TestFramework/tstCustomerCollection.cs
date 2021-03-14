using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstCustomerCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //test to see that it exists
            Assert.IsNotNull(AllCustomers);
        }

        [TestMethod]
        public void ThisCustomerPropertyOK()
        {
            //create the instance of the class we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create some test data to assign to the property
            clsCustomer TestCustomer = new clsCustomer();
            //set the properties of the test object
            TestCustomer.CustomerId = 2;
            TestCustomer.AccountNo = 3;
            TestCustomer.Name = "Noman Malik";
            TestCustomer.Phonenum = "08884433410";
            TestCustomer.DateJoined = DateTime.Now.Date;
            TestCustomer.Active = true;
            //assign the data to the property
            AllCustomers.ThisCustomer = TestCustomer;
            //test to see that the two values are the same
            Assert.AreEqual(AllCustomers.ThisCustomer, TestCustomer);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            //create an instance of the class we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create the item of test Customer
            clsCustomer TestItem = new clsCustomer();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set the properties of the test Customer object
            TestItem.CustomerId = 2;
            TestItem.AccountNo = 3;
            TestItem.Name = "Junnun Malik";
            TestItem.Phonenum = "08884433410";
            TestItem.DateJoined = DateTime.Now.Date;
            TestItem.Active = true;
            //assign the data to the property
            AllCustomers.ThisCustomer = TestItem;
            //add the record
            PrimaryKey = AllCustomers.Add();
            //set the primary key of the test data
            TestItem.CustomerId = PrimaryKey;
            //find the record
            AllCustomers.ThisCustomer.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //create an instance of the class we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create the item of test Customer
            clsCustomer TestItem = new clsCustomer();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set the properties of the test Customer object
            TestItem.CustomerId = 2;
            TestItem.AccountNo = 3;
            TestItem.Name = "Noman Malik";
            TestItem.Phonenum = "08884433410";
            TestItem.DateJoined = DateTime.Now.Date;
            TestItem.Active = true;
            //assign the data to the property
            AllCustomers.ThisCustomer = TestItem;
            //add the record
            PrimaryKey = AllCustomers.Add();
            //set the primary key of the test data
            TestItem.CustomerId = PrimaryKey;
            //modify the test data
            TestItem.AccountNo = 4;
            TestItem.Name = "Shorat Malika";
            TestItem.Phonenum = "11184455555";
            TestItem.DateJoined = DateTime.Now.Date;
            TestItem.Active = false;
            //set the record based on the new test data
            AllCustomers.ThisCustomer = TestItem;
            //update the record
            AllCustomers.Update();
            //find the record
            AllCustomers.ThisCustomer.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //create an instance of the class we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create the item of test data
            clsCustomer TestItem = new clsCustomer();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set it's properties
            TestItem.CustomerId = 1;
            TestItem.AccountNo = 1;
            TestItem.Name = "Junnun Safoan";
            TestItem.Phonenum = "22245677963";
            TestItem.DateJoined = DateTime.Now.Date;
            TestItem.Active = true;
            //set ThisAddress to the test data
            AllCustomers.ThisCustomer = TestItem;
            //add the record
            PrimaryKey = AllCustomers.Add();
            //set the primary key of the test data
            TestItem.CustomerId = PrimaryKey;
            //find the record
            AllCustomers.ThisCustomer.Find(PrimaryKey);
            //delete the record
            AllCustomers.Delete();
            //now find the record
            Boolean Found = AllCustomers.ThisCustomer.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByNameNotFound()
        {
            //create an instance of the filtered data
            clsCustomerCollection FilteredCustomers = new clsCustomerCollection();
            //apply a category that doesn't exist
            FilteredCustomers.ReportByName("Tanzim");
            //test to see that there are no records
            Assert.AreNotEqual(1, FilteredCustomers.Count);
        }
    }
}
