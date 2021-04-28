using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        private int mSellerShopLineId = 0;
        public int SellerShopLineID
        {
            set
            {
                mSellerShopLineId = value;
            }
        }

        string productName;

        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        clsSellerShopLine AllSellerShopLines = new clsSellerShopLine();
        //variables to store the values of the fields being passed from the FindCustomer page

        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            MyCart = (clsCart)Session["MyCart"];

           SellerShopLineID = Convert.ToInt32(Request.QueryString["SellerShopLineId"].Trim());
           productName = Convert.ToString(Request.QueryString["ProductName"].Trim());

          lblProductName.Text = Convert.ToString(productName);

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
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            //find the record to delete
            AllSellerShopLines.ThisSellerShopLine.Find(mSellerShopLineId);
            //delete the record
            AllSellerShopLines.Delete();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSellerShopLine();
            lblError.Text = "The Product has been Deleted successfully. Please click on 'Go Back To Shop1' button";
            //Response.Write("<script>alert('Product Deletion Successful.Please click on -Go Back to Shop- Button');</script>");
            
        }

        protected void btnBackToShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseMyShop.aspx");
        }
    }
}