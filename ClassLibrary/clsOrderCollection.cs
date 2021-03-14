using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsOrderCollection
    {
        //private data member for the list
        List<clsOrder> mOrderList = new List<clsOrder>();
        //private data member ThisOrder
        clsOrder mThisOrder = new clsOrder();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

        public clsOrderCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblOrder_SelectAll");
            //populate the array list with the data table
            PopulateArray(DB);
        }

        public clsOrder ThisOrder
        {
            get
            {
                //return this private data
                return mThisOrder;
            }

            set
            {
                //set the private data
                mThisOrder = value;
            }
        }

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

        public List<clsOrder> OrderList
        {

            get
            {
                List<clsOrder> mOrderList = new List<clsOrder>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsOrder NewOrder = new clsOrder();
                    //get the house no from the query results
                    NewOrder.AccountNo = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["AccountNo"]);
                    //get the street from the query results
                    NewOrder.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                    //get the post code from the query results
                    NewOrder.TotalPrice = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["TotalPrice"]);
                    //get the address no from the query results
                    NewOrder.DateOrdered = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateOrdered"]);
                    //increment the index
                    Index++;
                    //add the address to the list
                    mOrderList.Add(NewOrder);
                }
                //return the list of addresses
                return mOrderList;
            }

            set
            {
                mOrderList = value;
            }
        }

        public int Add()
        {
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisOrder
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@AccountNo", mThisOrder.AccountNo);
            dBConnection.AddParameter("@Email", mThisOrder.Email);
            dBConnection.AddParameter("@TotalPrice", mThisOrder.TotalPrice);
            dBConnection.AddParameter("@DateOrdered", mThisOrder.DateOrdered);
            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblOrder_Insert");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of ThisOrder
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@OrderId", mThisOrder.OrderId);
            dBConnection.AddParameter("@AccountNo", mThisOrder.AccountNo);
            dBConnection.AddParameter("@TotalPrice", mThisOrder.TotalPrice);
            dBConnection.AddParameter("@Email", mThisOrder.Email);
            dBConnection.AddParameter("@DateOrdered", mThisOrder.DateOrdered);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblOrder_Update");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@OrderId", mThisOrder.OrderId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblOrder_Delete");
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
            dBConnection.Execute("sproc_tblOrder_FilterByEmail");
            //populate the array list with the data table
            PopulateArray(dBConnection);
        }

        private void PopulateArray(clsDataConnection dBConnection)
        {
            //populates the array list based on the data table in the parameter DB
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount = 0;
            //get the count of records
            RecordCount = dBConnection.Count;
            //clear the private array list
            mOrderList = new List<clsOrder>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsOrder AnOrder = new clsOrder();
                //read in the fields from the current record
                AnOrder.OrderId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["OrderId"]);
                AnOrder.AccountNo = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["AccountNo"]);
                AnOrder.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                AnOrder.TotalPrice = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["TotalPrice"]);
                AnOrder.DateOrdered = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateJoined"]);

                //add the record to the private data member
                mOrderList.Add(AnOrder);
                //point at the next record
                Index++;
            }

        }
    }
}
