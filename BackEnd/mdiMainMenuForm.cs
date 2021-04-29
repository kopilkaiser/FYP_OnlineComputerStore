using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackEnd
{
    public partial class mdiMainMenuForm : Form
    {
        public mdiMainMenuForm()
        {
            InitializeComponent();
        }

        private void btnManageInventory_Click(object sender, EventArgs e)
        {
            InventoryManageForm IF = new InventoryManageForm();
            this.Hide();
            IF.ShowDialog();
            this.Close();
        }


        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            StaffManageForm SM = new StaffManageForm();
            this.Hide();
            SM.ShowDialog();
            this.Close();
        }

        private void btnReviewManage_Click_1(object sender, EventArgs e)
        {
            ReviewManageForm RM = new ReviewManageForm();
            this.Hide();
            RM.ShowDialog();
            this.Close();
        }

        private void mdiMainMenuForm_Load(object sender, EventArgs e)
        {
            // lblTime.Text = DateTime.Now.ToLocalTime().ToString();
            lblTime.Text = DateTime.Now.AddHours(24).ToShortTimeString();
            lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            MDIParent MDP = new MDIParent();
            this.Hide();
            MDP.ShowDialog();
            this.Close();
        }

        private void btnManagePayment_Click(object sender, EventArgs e)
        {
            PaymentManageForm PM = new PaymentManageForm();
            this.Hide();
            PM.ShowDialog();
            this.Close();
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            OrderManageForm OM = new OrderManageForm();
            this.Hide();
            OM.ShowDialog();
            this.Close();
        }

        private void btnSellerShop_Click(object sender, EventArgs e)
        {
            SellerShopManageForm SSM = new SellerShopManageForm();
            this.Hide();
            SSM.ShowDialog();
            this.Close();
        }
    }
}
