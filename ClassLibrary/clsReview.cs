using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsReview
    {
        private int mReviewId;
        private string mEmail;
        private string mDescription;
        private DateTime mDateReviewed;
        private int mRating;
        private int mProductId;


        public int ProductId
        {
            get
            {
                return mProductId;
            }
            set
            {
                mProductId = value;
            }
        }


        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
            }
        }

        public int ReviewId
        {
            get
            {
                return mReviewId;
            }
            set
            {
                mReviewId = value;
            }
        }

        public string Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                mEmail = value;
            }
        }

        public DateTime DateReviewed
        {
            get
            {
                return mDateReviewed;
            }
            set
            {
                mDateReviewed = value;
            }
        }

        public int Rating
        {
            get
            {
                return mRating;
            }
            set
            {
                mRating = value;
            }
        }

        public string Valid(string email, string description, string dateReviewed, string rating, string productId)
        {
            string Error = "";

            DateTime DateTemp;
            Int32 RatingTemp;
            Int32 ProductIdTemp;


            if (email.Length == 0)
            {
                Error = Error + "The Email cannot be blank : ";
            }

            if (email.Length > 50)
            {
                Error = Error + "The Email cannot exceed 50 characters : ";
            }


            if (description.Length == 0)
            {
                Error = Error + "The Description cannot be blank : ";
            }

            if (description.Length > 250)
            {
                Error = Error + "The Description cannot exceed 250 characters : ";
            }

            //if price entered is a valid price
            try
            {

                ProductIdTemp = Convert.ToInt32(productId);

                if (ProductIdTemp > 999999)
                {
                    Error = Error + "The ProductId exceeds it's limit : ";
                }

                if (ProductIdTemp <= 0)
                {
                    Error = Error + "The ProductId needs to be greater than zero : ";
                }
            }
            catch
            {
                //record the error
                Error = Error + "The ProductId is invalid : ";
            }

            //if price entered is a valid price
            try
            {

                RatingTemp = Convert.ToInt32(rating);

                if (RatingTemp > 5)
                {
                    Error = Error + "The Rating cannot be greater than 5 : ";
                }

                if (RatingTemp < 0)
                {
                    Error = Error + "The Rating cannot be less than zero : ";
                }
            }
            catch
            {
                //record the error
                Error = Error + "The Rating is invalid : ";
            }


            //if date entered is a valid date
            try
            {
                // convert the string value to DateTime
                //& then copy the value of dateAdded to DateTemp variable
                DateTemp = Convert.ToDateTime(dateReviewed);
                //if date value is less than today's date
                if (DateTemp < DateTime.Now.Date)
                {
                    //record the error
                    Error = Error + "Date cannot be in the past : ";
                }
                //if date value is more than today's date
                if (DateTemp > DateTime.Now.Date)
                {
                    //record the error
                    Error = Error + "Date cannot be in the future : ";
                }
            }
            //if date entered is an invalid date
            catch
            {
                //record the error
                Error = Error + "Date entered is invalid date : ";
            }

            return Error;
        }

        public bool Find(int ReviewId)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the Inventory id to search for
            DB.AddParameter("@ReviewId", ReviewId);
            //execute the stored procedure
            DB.Execute("sproc_tblReview_FilterByReviewId");
            //if one record is found (there should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy the data from the database from the private data members
                mReviewId = Convert.ToInt32(DB.DataTable.Rows[0]["ReviewId"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mDateReviewed = Convert.ToDateTime(DB.DataTable.Rows[0]["DateReviewed"]);
                mDescription = Convert.ToString(DB.DataTable.Rows[0]["Description"]);
                mRating = Convert.ToInt32(DB.DataTable.Rows[0]["Rating"]);
                mProductId = Convert.ToInt32(DB.DataTable.Rows[0]["ProductId"]);

                //return that everything worked ok
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating a problem
                return false;
            }
        }

        public string AllDetails
        {
            get
            {
                return ("ReviewId:" + ReviewId + "_" + "Email:" + Email + "_" + "Rating:" + Rating + "_" 
                    + "Description:" + "Click to View More" + "_" + "ProductId:" + ProductId + "_" + "DateReviewed:" + DateReviewed.ToString("dd/MM/yyyy"));
            }
        }
    }


}
