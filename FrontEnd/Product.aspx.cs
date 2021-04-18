using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class Product : System.Web.UI.Page
    {
        clsSecurity Sec;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if this is the first time the page is displayed
            if (IsPostBack == false)
            {
                //update the list box
                // lblError.Text = DisplayInventories("") + " records in the database";
            }

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

        }

        private void SetLinks(Boolean Authenticated)
        {
            //sets the visible state of the links based on the authentication state
            //

            /* lstInventories.Visible = Authenticated;
             lblError.Visible = Authenticated;
             btnAdd.Visible = Authenticated;
             btnEdit.Visible = Authenticated;
             btnDelete.Visible = Authenticated;
             txtCategory.Visible = Authenticated;
             btnApply.Visible = Authenticated;
             btnDisplayAll.Visible = Authenticated;

             lblCategory.Visible = Authenticated; */

        }

    }
}