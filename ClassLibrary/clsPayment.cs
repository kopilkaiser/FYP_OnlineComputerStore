﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /*PaymentId, PayeeName, Method, DatePurchased, OrderId, CardNumber, Amount */
    public class clsPayment
    {
        private int mPaymentId;
        private string mPayeeName;
        private string mMethod;
        private string mCardNumber;
        private decimal mAmount;
        private DateTime mDatePurchased;
        private string mEmail;

        public int PaymentId
        {
            get
            {
                return mPaymentId;
            }
            set
            {
                mPaymentId = value;
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
        
        public string PayeeName
        {
            get
            {
                return mPayeeName;
            }
            set
            {
                mPayeeName = value;
            }
        }

        public string Method
        {
            get
            {
                return mMethod;
            }
            set
            {
                mMethod = value;
            }
        }

        public string CardNumber
        {
            get
            {
                return mCardNumber;
            }
            set
            {
                mCardNumber = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return mAmount;
            }
            set
            {
                mAmount = value;
            }
        }

        public DateTime DatePurchased
        {
            get
            {
                return mDatePurchased;
            }
            set
            {
                mDatePurchased = value;
            }
        }



        public bool Find(int PaymentId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Inventory id to search for
            DB.AddParameter("@PaymentId", PaymentId);
            //execute the stored procedure
            DB.Execute("sproc_tblPayment_FilterByPaymentId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mPaymentId = Convert.ToInt32(DB.DataTable.Rows[0]["PaymentId"]);
                mPayeeName = Convert.ToString(DB.DataTable.Rows[0]["PayeeName"]);
                mMethod = Convert.ToString(DB.DataTable.Rows[0]["Method"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mAmount = Convert.ToDecimal(DB.DataTable.Rows[0]["Amount"]);
                mCardNumber = Convert.ToString(DB.DataTable.Rows[0]["CardNumber"]);
                mDatePurchased = Convert.ToDateTime(DB.DataTable.Rows[0]["DatePurchased"]);
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

        public string Valid(string payeeName, string method, string amount, string cardNumber, string datePurchased, string email)
        {
            string Error = "";

            DateTime DateTemp;
            decimal AmountTemp;
            Int64 CardNumberTemp;


            if (email.Length == 0)
            {
                Error = Error + "The Email cannot be blank : ";
            }

            if (email.Length > 40)
            {
                Error = Error + "The Emai cannot exceed 40 characters : ";
            }

            if (payeeName.Length == 0)
            {
                Error = Error + "The Payee name cannot be blank : ";
            }

            if (payeeName.Length > 40)
            {
                Error = Error + "The Payee name cannot exceed 40 characters : ";
            }

            if (method.Length == 0)
            {
                Error = Error + "The Method cannot be blank : ";
            }

            if (method.Length > 20)
            {
                Error = Error + "The Method cannot exceed 20 characters : ";
            }

            //if price entered is a valid price
            try
            {

                AmountTemp = Convert.ToDecimal(amount);

                if (AmountTemp > 100000000m)
                {
                    Error = Error + "Total Amount reached limits : ";
                }

                if (AmountTemp < 0m)
                {
                    Error = Error + "Ammount cannot be negative : ";
                }
            }
            catch
            {
                //record the error
                Error = Error + "The Amount entered is invalid : ";
            }

            //if Quantity entered is a valid quantity
            try
            {
                CardNumberTemp = Convert.ToInt64(cardNumber);

                if (CardNumberTemp > 11111111111111111)
                {
                    Error = Error + "The Card Number cannot exceed 16 : ";
                }

                if (CardNumberTemp < 111111111111111)
                {
                    Error = Error + "The Card number cannot be less than 16 : ";
                }

            }
            catch
            {
                //record the error
                Error = Error + "The Card Number entered is invalid : ";

            }

            //if date entered is a valid date
            try
            {
                // convert the string value to DateTime
                //& then copy the value of dateAdded to DateTemp variable
                DateTemp = Convert.ToDateTime(datePurchased);
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
                Error = Error + "The date entered was not a valid date : ";
            }

            return Error;
        }

        public string AllDetails
        {
            get
            {
                return ("PaymentId:" + PaymentId + "_" + "PayeeName:" + PayeeName + "_" + "Email:" + "["+ Email + "]" + "_" +"CardNumber:" + CardNumber + "_" + "Method:" + Method + "_"  
                    + "Amount:" + Amount + "_" + "DatePurchased:" + DateTime.Now.Date.ToString("dd/MM/yyyy")); 
            }
        }
    }
}
