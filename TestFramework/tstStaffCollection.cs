using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFramework
{
    [TestClass]
    public class tstStaffCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsStaffCollection AllStaffs = new clsStaffCollection();
            //test to see that it exists
            Assert.IsNotNull(AllStaffs);
        }

        [TestMethod]
        public void ThisStaffPropertyOK()
        {
            //create the instance of the class we want to create
            clsStaffCollection AllStaffs = new clsStaffCollection();
            //create some test data to assign to the property
            clsStaff TestStaff = new clsStaff();
            //set the properties of the test object
            TestStaff.StaffId = 1;
            TestStaff.AccountNo = 1;
            TestStaff.Name = "Syed";
            TestStaff.Phonenum = "123456789123456";
            TestStaff.Salary = 19999.99m;
            TestStaff.DateJoined = DateTime.Now.Date;
            TestStaff.Active = true;
            //TestStaff.IsAdmin = false;
            //assign the data to the property
            AllStaffs.ThisStaff = TestStaff;
            //test to see that the two values are the same;
            Assert.AreEqual(AllStaffs.ThisStaff, TestStaff);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            //create an instance of the class we want to create
            clsStaffCollection AllStaffs = new clsStaffCollection();
            //create the item of test data
            clsStaff TestItem = new clsStaff();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set it's properties
            TestItem.StaffId = 1;
            TestItem.AccountNo = 1;
            TestItem.Name = "Syed";
            TestItem.Phonenum = "123456789123456";
            TestItem.Salary = 19999.99m;
            TestItem.DateJoined = DateTime.Now.Date;
            TestItem.Active = true;
            //set ThisAddress to the test data
            AllStaffs.ThisStaff = TestItem;
            //add the record
            PrimaryKey = AllStaffs.Add();
            //set the primary key of the test data
            TestItem.StaffId = PrimaryKey;
            //find the record
            AllStaffs.ThisStaff.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllStaffs.ThisStaff, TestItem);
        }

        public void DeleteMethodOK()
        {
            //create an instance of the class we want to create
            clsStaffCollection AllStaffs = new clsStaffCollection();
            //create the item of test data
            clsStaff TestItem = new clsStaff();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set it's properties
            TestItem.StaffId = 1;
            TestItem.AccountNo = 1;
            TestItem.Name = "Syed";
            TestItem.Phonenum = "123456789123456";
            TestItem.Salary = 19999.99m;
            TestItem.DateJoined = DateTime.Now.Date;
            TestItem.Active = true;
            //set ThisAddress to the test data
            AllStaffs.ThisStaff = TestItem;
            //add the record
            PrimaryKey = AllStaffs.Add();
            //set the primary key of the test data
            TestItem.AccountNo = PrimaryKey;
            //find the record
            AllStaffs.ThisStaff.Find(PrimaryKey);
            //delete the record
            AllStaffs.Delete();
            //now find the record
            Boolean Found = AllStaffs.ThisStaff.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //create an instance of the class we want to create
            clsStaffCollection AllStaffs = new clsStaffCollection();
            //create the item of test data
            clsStaff TestItem = new clsStaff();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set it's properties
            TestItem.StaffId = 1;
            TestItem.AccountNo = 1;
            TestItem.Name = "Syed";
            TestItem.Phonenum = "123456789123456";
            TestItem.Salary = 19999.99m;
            TestItem.DateJoined = DateTime.Now.Date;
            TestItem.Active = true;
            //set ThisAddress to the test data
            AllStaffs.ThisStaff = TestItem;
            //add the record
            PrimaryKey = AllStaffs.Add();
            //set the primary key of the test data
            TestItem.AccountNo = PrimaryKey;
            //modify the test data
            TestItem.StaffId = 1;
            TestItem.AccountNo = 1;
            TestItem.Name = "Syed";
            TestItem.Phonenum = "123456789123456";
            TestItem.Salary = 19999.99m;
            TestItem.DateJoined = DateTime.Now.Date;
            TestItem.Active = true;
            //set the record based on the new test data
            AllStaffs.ThisStaff = TestItem;
            //update the record
            AllStaffs.Update();
            //find the record
            AllStaffs.ThisStaff.Find(PrimaryKey);
            //test to see ThisInventory matches with test data
            Assert.AreEqual(AllStaffs.ThisStaff, TestItem);
        }

        [TestMethod]
        public void ReportByNameNoneFound()
        {
            //create an instance of the filtered data
            clsStaffCollection FilteredStaffs = new clsStaffCollection();
            //apply a category that doesn't exist
            FilteredStaffs.ReportByName("Kopil");
            //test to see that there are no records
            Assert.AreEqual(0, FilteredStaffs.Count);
        }
    }
}
