using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm21 : System.Web.UI.Page
    {

        clsReviewCollection AllReviews = new clsReviewCollection();
        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        Int32 InventoryId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            MyCart = (clsCart)Session["MyCart"];

            InventoryId = Convert.ToInt32(Request.QueryString["InventoryId"].Trim());
            txtProductId.Text = InventoryId.ToString();

            txtEmail.Text = Sec.UserEMail;
            txtDateReviewed.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            Session["Sec"] = Sec;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Error = AllReviews.ThisReview.Valid(txtEmail.Text, txtDescription.Text, txtDateReviewed.Text, Convert.ToString(DDListRating.SelectedValue), txtProductId.Text);

            if (Error == "")
            {

                Add();
                Response.Redirect("BrowseAllReviews.aspx");

            }
            else
            {
                lblError.Text = "Following Errors: " + Error;
            }
        }

        void Add()
        {
            //create an instance of the Payment Collenction
            clsReviewCollection AllReviews = new clsReviewCollection();
            //validate the data on the web t
            string Error = AllReviews.ThisReview.Valid(txtEmail.Text, txtDescription.Text, txtDateReviewed.Text, Convert.ToString(DDListRating.SelectedValue), txtProductId.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllReviews.ThisReview.Email = Convert.ToString(txtEmail.Text);
                AllReviews.ThisReview.Description = txtDescription.Text;
                AllReviews.ThisReview.DateReviewed = Convert.ToDateTime(txtDateReviewed.Text);
                AllReviews.ThisReview.Rating = Convert.ToInt32(DDListRating.SelectedValue);
                AllReviews.ThisReview.ProductId = Convert.ToInt32(txtProductId.Text);

                //add the record
                AllReviews.Add();

            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }
    }
}