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
    public partial class ReviewManageForm : Form
    {
        public ReviewManageForm()
        {
            InitializeComponent();
        }

        private void ReviewManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Inventory Database List
            lblError.Text = "Total " + DisplayReviews("") + " records in the Database";
            //Clear all selections in the ListBox
            lstReviews.ClearSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsReview AReview = new clsReview();
            AReview.ReviewId = -1;
            ReviewAddForm RA = new ReviewAddForm();
            this.Hide();
            RA.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 ReviewId;
            //if a record has been selected from the list
            if (lstReviews.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                ReviewId = Convert.ToInt32(lstReviews.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                ReviewUpdateForm UpdateReview = new ReviewUpdateForm();
                //store the data in the session object
                UpdateReview.ReviewID = ReviewId;
                this.Hide();
                UpdateReview.ShowDialog();
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
            Int32 ReviewId;
            //if a record has been selected from the list
            if (lstReviews.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                ReviewId = Convert.ToInt32(lstReviews.SelectedValue);

                //redirect to the delete page
                ReviewDeleteForm RD = new ReviewDeleteForm();
                //store the data in the session object
                RD.ReviewID = ReviewId;
                this.Hide();
                RD.ShowDialog();
            }
            else //if no record has been selected
            {
                //display an error
                lblError.Text = "Please select a record to edit from the list";
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayReviews(txtEmail.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplayReviews("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtEmail.Text = "";

            lstReviews.ClearSelected();
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

        Int32 DisplayReviews(string EmailFilter)
        {
            clsReviewCollection AllReviews = new clsReviewCollection();
            AllReviews.ReportByEmail(EmailFilter);
            //set the data source to the list of Inventories in the collection
            lstReviews.DataSource = AllReviews.ReviewList;
            //set the name of the primary Key
            lstReviews.ValueMember = "ReviewId";
            //set the data field to display
            lstReviews.DisplayMember = "AllDetails";


            return AllReviews.Count;
        }
    }
}
