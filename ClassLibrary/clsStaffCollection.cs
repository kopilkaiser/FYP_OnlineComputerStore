using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsStaffCollection
    {

        //private data member for the list
        List<clsStaff> mStaffList = new List<clsStaff>();
        //private data member thisStaff
        clsStaff mThisStaff = new clsStaff();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

        public clsStaffCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblStaff_SelectAll");
            //populate the array list with the data table
            PopulateArray(DB);
        }

        public clsStaff ThisStaff
        {
            get
            {
                //return this private data
                return mThisStaff;
            }

            set
            {
                //set the private data
                mThisStaff = value;
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

        public List<clsStaff> StaffList
        {

            get
            {
                List<clsStaff> mStaffList = new List<clsStaff>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsStaff NewStaff = new clsStaff();
                    //get the Staff Id from the query results
                    NewStaff.StaffId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["StaffId"]);
                    //get the Account no from the query results
                    NewStaff.AccountNo = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["AccountNo"]);
                    //get the Name from the query results
                    NewStaff.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                    //get the Phone number from the query results
                    NewStaff.Phonenum = Convert.ToString(dBConnection.DataTable.Rows[Index]["Phonenum"]);
                    //get the Salary of the Staff from the query results
                    NewStaff.Salary = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["Salary"]);
                    //get the Date when the Staff member joined from the query results
                    NewStaff.DateJoined = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateJoined"]);
                    //get the Active status of the Staff 
                    NewStaff.Active = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Active"]);

                    //increment the index
                    Index++;
                    //add the address to the list
                    mStaffList.Add(NewStaff);
                }
                //return the list of addresses
                return mStaffList;
            }

            set
            {
                mStaffList = value;
            }
        }

        public int Add()
        {
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisStaff
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@AccountNo", mThisStaff.AccountNo);
            dBConnection.AddParameter("@Name", mThisStaff.Name);
            dBConnection.AddParameter("@Phonenum", mThisStaff.Phonenum);
            dBConnection.AddParameter("@Salary", mThisStaff.Salary);
            dBConnection.AddParameter("@DateJoined", mThisStaff.DateJoined);
            dBConnection.AddParameter("@Active", mThisStaff.Active);
            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblStaff_Insert");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of thisStaff
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@StaffId", mThisStaff.StaffId);
            dBConnection.AddParameter("@AccountNo", mThisStaff.AccountNo);
            dBConnection.AddParameter("@Name", mThisStaff.Name);
            dBConnection.AddParameter("@Phonenum", mThisStaff.Phonenum);
            dBConnection.AddParameter("@Salary", mThisStaff.Salary);
            dBConnection.AddParameter("@DateJoined", mThisStaff.DateJoined);
            dBConnection.AddParameter("@Active", mThisStaff.Active);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblStaff_Update");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@StaffId", mThisStaff.StaffId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblStaff_Delete");
        }

        public void ReportByName(string Name)
        {
            //filters the records based on a full or partial post code
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //send the Name parameter to the database
            dBConnection = new clsDataConnection();
            dBConnection.AddParameter("@Name", Name);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblStaff_FilterByName");
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
            mStaffList = new List<clsStaff>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsStaff AStaff = new clsStaff();
                //read in the fields from the current record
                AStaff.StaffId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["StaffId"]);
                AStaff.AccountNo = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["AccountNo"]);
                AStaff.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                AStaff.Phonenum = Convert.ToString(dBConnection.DataTable.Rows[Index]["Phonenum"]);
                AStaff.Salary = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["Salary"]);
                AStaff.DateJoined = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateJoined"]);
                AStaff.Active = Convert.ToBoolean(dBConnection.DataTable.Rows[Index]["Active"]);

                //add the record to the private data member
                mStaffList.Add(AStaff);
                //point at the next record
                Index++;
            }

        }
    }
}