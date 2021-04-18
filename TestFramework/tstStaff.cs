using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestFramework
{
    [TestClass]
    public class tstStaff   
    {
        //some good test data
        int StaffId = 1; //Primary Key (unique identifier)
        int AccountNo = 1;
        string Name = "Raj Shah";       
        string Phonenum = Convert.ToString(44111122223333);
        string Salary = 10000.99m.ToString();
        string DateJoined = DateTime.Now.Date.ToString();
        bool Active = true;
        


        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of class Staff
            clsStaff AStaff = new clsStaff();
            //test to see that exists
            Assert.IsNotNull(AStaff);
        }

        //Testing if all the Property fields are in the class
        [TestMethod]
        public void NamePropertyOK()
        {
            //create an instance of the class we want to create
            clsStaff AStaff = new clsStaff();
            //create some test data to assign to the property
            string Name = "Abdul Badshah";
            //assign the data to the property
            AStaff.Name = Name;
            //test to see that the two values are the same
            Assert.AreEqual(AStaff.Name, Name);

        }

        [TestMethod]
        public void PhonenumPropertyOK()
        {
            //create an instance of the class we want to create
            clsStaff AStaff = new clsStaff();
            //create some test data to assign to the property
            string Phonenum = "08867884623";
            //assign the data to the property
            AStaff.Phonenum = Phonenum;
            //test to see that the two values are the same
            Assert.AreEqual(AStaff.Phonenum, Phonenum);

        }

        [TestMethod]
        public void SalaryPropertyOK()
        {
            //create an instance of the class we want to create
            clsStaff AStaff = new clsStaff();
            //create some test data to assign to the property
            decimal Salary = 19999.99m;
            //assign the data to the property
            AStaff.Salary = Salary;
            //test to see that the two values are the same
            Assert.AreEqual(AStaff.Salary, Salary);

        }

        [TestMethod]
        public void DateJoinedPropertyOK()
        {
            //create an instance of the class we want to create
            clsStaff AStaff = new clsStaff();
            //create some test data to assign to the property
            DateTime DateJoined = DateTime.Now.Date;
            //assign the data to the property
            AStaff.DateJoined = DateJoined;
            //test to see that the two values are the same
            Assert.AreEqual(AStaff.DateJoined, DateJoined);

        }

        [TestMethod]
        public void ActivePropertyOK()
        {
            //create an instance of the class we want to create
            clsStaff AStaff = new clsStaff();
            //create some test data to assign to the property
            bool Active = true;
            //assign the data to the property
            AStaff.Active = Active;
            //test to see that the two values are the same
            Assert.AreEqual(AStaff.Active, Active);

        }
        //testing to see if the Valid method exists
        [TestMethod]
        public void ValidMethodOK()
        {
            //create an instance of the class we want to create
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of the validation
            string Error = "";
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see that the two values are the same
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class we want to create
            clsStaff AnStaff = new clsStaff();
            //boolean variable to store the result of the validation
            Boolean Found = false;
            //create some test data to use with method
            int StaffId = 1;
            //invoke the method
            Found = AnStaff.Find(StaffId);
            //test to see that the result is correct
            Assert.IsTrue(Found);
        }

        //Test methods for "Name" property

        [TestMethod]
        public void NameExtremeMin()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Name = "";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void NameMinMinusOne()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Name = "";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void NameMinBoundary()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Name = "a";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void NameMinPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Name = "aa";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void NameMaxMinusOne()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(39, 'a');
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMaxBoundary()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(40, 'a');
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMaxPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(41, 'a');
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void NameMid()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(20, 'a');
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameExtremeMax()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Name = "";
            Name = Name.PadRight(500, 'a');
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        //Test methods for"Phonenum" Property
        [TestMethod]
        public void PhonenumExtremeMin()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Phonenum = "";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMinMinusOne()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Phonenum = "1234567891";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");

        }
        [TestMethod]
        public void PhonenumMinBoundary()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Phonenum = "12345678912";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void PhonenumMinPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Phonenum = "123456789123";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void PhonenumMaxMinusOne()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Phonenum = "12345678912345";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMaxBoundary()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Phonenum = "123456789123456";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMaxPlusOne()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Phonenum = "1234567891234567";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumMid()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Phonenum = "1234567";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PhonenumExtremeMax()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string Phonenum = "";
            Phonenum = Phonenum.PadRight(500, '1');
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        //Test methods for "Salary" Property
        [TestMethod]
        public void SalaryExtremeMin()
        {
            //create an instance of the class Staff
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of validation
            string Error = "";
            //create some test data to test the method
            string Salary = Convert.ToString(-99999.99m);
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see the result is not OK. For i.e., an error message should return
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void SalaryMinMinusOne()
        {
            //create an instance of the class Staff
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of validation
            string Error = "";
            //create some test data to test the method
            string Salary = Convert.ToString(-1m);
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see the result is not OK. For i.e., an error message should return
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void SalaryMin()
        {
            //create an instance of the class Staff
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of validation
            string Error = "";
            //create some test data to test the method
            string Salary = Convert.ToString(0m);
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see the result is not OK. For i.e., an error message should return
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void SalaryMinPlusOne()
        {
            //create an instance of the class Staff
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of validation
            string Error = "";
            //create some test data to test the method
            string Salary = Convert.ToString(1m);
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see the result is not OK. For i.e., an error message should return
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void SalaryMaxMinusOne()
        {
            //create an instance of the class Staff
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of validation
            string Error = "";
            //create some test data to test the method
            string Salary = Convert.ToString(99999.00m);
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see the result is not OK. For i.e., an error message should return
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void SalaryMax()
        {
            //create an instance of the class Staff
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of validation
            string Error = "";
            //create some test data to test the method
            string Salary = Convert.ToString(100000.00m);
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see the result is not OK. For i.e., an error message should return
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void SalaryMaxPlusOne()
        {
            //create an instance of the class Staff
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of validation
            string Error = "";
            //create some test data to test the method
            string Salary = Convert.ToString(100001.00m);
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see the result is not OK. For i.e., an error message should return
            Assert.AreNotEqual(Error, "");
        }
        
        [TestMethod]
        public void SalaryMid()
        {
            //create an instance of the class Staff
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of validation
            string Error = "";
            //create some test data to test the method
            string Salary = Convert.ToString(50000.00m);
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see the result is not OK. For i.e., an error message should return
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void SalaryExtremeMax()
        {
            //create an instance of the class Staff
            clsStaff AStaff = new clsStaff();
            //create a string variable to store the result of validation
            string Error = "";
            //create some test data to test the method
            string Salary = Convert.ToString(99999999999.99m);
            //invoke the method
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            //test to see the result is not OK. For i.e., an error message should return
            Assert.AreNotEqual(Error, "");
        }

        //TestMethods for DateJoined property 

        [TestMethod]
        public void DateJoinedExtremeMin()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddYears(-100);
            string DateJoined = TestDate.ToString();
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateJoinedMinMinusOne()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddDays(-1);
            string DateJoined = TestDate.ToString();
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DateJoinedMinBoundary()
        {
            clsStaff AStaff = new clsStaff();
            string DateJoined = DateTime.Now.Date.ToString();
            string Error = "";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DateJoinedExtremeMax()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = DateTime.Now.AddYears(100);
            string DateJoined = TestDate.ToString();
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DateJoinedInvalidDataType()
        {
            clsStaff AStaff = new clsStaff();
            string Error = "";
            string DateJoined = "a";
            Error = AStaff.Valid(Name, Phonenum, Salary, DateJoined);
            Assert.AreNotEqual(Error, "");
        }
    }
}
