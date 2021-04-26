using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm16 : System.Web.UI.Page
    {
        clsSecurity Sec;
        clsCart MyCart = new clsCart();

        string reviewId;
        string email;
        string description;
        string rating;
        string productId;
        string dateReviewed;
        //dateReviewed
        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            MyCart = (clsCart)Session["MyCart"];
            //if the cart is null then we need to initialise it
            if (MyCart == null)
            {
                MyCart = new clsCart();
            }

            txtEmail.Text = Sec.UserEMail;

            reviewId = Convert.ToString(Request.QueryString["reviewId"]);
            email = Convert.ToString(Request.QueryString["Email"]);
            description = Convert.ToString(Request.QueryString["Description"]);
            rating = Convert.ToString(Request.QueryString["Rating"]);
            productId = Convert.ToString(Request.QueryString["ProductId"]);
            dateReviewed = Convert.ToString(Request.QueryString["DateReviewed"]);


            txtEmail.Text = email;
            txtDescription.Text = description.ToUpper();
            txtRating.Text = Convert.ToString(rating);
            txtProductId.Text = Convert.ToString(productId);
            txtDateReviewed.Text = dateReviewed.ToUpper();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseAllReviews.aspx");
        }
    }
}