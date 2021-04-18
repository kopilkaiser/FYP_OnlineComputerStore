using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            MyCart = (clsCart)Session["MyCart"];
            txtOrderTotal.Text = Session["Ordertotal"].ToString();
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            //update the security state in the session
            Session["Sec"] = Sec;
        }
    }
}