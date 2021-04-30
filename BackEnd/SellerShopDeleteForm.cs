using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace BackEnd
{
    public partial class SellerShopDeleteForm : Form
    {
        private int mShopId = 0;

        public int ShopID
        {
            set
            {
                mShopId = value;
            }
        }
        public SellerShopDeleteForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string message = "The Seller Shop has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteSellerShop();
                //all done so redirect back to the main page
                SellerShopManageForm SSM = new SellerShopManageForm();
                this.Hide();
                SSM.ShowDialog();
                this.Close();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //redirect to the main form
            SellerShopManageForm SSM = new SellerShopManageForm();
            this.Hide();
            SSM.ShowDialog();
            this.Close();
        }

        void DeleteSellerShop()
        {
            //function to delete the selected record

            //create an instance of the Inventory List
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            //find the record to delete
            AllSellerShops.ThisSellerShop.Find(mShopId);
            //delete the record
            AllSellerShops.Delete();
        }

        private void SellerShopDeleteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
