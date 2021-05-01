using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsSupportCollection
    {

        //private data member for the list
        List<clsSupport> mSupportList = new List<clsSupport>();
        //private data member ThisSupport
        clsSupport mThisSupport = new clsSupport();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

        public clsSupportCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblSupport_SelectAll");
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

        public clsSupport ThisSupport
        {
            get
            {
                //return this private data
                return mThisSupport;
            }
            set
            {
                //set the private data
                mThisSupport = value;
            }
        }

        //public property for the address list
        public List<clsSupport> SupportList
        {


            get
            {
                List<clsSupport> mSupportList = new List<clsSupport>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsSupport NewSupport = new clsSupport();
                    //get the Support Id from the query results
                    NewSupport.SupportId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["SupportId"]);
                    //get the Email  from the query results
                    NewSupport.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                    //get the Name from the query results
                    NewSupport.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                    //get the Phonenum from the query results
                    NewSupport.Phonenum = Convert.ToString(dBConnection.DataTable.Rows[Index]["Phonenum"]);
                    //get the Description no from the query results
                    NewSupport.Description = Convert.ToString(dBConnection.DataTable.Rows[Index]["Description"]);
                    //get the Date Submitted from the query results
                    NewSupport.DateSubmitted = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateSubmitted"]);

                    //increment the index
                    Index++;
                    //add the address to the list
                    mSupportList.Add(NewSupport);
                }
                //return the list of addresses
                return mSupportList;
            }

            set
            {
                mSupportList = value;
            }
        }


        public int Add()
        {
            //connect to the database
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisSupport
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@Email", mThisSupport.Email);
            dBConnection.AddParameter("@Name", mThisSupport.Name);
            dBConnection.AddParameter("@Phonenum", mThisSupport.Phonenum);
            dBConnection.AddParameter("@Description", mThisSupport.Description);
            dBConnection.AddParameter("@DateSubmitted", mThisSupport.DateSubmitted);

            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblSupport_Insert");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@SupportId", mThisSupport.SupportId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblSupport_Delete");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of ThisSupport
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@SupportId", mThisSupport.SupportId);
            dBConnection.AddParameter("@Email", mThisSupport.Email);
            dBConnection.AddParameter("@Name", mThisSupport.Name);
            dBConnection.AddParameter("@Phonenum", mThisSupport.Phonenum);
            dBConnection.AddParameter("@Description", mThisSupport.Description);
            dBConnection.AddParameter("@DateSubmitted", mThisSupport.DateSubmitted);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblSupport_Update");
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
            dBConnection.Execute("sproc_tblSupport_FilterByEmail");
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
            mSupportList = new List<clsSupport>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsSupport ASupport = new clsSupport();
                //read in the fields from the current record
                ASupport.SupportId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["SupportId"]);
                //get the Email  from the query results
                ASupport.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                //get the Name from the query results
                ASupport.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                //get the Phonenum from the query results
                ASupport.Phonenum = Convert.ToString(dBConnection.DataTable.Rows[Index]["Phonenum"]);
                //get the Description no from the query results
                ASupport.Description = Convert.ToString(dBConnection.DataTable.Rows[Index]["Description"]);
                //get the Date Submitted from the query results
                ASupport.DateSubmitted = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateSubmitted"]);

                //add the record to the private data member
                mSupportList.Add(ASupport);
                //point at the next record
                Index++;
            }
        }
    }
}