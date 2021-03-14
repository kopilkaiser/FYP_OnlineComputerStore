using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsOrder
    {
        private int mOrderId;
        private string mEmail;
        private int mAccountNo;
        private DateTime mDateOrdered;
        private decimal mTotalPrice;

        public int OrderId
        {
            get
            {
                return mOrderId;
            }
            set
            {
                mOrderId = value;
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

        public DateTime DateOrdered
        {
            get
            {
                return mDateOrdered;
            }
            set
            {
                mDateOrdered = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return mTotalPrice;
            }
            set
            {
                mTotalPrice = value;
            }
        }

        public bool Find(int OrderId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Order id to search for
            DB.AddParameter("@OrderId", OrderId);
            //execute the stored procedure
            DB.Execute("sproc_tblOrder_FilterByOrderId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mOrderId = Convert.ToInt32(DB.DataTable.Rows[0]["OrderId"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mAccountNo = Convert.ToInt32(DB.DataTable.Rows[0]["AccountNo"]);
                mDateOrdered = Convert.ToDateTime(DB.DataTable.Rows[0]["DateOrdered"]);
                mTotalPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["TotalPrice"]);

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

        public string Valid(string accountNo, string email, string totalPrice, string dateOrdered)
        {
            string Error = "";
            Int32 AccountNoTemp;
            decimal TotalPriceTemp;
            DateTime DateTemp;

            if (email.Length == 0)
            {
                Error = Error + "The Email field cannot be left blank : ";
            }

            if(email.Length > 40)
            {
                Error = Error + "The Email cannot exceed 40 characters : ";
            }

            try
            {
                AccountNoTemp = Convert.ToInt32(accountNo);

                if (AccountNoTemp <=0)
                {
                    Error = Error + "Please enter an Acccount number : ";
                }

                if(AccountNoTemp > 10000)
                {
                    Error = Error + "Account number cannot exceed 10000 : ";
                }
            }
            catch
            {
                Error = Error + "Please enter a valid Account number : ";
            }

            try
            {
                TotalPriceTemp = Convert.ToDecimal(totalPrice);

                if(TotalPriceTemp <= 0m)
                {
                    Error = Error + "Total price entered cannot be 0 or negative : ";
                }
                if(TotalPriceTemp > 100000.00m)
                {
                    Error = Error + "Total price cannot exceed £100000.00 : ";
                }
            }
            catch
            {
                Error = Error + "The Total price entered is an invalid input : ";
            }

            try
            {
                // convert the string value to DateTime
                //& then copy the value of datejoined to DateTemp variable
                DateTemp = Convert.ToDateTime(dateOrdered);
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
                Error = Error + "The date entered is not a valid date : ";
            }

            return Error;
        }

        public string AllDetails
        {
            get
            {
                return ("OrderId:" + OrderId + "_" + "AccountNo:" + AccountNo + "_"  + "Email:" + Email + "_" + "TotalPrice:" + TotalPrice + "_" + "DateOrdered:" + DateOrdered.ToString("dd/MM/yyyy"));
            }
        }
    }
}
