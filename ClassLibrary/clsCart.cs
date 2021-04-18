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

        private string mCardNumber;
        private string mEmail;

        public string CardNumber
        {
            get
            {
                return mCardNumber;
            }
            set
            {
                mCardNumber = value;
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

        public void Checkout()
        {
            //create an instance of the order class
            clsOrder Order = new clsOrder();
            //invoke the ProcessCart method
            Order.ProcessCart(this);
        }
    }
}
