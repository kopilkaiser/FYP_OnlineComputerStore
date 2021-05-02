using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstSupportCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            clsSupportCollection AllSupport = new clsSupportCollection();
            // teat to see tha t it exist
            Assert.IsNotNull(AllSupport);
        }
        [TestMethod]
        public void ThisSupportPropertyOK()
        {
            // create an instance of the class we want to create
            clsSupportCollection AllSupport = new clsSupportCollection();
            // create some test data to assign the property
            clsSupport TestSupport = new clsSupport();
            // set the properties of the object
            TestSupport.SupportId = 1;
            TestSupport.Email = "gogo@pro.com";
            TestSupport.Name = "GoGo Pro";
            TestSupport.Description = "A new invention in Camera module";
            TestSupport.Phonenum = "11111111111";
            TestSupport.DateSubmitted = DateTime.Now.Date;
            // assign the data to the property
            AllSupport.ThisSupport = TestSupport;
            // test to see that the two values are the same
            Assert.AreEqual(AllSupport.ThisSupport, TestSupport);

        }
        [TestMethod]
        public void AddMethodOK()
        {
            // create an instance for the class we want to create
            clsSupportCollection AllSupport = new clsSupportCollection();

            // create the item of the test data
            clsSupport TestItem = new clsSupport();

            // var to store the primary key
            Int32 PrimaryKey = 0;
            // set it properties
            TestItem.SupportId = 2;
            TestItem.Email = "gogo@pro.com";
            TestItem.Name = "GoGo Pro";
            TestItem.Description = "A new invention in Camera module";
            TestItem.Phonenum = "11111111111";
            TestItem.DateSubmitted = DateTime.Now.Date;

            // set thisAdress to the test data
            AllSupport.ThisSupport = TestItem;
            // add the record
            PrimaryKey = AllSupport.Add();
            // set the primary key TestI data
            TestItem.SupportId = PrimaryKey;
            // find the record
            AllSupport.ThisSupport.Find(PrimaryKey);

            // test to see that the two values are the same
            Assert.AreEqual(AllSupport.ThisSupport, TestItem);

        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            // create an instance for the class we want to create
            clsSupportCollection AllSupport = new clsSupportCollection();

            // create the item of the test data
            clsSupport TestItem = new clsSupport();
            // var to store the primary key
            Int32 PrimaryKey = 0;
            // set it properties
            TestItem.SupportId = 2;
            TestItem.Email = "gogo@pro.com";
            TestItem.Name = "GoGo Pro";
            TestItem.Description = "A new invention in Camera module";
            TestItem.Phonenum = "11111111111";
            TestItem.DateSubmitted = DateTime.Now.Date;
            // set thisAdress to the test data
            AllSupport.ThisSupport = TestItem;
            // add the record
            PrimaryKey = AllSupport.Add();
            // set the primary key TestI data
            TestItem.SupportId = PrimaryKey;
            // find the record
            AllSupport.ThisSupport.Find(PrimaryKey);
            // delete the record
            AllSupport.Delete();
            //now find the record
            Boolean Found = AllSupport.ThisSupport.Find(PrimaryKey);

            // test to see that the record was not found
            Assert.IsFalse(Found);

        }

        [TestMethod]

        public void UpdateMethodOK()
        {
            // create an instance for the class we want to create
            clsSupportCollection AllSupport = new clsSupportCollection();

            // create the item of the test data
            clsSupport TestItem = new clsSupport();
            // var to store the primary key
            Int32 PrimaryKey = 0;
            // set it properties
            TestItem.SupportId = 2;
            TestItem.Email = "gogo@pro.com";
            TestItem.Name = "GoGo Pro";
            TestItem.Description = "A new invention in Camera module";
            TestItem.Phonenum = "11111111111";
            TestItem.DateSubmitted = DateTime.Now.Date;
            // set thisAdress to the test data
            AllSupport.ThisSupport = TestItem;
            // add the record
            PrimaryKey = AllSupport.Add();
            // set the primary key TestI data
            TestItem.SupportId = PrimaryKey;
            // modify the test data
            TestItem.Email = "Samsung@Intense.com";
            TestItem.Name = "Samsung CameraPro";
            TestItem.Description = "Samsung's Latest Camera";
            TestItem.Phonenum = "22222222222";
            TestItem.DateSubmitted = DateTime.Now.Date;
            // set the record based on the new test data
            AllSupport.ThisSupport = TestItem;
            // Update the record
            AllSupport.Update();
            // find the record
            AllSupport.ThisSupport.Find(PrimaryKey);
            // test to see that the record was not found
            Assert.AreEqual(AllSupport.ThisSupport, TestItem);

        }
    }
}
