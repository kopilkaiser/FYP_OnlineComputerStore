using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstPayment
    {
        //some  good test data
        int PaymentId = 1;
        string PayeeName = "Michael Jolly";
        string Amount = "9.99";
        string Method = "Visa Debit";
        string CardNumber = "9999999999999999";
        string Email = "gmail@gmail.com";
        string DatePurchased = DateTime.Now.Date.ToString();

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class
            clsPayment APayment = new clsPayment();
            Assert.IsNotNull(APayment);
        }

    
        [TestMethod]
        public void PayeeNamePropertyOK()
        {
            clsPayment APayment = new clsPayment();
            string PayeeName = "Cadbury";
            APayment.PayeeName = PayeeName;
            Assert.AreEqual(PayeeName, APayment.PayeeName);
        }

        [TestMethod]
        public void AmountPropertyOK()
        {
            clsPayment APayment = new clsPayment();
            decimal Amount = 5.99m;
            APayment.Amount = Amount;
            Assert.AreEqual(Amount, APayment.Amount);
        }

        [TestMethod]
        public void MethodPropertyOK()
        {
            clsPayment APayment = new clsPayment();
            string Method = "Visa Debit";
            APayment.Method = Method;
            Assert.AreEqual(Method, APayment.Method);
        }

        [TestMethod]
        public void CardNumberPropertyOK()
        {
            clsPayment APayment = new clsPayment();
            string CardNumber = "4856123648597412";
            APayment.CardNumber = CardNumber;
            Assert.AreEqual(CardNumber, APayment.CardNumber);
        }

        [TestMethod]
        public void EmailPropertyOK()
        {
            //create an instance of the class we want to create
            clsPayment APayment = new clsPayment();
            //create some test data to assign to the property
            string Email = "gmail@gmail.com";
            //assign the data to the property
            APayment.Email = Email;
            //test to see that the two values are the same
            Assert.AreEqual(APayment.Email, Email);
        }

        [TestMethod]
        public void DatePurchasedPropertyOK()
        {
            clsPayment APayment = new clsPayment();
            DateTime DatePurchased = DateTime.Now.Date;
            APayment.DatePurchased = DatePurchased;
            Assert.AreEqual(DatePurchased, APayment.DatePurchased);
        }

        [TestMethod]
        public void ValidMethodOK()
        {
            clsPayment APayment = new clsPayment();
            string Error = "";
            Error = APayment.Valid(PayeeName, Method, Amount, CardNumber, DatePurchased, Email);
            Assert.AreEqual(Error, "");
        }
    }
}
