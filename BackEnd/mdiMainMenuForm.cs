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

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            CustomerManageForm CM = new CustomerManageForm();
            this.Hide();
            CM.ShowDialog();
            this.Close();
        }
    }
}
