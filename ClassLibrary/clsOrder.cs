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
        private DateTime mDateOrdered;
        private decimal mTotalPrice;
        private string mShippingAddress;
        private string mPhonenum;

        
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

        public string ShippingAddress
        {
            get
            {
                return mShippingAddress;
            }
            set
            {
                mShippingAddress = value;
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
                mDateOrdered = Convert.ToDateTime(DB.DataTable.Rows[0]["DateOrdered"]);
                mTotalPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["TotalPrice"]);
                mShippingAddress = Convert.ToString(DB.DataTable.Rows[0]["ShippingAddress"]);
                mPhonenum = Convert.ToString(DB.DataTable.Rows[0]["Phonenum"]);


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

        public string Valid(string email, string totalPrice, string dateOrdered, string shippingAddress, string phonenum)
        {
            string Error = "";
            decimal TotalPriceTemp;
            DateTime DateTemp;
            Int64 PhonenumTemp;


            if (email.Length == 0)
            {
                Error = Error + "The Email field cannot be left blank : ";
            }

            if(email.Length > 40)
            {
                Error = Error + "The Email cannot exceed 40 characters : ";
            }

            if (shippingAddress.Length == 0)
            {
                Error = Error + "The Shipping Address field cannot be left blank : ";
            }

            if (shippingAddress.Length > 250)
            {
                Error = Error + "The Shipping Address cannot exceed 250 characters : ";
            }


            //if Phone number entered is valid
            try
            {
                PhonenumTemp = Convert.ToInt64(phonenum);

                if (PhonenumTemp > 11111111111111111)
                {
                    Error = Error + "The Phone number cannot exceed more than 16 numbers : ";
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
                return ("OrderId:" + OrderId + "_" + "Email:" + Email + "_" + "TotalPrice:" + TotalPrice + "_" + 
                    "ShippingAddress:" + ShippingAddress + "_" + "Phonenum:" + Phonenum + "_" + "DateOrdered:" + DateOrdered.ToString("dd/MM/yyyy"));
            }
        }

        public void ProcessCart(clsCart ShoppingCart)
        {
            ///at this point all the data has been captured by the presentation layer
            ///this is the stage where all of the data is passed to the data layer via the two stored procedures like so
            ///

            //first we add the order to the database using data from the cart's private data member s
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //pass the data as parameters to the data layer
            DB.AddParameter("@DateOrdered", DateTime.Now.Date);
            DB.AddParameter("@Email", ShoppingCart.Email);
            DB.AddParameter("@TotalPrice", ShoppingCart.TotalPrice);
            DB.AddParameter("@Phonenum", ShoppingCart.Phonenum);
            DB.AddParameter("@ShippingAddress", ShoppingCart.ShippingAddress);

            //execute the stored procedure capturing the primary key of the new record in the variable OrderNo
            Int32 NewOrderNo;
            NewOrderNo = DB.Execute("sproc_tblOrder_Insert");

            //now we need to loop through all the products adding them to the Orderline table
            Int32 Index = 0;
            Int32 Count = ShoppingCart.Products.Count;
            while (Index < Count)
            {
                //reset the connection to the database
                DB = new clsDataConnection();
                DB.AddParameter("@OrderId", NewOrderNo);
                DB.AddParameter("@InventoryId", ShoppingCart.Products[Index].InventoryId);
                DB.AddParameter("@Quantity", ShoppingCart.Products[Index].QTY);
                Int32 OrderNo = DB.Execute("sproc_tblOrderLine_Insert");
                Index++;
            }
            //now look in the tables and the order should be present
            //we could also do other things here such as adjust stock levels
        }
    }
}
