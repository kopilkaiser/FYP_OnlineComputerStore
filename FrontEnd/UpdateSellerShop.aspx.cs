using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace FrontEnd
{
    public partial class WebForm22 : System.Web.UI.Page
    {
        private int mShopId = 0;
        public int ShopID
        {
            set
            {
                mShopId = value;
            }
        }

        string shopName;
        string sellerName;
        string rating;
        string email;
        string dateOpened;

        clsSecurity Sec;
        clsCart MyCart = new clsCart();
        clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            Sec = (clsSecurity)Session["Sec"];
            MyCart = (clsCart)Session["MyCart"];

            ShopID = Convert.ToInt32(Request.QueryString["ShopId"].Trim());
            shopName = Convert.ToString(Request.QueryString["ShopName"].Trim());
            sellerName = Convert.ToString(Request.QueryString["sellerName"].Trim());
            rating = Convert.ToString(Request.QueryString["Rating"].Trim());
            email = Convert.ToString(Request.QueryString["Email"].Trim());
            dateOpened = Convert.ToString(Request.QueryString["DateOpened"].Trim());

            txtShopId.Text = mShopId.ToString();
            txtEmail.Text = email.ToString();
            txtOldShopName.Text = shopName.ToString();
            txtOldSellerName.Text = shopName.ToString();
            txtRating.Text = rating.ToString();
            txtDateOpened.Text = dateOpened.ToString();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            //AllCustomers.ThisCustomer.CustomerId = CustomerId;

            string Error = AllSellerShops.ThisSellerShop.Valid(txtNewShopName.Text, txtNewSellerName.Text, txtEmail.Text, txtRating.Text);

            if (Error == "")
            {
                Update();
                lblError.Text = "Your Shop details have been updated succeessfully. You can now go back to your Shop";
            }

            else
            {
                lblError.Text = "Fix these issues : " + Error;
            }
        }

        public void Update()
        {
            //create an instance of the Inventory Collection
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            //validate the data on the Windows Form
            string Error = AllSellerShops.ThisSellerShop.Valid(txtNewShopName.Text, txtNewSellerName.Text, txtEmail.Text, txtRating.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllSellerShops.ThisSellerShop.Find(mShopId);
                //get the data entered by the user

                AllSellerShops.ThisSellerShop.ShopName = Convert.ToString(txtNewShopName);
                AllSellerShops.ThisSellerShop.SellerName = txtNewSellerName.Text;
                AllSellerShops.ThisSellerShop.Email = txtEmail.Text;
                AllSellerShops.ThisSellerShop.Rating = Convert.ToInt32(txtRating.Text);
                AllSellerShops.ThisSellerShop.DateOpened = Convert.ToDateTime(txtDateOpened.Text);


                //UPDATE the record
                AllSellerShops.Update();
                //All Done so Redirect to the previous Form

            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }

        }


        protected void btnGoBackShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSellerShop.aspx");
        }
    }
}