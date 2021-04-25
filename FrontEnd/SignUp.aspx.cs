using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class SignUp : System.Web.UI.Page
    {
        clsCustomerCollection AllCustomers = new clsCustomerCollection();
#pragma warning disable CS0169 // The field 'SignUp.customerEmail' is never used
        string customerEmail;
#pragma warning restore CS0169 // The field 'SignUp.customerEmail' is never used
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtDateJoined.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtAccountBalance.Text = "50";

        }


        protected void btnReSend_Click1(object sender, EventArgs e)
        {
            //view the email
            Response.Redirect("ReSet.aspx");
        }

        protected void btnSignUp_Click1(object sender, EventArgs e)
        {
            //create a new instance of the security class
            clsSecurity Sec = new clsSecurity();
            //try to sign up using the supplied credentials
            
            //string Outcome = Sec.SignUp(txtEmail.Text, txtPassword.Text, txtConfirmPassword.Text, false);

            //report the outcome of the operation

            //lblError.Text = Outcome;


            //store the object in the session objec for other pages to access
            Session["Sec"] = Sec;

            string Error = AllCustomers.ThisCustomer.Valid(txtName.Text, txtPhonenum.Text, txtEmail.Text, DateTime.Now.Date.ToString(), txtBio.Text, txtAccountBalance.Text);


            if (Error == "")
            {
                string Outcome = Sec.SignUp(txtEmail.Text, txtPassword.Text, txtConfirmPassword.Text, false);
                lblError.Text = Outcome;

                if(Outcome == "An email has been sent to your account allowing you to activate the account. Press 'View Email' button")
                {
                    Add();
                }

                else
                {
                    lblError.Text = Outcome;
                }

            }

            else
            {
                lblError.Text = Error;
            }

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

        protected void btnDone_Click1(object sender, EventArgs e)
        {
            //if done redirect to main page
            Response.Redirect("Default.aspx");
        }

        protected void btnView_Click1(object sender, EventArgs e)
        {
            //display re-set password form
            Response.Redirect("EMailViewer.aspx");
        }

       
    }
}