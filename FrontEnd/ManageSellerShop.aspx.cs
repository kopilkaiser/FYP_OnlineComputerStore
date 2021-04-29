using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class ManageSellerShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateSellerShop.aspx");

        }

        protected void btnManageSellerProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSellerProducts.aspx");

        }

        protected void btnBrowseAllProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseAllSellerProducts.aspx");
        }
    }
}