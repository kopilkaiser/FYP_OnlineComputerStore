using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        clsSecurity Sec;
        clsCart MyCart = new clsCart();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["MyCart"] = null;
            Sec = (clsSecurity)Session["Sec"];

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