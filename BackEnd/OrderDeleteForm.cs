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
    public partial class OrderDeleteForm : Form
    {
        private int mOrderId = 0;

        public int OrderID
        {
            set
            {
                mOrderId = value;
            }
        }
        public OrderDeleteForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string message = "The Order has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteOrder();
                //All done so redirect back to the main page
                OrderManageForm OM = new OrderManageForm();
                this.Hide();
                OM.ShowDialog();
                this.Close();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //All done so redirect back to the main page
            OrderManageForm OM = new OrderManageForm();
            this.Hide();
            OM.ShowDialog();
            this.Close();
        }

        void DeleteOrder()
        {
            //function to delete the selected record

            //create an instance of the Inventory List
            clsOrderCollection AllOrders = new clsOrderCollection();
            //find the record to delete
            AllOrders.ThisOrder.Find(mOrderId);
            //delete the record
            AllOrders.Delete();
        }

    }
}
