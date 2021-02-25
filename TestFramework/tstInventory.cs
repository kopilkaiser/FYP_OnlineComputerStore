using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestFramework
{
    //Module Title & Code: Database Management & Programming, IMAT3104
    //Testing Framework for my project, Online Computer Store
    //Developer: Kopil Kaiser
    //Supervisor: Hakeem Ibrahim

        //Testing for the class Inventory
    [TestClass]
    public class tstInventory
    {
        //For Class Inventory 
        [TestMethod]
        public void clsInventory_InstanceOK()
        {
            //create an instance of the class
            clsInventory AnInventory = new clsInventory();
            Assert.IsNotNull(AnInventory);
        }

        [TestMethod]
        public void ActiveProperyOK()
        {
            //create an instance of the class we want to create
            clsInventory AnInventory = new clsInventory();
            //create some test data to assign to the property
            Boolean TestData = true;
            //assign the data to the property
            AnInventory.Active = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AnInventory.Active, TestData);
        }
        
        //[TestMethod]


    }
}
