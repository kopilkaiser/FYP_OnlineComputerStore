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
    public partial class ReviewUpdateForm : Form
    {
        private int mReviewId = 0;

        public int ReviewID
        {
            set
            {
                mReviewId = value;
            }
        }
           
        public ReviewUpdateForm()
        {
            InitializeComponent();
        }

        public void Update()
        {
            //create an instance of the Inventory Collection
            clsReviewCollection AllReviews = new clsReviewCollection();
            //validate the data on the Windows Form
            string Error = AllReviews.ThisReview.Valid(txtEmail.Text, txtDescription.Text, txtDateReviewed.Text, Convert.ToString(comboBoxRating.SelectedItem), txtProductId.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllReviews.ThisReview.Find(mReviewId);
                //get the data entered by the user

                AllReviews.ThisReview.Email = Convert.ToString(txtEmail.Text);
                AllReviews.ThisReview.Description = Convert.ToString(txtDescription.Text);
                AllReviews.ThisReview.DateReviewed = Convert.ToDateTime(txtDateReviewed.Text);
                AllReviews.ThisReview.Rating = Convert.ToInt32(comboBoxRating.SelectedItem);
                AllReviews.ThisReview.ProductId = Convert.ToInt32(txtProductId.Text);


                //UPDATE the record
                AllReviews.Update();
                //All Done so Redirect to the previous Form
                ReviewManageForm RM = new ReviewManageForm();
                this.Hide();
                RM.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }

        }

        public void DisplayReview()
        {
            //create an instance of the Inventory Collection
            clsReviewCollection AllReviews = new clsReviewCollection();
            //find the record from the database to UPDATE
            AllReviews.ThisReview.Find(mReviewId);
            //Display the data for this record
            txtReviewId.Text = AllReviews.ThisReview.ReviewId.ToString();
            txtDescription.Text = AllReviews.ThisReview.Description;
            txtEmail.Text = AllReviews.ThisReview.Email.ToString();
            comboBoxRating.Text = AllReviews.ThisReview.Rating.ToString();
            txtDateReviewed.Text = AllReviews.ThisReview.DateReviewed.ToString();
            txtProductId.Text = AllReviews.ThisReview.ProductId.ToString();



        }

        private void ReviewUpdateForm_Load(object sender, EventArgs e)
        {
            //display the current data for the record
            DisplayReview();
            txtDateReviewed.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            comboBoxRating.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsReviewCollection AllReviews = new clsReviewCollection();
            string Error = AllReviews.ThisReview.Valid(txtEmail.Text, txtDescription.Text, txtDateReviewed.Text, Convert.ToString(comboBoxRating.SelectedItem), txtProductId.Text);
            string message = "Are you sure to Update the existing Review details?";
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
                    ReviewManageForm RM = new ReviewManageForm();
                    //hide the current form
                    this.Hide();
                    //show the Manaage Inventory Form
                    RM.ShowDialog();
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
            //create an instance of ManageInventoryForm
            ReviewManageForm RM = new ReviewManageForm();
            //hide the current form
            this.Hide();
            //show the Manaage Inventory Form
            RM.ShowDialog();
            //close the current form
            this.Close();
        }
    }
}
