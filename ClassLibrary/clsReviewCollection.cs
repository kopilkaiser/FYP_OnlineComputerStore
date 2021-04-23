using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsReviewCollection
    {
        //private data member for the list
        List<clsReview> mReviewList = new List<clsReview>();
        //private data member thisInventory
        clsReview mThisReview = new clsReview();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

        public clsReviewCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblReview_SelectAll");
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

        public clsReview ThisReview
        {
            get
            {
                //return this private data
                return mThisReview;
            }
            set
            {
                //set the private data
                mThisReview = value;
            }
        }


        //public property for the address list
        public List<clsReview> ReviewList
        {


            get
            {
                List<clsReview> mReviewList = new List<clsReview>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsReview NewReview = new clsReview();
                    //get the Inventory Id from the query results
                    NewReview.ReviewId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["ReviewId"]);
                    //get the Name  from the query results
                    NewReview.Description = Convert.ToString(dBConnection.DataTable.Rows[Index]["Description"]);
                    //get the Price from the query results
                    NewReview.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                    //get the Quantity from the query results
                    NewReview.DateReviewed = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateReviewed"]);
                    //get the Category no from the query results
                    NewReview.Rating = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Rating"]);
                    NewReview.ProductId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["ProductId"]);

                    //increment the index
                    Index++;
                    //add the address to the list
                    mReviewList.Add(NewReview);
                }
                //return the list of addresses
                return mReviewList;
            }

            set
            {
                mReviewList = value;
            }
        }

        public int Add()
        {
            //connect to the database
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisInventory
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@Description", mThisReview.Description);
            dBConnection.AddParameter("@DateReviewed", mThisReview.DateReviewed);
            dBConnection.AddParameter("@Rating", mThisReview.Rating);
            dBConnection.AddParameter("@ProductId", mThisReview.ProductId);
            dBConnection.AddParameter("@Email", mThisReview.Email);
            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblReview_Insert");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@ReviewId", mThisReview.ReviewId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblReview_Delete");
        }
        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of thisInventory
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@ReviewId", mThisReview.ReviewId);
            dBConnection.AddParameter("@Description", mThisReview.Description);
            dBConnection.AddParameter("@DateReviewed", mThisReview.DateReviewed);
            dBConnection.AddParameter("@Rating", mThisReview.Rating);
            dBConnection.AddParameter("@ProductId", mThisReview.ProductId);
            dBConnection.AddParameter("@Email", mThisReview.Email);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblReview_Update");
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
            dBConnection.Execute("sproc_tblReview_FilterByEmail");
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
            mReviewList = new List<clsReview>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsReview AReview = new clsReview();
                //read in the fields from the current record
                AReview.ReviewId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["ReviewId"]);
                AReview.Description = Convert.ToString(dBConnection.DataTable.Rows[Index]["Description"]);
                AReview.DateReviewed = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateReviewed"]);
                AReview.Rating = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Rating"]);
                AReview.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                AReview.ProductId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["ProductId"]);

                //add the record to the private data member
                mReviewList.Add(AReview);
                //point at the next record
                Index++;
            }
        }
    }
}
