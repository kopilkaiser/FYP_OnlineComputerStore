using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstPaymentCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //test to see that it exists
            Assert.IsNotNull(AllPayments);
        }

        [TestMethod]
        public void ThisPaymentProperyOK()
        {
            //create the instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //create some test data to assign to the property
            clsPayment TestPayment = new clsPayment();
            //set the properties of the test object
            TestPayment.PaymentId = 1;
            TestPayment.PayeeName = "Samsung OLED TV";
            TestPayment.Amount = 3999.99m;
            TestPayment.CardNumber = "111111111111111";
            TestPayment.Method = "Debit";
            TestPayment.DatePurchased = DateTime.Now.Date;
            TestPayment.Email = "gmail@gmail.com";
            //assign the data to the property
            AllPayments.ThisPayment = TestPayment;
            //test to see that the two values are the same
            Assert.AreEqual(AllPayments.ThisPayment, TestPayment);


        }

        [TestMethod]
        public void AddMethodOK()
        {
            //create the instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //create some test data to assign to the property
            clsPayment TestItem = new clsPayment();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set the properties of the test object
            TestItem.PaymentId = 1;
            TestItem.PayeeName = "Jack Daniel";
            TestItem.Amount = 8888.88m;
            TestItem.CardNumber = "555555555555555";
            TestItem.Method = "MasterCard";
            TestItem.DatePurchased = DateTime.Now.Date;
            TestItem.Email = "hightime@hotmail.com";
            //set ThisPayment to the test data
            AllPayments.ThisPayment = TestItem;
            //add the record
            PrimaryKey = AllPayments.Add();
            //set the primary key to the test data
            TestItem.PaymentId = PrimaryKey;
            //assign the data to the property
            AllPayments.ThisPayment = TestItem;
            //test to see that the two values are the same
            Assert.AreEqual(AllPayments.ThisPayment, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //create the instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //create some test data to assign to the property
            clsPayment TestItem = new clsPayment();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set the properties of the test object
            TestItem.PaymentId = 1;
            TestItem.PayeeName = "Samsung OLED TV";
            TestItem.Amount = 3999.99m;
            TestItem.CardNumber = "111111111111111";
            TestItem.Method = "Debit";
            TestItem.DatePurchased = DateTime.Now.Date;
            TestItem.Email = "gmail@gmail.com";
            //set ThisPayment to the test data
            AllPayments.ThisPayment = TestItem;
            //add the record
            PrimaryKey = AllPayments.Add();
            //set the primary key to the test data
            TestItem.PaymentId = PrimaryKey;
            //modify the test data
            TestItem.PaymentId = 1;
            TestItem.PayeeName = "George Milkin";
            TestItem.Amount = 5555.55m;
            TestItem.CardNumber = "4444444444444444";
            TestItem.Method = "MasterCard";
            TestItem.DatePurchased = DateTime.Now.Date;
            TestItem.Email = "rockaby@gmail.com";
            //assign the new data to the property
            AllPayments.ThisPayment = TestItem;
            //update the record
            AllPayments.Update();
            //find the record
            AllPayments.ThisPayment.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllPayments.ThisPayment, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //create the instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //create some test data to assign to the property
            clsPayment TestItem = new clsPayment();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set the properties of the test object
            TestItem.PaymentId = 7;
            TestItem.PayeeName = "Samsung OLED TV";
            TestItem.Amount = 3999.99m;
            TestItem.CardNumber = "111111111111111";
            TestItem.Method = "Debit";
            TestItem.DatePurchased = DateTime.Now.Date;
            TestItem.Email = "gmail@gmail.com";
            //set ThisPayment to the test data
            AllPayments.ThisPayment = TestItem;
            //add the record
            PrimaryKey = AllPayments.Add();
            //set the primary key to the test data
            TestItem.PaymentId = PrimaryKey;
            //find the record
            AllPayments.ThisPayment.Find(PrimaryKey);
            //delete the record
            AllPayments.Delete();
            //now find the record
            Boolean Found = AllPayments.ThisPayment.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.IsFalse(Found);
        }
    }
}
