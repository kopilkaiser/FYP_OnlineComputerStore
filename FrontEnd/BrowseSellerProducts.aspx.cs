using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm12 : System.Web.UI.Page
    {

        clsCart MyCart = new clsCart();
        clsSecurity Sec;
        public string userEmail;
        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            //upon loading the page you need to read in the cart from the session object
            MyCart = (clsCart)Session["MyCart"];
            //if the cart is null then we need to initialise it
            if (MyCart == null)
            {
                MyCart = new clsCart();
            }
            //then you can display how many items are in your cart

            userEmail = Convert.ToString(Request.QueryString["Email"]);
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            Session["Sec"] = Sec;

        }

        protected void btnBrowseSellerShops_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseSellerShops.aspx");
        }

        protected void btnBrowseMyShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseMyShop.aspx");
        }
    }
}