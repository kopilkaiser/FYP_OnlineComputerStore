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
    public partial class ReplyToSupportForm : Form
    {
        private int mSupportId = 0;
        public int SupportID
        {
            set
            {
                mSupportId = value;
            }
        }
        public ReplyToSupportForm()
        {
            InitializeComponent();
        }

        private void ReplyToSupport_Load(object sender, EventArgs e)
        {
            //display the current data for the record
            DisplaySupport();
            txtDateReplied.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        public void DisplaySupport()
        {
            //create an instance of the Support Collection
            clsSupportCollection AllSupports = new clsSupportCollection();
            //find the record from the database to UPDATE
            AllSupports.ThisSupport.Find(mSupportId);
            //Display the data for this record
            txtEmail.Text = AllSupports.ThisSupport.Email;
            txtUserDescription.Text = AllSupports.ThisSupport.Description;
        }

        private void backToManageSupport_Click(object sender, EventArgs e)
        {
            SupportManageForm Sm = new SupportManageForm();
            this.Hide();
            Sm.ShowDialog();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clsReplySupportCollection AllReplySupports = new clsReplySupportCollection();
            string Error = AllReplySupports.ThisReplySupport.Valid(txtEmail.Text, txtDescription.Text, txtDateReplied.Text);
            if (Error == "")
            {
                //Execute the Add Method
                Add();
                lblError.Text = "Your reply has been submitted successfully. Press 'Check Reply' button to see List of Replies";
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

        void Add()
        {
            //create an instance of the Order Collenction
            clsReplySupportCollection AllReplySupports = new clsReplySupportCollection();
            //validate the data on the web form
            string Error = AllReplySupports.ThisReplySupport.Valid(txtEmail.Text, txtDescription.Text, txtDateReplied.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllReplySupports.ThisReplySupport.Email = txtEmail.Text;
                AllReplySupports.ThisReplySupport.Description = Convert.ToString(txtDescription.Text);
                AllReplySupports.ThisReplySupport.DateReplied = Convert.ToDateTime(txtDateReplied.Text);

                //add the record
                AllReplySupports.Add();
                //all done so redirect back to the main page
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ReplySupportManageForm RSM = new ReplySupportManageForm();
            this.Hide();
            RSM.ShowDialog();
            this.Close();
        }
    }
}
