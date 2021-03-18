using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class SiteMaster : MasterPage       
    {
        //create an instance of the security class with page level scope
        clsSecurity Sec;
        protected void Page_Load(object sender, EventArgs e)
        {
            //on load get the current state from the session
            Sec = (clsSecurity)Session["Sec"];
            //if the object is null then it needs initialising
            if (Sec == null)
            {
                //initialize the object
                Sec = new clsSecurity();
                //update the session
                Session["Sec"] = Sec;
            }
            //set the state of the link based on the current state of authentication
            SetLinks(Sec.Authenticated);

            if (!IsPostBack)
            {
                DropDownList2.SelectedValue = Request.Url.AbsolutePath;
            }
        }

        protected void SetLinks(Boolean Authenticated)
        {
            //sets the visible state of the links based on the authentication state


            //set the state of the following to not authenticated i.e. they will be visible when not logged in

            //set the state of the following to not authenticated i.e. they will be visible when logged in
           DropDownList2.Visible = Authenticated;

            txtUserEmail.Visible = Authenticated;
            txtUserEmail.Text = "Welcome" + Sec.UserEMail + "!";

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(DropDownList2.SelectedValue);
        }

    }

    
}