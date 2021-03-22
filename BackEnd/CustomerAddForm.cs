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
    public partial class CustomerAddForm : Form
    {
        int CustomerId;
        public CustomerAddForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            string Error = AllCustomers.ThisCustomer.Valid(txtName.Text, txtPhonenum.Text, txtAccountNo.Text, txtDateJoined.Text);
            string message = "Are you sure to Add the new Customer to the Database?";
            string caption = "User Confirmation!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            //Displays the MessageBox

            //if there are no Errors returned
            if (Error == "")
            {
                //show the Message box
                result = MessageBox.Show(message, caption, buttons);

                //if "Yes" is pressed
                if (result == DialogResult.Yes)
                {
                    //execute the Update method
                    Add();

                    //create an instance of ManageInventoryForm
                    InventoryManageForm mdiMF = new InventoryManageForm();
                    //hide the current form
                    this.Hide();
                    //show the Manaage Inventory Form
                    mdiMF.ShowDialog();
                    //close the current form
                    this.Close();
                }
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CustomerManageForm IM = new CustomerManageForm();

            this.Hide();
            IM.ShowDialog();
            this.Close();
        }

        void Add()
        {
            //create an instance of the Inventory Collenction
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //validate the data on the web form
            string Error = AllCustomers.ThisCustomer.Valid(txtName.Text, txtPhonenum.Text, txtAccountNo.Text, txtDateJoined.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllCustomers.ThisCustomer.Name = txtName.Text;
                AllCustomers.ThisCustomer.AccountNo = Convert.ToInt32(txtAccountNo.Text);
                AllCustomers.ThisCustomer.Phonenum = Convert.ToString(txtPhonenum.Text);
                AllCustomers.ThisCustomer.DateJoined = Convert.ToDateTime(txtDateJoined.Text);
                AllCustomers.ThisCustomer.Active = chkActive.Checked;
                //add the record
                AllCustomers.Add();
                //all done so redirect back to the main page
                CustomerManageForm IM = new CustomerManageForm();
                this.Hide();
                IM.ShowDialog();
                this.Close();
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

        private void CustomerAddForm_Load(object sender, EventArgs e)
        {
            CustomerId = Convert.ToInt32(CustomerId);

            //Display the details of the Customer
            txtAccountNo.Text = "";
            txtName.Text = "";
            txtPhonenum.Text = "";
            txtDateJoined.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            chkActive.Checked = true;
        }
    }
}
