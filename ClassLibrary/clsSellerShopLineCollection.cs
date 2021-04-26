using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsSellerShopLineCollection
    {
        //private data member for the list
        List<clsSellerShopLine> mSellerShopLineList = new List<clsSellerShopLine>();
        //private data member thisInventory
        clsSellerShopLine mThisSellerShopLine = new clsSellerShopLine();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

        public clsSellerShopLineCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblSellerShopLine_SelectAll");
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

        public clsSellerShopLine ThisSellerShopLine
        {
            get
            {
                //return this private data
                return mThisSellerShopLine;
            }
            set
            {
                //set the private data
                mThisSellerShopLine = value;
            }
        }

        //public property for the address list
        public List<clsSellerShopLine> SellerShopLineList
        {


            get
            {
                List<clsSellerShopLine> mSellerShopLineList = new List<clsSellerShopLine>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsSellerShopLine NewSellerShopLine = new clsSellerShopLine();
                    //get the Inventory Id from the query results
                    NewSellerShopLine.SellerShopLineId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["SellerShopLineId"]);
                    //get the Name  from the query results
                    NewSellerShopLine.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                    //get the Price from the query results
                    NewSellerShopLine.Price = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["Price"]);
                    //get the Quantity from the query results
                    NewSellerShopLine.Quantity = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Quantity"]);
                    //get the Category no from the query results
                    NewSellerShopLine.ProductName = Convert.ToString(dBConnection.DataTable.Rows[Index]["ProductName"]);
                    //get the Description of the Inventory from the query results
                    NewSellerShopLine.Description = Convert.ToString(dBConnection.DataTable.Rows[Index]["Description"]);
                    //increment the index
                    Index++;
                    //add the address to the list
                    mSellerShopLineList.Add(NewSellerShopLine);
                }
                //return the list of addresses
                return mSellerShopLineList;
            }

            set
            {
                mSellerShopLineList = value;
            }
        }


        public int Add()
        {
            //connect to the database
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisInventory
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@Email", mThisSellerShopLine.Email);
            dBConnection.AddParameter("@Price", mThisSellerShopLine.Price);
            dBConnection.AddParameter("@Quantity", mThisSellerShopLine.Quantity);
            dBConnection.AddParameter("@ProductName", mThisSellerShopLine.ProductName);
            dBConnection.AddParameter("@Description", mThisSellerShopLine.Description);
            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblSellerShopLine_Insert");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@SellerShopLineId", mThisSellerShopLine.SellerShopLineId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblSellerShopLine_Delete");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of thisInventory
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@SellerShopLineId", mThisSellerShopLine.SellerShopLineId);
            dBConnection.AddParameter("@Email", mThisSellerShopLine.Email);
            dBConnection.AddParameter("@Price", mThisSellerShopLine.Price);
            dBConnection.AddParameter("@Quantity", mThisSellerShopLine.Quantity);
            dBConnection.AddParameter("@ProductName", mThisSellerShopLine.ProductName);
            dBConnection.AddParameter("@Description", mThisSellerShopLine.Description);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblSellerShopLine_Update");
        }

        public void ReportByEmail(string Email)
        {
            //filters the records based on a full or partial post code
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //send the Category parameter to the database
            dBConnection = new clsDataConnection();
            dBConnection.AddParameter("@Email", Email);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblSellerShopLine_FilterByEmail");
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
            mSellerShopLineList = new List<clsSellerShopLine>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsSellerShopLine ASellerShopLine = new clsSellerShopLine();
                //read in the fields from the current record
                ASellerShopLine.SellerShopLineId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["SellerShopLineId"]);
                ASellerShopLine.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                ASellerShopLine.ProductName = Convert.ToString(dBConnection.DataTable.Rows[Index]["ProductName"]);
                ASellerShopLine.Price = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["Price"]);
                ASellerShopLine.Quantity = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Quantity"]);
                ASellerShopLine.Description = Convert.ToString(dBConnection.DataTable.Rows[Index]["Description"]);

                //add the record to the private data member
                mSellerShopLineList.Add(ASellerShopLine);
                //point at the next record
                Index++;
            }
        }
    }
}
