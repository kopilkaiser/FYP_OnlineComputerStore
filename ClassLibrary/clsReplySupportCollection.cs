using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsReplySupportCollection
    {
        //private data member for the list
        List<clsReplySupport> mReplySupportList = new List<clsReplySupport>();
        //private data member ThisSupport
        clsReplySupport mThisReplySupport = new clsReplySupport();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

        public clsReplySupportCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblReplySupport_SelectAll");
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

        public clsReplySupport ThisReplySupport
        {
            get
            {
                //return this private data
                return mThisReplySupport;
            }
            set
            {
                //set the private data
                mThisReplySupport = value;
            }
        }

        //public property for the address list
        public List<clsReplySupport> ReplySupportList
        {


            get
            {
                List<clsReplySupport> mReplySupportList = new List<clsReplySupport>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsReplySupport NewReplySupport = new clsReplySupport();
                    //get the Support Id from the query results
                    NewReplySupport.ReplySupportId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["ReplySupportId"]);
                    //get the Email  from the query results
                    NewReplySupport.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                    //get the Description no from the query results
                    NewReplySupport.Description = Convert.ToString(dBConnection.DataTable.Rows[Index]["Description"]);
                    //get the Date Submitted from the query results
                    NewReplySupport.DateReplied = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateReplied"]);

                    //increment the index
                    Index++;
                    //add the address to the list
                    mReplySupportList.Add(NewReplySupport);
                }
                //return the list of addresses
                return mReplySupportList;
            }

            set
            {
                mReplySupportList = value;
            }
        }


        public int Add()
        {
            //connect to the database
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisSupport
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@Email", mThisReplySupport.Email);
            dBConnection.AddParameter("@Description", mThisReplySupport.Description);
            dBConnection.AddParameter("@DateReplied", mThisReplySupport.DateReplied);

            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblReplySupport_Insert");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@ReplySupportId", mThisReplySupport.ReplySupportId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblReplySupport_Delete");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of ThisSupport
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@ReplySupportId", mThisReplySupport.ReplySupportId);
            dBConnection.AddParameter("@Email", mThisReplySupport.Email);
            dBConnection.AddParameter("@Description", mThisReplySupport.Description);
            dBConnection.AddParameter("@DateReplied", mThisReplySupport.DateReplied);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblReplySupport_Update");
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
            dBConnection.Execute("sproc_tblReplySupport_FilterByEmail");
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
            mReplySupportList = new List<clsReplySupport>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //read in the fields from the current record
                clsReplySupport AReplySupport = new clsReplySupport();
                //get the Support Id from the query results
                AReplySupport.ReplySupportId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["ReplySupportId"]);
                //get the Email  from the query results
                AReplySupport.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                //get the Description no from the query results
                AReplySupport.Description = Convert.ToString(dBConnection.DataTable.Rows[Index]["Description"]);
                //get the Date Submitted from the query results
                AReplySupport.DateReplied = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateReplied"]);

                //add the record to the private data member
                mReplySupportList.Add(AReplySupport);
                //point at the next record
                Index++;
            }
        }
    }
}
