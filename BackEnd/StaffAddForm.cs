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
    public partial class StaffAddForm : Form
    {
        int StaffId;
        public StaffAddForm()
        {
            InitializeComponent();
        }

        void Add()
        {
            //create an instance of the Inventory Collenction
            clsStaffCollection AllStaffs = new clsStaffCollection();
            //validate the data on the web form
            string Error = AllStaffs.ThisStaff.Valid(txtName.Text, txtPhonenum.Text, txtSalary.Text, txtDateJoined.Text, txtAccountNo.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllStaffs.ThisStaff.Name = txtName.Text;
                AllStaffs.ThisStaff.Phonenum = Convert.ToString(txtPhonenum.Text);
                AllStaffs.ThisStaff.Salary = Convert.ToDecimal(txtSalary.Text);
                AllStaffs.ThisStaff.DateJoined = Convert.ToDateTime(txtDateJoined.Text);
                AllStaffs.ThisStaff.Active = chkActive.Checked;
                AllStaffs.ThisStaff.AccountNo = Convert.ToInt32(txtAccountNo.Text);
      
                //add the record
                AllStaffs.Add();
                //all done so redirect back to the main page
                StaffManageForm SM = new StaffManageForm();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsStaffCollection AllStaffs = new clsStaffCollection();
            string Error = AllStaffs.ThisStaff.Valid(txtName.Text, txtPhonenum.Text, txtSalary.Text, txtDateJoined.Text, txtAccountNo.Text);
            string message = "Are you sure to Add the new Staff to the Database?";
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
                    StaffManageForm SM = new StaffManageForm();
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
            //all done so redirect back to the main page
            StaffManageForm SM = new StaffManageForm();
            this.Hide();
            SM.ShowDialog();
            this.Close();
        }

        private void StaffAddForm_Load(object sender, EventArgs e)
        {
            StaffId = Convert.ToInt32(StaffId);


            //Display the details of the Inventory
            txtDateJoined.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtName.Text = "";
            txtPhonenum.Text = "";
            txtSalary.Text = "";
            txtAccountNo.Text = "";
            chkActive.Checked = true;
        }
    }
}
