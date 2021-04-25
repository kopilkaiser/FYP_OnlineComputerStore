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
        //private data member ThisCustomer
        clsCustomer mThisCustomer = new clsCustomer();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

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
                    //get the Staff Id from the query results
                    NewCustomer.CustomerId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["CustomerId"]);
                    //get the Name from the query results
                    NewCustomer.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                    //get the Phone number from the query results
                    NewCustomer.Phonenum = Convert.ToString(dBConnection.DataTable.Rows[Index]["Phonenum"]);
                    //get the Salary of the Staff from the query results
                    NewCustomer.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                    //get the Date when the Staff member joined from the query results
                    NewCustomer.DateJoined = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateJoined"]);
                    //get the Active status of the Staff 
                    NewCustomer.Bio = Convert.ToString(dBConnection.DataTable.Rows[Index]["Bio"]);
                    //get the Active status of the Staff 
                    NewCustomer.AccountBalance = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["AccountBalance"]);

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
            //add a new record to the database based on the values of ThisCustomer
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@Name", mThisCustomer.Name);
            dBConnection.AddParameter("@Phonenum", mThisCustomer.Phonenum);
            dBConnection.AddParameter("@Email", mThisCustomer.Email);
            dBConnection.AddParameter("@DateJoined", mThisCustomer.DateJoined);
            dBConnection.AddParameter("@Bio", mThisCustomer.Bio);
            dBConnection.AddParameter("@AccountBalance", mThisCustomer.AccountBalance);

            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblCustomer_Insert");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of ThisCustomer
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@CustomerId", mThisCustomer.CustomerId);
            dBConnection.AddParameter("@Name", mThisCustomer.Name);
            dBConnection.AddParameter("@Phonenum", mThisCustomer.Phonenum);
            dBConnection.AddParameter("@Email", mThisCustomer.Email);
            dBConnection.AddParameter("@DateJoined", mThisCustomer.DateJoined);
            dBConnection.AddParameter("@Bio", mThisCustomer.Bio);
            dBConnection.AddParameter("@AccountBalance", mThisCustomer.AccountBalance);
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

        public void ReportByEmail(string Email)
        {
            //filters the records based on a full or partial post code
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //send the Name parameter to the database
            dBConnection = new clsDataConnection();
            dBConnection.AddParameter("@Email", Email);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblCustomer_FilterByEmail");
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
            mCustomerList = new List<clsCustomer>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsCustomer ACustomer = new clsCustomer();
                //read in the fields from the current record
                ACustomer.CustomerId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["CustomerId"]);
                ACustomer.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                ACustomer.Phonenum = Convert.ToString(dBConnection.DataTable.Rows[Index]["Phonenum"]);
                ACustomer.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                ACustomer.DateJoined = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateJoined"]);
                ACustomer.Bio = Convert.ToString(dBConnection.DataTable.Rows[Index]["Bio"]);
                ACustomer.AccountBalance = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["AccountBalance"]);

                //add the record to the private data member
                mCustomerList.Add(ACustomer);
                //point at the next record
                Index++;
            }

        }
    }
}
