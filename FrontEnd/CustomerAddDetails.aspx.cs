using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        clsCustomerCollection AllCustomers = new clsCustomerCollection();
        clsSecurity Sec;
        clsCart MyCart = new clsCart();

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
            txtAccountBalance.Text = "50";
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            Session["Sec"] = Sec;
            
        }

        void Add()
        {
            //create an instance of the Payment Collenction
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //validate the data on the web form
            string Error = AllCustomers.ThisCustomer.Valid(txtName.Text, txtPhonenum.Text, txtEmail.Text, DateTime.Now.Date.ToString(), txtBio.Text, txtAccountBalance.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllCustomers.ThisCustomer.Name = txtName.Text;
                AllCustomers.ThisCustomer.Email = txtEmail.Text;
                AllCustomers.ThisCustomer.Phonenum = txtPhonenum.Text;
                AllCustomers.ThisCustomer.Bio = txtBio.Text;
                AllCustomers.ThisCustomer.DateJoined = DateTime.Now.Date;
                AllCustomers.ThisCustomer.AccountBalance = Convert.ToDecimal(txtAccountBalance.Text);

                //add the record
                AllCustomers.Add();

            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Error = AllCustomers.ThisCustomer.Valid(txtName.Text, txtPhonenum.Text, txtEmail.Text, DateTime.Now.Date.ToString(), txtBio.Text, txtAccountBalance.Text);

            if (Error == "")
            {

                Add();
                Response.Redirect("Default.aspx");

            }
            else
            {
                lblError.Text = "Following Errors: " + Error;
            }

        }
    }

   
}