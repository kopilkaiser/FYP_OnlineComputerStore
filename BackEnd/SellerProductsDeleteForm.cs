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
    public partial class SellerProductsDeleteForm : Form
    {
        private int mSellerShopLineId = 0;

        public int SellerShopLineID
        {
            set
            {
                mSellerShopLineId = value;
            }
        }
        public SellerProductsDeleteForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string message = "The Seller Product has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteSellerProduct();
                //redirect to the main form
                SellerProductsManageForm SPM = new SellerProductsManageForm();
                this.Hide();
                SPM.ShowDialog();
                this.Close();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //redirect to the main form
            SellerProductsManageForm SPM = new SellerProductsManageForm();
            this.Hide();
            SPM.ShowDialog();
            this.Close();
        }

        void DeleteSellerProduct()
        {
            //function to delete the selected record

            //create an instance of the Inventory List
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            //find the record to delete
            AllSellerShopLines.ThisSellerShopLine.Find(mSellerShopLineId);
            //delete the record
            AllSellerShopLines.Delete();
        }
    }
}
