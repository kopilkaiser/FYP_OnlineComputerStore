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


    }
}
