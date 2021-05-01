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
    public partial class SupportAddForm : Form
    {
        int SupportId;
        public SupportAddForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsSupportCollection AllSupports = new clsSupportCollection();
            string Error = AllSupports.ThisSupport.Valid(txtEmail.Text, txtName.Text, txtDescription.Text, txtPhonenum.Text, txtDateSubmitted.Text);
            string message = "Are you sure to Add the new Support to the Database?";
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

                    //all done so redirect back to the main page
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

        private void SupportAddForm_Load(object sender, EventArgs e)
        {
            SupportId = Convert.ToInt32(SupportId);


            //Display the details of the Inventory
            txtDateSubmitted.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhonenum.Text = "";
            txtDescription.Text = "";
        }

        void Add()
        {
            //create an instance of the Order Collenction
            clsSupportCollection AllSupports = new clsSupportCollection();
            //validate the data on the web form
            string Error = AllSupports.ThisSupport.Valid(txtEmail.Text, txtName.Text, txtDescription.Text, txtPhonenum.Text, txtDateSubmitted.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllSupports.ThisSupport.Email = txtEmail.Text;
                AllSupports.ThisSupport.Name = Convert.ToString(txtName.Text);
                AllSupports.ThisSupport.Phonenum = Convert.ToString(txtPhonenum.Text);
                AllSupports.ThisSupport.Description = Convert.ToString(txtDescription.Text);
                AllSupports.ThisSupport.DateSubmitted = Convert.ToDateTime(txtDateSubmitted.Text);

                //add the record
                AllSupports.Add();
                //all done so redirect back to the main page
                SupportManageForm SM = new SupportManageForm();
                this.Hide();
                SM.ShowDialog();
                this.Close();
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

    }
}
