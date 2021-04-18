using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCart
    {
        List<clsCartItem> mProducts = new List<clsCartItem>();

        public clsCart()
        {

        }


        public List<clsCartItem> Products
        {
            get
            {
                return mProducts;
            }
        }

        private string mShippingAddress;
        private string mEmail;
        private string mPhonenum;
        private decimal mTotalPrice;

        public string ShippingAddress
        {
            get
            {
                return mShippingAddress;
            }
            set
            {
                mShippingAddress = value;
            }
        }

        public string Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                mEmail = value;
            }
        }

        public string Phonenum
        {
            get
            {
                return mPhonenum;
            }
            set
            {
                mPhonenum = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return mTotalPrice;
            }
            set
            {
                mTotalPrice = value;
            }
        }


        public void Checkout()
        {
            //create an instance of the order class
            clsOrder Order = new clsOrder();
            //invoke the ProcessCart method
            Order.ProcessCart(this);
        }
    }
}
