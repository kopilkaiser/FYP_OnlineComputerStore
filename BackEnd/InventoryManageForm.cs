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
    public partial class InventoryManageForm : Form
    {

        public InventoryManageForm()
        {
            InitializeComponent();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsInventory AnInventory = new clsInventory();
            AnInventory.InventoryId = -1;
            InventoryAddForm IF = new InventoryAddForm();
            this.Hide();
            IF.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 InventoryId;
            //if a record has been selected from the list
            if(lstInventories.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                InventoryId = Convert.ToInt32(lstInventories.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                InventoryUpdateForm UpdateInv = new InventoryUpdateForm();
                //store the data in the session object
                UpdateInv.InventoryID = InventoryId;
                this.Hide();
                UpdateInv.ShowDialog();
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
            Int32 InventoryId;
            //if a record has been selected from the list
            if (lstInventories.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                InventoryId = Convert.ToInt32(lstInventories.SelectedValue);

                //redirect to the delete page
                InventoryDeleteForm DIF = new InventoryDeleteForm();
                //store the data in the session object
                DIF.InventoryID = InventoryId;
                this.Hide();
                DIF.ShowDialog();
            }
            else //if no record has been selected
            {
                //display an error
                lblError.Text = "Please select a record to edit from the list";
            }
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayInventories("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtCategory.Text = "";

            lstInventories.ClearSelected();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayInventories(txtCategory.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";

        }

        private void ManageInventoryForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Inventory Database List
            lblError.Text = "Total " + DisplayInventories("") + " records in the Database";
            //Clear all selections in the ListBox
            lstInventories.ClearSelected();
        }

        Int32 DisplayInventories(string CategoryFilter)
        {
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            AllInventories.ReportByCategory(CategoryFilter);
            //set the data source to the list of Inventories in the collection
            lstInventories.DataSource = AllInventories.InventoryList;
            //set the name of the primary Key
            lstInventories.ValueMember = "InventoryId";
            //set the data field to display
            lstInventories.DisplayMember = "AllDetails";


            return AllInventories.Count;
        }
    }
}


