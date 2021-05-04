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
    public partial class ReplySupportManageForm : Form
    {
        public ReplySupportManageForm()
        {
            InitializeComponent();
        }

        private void ReplySupportManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Inventory Database List
            lblError.Text = "Total " + DisplayReplySupports("") + " records in the Database";
            //Clear all selections in the ListBox
            lstReplySupports.ClearSelected();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayReplySupports(txtEmail.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayReplySupports("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtEmail.Text = "";

            lstReplySupports.ClearSelected();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 ReplySupportId;
            //if a record has been selected from the list
            if (lstReplySupports.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                ReplySupportId = Convert.ToInt32(lstReplySupports.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                ReplySupportUpdateForm ReplyUpdateSupport = new ReplySupportUpdateForm();
                //store the data in the session object
                ReplyUpdateSupport.ReplySupportID = ReplySupportId;
                this.Hide();
                ReplyUpdateSupport.ShowDialog();
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
            Int32 ReplySupportId;
            //if a record has been selected from the list
            if (lstReplySupports.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                ReplySupportId = Convert.ToInt32(lstReplySupports.SelectedValue);

                //redirect to the delete page
                ReplySupportDeleteForm DeleteSupport = new ReplySupportDeleteForm();
                //store the data in the session object
                DeleteSupport.ReplySupportID = ReplySupportId;
                this.Hide();
                DeleteSupport.ShowDialog();
            }
            else //if no record has been selected
            {
                //display an error
                lblError.Text = "Please select a record to edit from the list";
            }
        }

        Int32 DisplayReplySupports(string EmailFilter)
        {
            clsReplySupportCollection AllReplySupports = new clsReplySupportCollection();
            AllReplySupports.ReportByEmail(EmailFilter);
            //set the data source to the list of Inventories in the collection
            lstReplySupports.DataSource = AllReplySupports.ReplySupportList;
            //set the name of the primary Key
            lstReplySupports.ValueMember = "ReplySupportId";
            //set the data field to display
            lstReplySupports.DisplayMember = "AllDetails";


            return AllReplySupports.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupportManageForm SM = new SupportManageForm();
            this.Hide();
            SM.ShowDialog();
            this.Close();
        }
    }
}
