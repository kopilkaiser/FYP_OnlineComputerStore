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
    public partial class ReviewAddForm : Form
    {
        int ReviewId;
        public ReviewAddForm()
        {
            InitializeComponent();
        }

        void Add()
        {
            //create an instance of the Inventory Collenction
            clsReviewCollection AllReviews = new clsReviewCollection();
            //validate the data on the web form
            string Error = AllReviews.ThisReview.Valid(txtEmail.Text, txtDescription.Text, txtDateReviewed.Text, Convert.ToString(comboBoxRating.SelectedItem), txtProductId.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllReviews.ThisReview.Email = Convert.ToString(txtEmail.Text);
                AllReviews.ThisReview.Description = Convert.ToString(txtDescription.Text);
                AllReviews.ThisReview.DateReviewed = Convert.ToDateTime(txtDateReviewed.Text);
                AllReviews.ThisReview.Rating = Convert.ToInt32(comboBoxRating.SelectedItem);
                AllReviews.ThisReview.ProductId = Convert.ToInt32(txtProductId.Text);

                //add the record
                AllReviews.Add();
                //all done so redirect back to the main page
                ReviewManageForm RM = new ReviewManageForm();
                this.Hide();
                RM.ShowDialog();
                this.Close();
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReviewManageForm RM = new ReviewManageForm();

            this.Hide();
            RM.ShowDialog();
            this.Close();
        }

        private void ReviewAddForm_Load(object sender, EventArgs e)
        {
            ReviewId = Convert.ToInt32(ReviewId);


            //Display the details of the Inventory
            txtDateReviewed.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtEmail.Text = "";
            txtDescription.Text = "";
            txtProductId.Text = "";
            comboBoxRating.Text = "";
            comboBoxRating.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsReviewCollection AllReviews = new clsReviewCollection();
            string Error = AllReviews.ThisReview.Valid(txtEmail.Text, txtDescription.Text, txtDateReviewed.Text, Convert.ToString(comboBoxRating.SelectedItem), txtProductId.Text);
            string message = "Are you sure to Add the new Review to the Database?";
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
    }
}
