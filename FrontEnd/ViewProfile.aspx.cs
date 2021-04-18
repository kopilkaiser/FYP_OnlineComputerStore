using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    
    public partial class WebForm7 : System.Web.UI.Page
    {
        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            lblName.Text = Session["Sec.Name"].ToString();
            lblPhonenum.Text = Session["Sec.Phonenum"].ToString();
            lblDateJoined.Text = Session["Sec.DateJoined"].ToString();
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            Session["Sec"] = Sec;
        }
    }
}