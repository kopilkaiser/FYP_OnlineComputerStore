using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class _Default : Page
    {
        clsSecurity Sec;
        clsCart MyCart = new clsCart();
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

            if (Sec == null)
            {
                //initialize the object
                Sec = new clsSecurity();
                //update the session
                Session["Sec"] = Sec;
            }

            if (Sec.UserEMail.Length == 0)
            {
                Label1.Visible = true;
            }

            else
            {
                Label1.Visible = false;
            }
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            Session["Sec"] = Sec;

        }
    }
}