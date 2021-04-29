using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        Int32 InventoryId;
        string Name;
        decimal Price;
        string ImagePath;
        string Description;
        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            //upon loading the page you need to read in the cart from the session object
            MyCart = (clsCart)Session["MyCart"];

            //you also need to get the product id from the query string
            InventoryId = Convert.ToInt32(Request.QueryString["InventoryId"].Trim());

            Name = Convert.ToString(Request.QueryString["Name"].Trim());
            Price = Convert.ToDecimal(Request.QueryString["Price"].Trim());
            Description = Convert.ToString(Request.QueryString["Description"].Trim());
            //ImagePath = Convert.ToString(Request.QueryString["ImagePath"].Trim());

            txtName.Text = Convert.ToString(Name);         
            txtPrice.Text = Convert.ToString(Price);
            txtDescription.Text = Convert.ToString(Description);

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;


        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //create a new instance of clsCartItem
            clsCartItem AnItem = new clsCartItem();
            //set the product id
            AnItem.InventoryId = InventoryId;
            //set the Item properties
            AnItem.Name = Convert.ToString(txtName.Text);
            AnItem.QTY = Convert.ToInt32(txtQuantity.Text);
            AnItem.Price = Convert.ToDecimal(txtPrice.Text);
            AnItem.TotalPrice = Convert.ToDecimal((AnItem.QTY) * (AnItem.Price));

            //add the item to the cart's products collection
            MyCart.Products.Add(AnItem);
            //go back to shopping
            Response.Redirect("Product.aspx");
        }
    }
}