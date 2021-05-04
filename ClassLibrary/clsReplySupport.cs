using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsReplySupport
    {
        private int mReplySupportId;
        private string mEmail;
        private string mDescription;
        private DateTime mDateReplied;

        public int ReplySupportId
        {
            get
            {
                return mReplySupportId;
            }
            set
            {
                mReplySupportId = value;
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

        public DateTime DateReplied
        {
            get
            {
                return mDateReplied;
            }
            set
            {
                mDateReplied = value;
            }
        }

        public string Valid(string email, string description, string dateReplied)
        {
            string Error = "";

            DateTime DateTemp;


           
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
            
            //if date entered is a valid date
            try
            {
                // convert the string value to DateTime
                //& then copy the value of dateAdded to DateTemp variable
                DateTemp = Convert.ToDateTime(dateReplied);
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

        public bool Find(int ReplySupportId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Inventory id to search for
            DB.AddParameter("@ReplySupportId", ReplySupportId);
            //execute the stored procedure
            DB.Execute("sproc_tblReplySupport_FilterByReplySupportId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mReplySupportId = Convert.ToInt32(DB.DataTable.Rows[0]["ReplySupportId"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mDescription = Convert.ToString(DB.DataTable.Rows[0]["Description"]);
                mDateReplied = Convert.ToDateTime(DB.DataTable.Rows[0]["DateReplied"]);

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
                return ("Id:" + ReplySupportId + "__" + "Email: " + Email + "__" + "Description: " + "Click 'Update' to View Reply " + "__" + "DateReplied: " + DateReplied.ToString("dd/MM/yyyy"));
            }
        }
    }
}
