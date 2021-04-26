using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsSellerShop
    {
        private int mShopId;
        private string mShopName;
        private string mEmail;
        private int mRating;
        private DateTime mDateOpened;
        private string mSellerName;

        public int ShopId
        {
            get
            {
                return mShopId;
            }
            set
            {
                mShopId = value;
            }
        }

        public string ShopName
        {
            get
            {
                return mShopName;
            }
            set
            {
                mShopName = value;
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

        public int Rating
        {
            get
            {
                return mRating;
            }
            set
            {
                mRating = value;
            }
        }

        public DateTime DateOpened
        {
            get
            {
                return mDateOpened;
            }
            set
            {
                mDateOpened = value;
            }
        }

        public string SellerName
        {
            get
            {
                return mSellerName;
            }
            set
            {
                mSellerName = value;
            }
        }

        public string Valid(string shopName, string sellerName, string email, string rating, string dateOpened)
        {
            string Error = "";

            DateTime DateTemp;
            Int32 RatingTemp;



            if (shopName.Length == 0)
            {
                Error = Error + "The ShopName cannot be blank : ";
            }

            if (shopName.Length > 50)
            {
                Error = Error + "The ShopName cannot exceed 50 characters : ";
            }

            if (sellerName.Length == 0)
            {
                Error = Error + "The SellerName cannot be blank : ";
            }

            if (sellerName.Length > 50)
            {
                Error = Error + "The SellerName cannot exceed 50 characters : ";
            }


            //if Quantity entered is a valid quantity
            try
            {
                RatingTemp = Convert.ToInt32(rating);

                if (RatingTemp > 5)
                {
                    Error = Error + "The Rating cannot exceed 5 : ";
                }

                if (RatingTemp < 0)
                {
                    Error = Error + "The Rating cannot be less than zero : ";
                }

            }
            catch
            {
                //record the error
                Error = Error + "The Rating is invalid : ";

            }


            if (email.Length == 0)
            {
                Error = Error + "The Email cannot be blank : ";
            }

            if (email.Length > 50)
            {
                Error = Error + "The Email cannot exceed 50 characters : ";
            }

            //if date entered is a valid date
            try
            {
                // convert the string value to DateTime
                //& then copy the value of dateAdded to DateTemp variable
                DateTemp = Convert.ToDateTime(dateOpened);
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

        public bool Find(int ShopId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Inventory id to search for
            DB.AddParameter("@ShopId", ShopId);
            //execute the stored procedure
            DB.Execute("sproc_tblShop_FilterByShopId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mShopId = Convert.ToInt32(DB.DataTable.Rows[0]["ShopId"]);
                mShopName = Convert.ToString(DB.DataTable.Rows[0]["ShopName"]);
                mSellerName = Convert.ToString(DB.DataTable.Rows[0]["SellerName"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mRating = Convert.ToInt32(DB.DataTable.Rows[0]["Rating"]);
                mDateOpened = Convert.ToDateTime(DB.DataTable.Rows[0]["DateOpened"]);

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
                return ("ShopId:" + ShopId + "_"  + "ShopName:" + ShopName + "_" + "SellerName" 
                    + SellerName + "_" + "Email" + Email + "_" + "Rating" + Rating + "_" + "DateOpened" + DateOpened.ToString("dd/MM/yyyy"));
            }
        }
    }
}
