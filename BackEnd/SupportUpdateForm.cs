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
    public partial class SupportUpdateForm : Form
    {
        private int mSupportId = 0;

        public int SupportID
        {
            set
            {
                mSupportId = value;
            }
        }
        public SupportUpdateForm()
        {
            InitializeComponent();
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            clsSupportCollection AllSupports = new clsSupportCollection();
            string Error = AllSupports.ThisSupport.Valid(txtEmail.Text, txtName.Text, txtDescription.Text, txtPhonenum.Text, txtDateSubmitted.Text);
            string message = "Are you sure to Update the existing Support?";
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
                    SupportManageForm SM = new SupportManageForm();
                    this.Hide();
                    SM.ShowDialog();
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
            SupportManageForm SM = new SupportManageForm();
            this.Hide();
            SM.ShowDialog();
            this.Close();
        }

        public void DisplaySupport()
        {
            //create an instance of the Inventory Collection
            clsSupportCollection AllSupports = new clsSupportCollection();
            //find the record from the database to UPDATE
            AllSupports.ThisSupport.Find(mSupportId);
            //Display the data for this record
            txtSupportId.Text = AllSupports.ThisSupport.SupportId.ToString();
            txtEmail.Text = AllSupports.ThisSupport.Email;
            txtName.Text = AllSupports.ThisSupport.Name;
            txtPhonenum.Text = AllSupports.ThisSupport.Phonenum;
            txtDescription.Text = AllSupports.ThisSupport.Description;
            txtDateSubmitted.Text = AllSupports.ThisSupport.DateSubmitted.ToString("dd/MM/yyyy");
        }

        public void Update()
        {
            //create an instance of the Inventory Collection
            clsSupportCollection AllSupports = new clsSupportCollection();
            //validate the data on the Windows Form
            string Error = AllSupports.ThisSupport.Valid(txtEmail.Text, txtName.Text, txtDescription.Text, txtPhonenum.Text, txtDateSubmitted.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllSupports.ThisSupport.Find(mSupportId);
                //get the data entered by the user
                AllSupports.ThisSupport.Email = txtEmail.Text;
                AllSupports.ThisSupport.Name = Convert.ToString(txtName.Text);
                AllSupports.ThisSupport.Phonenum = Convert.ToString(txtPhonenum.Text);
                AllSupports.ThisSupport.Description = Convert.ToString(txtDescription.Text);
                AllSupports.ThisSupport.DateSubmitted = Convert.ToDateTime(txtDateSubmitted.Text);

                //UPDATE the record
                AllSupports.Update();
                //All done so redirect back to the main page
                SupportManageForm SM = new SupportManageForm();
                this.Hide();
                SM.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }
        }

        private void SupportUpdateForm_Load(object sender, EventArgs e)
        {
                //display the current data for the record
                DisplaySupport();           
        }
    }
}
