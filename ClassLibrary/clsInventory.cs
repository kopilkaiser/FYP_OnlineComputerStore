using System;

namespace ClassLibrary
{
    public class clsInventory
    {
        private string mName;
        private decimal mPrice;
        private int mQuantity;
        private string mCategory;
        private DateTime mDateAdded;
        private bool mActive;
        private int mInventoryId;

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

        public DateTime DateAdded
        {
            get
            {
                return mDateAdded;
            }

            set
            {
                mDateAdded = value;
            }
        }

        public int InventoryId
        {
            get
            {
                return mInventoryId;
            }

            set
            {
                mInventoryId = value;
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

        public string Category
        {
            get
            {
                return mCategory;
            }

            set
            {
                mCategory = value;
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



        public string Valid(string name, string price, string quantity, string category, string dateAdded)
        {
            string Error = "";

            DateTime DateTemp;
            decimal PriceTemp;
            Int32 QuantityTemp;



            if (name.Length == 0)
            {
                Error = Error + "The Name cannot be blank : ";
            }

            if (name.Length > 40)
            {
                Error = Error + "The Name cannot exceed 40 characters : ";
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


            if (category.Length == 0)
            {
                Error = Error + "The Category cannot be blank : ";
            }

            if (category.Length > 20)
            {
                Error = Error + "The Category cannot exceed 20 characters : ";
            }

            //if date entered is a valid date
            try
            {
                // convert the string value to DateTime
                //& then copy the value of dateAdded to DateTemp variable
                DateTemp = Convert.ToDateTime(dateAdded);
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

        public bool Find(int InventoryId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Inventory id to search for
            DB.AddParameter("@InventoryId", InventoryId);
            //execute the stored procedure
            DB.Execute("sproc_tblInventory_FilterByInventoryId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mInventoryId = Convert.ToInt32(DB.DataTable.Rows[0]["InventoryId"]);
                mActive = Convert.ToBoolean(DB.DataTable.Rows[0]["Active"]);
                mName = Convert.ToString(DB.DataTable.Rows[0]["Name"]);
                mPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["Price"]);
                mQuantity = Convert.ToInt32(DB.DataTable.Rows[0]["Quantity"]);
                mCategory = Convert.ToString(DB.DataTable.Rows[0]["Category"]);
                mDateAdded = Convert.ToDateTime(DB.DataTable.Rows[0]["DateAdded"]);
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
                return ("InventoryId:" + InventoryId + "__" + "Name:" + Name + "__" + "Price:" + Price + "__"
                    + "Quantity:" + Quantity + "__" + "Category:" + Category + "__" + "DateAdded:" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "_" + "Active: " + Active);
            }
        }
    }
}