using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCustomerCollection
    {
        //private data member for the list
        List<clsCustomer> mCustomerList = new List<clsCustomer>();
        //private data member thisCustomer
        clsCustomer mThisCustomer = new clsCustomer();
        clsDataConnection dBConnection = new clsDataConnection();

        public clsCustomerCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblCustomer_SelectAll");
            //populate the array list with the data table
            PopulateArray(DB);
        }

        public clsCustomer ThisCustomer
        {
            get
            {
                //return this private data
                return mThisCustomer;
            }

            set
            {
                //set the private data
                mThisCustomer = value;
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

        public List<clsCustomer> CustomerList
        {

            get
            {
                List<clsCustomer> mCustomerList = new List<clsCustomer>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsCustomer NewCustomer = new clsCustomer();
                    //get the Customer Id from the query results
                    NewCustomer.CustomerId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["CustomerId"]);
                    //get the Account no from the query results
                    NewCustomer.AccountNo = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["AccountNo"]);
                    //get the Name from the query results
                    NewCustomer.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                    //get the Phone number from the query results
                    NewCustomer.Phonenum = Convert.ToString(dBConnection.DataTable.Rows[Index]["Phonenum"]);
                    //get the Date when the Customer has registered from the query results
                    NewCustomer.DateJoined = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateJoined"]);
                    //get the Active status of the Customer
                    NewCustomer.Active = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Active"]);

                    //increment the index
                    Index++;
                    //add the address to the list
                    mCustomerList.Add(NewCustomer);
                }
                //return the list of addresses
                return mCustomerList;
            }

            set
            {
                mCustomerList = value;
            }
        }

        public int Add()
        {
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisStaff
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@AccountNo", mThisCustomer.AccountNo);
            dBConnection.AddParameter("@Name", mThisCustomer.Name);
            dBConnection.AddParameter("@Phonenum", mThisCustomer.Phonenum);
            dBConnection.AddParameter("@DateJoined", mThisCustomer.DateJoined);
            dBConnection.AddParameter("@Active", mThisCustomer.Active);
            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblCustomer_Insert");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of thisStaff
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@CustomerId", mThisCustomer.CustomerId);
            dBConnection.AddParameter("@AccountNo", mThisCustomer.AccountNo);
            dBConnection.AddParameter("@Name", mThisCustomer.Name);
            dBConnection.AddParameter("@Phonenum", mThisCustomer.Phonenum);
            dBConnection.AddParameter("@DateJoined", mThisCustomer.DateJoined);
            dBConnection.AddParameter("@Active", mThisCustomer.Active);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblCustomer_Update");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@CustomerId", mThisCustomer.CustomerId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblCustomer_Delete");
        }

        public void ReportByName(string Name)
        {
            //connect to the database
            dBConnection = new clsDataConnection();
            //send the name parameter to the database
            dBConnection.AddParameter("@Name", Name);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblCustomer_FilterByName");
            //populate the array list with the data table
            PopulateArray(dBConnection);

        }

        private void PopulateArray(clsDataConnection dBConnection)
        {
            //populate the arry list based on the data table in the parameter DB
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount = 0;
            //get the count of records
            RecordCount = dBConnection.Count;
            //clear the private array list
            mCustomerList = new List<clsCustomer>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank Customer detail
                clsCustomer ACustomer = new clsCustomer();
                //read in the fields from the current record
                ACustomer.CustomerId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["CustomerId"]);
                ACustomer.AccountNo = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["AccountNo"]);
                ACustomer.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                ACustomer.Phonenum = Convert.ToString(dBConnection.DataTable.Rows[Index]["Phonenum"]);
                ACustomer.DateJoined = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateJoined"]);
                ACustomer.Active = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Active"]);

                //add the record to the private member
                mCustomerList.Add(ACustomer);
                //point at the next record
                Index++;

            }       
        }

    


    }
   
}
