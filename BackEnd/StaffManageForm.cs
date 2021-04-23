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
    public partial class StaffManageForm : Form
    {
        public StaffManageForm()
        {
            InitializeComponent();
        }

        private void StaffManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Customer Database List
            lblError.Text = "Total " + DisplayStaffs("") + " records in the Database";
            //Clear all selections in the ListBox
            lstStaffs.ClearSelected();
        }

        Int32 DisplayStaffs(string NameFilter)
        {
            clsStaffCollection AllStaffs = new clsStaffCollection();
            AllStaffs.ReportByName(NameFilter);
            //set the data source to the list of Customers in the collection
            lstStaffs.DataSource = AllStaffs.StaffList;
            //set the name of the Primary Key
            lstStaffs.ValueMember = "StaffId";
            //set the data field to display
            lstStaffs.DisplayMember = "AllDetails";

            return AllStaffs.Count;
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
            clsStaff AStaff = new clsStaff();
            AStaff.StaffId = -1;
            StaffAddForm SA = new StaffAddForm();
            this.Hide();
            SA.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //var to store the primary key value of the record to be edited
            Int32 StaffId;
            //if a record has been selected from the list
            if (lstStaffs.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                StaffId = Convert.ToInt32(lstStaffs.SelectedValue);

                //redirect to the delete page
                StaffDeleteForm SD = new StaffDeleteForm();
                //store the data in the session object
                SD.StaffID = StaffId;
                this.Hide();
                SD.ShowDialog();
            }
            else //if no record has been selected
            {
                //display an error
                lblError.Text = "Please select a record to edit from the list";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 StaffId;
            //if a record has been selected from the list
            if (lstStaffs.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                StaffId = Convert.ToInt32(lstStaffs.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                StaffUpdateForm UpdateStaff = new StaffUpdateForm();
                //store the data in the session object
                UpdateStaff.StaffID = StaffId;
                this.Hide();
                UpdateStaff.ShowDialog();
                this.Close();
            }
            //if no record has been selected
            else
            {
                //Display an error
                lblError.Text = "Please select a record to Update from the List";
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayStaffs(txtName.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";

        }

        private void btnDisplayAll_Click_1(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayStaffs("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtName.Text = "";

            lstStaffs.ClearSelected();
        }
    }

}