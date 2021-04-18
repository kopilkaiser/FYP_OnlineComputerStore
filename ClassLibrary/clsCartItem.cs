using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCartItem
    {
        public clsCartItem()
        {

        }

        private Int32 mInventoryId;
        public Int32 InventoryId
        {
            get
            {
                return mInventoryId;
            }

            set
            {
                mInventoryId = value;
            }
        }

        private string mName;
        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }

        private Int32 mQTY;
        public Int32 QTY
        {
            get
            {
                return mQTY;
            }

            set
            {
                mQTY = value;
            }
        }

        private decimal mPrice;
        public decimal Price
        {
            get
            {
                return mPrice;
            }

            set
            {
                mPrice = value;
            }
        }

        private decimal mTotalPrice;
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
    }
}
