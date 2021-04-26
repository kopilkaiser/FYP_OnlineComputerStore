using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsSellerShopLine
    {
        private int mSellerShopLineId;
        private string mProductName;
        private string mEmail;
        private decimal mPrice;
        private int mQuantity;
        private string mDescription;

        public int SellerShopLineId
        {
            get
            {
                return mSellerShopLineId;
            }
            set
            {
                mSellerShopLineId = value;
            }
        }

        public string ProductName
        {
            get
            {
                return mProductName;
            }
            set
            {
                mProductName = value;
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

        public decimal Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }

        public int Quantity
        {
            get
            {
                return mQuantity;
            }
            set
            {
                mQuantity = value;
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

        public string Valid(string email, string productName, string price, string quantity, string description)
        {
            string Error = "";
            
            decimal PriceTemp;
            Int32 QuantityTemp;



            if (email.Length == 0)
            {
                Error = Error + "The Email cannot be blank : ";
            }

            if (email.Length > 50)
            {
                Error = Error + "The Email cannot exceed 40 characters : ";
            }



            if (productName.Length == 0)
            {
                Error = Error + "The ProductName cannot be blank : ";
            }

            if (productName.Length > 50)
            {
                Error = Error + "The ProductName cannot exceed 20 characters : ";
            }

            if (description.Length == 0)
            {
                Error = Error + "The Description cannot be blank : ";
            }

            if (description.Length > 50)
            {
                Error = Error + "The Description cannot exceed 50 characters : ";
            }



            //if price entered is a valid price
            try
            {

                PriceTemp = Convert.ToDecimal(price);

                if (PriceTemp > 100000m)
                {
                    Error = Error + "The Price cannot exceed 100000 : ";
                }

                if (PriceTemp < 0m)
                {
                    Error = Error + "The Price cannot be less than zero : ";
                }
            }
            catch
            {
                //record the error
                Error = Error + "The Price is invalid : ";
            }

            //if Quantity entered is a valid quantity
            try
            {
                QuantityTemp = Convert.ToInt32(quantity);

                if (QuantityTemp > 10000)
                {
                    Error = Error + "The Quantity cannot exceed 1000 : ";
                }

                if (QuantityTemp < 0)
                {
                    Error = Error + "The Quantity cannot be less than zero : ";
                }

            }
            catch
            {
                //record the error
                Error = Error + "The Quantity is invalid : ";

            }


            return Error;
        }

        public bool Find(int SellerShopLineId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Inventory id to search for
            DB.AddParameter("@SellerShopLineId", SellerShopLineId);
            //execute the stored procedure
            DB.Execute("sproc_tblSellerShopLine_FilterBySellerShopLineId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mSellerShopLineId = Convert.ToInt32(DB.DataTable.Rows[0]["SellerShopLineId"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mProductName = Convert.ToString(DB.DataTable.Rows[0]["ProductName"]);
                mPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["Price"]);
                mQuantity = Convert.ToInt32(DB.DataTable.Rows[0]["Quantity"]);
                mDescription = Convert.ToString(DB.DataTable.Rows[0]["Description"]);
 
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
                return ("Id:" + SellerShopLineId + "__" + "ProductName:" + ProductName + "__" + "Email:" + Email + "__"
                    + "Quantity:" + Quantity + "__" + "Price:" + Price + "__" + "Description: " + "Click to View more" );
            }
        }

    }
}
