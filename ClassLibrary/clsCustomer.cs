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
        private string mName;
        private string mPhonenum;
        private string mEmail;
        private DateTime mDateJoined;
        private string mBio;
        private decimal mAccountBalance;


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

        public string Bio
        {
            get
            {
                return mBio;
            }

            set
            {
                mBio = value;
            }
        }

        public string Email
        {
            get
            {
                return mEmail;
            }

            set
            {
                mEmail = value;
            }
        }

        public decimal AccountBalance
        {
            get
            {
                return mAccountBalance;
            }

            set
            {
                mAccountBalance = value;
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

        public string Valid(string name, string phonenum, string email, string dateJoined, string bio, string accountBalance)
        {
            string Error = "";

            DateTime DateTemp;
            decimal AccountBalanceTemp;
            Int64 PhonenumTemp;


            if (name.Length == 0)
            {
                Error = Error + "The Name cannot be blank : ";
            }

            if (name.Length > 40)
            {
                Error = Error + "The Name cannot exceed 40 characters : ";
            }


            if (email.Length == 0)
            {
                Error = Error + "The Email cannot be blank : ";
            }

            if (email.Length > 50)
            {
                Error = Error + "The Email cannot exceed 50 characters : ";
            }

            if (bio.Length == 0)
            {
                Error = Error + "The Bio cannot be blank : ";
            }

            if (bio.Length > 250)
            {
                Error = Error + "The Bio cannot exceed 250 characters : ";
            }

            //if Phonenum entered is a valid balance
            try
            {

                PhonenumTemp = Convert.ToInt64(phonenum);

                if (PhonenumTemp > 111111111111)
                {
                    Error = Error + "The Phonenum cannot be greater than 11 digits : ";
                }

                if (PhonenumTemp < 11111111111)
                {
                    Error = Error + "The Phonenum cannot be less than 11 digits : ";
                }
            }
            catch
            {
                //record the error
                Error = Error + "The Phonenum is invalid : ";
            }

            //if Account Balance entered is a valid balance
            try
            {

                AccountBalanceTemp = Convert.ToDecimal(accountBalance);

                if (AccountBalanceTemp > 10000000m)
                {
                    Error = Error + "The Account Balance has exceeded its limit : ";
                }

                if (AccountBalanceTemp < 0m)
                {
                    Error = Error + "The Account Balance cannot be less than zero : ";
                }
            }
            catch
            {
                //record the error
                Error = Error + "The Account Balance is invalid : ";
            }


            //if date entered is a valid date
            try
            {
                // convert the string value to DateTime
                //& then copy the value of dateAdded to DateTemp variable
                DateTemp = Convert.ToDateTime(dateJoined);
                //if date value is less than today's date
                if (DateTemp < DateTime.Now.Date)
                {
                    //record the error
                    Error = Error + "Date cannot be in the past : ";
                }
                //if date value is more than today's date
                if (DateTemp > DateTime.Now.Date)
                {
                    //record the error
                    Error = Error + "Date cannot be in the future : ";
                }
            }
            //if date entered is an invalid date
            catch
            {
                //record the error
                Error = Error + "Date entered is invalid date : ";
            }

            return Error;
        }

        public bool Find(int CustomerId)
        {
            //create an instane of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Staff Id to search for
            DB.AddParameter("@CustomerId", CustomerId);
            //execute the stored procedure
            DB.Execute("sproc_tblCustomer_FilterByCustomerId");
            //if one record is found(there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mCustomerId = Convert.ToInt32(DB.DataTable.Rows[0]["CustomerId"]);
                mName = Convert.ToString(DB.DataTable.Rows[0]["Name"]);
                mPhonenum = Convert.ToString(DB.DataTable.Rows[0]["Phonenum"]);
                mBio = Convert.ToString(DB.DataTable.Rows[0]["Bio"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mDateJoined = Convert.ToDateTime(DB.DataTable.Rows[0]["DateJoined"]);
                mAccountBalance = Convert.ToDecimal(DB.DataTable.Rows[0]["AccountBalance"]);
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
                return ("Customer Id:" + CustomerId + "_" + "Name:" + Name + "_" + "Email:" + Email + "_" + "Phonenum:" + Phonenum + "_" 
                    + "DateJoined:" + DateJoined.ToString("dd/MM/yyyy") + "_" 
                    + "AccountBalance:" + AccountBalance + "_" + "Bio:" + "Click to view more");
            }
        }
    }
    
}
    