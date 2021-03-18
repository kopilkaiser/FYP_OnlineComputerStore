using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class SignIn : System.Web.UI.Page
    {
        //create a copy of the security object with page level scope
        clsSecurity Sec;
        protected void Page_Load(object sender, EventArgs e)
        {
            //get the current security state from the session
            Sec = (clsSecurity)Session["Sec"];

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //update the security state in the session
            Session["Sec"] = Sec;
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            //try to Sign In and record any errors
            String Error = Sec.SignIn(txtEmail.Text, txtPassword.Text);
            //if there were no errors
            if(Error == "")
            {
                //navigate to the re-send page
                Response.Redirect("Default.aspx");
            }
            else
            {
                //otherwise display any error
                lblError.Text = Error;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //navigate back to default
            Response.Redirect("Default.aspx");
        }

        protected void btnReSend_Click(object sender, EventArgs e)
        {
            //navigate to the re-send page
            Response.Redirect("ReSet.aspx");
        }
    }
}