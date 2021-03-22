using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCustomer
    {
        private int mCustomerId;
        private int mAccountNo;
        private string mName;
        private string mPhonenum;         
        private DateTime mDateJoined; 
        private bool mActive; 

        public int CustomerId
        {
            get
            {
                return mCustomerId;
            }

            set
            {
                mCustomerId = value;
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



        public string Valid(string name, string phonenum, string accountNo, string dateJoined)
        {
            string Error = "";
            DateTime DateTemp;
            Int32 AccountNoTemp;
            Int64 PhonenumTemp;

            //If Name field is left blank
            if(name.Length == 0)
            {
                Error = Error + "The name cannot be blank : ";
            }
            //If Name field input exceeds 40 characters
            if(name.Length > 40)
            {
                Error = Error + "The name cannot exceed 40 charachters : ";
            }
            //if AccountNo is a valid number
            try
            {
                AccountNoTemp = Convert.ToInt32(accountNo);

                if (AccountNoTemp > 10000)
                {
                    Error = Error + "Account No can not be exceed the limit of 10 : ";
                }

                if (AccountNoTemp <= 0)
                {
                    Error = Error + "Please enter an Account No: ";
                }
            }
            //if AccountNo is an invalid number
            catch
            {
                //record the error
                Error = Error + "The AccountNo is not valid: ";
            }

            //if Phone number entered is valid
            try
            {
                PhonenumTemp = Convert.ToInt64(phonenum);

                if (PhonenumTemp > 111111111111111)
                {
                    Error = Error + "The Phone number cannot exceed more than 15 numbers : ";
                }

                if (PhonenumTemp < 11111111111)
                {
                    Error = Error + "The Phone number cannot be less than 11 numbers : ";
                }
            }
            //if Phone number entered is invalid
            catch
            {
                Error = Error + "The Phone number entered is invalid : ";
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

        public bool Find(int CustomerId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the AccountNo to search for
            DB.AddParameter("@CustomerId", CustomerId);
            //execute the stored procedure
            DB.Execute("sproc_tblCustomer_FilterByCustomerId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mCustomerId = Convert.ToInt32(DB.DataTable.Rows[0]["CustomerId"]);
                mAccountNo = Convert.ToInt32(DB.DataTable.Rows[0]["AccountNo"]);
                mName = Convert.ToString(DB.DataTable.Rows[0]["Name"]);
                mPhonenum = Convert.ToString(DB.DataTable.Rows[0]["Phonenum"]);
                mDateJoined = Convert.ToDateTime(DB.DataTable.Rows[0]["DateJoined"]);
                mActive = Convert.ToBoolean(DB.DataTable.Rows[0]["Active"]); ;

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
                return ("CustomerId:" + CustomerId + "_" + "AccountNo:" + AccountNo + "_" + "Name:" + Name + "_" + "Phonenum:" + Phonenum + "_"
                    + "DateJoined:" + DateJoined.ToString("dd/MM/yyyy") + "_" + "Active:" + Active);
            }
        }

    }
}
