using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        clsPaymentCollection AllPayments = new clsPaymentCollection();
        clsCartItem MyCartList = new clsCartItem();

        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            MyCart = (clsCart)Session["MyCart"];
            MyCartList = (clsCartItem)Session["MyCartList"];
            txtOrderTotal.Text = Session["Ordertotal"].ToString();

            MyCart.Email = Sec.UserEMail;
            txtEmail.Text = Sec.UserEMail;
            txtDatePurchased.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }
 //        public string Valid(string payeeName, string method, string amount, string cardNumber, string datePurchased, string email)

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place 
           Session["MyCart"] = MyCart;
            //update the security state in the session
            Session["Sec"] = Sec;
        }
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            string Error = AllPayments.ThisPayment.Valid(txtName.Text, Convert.ToString(DDListMethod.SelectedItem), txtOrderTotal.Text, txtCardNumber.Text, txtDatePurchased.Text, txtEmail.Text);
            
            if (Error == "")
            {
                if ((txtStreet.Text.Length != 0) && (txtPostCode.Text.Length != 0) && (txtPhonenum.Text.Length != 0) && (txtCity.Text.Length != 0))
                {
                    Add();
                    MyCart.ShippingAddress = txtStreet.Text + ", " + txtPostCode.Text + ", " + txtCity.Text;
                    MyCart.TotalPrice = Convert.ToDecimal(txtOrderTotal.Text);
                    MyCart.Phonenum = txtPhonenum.Text;
                    MyCart.Checkout();
                    Response.Redirect("PaymentComplete.aspx");
                }

                else
                {
                    lblError.Text = "Please fill up all the following fields: Street Address, Post Code, City, Phonenum ";
                }
            }

            else
            {
                lblError.Text = "Problems occured : " + Error;
            }
        }

        void Add()
        {
            //create an instance of the Payment Collenction
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //validate the data on the web form
            string Error = AllPayments.ThisPayment.Valid(txtName.Text, Convert.ToString(DDListMethod.SelectedItem), txtOrderTotal.Text, txtCardNumber.Text, txtDatePurchased.Text, txtEmail.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllPayments.ThisPayment.PayeeName = txtName.Text;
                AllPayments.ThisPayment.CardNumber = txtCardNumber.Text;
                AllPayments.ThisPayment.Method = Convert.ToString(DDListMethod.SelectedItem);
                AllPayments.ThisPayment.Amount = Convert.ToDecimal(txtOrderTotal.Text);
                AllPayments.ThisPayment.DatePurchased = Convert.ToDateTime(txtDatePurchased.Text);
                AllPayments.ThisPayment.Email = Convert.ToString(txtEmail.Text);

                //add the record
                AllPayments.Add();

            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

    }
}