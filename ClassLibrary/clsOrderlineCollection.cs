using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsOrderlineCollection
    {
        //private data member for the list
        List<clsOrderline> mOrderlineList = new List<clsOrderline>();
        //private data member thisOrder
        clsOrderline mThisOrderline = new clsOrderline();
        clsDataConnection dBConnection = new clsDataConnection();
        
        public clsOrderlineCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblOrderline_SelectAll");
            //populate the array list with data table
            PopulateArray(DB);
        }

        //Public property for the Orderline List
        public List<clsOrderline> OrderlineList
        {
            get
            {
                List<clsOrderline> mOrderlineList = new List<clsOrderline>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsOrderline NewOrderline = new clsOrderline();

                    //get the orderline details from the query
                    NewOrderline.OrderlineId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["OrderlineId"]);
                    NewOrderline.OrderId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["OrderId"]);
                    NewOrderline.InventoryId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["InventoryId"]);
                    NewOrderline.Quantity = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Quantity"]);
                    //increment the Index
                    Index++;
                    //add the Order to the list
                    mOrderlineList.Add(NewOrderline);
                }
                //return the list of Orders
                return mOrderlineList;
            }

            set
            {
                mOrderlineList = value;
            }
        }

        //public property for Count
        public int Count
        {
            get
            {
                //return the count of the list
                return dBConnection.Count;
            }
            set
            {
                //we shall worry about this later
            }
        }

        public clsOrderline ThisOrderline
        {
            get
            {
                //return this private data
                return mThisOrderline;
            }
            set
            {
                //set the private data
                mThisOrderline = value;
            }
        }

        public int Add()
        {
            //connect to the database
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisOrderline
            //set the parameters for the stored procedure
            dBConnection.AddParameter("OrderId", mThisOrderline.OrderId);
            dBConnection.AddParameter("InventoryId", mThisOrderline.InventoryId);
            dBConnection.AddParameter("Quantity", mThisOrderline.Quantity);
            //execute the query returning the primary Key value
            return dBConnection.Execute("sproc_tblOrderline_Insert");

        }
        public void Update()
        {
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@OrderlineId", mThisOrderline.OrderlineId);
            dBConnection.AddParameter("@OrderId", mThisOrderline.OrderId);
            dBConnection.AddParameter("@Quantity", mThisOrderline.Quantity);
            dBConnection.AddParameter("@InventoryId", mThisOrderline.InventoryId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblOrderline_Update");
        }
        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@OrderlineId", mThisOrderline.OrderlineId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblOrderline_Delete");
        }
        public void FilterByOrderlineId(string OrderlineId)
        {
            //filters the records based on a full or partial post code
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //send the Category parameter to the database
            dBConnection = new clsDataConnection();
            dBConnection.AddParameter("@OrderlineId", OrderlineId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblOrderline_FilterByOrderlineId");
            //populate the array list with the data table
            PopulateArray(dBConnection);
        }
        void PopulateArray(clsDataConnection dBConnection)
        {
            //populates the array list based on the data table in the parameter DB
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount = 0;
            //get the count of records
            RecordCount = dBConnection.Count;
            //clear the private array list
            mOrderlineList = new List<clsOrderline>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsOrderline AnOrderline = new clsOrderline();
                //read in the fields from the current record
                AnOrderline.OrderlineId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["OrderlineId"]);
                AnOrderline.OrderId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["OrderId"]);
                AnOrderline.Quantity = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Quantity"]);
                AnOrderline.InventoryId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["InventoryId"]);

                //add the record to the private data member
                mOrderlineList.Add(AnOrderline);
                //point at the next record
                Index++;
            }
        }
    }
}
