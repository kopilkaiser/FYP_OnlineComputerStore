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
    public partial class OrderManageForm : Form
    {
        public OrderManageForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsOrder AnOrder = new clsOrder();
            AnOrder.OrderId = -1;
            OrderAddForm OA = new OrderAddForm();
            this.Hide();
            OA.ShowDialog();
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayOrders(txtEmail.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";

        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayOrders("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtEmail.Text = "";

            lstOrders.ClearSelected();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 OrderId;
            //if a record has been selected from the list
            if (lstOrders.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                OrderId = Convert.ToInt32(lstOrders.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                OrderUpdateForm UpdateOrder = new OrderUpdateForm();
                //store the data in the session object
                UpdateOrder.OrderID = OrderId;
                this.Hide();
                UpdateOrder.ShowDialog();
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
            Int32 OrderId;
            //if a record has been selected from the list
            if (lstOrders.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                OrderId = Convert.ToInt32(lstOrders.SelectedValue);

                //redirect to the delete page
                OrderDeleteForm OrderDelete = new OrderDeleteForm();
                //store the data in the session object
                OrderDelete.OrderID = OrderId;
                this.Hide();
                OrderDelete.ShowDialog();
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
        Int32 DisplayOrders(string EmailFilter)
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            AllOrders.ReportByEmail(EmailFilter);
            //set the data source to the list of Inventories in the collection
            lstOrders.DataSource = AllOrders.OrderList;
            //set the name of the primary Key
            lstOrders.ValueMember = "OrderId";
            //set the data field to display
            lstOrders.DisplayMember = "AllDetails";


            return AllOrders.Count;
        }

        private void OrderManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Inventory Database List
            lblError.Text = "Total " + DisplayOrders("") + " records in the Database";
            //Clear all selections in the ListBox
            lstOrders.ClearSelected();
        }
    }
}
