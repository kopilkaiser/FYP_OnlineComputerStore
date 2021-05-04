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
    public partial class ReplySupportUpdateForm : Form
    {
        private int mReplySupportId = 0;

        public int ReplySupportID
        {
            set
            {
                mReplySupportId = value;
            }
        }
        public ReplySupportUpdateForm()
        {
            InitializeComponent();
        }



        private void ReplySupportUpdateForm_Load(object sender, EventArgs e)
        {
            //display the current data for the record
            DisplayReplySupport();
        }

        private void backToManageReplySupport_Click(object sender, EventArgs e)
        {
            ReplySupportManageForm RSM = new ReplySupportManageForm();
            this.Hide();
            RSM.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            clsReplySupportCollection AllReplySupports = new clsReplySupportCollection();
            string Error = AllReplySupports.ThisReplySupport.Valid(txtEmail.Text, txtDescription.Text, txtDateReplied.Text);
            string message = "Are you sure to Update the existing Reply?";
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

                    //All done so redirect back to the main page
                    ReplySupportManageForm RSM = new ReplySupportManageForm();
                    this.Hide();
                    RSM.ShowDialog();
                    this.Close(); ;
                }
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

        public void Update()
        {
            //create an instance of the Reply Support Collection
            clsReplySupportCollection AllReplySupports = new clsReplySupportCollection();
            //validate the data on the Windows Form
            string Error = AllReplySupports.ThisReplySupport.Valid(txtEmail.Text, txtDescription.Text, txtDateReplied.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllReplySupports.ThisReplySupport.Find(mReplySupportId);
                //get the data entered by the user
                AllReplySupports.ThisReplySupport.Email = txtEmail.Text;
                AllReplySupports.ThisReplySupport.Description = Convert.ToString(txtDescription.Text);
                AllReplySupports.ThisReplySupport.DateReplied = Convert.ToDateTime(txtDateReplied.Text);

                //UPDATE the record
                AllReplySupports.Update();
                //All done so redirect back to the main page
                ReplySupportManageForm RSM = new ReplySupportManageForm();
                this.Hide();
                RSM.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }
        }

        public void DisplayReplySupport()
        {
            //create an instance of the Reply Support Collection
            clsReplySupportCollection AllReplySupports = new clsReplySupportCollection();
            //find the record from the database to UPDATE
            AllReplySupports.ThisReplySupport.Find(mReplySupportId);
            //Display the data for this record
            txtReplySupportId.Text = AllReplySupports.ThisReplySupport.ReplySupportId.ToString();
            txtEmail.Text = AllReplySupports.ThisReplySupport.Email;
            txtDescription.Text = AllReplySupports.ThisReplySupport.Description;
            txtDateReplied.Text = AllReplySupports.ThisReplySupport.DateReplied.ToString("dd/MM/yyyy");
        }
    }
}
