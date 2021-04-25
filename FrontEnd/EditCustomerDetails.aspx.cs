using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private int mCustomerId = 0;
        public int CustomerID
        {
            set
            {
                mCustomerId = value;
            }
        }

        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        clsCustomerCollection AllCustomers = new clsCustomerCollection();
        //variables to store the values of the fields being passed from the FindCustomer page
        Int32 CustomerId;
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

            CustomerId = Convert.ToInt32(Request.QueryString["CustomerId"]);
            email = Convert.ToString(Request.QueryString["Email"]);
            phonenum = Convert.ToString(Request.QueryString["Phonenum"]);
            AccountBalance = Convert.ToString(Request.QueryString["AccountBalance"]);
            Bio = Convert.ToString(Request.QueryString["Bio"]);
            dateJoined = Convert.ToDateTime(Request.QueryString["DateJoined"]);
            name = Convert.ToString(Request.QueryString["Name"]);

            txtCustomerId.Text = CustomerId.ToString();
            txtEmail.Text = "";
            txtAccountBalance.Text = "";
            txtPhonenum.Text = "";
            txtBio.Text = "";
            txtName.Text = "";
            txtDateJoined.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
            Session["Sec"] = Sec;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            string Error = AllCustomers.ThisCustomer.Valid(txtName.Text, txtPhonenum.Text, txtEmail.Text,txtDateJoined.Text, txtBio.Text, txtAccountBalance.Text);

            if(Error == "")
            {
                Update();
                lblError.Text = "Your records have been updated succeessfully";
            }

            else
            {
                lblError.Text = "Fix these issues : " + Error;
            }
  
        }

        public void Update()
        {
            //create an instance of the Inventory Collection
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //validate the data on the Windows Form
            string Error = AllCustomers.ThisCustomer.Valid(txtName.Text, txtPhonenum.Text, txtEmail.Text, DateTime.Now.Date.ToString(), txtBio.Text, txtAccountBalance.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllCustomers.ThisCustomer.Find(mCustomerId);
                //get the data entered by the user

                AllCustomers.ThisCustomer.Name = txtName.Text;
                AllCustomers.ThisCustomer.Email = txtEmail.Text;
                AllCustomers.ThisCustomer.AccountBalance = Convert.ToDecimal(txtAccountBalance.Text);
                AllCustomers.ThisCustomer.Bio = Convert.ToString(txtBio.Text);
                AllCustomers.ThisCustomer.DateJoined = Convert.ToDateTime(txtDateJoined.Text);
                AllCustomers.ThisCustomer.Phonenum = txtPhonenum.Text;


                //UPDATE the record
                AllCustomers.Update();
                //All Done so Redirect to the previous Form

            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }

        }

    }
}