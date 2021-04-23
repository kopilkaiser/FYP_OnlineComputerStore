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
    public partial class ReviewDeleteForm : Form
    {
        private int mReviewId = 0;
        public int ReviewID
        {
            set
            {
                mReviewId = value;
            }
        }
        public ReviewDeleteForm()
        {
            InitializeComponent();
        }
        void DeleteInventory()
        {
            //function to delete the selected record

            //create an instance of the Inventory List
            clsReviewCollection AllReviews = new clsReviewCollection();
            //find the record to delete
            AllReviews.ThisReview.Find(mReviewId);
            //delete the record
            AllReviews.Delete();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string message = "The Review has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteInventory();
                //redirect to the main form
                ReviewManageForm RM = new ReviewManageForm();
                this.Hide();
                RM.ShowDialog();
                this.Close();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //redirect to the main form
            ReviewManageForm RM = new ReviewManageForm();
            this.Hide();
            RM.ShowDialog();
            this.Close();
        }
    }
}
