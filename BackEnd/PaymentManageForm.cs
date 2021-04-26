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
    public partial class PaymentManageForm : Form
    {
        public PaymentManageForm()
        {
            InitializeComponent();
        }

        private void PaymentManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Inventory Database List
            lblError.Text = "Total " + DisplayPayments("") + " records in the Database";
            //Clear all selections in the ListBox
            lstPayments.ClearSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsPayment APayment = new clsPayment();
            APayment.PaymentId = -1;
            PaymentAddForm PA = new PaymentAddForm();
            this.Hide();
            PA.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 PaymentId;
            //if a record has been selected from the list
            if (lstPayments.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                PaymentId = Convert.ToInt32(lstPayments.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                PaymentUpdateForm UpdatePay = new PaymentUpdateForm();
                //store the data in the session object
                UpdatePay.PaymentID = PaymentId;
                this.Hide();
                UpdatePay.ShowDialog();
                this.Close();
            }
            //if no record has been selected
            else
            {
                //Display an error
                lblError.Text = "Please select a record to Update from the List";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //var to store the primary key value of the record to be edited
            Int32 PaymentId;
            //if a record has been selected from the list
            if (lstPayments.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                PaymentId = Convert.ToInt32(lstPayments.SelectedValue);

                //redirect to the delete page
                PaymentDeleteForm PD = new PaymentDeleteForm();
                //store the data in the session object
                PD.PaymentID = PaymentId;
                this.Hide();
                PD.ShowDialog();
            }
            else //if no record has been selected
            {
                //display an error
                lblError.Text = "Please select a record to edit from the list";
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            string message = "Are you sure to go back to the Main Menu?";
            string caption = "User Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            //Displays the MessageBox
            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                mdiMainMenuForm mdiMF = new mdiMainMenuForm();

                this.Hide();
                mdiMF.ShowDialog();
                this.Close();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayPayments(txtPayeeName.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayPayments("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtPayeeName.Text = "";

            lstPayments.ClearSelected();
        }

        Int32 DisplayPayments(string EmailFilter)
        {
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            AllPayments.ReportByEmail(EmailFilter);
            //set the data source to the list of Inventories in the collection
            lstPayments.DataSource = AllPayments.PaymentList;
            //set the name of the primary Key
            lstPayments.ValueMember = "PaymentId";
            //set the data field to display
            lstPayments.DisplayMember = "AllDetails";


            return AllPayments.Count;
        }
    }
}
