using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        private int mSellerShopLineId = 0;
        public int SellerShopLineID
        {
            set
            {
                mSellerShopLineId = value;
            }
        }

        string productName;
        string email;
        string price;
        string description;
        string quantity;

        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            MyCart = (clsCart)Session["MyCart"];

            SellerShopLineID = Convert.ToInt32(Request.QueryString["SellerShopLineId"].Trim());
            productName = Convert.ToString(Request.QueryString["ProductName"].Trim());
            email = Convert.ToString(Request.QueryString["Email"].Trim());
            description = Convert.ToString(Request.QueryString["Description"].Trim());
            quantity = Convert.ToString(Request.QueryString["Quantity"].Trim());
            price = Convert.ToString(Request.QueryString["Price"].Trim());


            txtEmail.Text = email.ToString();
            txtProductName.Text = productName.ToString();
            txtPrice.Text = price.ToString();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            //AllCustomers.ThisCustomer.CustomerId = CustomerId;

            string Error = AllSellerShopLines.ThisSellerShopLine.Valid(txtEmail.Text, Convert.ToString(DDListProductName.SelectedValue), txtNewPrice.Text, txtQuantity.Text, txtDescription.Text);

            if (Error == "")
            {
                Update();
                lblError.Text = "Your Product details have been updated succeessfully. You can now go back to your Shop";
            }

            else
            {
                lblError.Text = "Fix these issues : " + Error;
            }
        }

        public void Update()
        {
            //create an instance of the Inventory Collection
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            //validate the data on the Windows Form
            string Error = AllSellerShopLines.ThisSellerShopLine.Valid(txtEmail.Text, Convert.ToString(DDListProductName.SelectedValue), txtNewPrice.Text, txtQuantity.Text, txtDescription.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllSellerShopLines.ThisSellerShopLine.Find(mSellerShopLineId);
                //get the data entered by the user

                AllSellerShopLines.ThisSellerShopLine.ProductName = Convert.ToString(DDListProductName.SelectedValue);
                AllSellerShopLines.ThisSellerShopLine.Email = txtEmail.Text;
                AllSellerShopLines.ThisSellerShopLine.Price = Convert.ToDecimal(txtNewPrice.Text);
                AllSellerShopLines.ThisSellerShopLine.Quantity = Convert.ToInt32(txtQuantity.Text);
                AllSellerShopLines.ThisSellerShopLine.Description = txtDescription.Text;


                //UPDATE the record
                AllSellerShopLines.Update();
                //All Done so Redirect to the previous Form

            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }

        }

        protected void btnGoBackShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSellerProduct.aspx");
        }
    }
}