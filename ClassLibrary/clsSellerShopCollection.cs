using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsSellerShopCollection
    {
        //private data member for the list
        List<clsSellerShop> mSellerShopList = new List<clsSellerShop>();
        //private data member ThisSellerShop
        clsSellerShop mThisSellerShop = new clsSellerShop();
        clsDataConnection dBConnection = new clsDataConnection();
        //dBConnection = new clsDataConnection();

        public clsSellerShopCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the store procedure
            DB.Execute("sproc_tblSellerShop_SelectAll");
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

        public clsSellerShop ThisSellerShop
        {
            get
            {
                //return this private data
                return mThisSellerShop;
            }
            set
            {
                //set the private data
                mThisSellerShop = value;
            }
        }

        //public property for the address list
        public List<clsSellerShop> SellerShopList
        {


            get
            {
                List<clsSellerShop> mSellerShopList = new List<clsSellerShop>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsSellerShop NewSellerShop = new clsSellerShop();
                    //get the Inventory Id from the query results
                    NewSellerShop.ShopId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["ShopId"]);
                    //get the Name  from the query results
                    NewSellerShop.ShopName = Convert.ToString(dBConnection.DataTable.Rows[Index]["ShopName"]);
                    //get the Price from the query results
                    NewSellerShop.SellerName = Convert.ToString(dBConnection.DataTable.Rows[Index]["SellerName"]);
                    //get the Rating from the query results
                    NewSellerShop.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                    NewSellerShop.Rating = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Rating"]);
                    NewSellerShop.DateOpened = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateOpened"]);
                    //increment the index
                    Index++;
                    //add the address to the list
                    mSellerShopList.Add(NewSellerShop);
                }
                //return the list of addresses
                return mSellerShopList;
            }

            set
            {
                mSellerShopList = value;
            }
        }


        public int Add()
        {
            //connect to the database
            dBConnection = new clsDataConnection();
            //add a new record to the database based on the values of ThisSellerShop
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@ShopName", mThisSellerShop.ShopName);
            dBConnection.AddParameter("@SellerName", mThisSellerShop.SellerName);
            dBConnection.AddParameter("@Rating", mThisSellerShop.Rating);
            dBConnection.AddParameter("@Email", mThisSellerShop.Email);
            dBConnection.AddParameter("@DateOpened", mThisSellerShop.DateOpened);
            //execute the query returning the primary key value
            return dBConnection.Execute("sproc_tblSellerShop_Insert");
        }

        public void Delete()
        {
            //delete the record pointed to by thisAddress();
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            dBConnection = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@ShopId", mThisSellerShop.ShopId);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblSellerShop_Delete");
        }

        public void Update()
        {
            dBConnection = new clsDataConnection();
            //update an existing record based on the values of ThisSellerShop
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            dBConnection.AddParameter("@ShopId", mThisSellerShop.ShopId);
            dBConnection.AddParameter("@ShopName", mThisSellerShop.ShopName);
            dBConnection.AddParameter("@SellerName", mThisSellerShop.SellerName);
            dBConnection.AddParameter("@Rating", mThisSellerShop.Rating);
            dBConnection.AddParameter("@Email", mThisSellerShop.Email);
            dBConnection.AddParameter("@DateOpened", mThisSellerShop.DateOpened);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblSellerShop_Update");
        }

        public void ReportByEmail(string Email)
        {
            //filters the records based on a full or partial post code
            //connect to the database
            //clsDataConnection DB = new clsDataConnection();
            //send the Email parameter to the database
            dBConnection = new clsDataConnection();
            dBConnection.AddParameter("@Email", Email);
            //execute the stored procedure
            dBConnection.Execute("sproc_tblSellerShop_FilterByEmail");
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
            mSellerShopList = new List<clsSellerShop>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsSellerShop ASellerShop = new clsSellerShop();
                //read in the fields from the current record
                ASellerShop.ShopId = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["ShopId"]);
                ASellerShop.ShopName = Convert.ToString(dBConnection.DataTable.Rows[Index]["ShopName"]);
                ASellerShop.SellerName = Convert.ToString(dBConnection.DataTable.Rows[Index]["SellerName"]);
                ASellerShop.Email = Convert.ToString(dBConnection.DataTable.Rows[Index]["Email"]);
                ASellerShop.Rating = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Rating"]);
                ASellerShop.DateOpened = Convert.ToDateTime(dBConnection.DataTable.Rows[Index]["DateOpened"]);

                //add the record to the private data member
                mSellerShopList.Add(ASellerShop);
                //point at the next record
                Index++;
            }
        }
    }
}
