using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsSupport
    {
        private int mSupportId;
        private string mEmail;
        private string mName;
        private string mDescription;
        private string mPhonenum;
        private DateTime mDateSubmitted;

        public int SupportId
        {
            get
            {
                return mSupportId;
            }
            set
            {
                mSupportId = value;
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

        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
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

        public DateTime DateSubmitted
        {
            get
            {
                return mDateSubmitted;
            }
            set
            {
                mDateSubmitted = value;
            }
        }

        public string Valid(string email, string name, string description, string phonenum, string dateSubmitted)
        {
            string Error = "";

            Int64 PhonenumTemp;
            DateTime DateTemp;


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

            if (description.Length == 0)
            {
                Error = Error + "The Description cannot be blank : ";
            }

            if (description.Length > 250)
            {
                Error = Error + "The Description cannot exceed 250 characters : ";
            }


            //if Phonenum entered is a valid Phone number
            try
            {
                PhonenumTemp = Convert.ToInt64(phonenum);

                if (PhonenumTemp > 111111111111)
                {
                    Error = Error + "The Phone number requires to be 11 digits : ";
                }

                if (PhonenumTemp < 1111111111)
                {
                    Error = "The Phone number requires to be 11 digits : ";
                }
            }
            catch
            {
                Error = Error + "The Phone number entered is invalid : ";
            }

            //if date entered is a valid date
            try
            {
                // convert the string value to DateTime
                //& then copy the value of dateAdded to DateTemp variable
                DateTemp = Convert.ToDateTime(dateSubmitted);
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

        public bool Find(int ReviewId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Inventory id to search for
            DB.AddParameter("@SupportId", SupportId);
            //execute the stored procedure
            DB.Execute("sproc_tblSupport_FilterBySupportId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mSupportId = Convert.ToInt32(DB.DataTable.Rows[0]["SupportId"]);
                mName = Convert.ToString(DB.DataTable.Rows[0]["Name"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mPhonenum = Convert.ToString(DB.DataTable.Rows[0]["Phonenum"]);
                mDescription = Convert.ToString(DB.DataTable.Rows[0]["Description"]);
                mDateSubmitted = Convert.ToDateTime(DB.DataTable.Rows[0]["DateSubmitted"]);

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
                return ("SupportId:" + SupportId + "__" + "Email:" + Email + "__" + "Name:" + Name + "__" + "Phonenum"
                    + Phonenum + "__" + "Description:" + "Click Update to View" + "__" + "DateSubmitted:" + DateSubmitted.ToString("dd/MM/yyyy"));
            }
        }
    }
}
