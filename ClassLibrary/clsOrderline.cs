using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsOrderline
    {
        private int mOrderlineId;
        private int mOrderId;
        private int mInventoryId;
        private int mQuantity;

        public int OrderlineId
        {
            get
            {
                return mOrderlineId;
            }

            set
            {
                mOrderlineId = value;
            }
        }
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

        public string Valid(string orderId, string inventoryId, string quantity)
        {
            // create a variable to store any error message
            String Error = "";
            Int32 OrderIdTemp;
            Int32 QuantityTemp;
            Int32 InventoryIdTemp;
            //if price entered is a valid price

            //if Order number is valid
            try
            {
                OrderIdTemp = Convert.ToInt32(orderId);

                if (OrderIdTemp > 1000)
                {
                    Error = Error + "The Order number cannot exceed 1000 : ";
                }

                if (OrderIdTemp <= 0)
                {
                    Error = Error + "The Order number cannot be less than or equal to 0 : ";
                }

            }
            catch
            {
                //record the error
                Error = Error + "The Order number is not valid : ";
            }

            //if Quantity entered is a valid quantity
            try
            {
                QuantityTemp = Convert.ToInt32(quantity);

                if (QuantityTemp > 100)
                {
                    Error = Error + "The quantity of Order cannot exceed 100 : ";
                }

                if (QuantityTemp <= 0)
                {
                    Error = Error + "The Quantity cannot be less than or equal to 0 : ";
                }

            }
            catch
            {
                //record the error
                Error = Error + "The Quantity is invalid : ";
            }

            try
            {
                InventoryIdTemp = Convert.ToInt32(inventoryId);

                if (InventoryIdTemp > 100000)
                {
                    Error = Error + "The Inventory Id cannot exceed 100000 : ";
                }

                if (InventoryIdTemp <= 0)
                {
                    Error = Error + "Please enter an valid Inventory Id : ";
                }



            }
            catch
            {
                //record the error
                Error = Error + "The Order is not valid : ";
            }


            return Error;
        }

        public bool Find(int OrderlineId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Inventory id to search for
            DB.AddParameter("@OrderlineId", OrderlineId);
            //execute the stored procedure
            DB.Execute("sproc_tblOrderline_FilterByOrderlineId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mOrderlineId = Convert.ToInt32(DB.DataTable.Rows[0]["OrderlineId"]);
                mOrderId = Convert.ToInt32(DB.DataTable.Rows[0]["OrderId"]);
                mQuantity = Convert.ToInt32(DB.DataTable.Rows[0]["Quantity"]);
                mInventoryId = Convert.ToInt32(DB.DataTable.Rows[0]["InventoryId"]);

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
                return "OrderlineId:" + OrderlineId + "_" + "OrderId:" + OrderId + "_" + "InventoryId:" + InventoryId + "_" + "Quantity:" + Quantity;
            }
        }
    }
}
