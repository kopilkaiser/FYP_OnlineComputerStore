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
    public partial class PaymentDeleteForm : Form
    {

        private int mPaymentId = 0;

        public int PaymentID
        {
            set
            {
                mPaymentId = value;
            }
        }

        public PaymentDeleteForm()
        {
            InitializeComponent();
        }

        void DeleteInventory()
        {
            //function to delete the selected record

            //create an instance of the Inventory List
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //find the record to delete
            AllPayments.ThisPayment.Find(mPaymentId);
            //delete the record
            AllPayments.Delete();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string message = "The Payment has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteInventory();
                //All Done so Redirect to the previous Form
                PaymentManageForm PM = new PaymentManageForm();
                this.Hide();
                PM.ShowDialog();
                this.Close();
            }

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //Redirect to the Payment Manage Form
            PaymentManageForm PM = new PaymentManageForm();
            this.Hide();
            PM.ShowDialog();
            this.Close();
        }
    }
}
