using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewBackEnd
{
    public partial class mdiMainMenuForm : Form
    {
        public mdiMainMenuForm()
        {
            InitializeComponent();
        }

        private void mdiMainMenuForm_Load(object sender, EventArgs e)
        {
            // lblTime.Text = DateTime.Now.ToLocalTime().ToString();
            lblTime.Text = DateTime.Now.AddHours(24).ToShortTimeString();
            lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        private void btnManageInventory_Click(object sender, EventArgs e)
        {
            InventoryManageForm SS = new InventoryManageForm();
            this.Hide();
            SS.ShowDialog();
            this.Close();
        }

        private void btnManageStaff_Click(object sender, EventArgs e)
        {

        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnSellerShop_Click(object sender, EventArgs e)
        {

        }

        private void btnReviewManage_Click(object sender, EventArgs e)
        {

        }

        private void btnManagePayment_Click(object sender, EventArgs e)
        {

        }

        private void btnSupportManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
