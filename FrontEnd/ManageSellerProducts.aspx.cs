using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddProductToShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSellerProduct.aspx");

        }

        protected void btnBrowseAllProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseAllSellerProducts.aspx");

        }

        protected void btnBackToManageShop_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ManageSellerShop.aspx");

        }
    }
}