using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestFramework
{
    [TestClass]
    public class tstOrderline
    {

        // some good data to pass the method 
        int OrderlineId = 1;
        string OrderId = "2";
        string InventoryId = "1";
        string Quantity = "2";


        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of class Orderline
            clsOrderline AnOrderline = new clsOrderline();
            // test to see that it exist
            Assert.IsNotNull(AnOrderline);
        }


        [TestMethod]
        public void QuantityPropertyOK()
        {
            //create an instance of class Orderlineline
            clsOrderline AnOrderline = new clsOrderline();
            // create some test dat to assign the property
            int Quantity = 1;
            // assign the data to the property
            AnOrderline.Quantity = Quantity;
            //test to see that it exist
            Assert.AreEqual(AnOrderline.Quantity, Quantity);

        }
        [TestMethod]
        public void InventoryIdPropertyOK()
        {
            //create an instance of class Orderlineline
            clsOrderline AnOrderline = new clsOrderline();
            // create some test dat to assign the property
            int InventoryId = 1;
            // assign the data to the property
            AnOrderline.InventoryId = InventoryId;
            //test to see that it exist
            Assert.AreEqual(AnOrderline.InventoryId, InventoryId);

        }
        public void ValidMethodOK()
        {
            //create an instance of class Orderline
            clsOrderline AnOrderline = new clsOrderline();
            // test to see that it exist
            string Error = "";
            string OrderId = 1.ToString();
            string InventoryId = 2.ToString();
            string Quantity = 5.ToString();
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreEqual(Error, "");

        }
        [TestMethod]
        public void FindMethodOK()
        {
            // create an instance of the class
            clsOrderline AnOrderline = new clsOrderline();
            // boolean variable to store the result of validation
            Boolean Found = false;
            // some test data to test the method
            Int32 OrderId = 1;
            // invoke the method
            Found = AnOrderline.Find(OrderId);
            // test to see that the result is correct
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void QuantityMinLessOne()
        {
            //create an instance of class Orderlineline
            clsOrderline AnOrderline = new clsOrderline();
            // create an string variable to store the result of validation
            String Error = "";
            // create some test data to the test method
            string Quantity = "0";
            // invoke the method
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            // test to see that result is ok , e, g - There shold be an error message
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void OrderlineIdPropertyOK()
        {
            clsOrderline AnOrderline = new clsOrderline();
            int OrderlineId = 567;
            AnOrderline.OrderlineId = OrderlineId;
            Assert.AreEqual(OrderlineId, AnOrderline.OrderlineId);
        }
        [TestMethod]


        public void QuantityMinBoundary()
        {
            //create an instance of class Orderline
            clsOrderline AnOrderline = new clsOrderline();
            // create an string variable to store the result of validation
            String Error = "";
            // create some test data to the test method
            string Quantity = "1";
            // invoke the method
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            // test to see that result is ok , e, g - There should be an error message
            Assert.AreEqual(Error, "");

        }
        [TestMethod]
        public void QuantityMinPlusOne()
        {
            //create an instance of class Orderline
            clsOrderline AnOrderline = new clsOrderline();
            // create an string variable to store the result of validation
            String Error = "";
            // create some test data to the test method
            string Quantity = "2";
            // invoke the method
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            // test to see that result is ok , e, g - There should be NO error message
            Assert.AreEqual(Error, "");

        }
        [TestMethod]
        public void QuantityMaxBoundary()
        {
            //create an instance of class Orderline
            clsOrderline AnOrderline = new clsOrderline();
            // create an string variable to store the result of validation
            String Error = "";
            // create some test data to the test method
            string Quantity = 100.ToString();
            // invoke the method
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            // test to see that result is ok , e, g - There should be NO error message
            Assert.AreEqual(Error, "");

        }
        [TestMethod]
        public void QuantityMaxPlusOne()
        {
            //create an instance of class Orderline
            clsOrderline AnOrderline = new clsOrderline();
            // create an string variable to store the result of validation
            String Error = "";
            // create some test data to the test method
            string Quantity = "101";
            // invoke the method
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            // test to see that result is ok , e, g - There should be an error message
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void QuantityMid()
        {
            //create an instance of class Orderline
            clsOrderline AnOrderline = new clsOrderline();
            // create an string variable to store the result of validation
            String Error = "";
            // create some test data to the test method
            string Quantity = "50";
            // invoke the method
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            // test to see that result is ok , e, g - There should be no error message
            Assert.AreEqual(Error, "");

        }
        [TestMethod]
        public void QuantityExtremeMax()
        {
            //create an instance of class Orderline
            clsOrderline AnOrderline = new clsOrderline();
            // create an string variable to store the result of validation
            String Error = "";
            // create some test data to the test method
            string Quantity = 10000.ToString();
            // invoke the method
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            // test to see that result is ok , e, g - There should be an error message
            Assert.AreNotEqual(Error, "");

        }
        ////////////////////////////
        /// // testing for Inventory Id

        [TestMethod]
        public void InventoryIdExtremeMin()
        {
            //create an instance of class Orderline
            clsOrderline AnOrderline = new clsOrderline();
            // create an string variable to store the result of validation
            string Error = "";
            string InventoryId = "";
            // invoke the method
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void InventoryIdMinMinusOne()
        {
            clsOrderline AnOrderline = new clsOrderline();
            string Error = "";
            string InventoryId = "";
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void InventoryIdMinBoundary()
        {
            clsOrderline AnOrderline = new clsOrderline();
            string Error = "";
            string InventoryId = "1";
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void InventoryIdMinPlusOne()
        {
            clsOrderline AnOrderline = new clsOrderline();
            string Error = "";
            string InventoryId = "2";
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void InventoryIdMaxMinusOne()
        {
            clsOrderline AnOrderline = new clsOrderline();
            string Error = "";
            string InventoryId = "99999";
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void InventoryIdMaxBoundary()
        {
            clsOrderline AnOrderline = new clsOrderline();
            string Error = "";
            string InventoryId = "100000";
            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void InventoryIdMaxPlusOne()
        {
            clsOrderline AnOrderline = new clsOrderline();
            string Error = "";
            string InventoryId = "100001";

            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void InventoryIdMid()
        {
            clsOrderline AnOrderline = new clsOrderline();
            string Error = "";
            string InventoryId = "50000";

            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void InventoryIdExtremeMax()
        {
            clsOrderline AnOrderline = new clsOrderline();
            string Error = "";
            string InventoryId = "50000000";

            Error = AnOrderline.Valid(OrderId, InventoryId, Quantity);
            Assert.AreNotEqual(Error, "");
        }
    }
}
