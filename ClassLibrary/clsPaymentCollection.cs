using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsPaymentCollection
    {
        //private data member for the list
        List<clsPayment> mPaymentList = new List<clsPayment>();
        //private data member ThisPayment
        clsPayment mThisPayment = new clsPayment();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

        public clsPaymentCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblPayment_SelectAll");
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
        public clsPayment ThisPayment
        {
            get
            {
                //return this private data
                return mThisPayment;
            }
            set
            {
                //set the private data
                mThisPayment = value;
            }
        }

        //public property for the address list
        public List<clsPayment> PaymentList
        {


            get
            {
                List<clsPayment> mPaymentList = new List<clsPayment>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsPayment NewPayment = new clsPayment();
                    //get the Payment Id from the query results
                    NewPayment.PaymentId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["PaymentId"]);
                    //get the Payee Name from the query results
                    NewPayment.PayeeName = Convert.ToString(dBConnection.DataTable.Rows[Index]["PayeeName"]);
                    //get the Method from the query results
                    NewPayment.Method = Convert.ToString(dBConnection.DataTable.Rows[Index]["Method"]);
                    //get the Email no from the query results
                    NewPayment.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                    //get the CardNumber from the query results
                    NewPayment.CardNumber = Convert.ToString(dBConnection.DataTable.Rows[Index]["CardNumber"]);
                    //get the Amount from the query results
                    NewPayment.Amount = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["Amount"]);
                    //get the Date on which the product was purchased from the query results
                    NewPayment.DatePurchased = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DatePurchased"]);
                    //increment the index
                    Index++;
                    //add the address to the list
                    mPaymentList.Add(NewPayment);
                }
                //return the list of addresses
                return mPaymentList;
            }

            set
            {
                mPaymentList = value;
            }
        }

        public int Add()
        {
            //connect to the database
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisInventory
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@PayeeName", mThisPayment.PayeeName);
            dBConnection.AddParameter("@Method", mThisPayment.Method);
            dBConnection.AddParameter("@Email", mThisPayment.Email);
            dBConnection.AddParameter("@CardNumber", mThisPayment.CardNumber);
            dBConnection.AddParameter("@Amount", mThisPayment.Amount);
            dBConnection.AddParameter("@DatePurchased", mThisPayment.DatePurchased);
            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblPayment_Insert");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of thisInventory
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@PaymentId", mThisPayment.PaymentId);
            dBConnection.AddParameter("@PayeeName", mThisPayment.PayeeName);
            dBConnection.AddParameter("@Method", mThisPayment.Method);
            dBConnection.AddParameter("@Amount", mThisPayment.Amount);
            dBConnection.AddParameter("@CardNumber", mThisPayment.CardNumber);
            dBConnection.AddParameter("@Email", mThisPayment.Email);
            dBConnection.AddParameter("@DatePurchased", mThisPayment.DatePurchased);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblPayment_Update");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@PaymentId", mThisPayment.PaymentId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblPayment_Delete");
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
            dBConnection.Execute("sproc_tblPayment_FilterByEmail");
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
            mPaymentList = new List<clsPayment>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsPayment APayment = new clsPayment();
                //read in the fields from the current record
                APayment.PaymentId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["PaymentId"]);
                APayment.PayeeName = Convert.ToString(dBConnection.DataTable.Rows[Index]["PayeeName"]);
                APayment.Amount = Convert.ToDecimal(dBConnection.DataTable.Rows[Index]["Amount"]);
                APayment.Method = Convert.ToString(dBConnection.DataTable.Rows[Index]["Method"]);
                APayment.CardNumber = Convert.ToString(dBConnection.DataTable.Rows[Index]["CardNumber"]);
                APayment.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                APayment.DatePurchased = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DatePurchased"]);
                //add the record to the private data member
                mPaymentList.Add(APayment);
                //point at the next record
                Index++;
            }
        }

    }
}
