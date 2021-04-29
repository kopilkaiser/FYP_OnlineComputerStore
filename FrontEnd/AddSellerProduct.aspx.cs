using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        clsSellerShopLineCollection AllSellerShopLine = new clsSellerShopLineCollection();
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
            clsSellerShopLineCollection AllSellerProducts = new clsSellerShopLineCollection();
            //validate the data on the web form
            string Error = AllSellerProducts.ThisSellerShopLine.Valid(txtEmail.Text, Convert.ToString(DDListProductName.SelectedValue), txtPrice.Text, txtQuantity.Text, txtDescription.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllSellerProducts.ThisSellerShopLine.Email = Convert.ToString(txtEmail.Text);
                AllSellerProducts.ThisSellerShopLine.ProductName = Convert.ToString(DDListProductName.SelectedValue);
                AllSellerProducts.ThisSellerShopLine.Price = Convert.ToDecimal(txtPrice.Text);
                AllSellerProducts.ThisSellerShopLine.Quantity = Convert.ToInt32(txtQuantity.Text);
                AllSellerProducts.ThisSellerShopLine.Description = txtDescription.Text;

                //add the record
                AllSellerProducts.Add();

            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Error = AllSellerShopLine.ThisSellerShopLine.Valid(txtEmail.Text, Convert.ToString(DDListProductName.SelectedValue), txtPrice.Text, txtQuantity.Text, txtDescription.Text);
            
            if (Error == "")
            {

                Add();
                Response.Redirect("ManageSellerProducts.aspx");

            }
            else
            {
                lblError.Text = "Following Errors: " + Error;
            }
        }
    }
}