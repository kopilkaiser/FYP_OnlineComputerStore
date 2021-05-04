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
    public partial class SupportManageForm : Form
    {
        public SupportManageForm()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplaySupports(txtEmail.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplaySupports("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtEmail.Text = "";

            lstSupports.ClearSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsSupport ASupport = new clsSupport();
            ASupport.SupportId = -1;
            SupportAddForm SA = new SupportAddForm();
            this.Hide();
            SA.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 SupportId;
            //if a record has been selected from the list
            if (lstSupports.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                SupportId = Convert.ToInt32(lstSupports.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                SupportUpdateForm UpdateSupport = new SupportUpdateForm();
                //store the data in the session object
                UpdateSupport.SupportID = SupportId;
                this.Hide();
                UpdateSupport.ShowDialog();
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
            Int32 SupportId;
            //if a record has been selected from the list
            if (lstSupports.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                SupportId = Convert.ToInt32(lstSupports.SelectedValue);

                //redirect to the delete page
                SupportDeleteForm DeleteSupport = new SupportDeleteForm();
                //store the data in the session object
                DeleteSupport.SupportID = SupportId;
                this.Hide();
                DeleteSupport.ShowDialog();
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

        Int32 DisplaySupports(string EmailFilter)
        {
            clsSupportCollection AllSupports = new clsSupportCollection();
            AllSupports.ReportByEmail(EmailFilter);
            //set the data source to the list of Inventories in the collection
            lstSupports.DataSource = AllSupports.SupportList;
            //set the name of the primary Key
            lstSupports.ValueMember = "SupportId";
            //set the data field to display
            lstSupports.DisplayMember = "AllDetails";


            return AllSupports.Count;
        }

        private void SupportManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Inventory Database List
            lblError.Text = "Total " + DisplaySupports("") + " records in the Database";
            //Clear all selections in the ListBox
            lstSupports.ClearSelected();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 SupportId;
            //if a record has been selected from the list
            if (lstSupports.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                SupportId = Convert.ToInt32(lstSupports.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                ReplyToSupportForm RTS = new ReplyToSupportForm();
                //store the data in the session object
                RTS.SupportID = SupportId;
                this.Hide();
                RTS.ShowDialog();
                this.Close();
            }
            //if no record has been selected
            else
            {
                //Display an error
                lblError.Text = "Please select a record to Reply from the List";
            }
        }
    }
}
