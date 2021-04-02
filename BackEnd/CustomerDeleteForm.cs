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
    public partial class CustomerDeleteForm : Form
    {
        private int mCustomerId = 0;
        public int CustomerID
        {
            set
            {
                mCustomerId = value;
            }
        }
        public CustomerDeleteForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string message = "The Customer has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteCustomer();
                //redirect to the main form
                CustomerManageForm CustManageForm = new CustomerManageForm();
                this.Hide();
                CustManageForm.ShowDialog();
                this.Close();
            }
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //redirect to the main form
            CustomerManageForm CustManageForm = new CustomerManageForm();
            this.Hide();
            CustManageForm.ShowDialog();
            this.Close();
        }

        void DeleteCustomer()
        {
            //function to delete the selected record

            //create an instance of the Class List
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //find the record to delete
            AllCustomers.ThisCustomer.Find(mCustomerId);
            //delete the record
            AllCustomers.Delete();
        }

        private void CustomerDeleteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
