using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstCustomer
    {
        //some good test data
        string CustomerId = "1";
        string Name = "Smith John";
        string Phonenum = "123456789123456";
        string AccountNo = "1";
        string DateJoined = DateTime.Now.Date.ToString();

        [TestMethod]
        public void InstanceOK()
        {
            clsCustomer ACustomer = new clsCustomer();
            Assert.IsNotNull(ACustomer);
        }

        [TestMethod]
        public void NamePropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            string Name = "John Smith";
            //assign data to the property
            ACustomer.Name = Name;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.Name, Name);
        }

        [TestMethod]
        public void AccountNoPropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            int AccountNo = 1;
            //assign data to the property
            ACustomer.AccountNo = AccountNo;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.AccountNo, AccountNo);
        }

        [TestMethod]
        public void PhonenumPropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            string Phonenum = "123456789123456";
            //assign data to the property
            ACustomer.Phonenum = Phonenum;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.Phonenum, Phonenum);
        }

        [TestMethod]
        public void DateJoinedPropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            DateTime DateJoined = DateTime.Now.Date;
            //assign data to the property
            ACustomer.DateJoined = DateJoined;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.DateJoined, DateJoined);
        }

        [TestMethod]
        public void ValidMethodOK()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //boolean variable to store the result of the validation
            Boolean Found = false;
            //create some test data to use with the method
            int CustomerId = 1;
            //invoke the method
            Found = ACustomer.Find(CustomerId);
            //test to see that the result is correct
            Assert.IsTrue(Found);
        }

        ///////////////////////////////
        //TestMethods for AccountNo property

        [TestMethod]
        public void AccountNoExtremeMin()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string AccountNo = "";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void AccountNoMinMinusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string AccountNo = "";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void AccountNoMinBoundary()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string AccountNo = "9";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void AccountNoMinPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string AccountNo = "99";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void AccountNoMaxMinusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string AccountNo = "9999";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void AccountNoMaxBoundary()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string AccountNo = "10000";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void AccountNoMaxPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string AccountNo = "10001";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void AccountNoMid()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string AccountNo = "5000";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void AccountNoExtremeMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string AccountNo = "500000";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        ///////////////////////////////
        //TestMethods for Name property

        [TestMethod]
        public void NameExtremeMin()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Name = "";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void NameMinMinusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Name = "";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void NameMinBoundary()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Name = "a";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void NameMinPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Name = "aa";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void NameMaxMinusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(39, 'a');
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMaxBoundary()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(40, 'a');
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMaxPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(41, 'a');
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void NameMid()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(25, 'a');
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameExtremeMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(100, 'a');
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        ///////////////////////////////
        //TestMethods for Phonenum property

        [TestMethod]
        public void PhonenumExtremeMin()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Phonenum = "";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMinMinusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Phonenum = "";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void PhonenumMinBoundary()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Phonenum = "1";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void PhonenumMinPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Phonenum = "12";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void PhonenumMaxMinusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Phonenum = "12345678912345";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMaxBoundary()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Phonenum = "123456789123456";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMaxPlusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Phonenum = "1234567891234567";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMid()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Phonenum = "1234567896";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumExtremeMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string Phonenum = "123456789123456789";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        ///////////////////////////////
        //TestMethods for DateJoined property

        [TestMethod]
        public void DateJoinedExtremeMin()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddYears(-100);
            string DateJoined = TestDate.ToString();
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateJoinedMinMinusOne()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddDays(-1);
            string DateJoined = TestDate.ToString();
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DateJoinedMinBoundary()
        {
            clsCustomer ACustomer = new clsCustomer();
            string DateJoined = DateTime.Now.Date.ToString();
            string Error = "";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DateJoinedExtremeMax()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddYears(100);
            string DateJoined = TestDate.ToString();
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DateJoinedInvalidDataType()
        {
            clsCustomer ACustomer = new clsCustomer();
            string Error = "";
            string DateJoined = "a";
            Error = ACustomer.Valid(Name, Phonenum, AccountNo, DateJoined);
            Assert.AreNotEqual(Error, "");
        }
    }
}
