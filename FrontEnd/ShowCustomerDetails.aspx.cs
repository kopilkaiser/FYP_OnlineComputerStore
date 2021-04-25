using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        //variables to store the values of the fields being passed from the FindCustomer page
        string customerId;
        string email;
        string phonenum;
        string Bio;
        string AccountBalance;
        DateTime dateJoined;
        string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            MyCart = (clsCart)Session["MyCart"];

            customerId = Convert.ToString(Request.QueryString["CustomerId"]);
            email = Convert.ToString(Request.QueryString["Email"]);
            phonenum = Convert.ToString(Request.QueryString["Phonenum"]);
            AccountBalance = Convert.ToString(Request.QueryString["AccountBalance"]);
            Bio = Convert.ToString(Request.QueryString["Bio"]);
            dateJoined = Convert.ToDateTime(Request.QueryString["DateJoined"]);
            name = Convert.ToString(Request.QueryString["Name"]);

            txtCustomerId.Text = customerId;
            txtEmail.Text = email;
            txtAccountBalance.Text = AccountBalance;
            txtPhonenum.Text = phonenum;
            txtBio.Text = Bio;
            lblCustomerName.Text = name;
            txtDateJoined.Text = dateJoined.ToString("dd/MM/yyyy");
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            Session["Sec"] = Sec;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FindCustomer.aspx");
        }
    }
}