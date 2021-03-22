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
    public partial class CustomerManageForm : Form
    {
        public CustomerManageForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsCustomer ACustomer = new clsCustomer();
            ACustomer.CustomerId = -1;
            CustomerAddForm CA = new CustomerAddForm();
            this.Hide();
            CA.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 CustomerId;
            //if a record has been selected from the list
            if (lstCustomers.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                CustomerId = Convert.ToInt32(lstCustomers.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                CustomerUpdateForm UpdateCus = new CustomerUpdateForm();
                //store the data in the session object
                UpdateCus.CustomerID = CustomerId;
                this.Hide();
                UpdateCus.ShowDialog();
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
            Int32 CustomerId;
            //if a record has been selected from the list
            if (lstCustomers.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                CustomerId = Convert.ToInt32(lstCustomers.SelectedValue);

                //redirect to the delete page
                CustomerDeleteForm DIF = new CustomerDeleteForm();
                //store the data in the session object
                DIF.CustomerID = CustomerId;
                this.Hide();
                DIF.ShowDialog();
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
            RecordCount = DisplayCustomers(txtName.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayCustomers("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtName.Text = "";

            lstCustomers.ClearSelected();
        }

        Int32 DisplayCustomers(string NameFilter)
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            AllCustomers.ReportByName(NameFilter);
            //set the data source to the list of Customers in the collection
            lstCustomers.DataSource = AllCustomers.CustomerList;
            //set the name of the Primary Key
            lstCustomers.ValueMember = "CustomerId";
            //set the data field to display
            lstCustomers.DisplayMember = "AllDetails";

            return AllCustomers.Count;
        }

        private void CustomerManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Customer Database List
            lblError.Text = "Total " + DisplayCustomers("") + " records in the Database";
            //Clear all selections in the ListBox
            lstCustomers.ClearSelected();
        }
    }
}
