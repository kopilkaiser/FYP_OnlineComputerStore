using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsInventoryCollection
    {

        //private data member for the list
        List<clsInventory> mInventoryList = new List<clsInventory>();
        //private data member thisInventory
        clsInventory mThisInventory = new clsInventory();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

        public clsInventoryCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblInventory_SelectAll");
            //populate the array list with the data table
            PopulateArray(DB);

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
        public clsInventory ThisInventory
        {
            get
            {
                //return this private data
                return mThisInventory;
            }
            set
            {
                //set the private data
                mThisInventory = value;
            }
        }

        //public property for the address list
        public List<clsInventory> InventoryList
        {
         

            get
            {
                List<clsInventory> mInventoryList = new List<clsInventory>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsInventory NewInventory = new clsInventory();
                    //get the house no from the query results
                    NewInventory.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                    //get the street from the query results
                    NewInventory.Price = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["Price"]);
                    //get the post code from the query results
                    NewInventory.Quantity = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Quantity"]);
                    //get the address no from the query results
                    NewInventory.Category = Convert.ToString(dBConnection.DataTable.Rows[Index]["Category"]);
                    NewInventory.InventoryId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["InventoryId"]);
                    //increment the index
                    Index++;
                    //add the address to the list
                    mInventoryList.Add(NewInventory);
                }
                //return the list of addresses
                return mInventoryList;
            }

            set
            {
                mInventoryList = value;
            }
        }


        public int Add()
        {
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisInventory
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@Name", mThisInventory.Name);
            dBConnection.AddParameter("@Price", mThisInventory.Price);
            dBConnection.AddParameter("@Quantity", mThisInventory.Quantity);
            dBConnection.AddParameter("@Category", mThisInventory.Category);
            dBConnection.AddParameter("@DateAdded", mThisInventory.DateAdded);
            dBConnection.AddParameter("@Active", mThisInventory.Active);
            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblInventory_Insert");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@InventoryId", mThisInventory.InventoryId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblInventory_Delete");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of thisInventory
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@InventoryId", mThisInventory.InventoryId);
            dBConnection.AddParameter("@Name", mThisInventory.Name);
            dBConnection.AddParameter("@Price", mThisInventory.Price);
            dBConnection.AddParameter("@Quantity", mThisInventory.Quantity);
            dBConnection.AddParameter("@Category", mThisInventory.Category);
            dBConnection.AddParameter("@DateAdded", mThisInventory.DateAdded);
            dBConnection.AddParameter("@Active", mThisInventory.Active);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblInventory_Update");
        }

        public void ReportByCategory(string Category)
        {
            //filters the records based on a full or partial post code
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //send the Category parameter to the database
            dBConnection = new clsDataConnection();
            dBConnection.AddParameter("@Category", Category);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblInventory_FilterByCategory");
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
            //get the count of recordsA
            RecordCount = dBConnection.Count;
            //clear the private array list
            mInventoryList = new List<clsInventory>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsInventory AnInventory = new clsInventory();
                //read in the fields from the current record
                AnInventory.InventoryId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["InventoryId"]);
                AnInventory.Active = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Active"]);
                AnInventory.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                AnInventory.Price = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["Price"]);
                AnInventory.Quantity = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Quantity"]);
                AnInventory.Category = Convert.ToString(dBConnection.DataTable.Rows[Index]["Category"]);
                AnInventory.DateAdded = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateAdded"]);
                //add the record to the private data member
                mInventoryList.Add(AnInventory);
                //point at the next record
                Index++;
            }
        }
    }
}