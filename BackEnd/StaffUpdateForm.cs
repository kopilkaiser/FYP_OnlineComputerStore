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
    public partial class StaffUpdateForm : Form
    {
        private int mStaffId = 0;

        public int StaffID
        {
            set
            {
                mStaffId = value;
            }
        }
        public StaffUpdateForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsStaffCollection AllStaffs = new clsStaffCollection();
            string Error = AllStaffs.ThisStaff.Valid(txtName.Text, txtPhonenum.Text, txtSalary.Text, txtDateJoined.Text);
            string message = "Are you sure to Update the existing Staff?";
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

                    //All Done so Redirect to the previous Form
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
            StaffManageForm SM = new StaffManageForm();
            this.Hide();
            SM.ShowDialog();
            this.Close();
        }

        private void StaffUpdateForm_Load(object sender, EventArgs e)
        {
            DisplayStaff();
            txtDateJoined.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        public void DisplayStaff()
        {
            //create an instance of the Inventory Collection
            clsStaffCollection AllStaffs = new clsStaffCollection();
            //find the record from the database to UPDATE
            AllStaffs.ThisStaff.Find(mStaffId);
            //Display the data for this record
            txtName.Text = AllStaffs.ThisStaff.Name.ToString();
            txtPhonenum.Text = AllStaffs.ThisStaff.Name;
            txtSalary.Text = AllStaffs.ThisStaff.Salary.ToString();
            txtDateJoined.Text = AllStaffs.ThisStaff.DateJoined.ToString();
            chkActive.Checked = AllStaffs.ThisStaff.Active;
        }

        public void Update()
        {
            //create an instance of the Inventory Collection
            clsStaffCollection AllStaffs = new clsStaffCollection();
            //validate the data on the Windows Form
            string Error = AllStaffs.ThisStaff.Valid(txtName.Text, txtPhonenum.Text, txtSalary.Text, txtDateJoined.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllStaffs.ThisStaff.Find(mStaffId);
                //get the data entered by the user

                AllStaffs.ThisStaff.Name = txtName.Text;
                AllStaffs.ThisStaff.Phonenum = Convert.ToString(txtPhonenum.Text);
                AllStaffs.ThisStaff.Salary = Convert.ToDecimal(txtSalary.Text);
                AllStaffs.ThisStaff.DateJoined = Convert.ToDateTime(txtDateJoined.Text);
                AllStaffs.ThisStaff.Active = chkActive.Checked;
                AllStaffs.ThisStaff.AccountNo = Convert.ToInt32(txtAccountNo.Text);

                //UPDATE the record
                AllStaffs.Update();
                //All Done so Redirect to the previous Form
                StaffManageForm SM = new StaffManageForm();
                this.Hide();
                SM.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }

        }
    }
}
