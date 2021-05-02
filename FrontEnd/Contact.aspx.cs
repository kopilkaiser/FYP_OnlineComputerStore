using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class Contact : Page
    {
        clsSupportCollection AllSupports = new clsSupportCollection();
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
            txtDateSubmitted.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            Session["Sec"] = Sec;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Error = AllSupports.ThisSupport.Valid(txtEmail.Text, txtName.Text, txtDescription.Text, txtPhonenum.Text, txtDateSubmitted.Text);

            if (Error == "")
            {

                Add();
                lblError.Text = "Your enquiry has been submitted successfully. We will get back to you soon!";

            }
            else
            {
                lblError.Text = "Following Errors: " + Error;
            }
        }

        void Add()
        {
            //create an instance of the Payment Collenction
            clsSupportCollection AllSupports = new clsSupportCollection();
            //validate the data on the web t
            string Error = AllSupports.ThisSupport.Valid(txtEmail.Text, txtName.Text, txtDescription.Text, txtPhonenum.Text, txtDateSubmitted.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllSupports.ThisSupport.Email = Convert.ToString(txtEmail.Text);
                AllSupports.ThisSupport.Description = txtDescription.Text;
                AllSupports.ThisSupport.Name = Convert.ToString(txtName.Text);
                AllSupports.ThisSupport.Phonenum = Convert.ToString(txtPhonenum.Text);
                AllSupports.ThisSupport.DateSubmitted = Convert.ToDateTime(txtDateSubmitted.Text);

                //add the record
                AllSupports.Add();

            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }
    }
}