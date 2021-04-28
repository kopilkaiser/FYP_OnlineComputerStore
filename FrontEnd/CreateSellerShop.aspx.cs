using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm20 : System.Web.UI.Page
    {
        clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
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
            txtDateOpened.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
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
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            //validate the data on the web form
            string Error = AllSellerShops.ThisSellerShop.Valid(txtShopName.Text, txtSellerName.Text, txtEmail.Text, Convert.ToString(DDListProductName0.SelectedValue), txtDateOpened.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllSellerShops.ThisSellerShop.Email = Convert.ToString(txtEmail.Text);
                AllSellerShops.ThisSellerShop.ShopName = Convert.ToString(txtShopName.Text);
                AllSellerShops.ThisSellerShop.SellerName = Convert.ToString(txtSellerName.Text);
                AllSellerShops.ThisSellerShop.Rating = Convert.ToInt32(DDListProductName0.SelectedValue);
                AllSellerShops.ThisSellerShop.DateOpened = Convert.ToDateTime(txtDateOpened.Text);

                //add the record
                AllSellerShops.Add();

            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

        protected void btnCreateShop_Click(object sender, EventArgs e)
        {
            string Error = AllSellerShops.ThisSellerShop.Valid(txtShopName.Text, txtSellerName.Text, txtEmail.Text, Convert.ToString(DDListProductName0.SelectedValue), txtDateOpened.Text);

            if (Error == "")
            {

                Add();
                lblError.Text = "Your shop has been created Successfully. Add your First Product";
                btnCreateShop.Visible = false;
                btnAddSellerProduct.Visible = true;
            }
            else
            {
                lblError.Text = "Following Errors: " + Error;
            }
        }

        protected void btnAddSellerProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSellerProduct.aspx");
        }
    }
}