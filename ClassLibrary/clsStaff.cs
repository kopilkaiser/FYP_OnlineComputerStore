using System;

namespace ClassLibrary
{
    public class clsStaff
    {
        private int mStaffId;
        private int mAccountNo;
        private string mName;
        private string mPhonenum;
        private decimal mSalary;
        private DateTime mDateJoined;
        private bool mActive;

        public int StaffId
        {
            get
            {
                return mStaffId;
            }

            set
            {
                mStaffId = value;
            }
        }

        public int AccountNo
        {
            get
            {
                return mAccountNo;
            }
            set
            {
                mAccountNo = value;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        public string Phonenum
        {
            get
            {
                return mPhonenum;
            }
            set
            {
                mPhonenum = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return mSalary;
            }
            set
            {
                mSalary = value;
            }
        }

        public DateTime DateJoined
        {
            get
            {
                return mDateJoined;
            }
            set
            {
                mDateJoined = value;
            }
        }

        public bool Active
        {
            get
            {
                return mActive;
            }
            set
            {
                mActive = value;
            }
        }

        public string Valid(string name, string phonenum, string salary, string dateJoined, string accountNo)
        {
            string Error = "";
            Int64 PhonenumTemp;
            decimal SalaryTemp;
            DateTime DateTemp;
            Int64 AccountNoTemp;


            if (name.Length == 0)
            {
                Error = Error + "The Name field cannot be left blank : ";
            }

            if (name.Length > 40)
            {
                Error = Error + "The Name field cannot exceed 40 characters : ";
            }

            //if Account No entered is valid
            try
            {
                AccountNoTemp = Convert.ToInt64(accountNo);

                if (AccountNoTemp > 1000000)
                {
                    Error = Error + "The Account number has reached it's limit : ";
                }

                if (AccountNoTemp <= 0)
                {
                    Error = Error + "The Account number has to be greater than 0 : ";
                }
            }

            //if Phone number entered is invalid
            catch
            {
                Error = Error + "The Account number entered is invalid : ";
            }


            //if Phone number entered is valid
            try
            {
                PhonenumTemp = Convert.ToInt64(phonenum);

                if (PhonenumTemp > 999999999999999)
                {
                    Error = Error + "The Phone number cannot exceed more than 15 numbers : ";
                }

                if (PhonenumTemp < 12345678912)
                {
                    Error = Error + "The Phone number cannot be less than 11 numbers : ";
                }
            }

            //if Phone number entered is invalid
            catch
            {
                Error = Error + "The Phone number entered is invalid : ";
            }

            //If Salary entered is a valid input
            try
            {
                SalaryTemp = Convert.ToDecimal(salary);

                if (SalaryTemp > 100000.00m)
                {
                    Error = Error + "The Salary amount exceeds the maximum limit : ";
                }

                if (SalaryTemp < 0.00m)
                {
                    Error = Error + "The Salary cannot be negative : ";
                }
            }
            //if salary entered is invalid
            catch
            {
                Error = Error + "The Salary entered is an invalid input : ";
            }

            //If Date entered is a valid date
            try
            {
                DateTemp = Convert.ToDateTime(dateJoined);

                //if date entered is less that today's date
                if (DateTemp < DateTime.Now.Date)
                {
                    //record the error message
                    Error = Error + "Date cannot be in the past : ";
                }
                //if date entered is in the future
                if (DateTemp > DateTime.Now.Date)
                {
                    //record the error message
                    Error = Error + "Date cannot be in the future : ";
                }
            }
            //if Date entered is an invalid date
            catch
            {
                //record the error
                Error = Error + "Date entered is an invalid date : ";
            }

            return Error;
        }

        public bool Find(int StaffId)
        {
            //create an instane of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Staff Id to search for
            DB.AddParameter("@StaffId", StaffId);
            //execute the stored procedure
            DB.Execute("sproc_tblStaff_FilterByStaffId");
            //if one record is found(there should be either one or zero!)
            if(DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mStaffId = Convert.ToInt32(DB.DataTable.Rows[0]["StaffId"]);
                mName = Convert.ToString(DB.DataTable.Rows[0]["Name"]);
                mPhonenum = Convert.ToString(DB.DataTable.Rows[0]["Phonenum"]);
                mSalary = Convert.ToDecimal(DB.DataTable.Rows[0]["Salary"]);
                mDateJoined = Convert.ToDateTime(DB.DataTable.Rows[0]["DateJoined"]);
                mActive = Convert.ToBoolean(DB.DataTable.Rows[0]["Active"]);
                //return that everything worked ok
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating a problem
                return false;
            }
        }

        public string AllDetails
        {
            get
            {
                return ("StaffId:" + StaffId + "_" + "AccountNo:" + AccountNo + "_" + "Name:" + Name + "_" + "Phonenum:" + 
                       Phonenum + "_" + "Salary:" + Salary + "_" + "DateJoined:" + DateJoined.ToString("dd/MM/yyyy") + "_" + "Active:" + Active + "_" );
            }
        }
    }
}