using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm25 : System.Web.UI.Page
    {
        clsSecurity Sec;
        clsCart MyCart = new clsCart();

        string replySupportId;
        string email;
        string description;
        string dateReplied;
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

            replySupportId = Convert.ToString(Request.QueryString["ReplySupportId"].Trim());
            email = Convert.ToString(Request.QueryString["Email"].Trim());
            description = Convert.ToString(Request.QueryString["Description"].Trim());
            dateReplied = Convert.ToString(Request.QueryString["DateReplied"].Trim());

            lblReplySupportId.Text = replySupportId;
            txtDescription.Text = description.ToUpper();
            txtDateReplied.Text = dateReplied.ToUpper();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupportReplies.aspx");
        }

        protected void btnAddSupport_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }
    }
}