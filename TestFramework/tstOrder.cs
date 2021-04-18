using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstOrder
    {
        //some good test data
        int OrderId = 1;
        string Email = "moosasamsurladi@gmail.com";
        string TotalPrice = "2959.99";
        string DateOrdered = DateTime.Now.Date.ToString();
        string Phonenum = "1111111111111111";
        string ShippingAddress = "99 Grasmere Street, LE2 7DA, Leicester";

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class
            clsOrder AnOrder = new clsOrder();
            Assert.IsNotNull(AnOrder);
        }

  
        [TestMethod]
        public void EmailPropertyOK()
        {
            clsOrder AnOrder = new clsOrder();
            string Email = "Cadbury";
            AnOrder.Email = Email;
            Assert.AreEqual(Email, AnOrder.Email);
        }

        [TestMethod]
        public void TotalPricePropertyOK()
        {
            clsOrder AnOrder = new clsOrder();
            decimal TotalPrice = 5.99m;
            AnOrder.TotalPrice = TotalPrice;
            Assert.AreEqual(TotalPrice, AnOrder.TotalPrice);
        }

        [TestMethod]
        public void DateOrderedPropertyOK()
        {
            clsOrder AnOrder = new clsOrder();
            DateTime DateOrdered = DateTime.Now.Date;
            AnOrder.DateOrdered = DateOrdered;
            Assert.AreEqual(DateOrdered, AnOrder.DateOrdered);
        }

        [TestMethod]
        public void PhonenumPropertyOK()
        {
            clsOrder AnOrder = new clsOrder();
            string Phonenum = "1111111111111111";
            AnOrder.Phonenum = Phonenum;
            Assert.AreEqual(Phonenum, AnOrder.Phonenum);
        }

        [TestMethod]
        public void ShippingAddressPropertyOK()
        {
            clsOrder AnOrder = new clsOrder();
            string ShippingAddress = "99 Grasmere Street, LE2 7DA, Leicester";
            AnOrder.ShippingAddress = ShippingAddress;
            Assert.AreEqual(ShippingAddress, AnOrder.ShippingAddress);
        }

        [TestMethod]
        public void ValidMethodOK()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class we want to create
            clsOrder AnOrder = new clsOrder();
            //boolean variable to store the result of the validation
            Boolean Found = false;
            //create some test data to use with the method
            int OrderId = 1;
            //invoke the method
            Found = AnOrder.Find(OrderId);
            //test to see that the result is correct
            Assert.IsTrue(Found);
        }

        //TestMethods for DateOrdered property by different test types and test data
        [TestMethod]
        public void DateOrderedExtremeMin()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddYears(-100);
            string DateOrdered = TestDate.ToString();
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateOrderedMinMinusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddDays(-1);
            string DateOrdered = TestDate.ToString();
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DateOrderedMinBoundary()
        {
            clsOrder AnOrder = new clsOrder();
            string DateOrdered = DateTime.Now.Date.ToString();
            string Error = "";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DateOrderedExtremeMax()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddYears(100);
            string DateOrdered = TestDate.ToString();
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DateOrderedInvalidDataType()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string DateOrdered = "a";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        //TestMethods for Email property by different test types and test data

        [TestMethod]
        public void EmailExtremeMin()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Email = "";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EmailMinMinusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Email = "";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void EmailMinBoundary()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Email = "a";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void EmailMinPlusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Email = "aa";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void EmailMaxMinusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Email = "";
            Email = Email.PadRight(39, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EmailMaxBoundary()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Email = "";
            Email = Email.PadRight(40, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EmailMaxPlusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Email = "";
            Email = Email.PadRight(41, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EmailMid()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Email = "";
            Email = Email.PadRight(20, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EmailExtremeMax()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Email = "";
            Email = Email.PadRight(500, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        //TestMethods for TotalPrice property by different Test Types and Test Data

        [TestMethod]
        public void TotalPriceExtremeMin()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TotalPrice = "-1";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TotalPriceMinMinusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TotalPrice = "-1";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void TotalPriceMinBoundary()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TotalPrice = "0";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void TotalPriceMinPlusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TotalPrice = "2";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void TotalPriceMaxMinusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TotalPrice = "9999";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TotalPriceMaxBoundary()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TotalPrice = "100000";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TotalPriceMaxPlusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TotalPrice = "100001";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TotalPriceMid()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TotalPrice = "50000";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TotalPriceExtremeMax()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string TotalPrice = "999999999.99";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        //TestMethods for ShippingAddress property
        [TestMethod]
        public void ShippingAddressExtremeMin()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string ShippingAddress = "";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void ShippingAddressMinMinusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string ShippingAddress = "";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void ShippingAddressMinBoundary()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string ShippingAddress = "a";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void ShippingAddressMinPlusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string ShippingAddress = "aa";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void ShippingAddressMaxMinusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string ShippingAddress = "";
            ShippingAddress = ShippingAddress.PadRight(249, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ShippingAddressMaxBoundary()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string ShippingAddress = "";
            ShippingAddress = ShippingAddress.PadRight(250, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ShippingAddressMaxPlusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string ShippingAddress = "";
            ShippingAddress = ShippingAddress.PadRight(251, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void ShippingAddressMid()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string ShippingAddress = "";
            ShippingAddress = ShippingAddress.PadRight(125, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ShippingAddressExtremeMax()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string ShippingAddress = "";
            ShippingAddress = ShippingAddress.PadRight(500, 'a');
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        //TestMethods for Phonenum Property
        [TestMethod]
        public void PhonenumExtremeMin()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Phonenum = "";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMinMinusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Phonenum = "";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void PhonenumMinBoundary()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Phonenum = "1";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void PhonenumMinPlusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Phonenum = "12";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void PhonenumMaxMinusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Phonenum = "12345678912345";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMaxBoundary()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Phonenum = "111111111111111";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMaxPlusOne()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Phonenum = "12345678912345677";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMid()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Phonenum = "1234567896";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumExtremeMax()
        {
            clsOrder AnOrder = new clsOrder();
            string Error = "";
            string Phonenum = "123456789123456789";
            Error = AnOrder.Valid(Email, TotalPrice, DateOrdered, ShippingAddress, Phonenum);
            Assert.AreNotEqual(Error, "");
        }

    }
}
