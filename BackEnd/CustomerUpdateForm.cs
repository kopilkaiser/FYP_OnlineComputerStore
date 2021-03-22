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
    public partial class CustomerUpdateForm : Form
    {
        private int mCustomerId = 0;
        
        public int CustomerID
        {
            set
            {
                mCustomerId = value;
            }
        }
        public CustomerUpdateForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            string Error = AllCustomers.ThisCustomer.Valid(txtName.Text, txtPhonenum.Text, txtAccountNo.Text, txtDateJoined.Text);
            string message = "Are you sure to Update the existing Customer in the Database?";
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
                    Update();

                    //create an instance of ManageInventoryForm
                    CustomerManageForm mdiMF = new CustomerManageForm();
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
            CustomerManageForm IF = new CustomerManageForm();
            this.Hide();
            IF.ShowDialog();
            this.Close();
        }

        private void CustomerUpdateForm_Load(object sender, EventArgs e)
        {
            //Display the current data for the record
            DisplayCustomer();
            txtDateJoined.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        public void DisplayCustomer()
        {
            //create an instance of the Inventory Collection
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //find the record from the database to UPDATE
            AllCustomers.ThisCustomer.Find(mCustomerId);
            //Display the data for this record
            txtAccountNo.Text = AllCustomers.ThisCustomer.AccountNo.ToString();
            txtName.Text = AllCustomers.ThisCustomer.Name;
            txtPhonenum.Text = AllCustomers.ThisCustomer.Phonenum.ToString();
            txtDateJoined.Text = AllCustomers.ThisCustomer.DateJoined.ToString();
            chkActive.Checked = AllCustomers.ThisCustomer.Active;

        }

        public void Update()
        {
            //create an instance of the Inventory Collenction
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //validate the data on the web form
            string Error = AllCustomers.ThisCustomer.Valid(txtName.Text, txtPhonenum.Text, txtAccountNo.Text, txtDateJoined.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllCustomers.ThisCustomer.Find(mCustomerId);
                //get the data entered by the user
                AllCustomers.ThisCustomer.Name = txtName.Text;
                AllCustomers.ThisCustomer.AccountNo = Convert.ToInt32(txtAccountNo.Text);
                AllCustomers.ThisCustomer.Phonenum = Convert.ToString(txtPhonenum.Text);
                AllCustomers.ThisCustomer.DateJoined = Convert.ToDateTime(txtDateJoined.Text);
                AllCustomers.ThisCustomer.Active = chkActive.Checked;
                //add the record
                AllCustomers.Update();
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
    }
}
