using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm23 : System.Web.UI.Page
    {
        private int mShopId = 0;
        public int ShopID
        {
            set
            {
                mShopId = value;
            }
        }

        string shopName;

        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        clsSellerShopLine AllSellerShopLines = new clsSellerShopLine();
        //variables to store the values of the fields being passed from the FindCustomer page

        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            MyCart = (clsCart)Session["MyCart"];

            ShopID = Convert.ToInt32(Request.QueryString["ShopId"].Trim());
            shopName = Convert.ToString(Request.QueryString["ShopName"].Trim());

            lblShopName.Text = Convert.ToString(shopName);
            lblShopId.Text = Convert.ToString(mShopId);

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            Session["Sec"] = Sec;
        }


        void DeleteSellerShopLine()
        {
            //function to delete the selected record

            //create an instance of the Inventory List
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            //find the record to delete
            AllSellerShops.ThisSellerShop.Find(mShopId);
            //delete the record
            AllSellerShops.Delete();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSellerShopLine();
            lblError.Text = "The Shop has been Deleted successfully. Please click on 'Back To Manage Shop' button";
            btnDelete.Visible = false;
            //Response.Write("<script>alert('Product Deletion Successful.Please click on -Go Back to Shop- Button');</script>");

        }

        protected void btnBackToShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSellerShop.aspx");
        }
    }
}