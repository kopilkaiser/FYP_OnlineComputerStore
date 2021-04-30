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
    public partial class StaffDeleteForm : Form
    {
        private int mStaffId = 0;

        public int StaffID
        {
            set
            {
                mStaffId = value;
            }
        }
        public StaffDeleteForm()
        {
            InitializeComponent();
        }

        void DeleteStaff()
        {
            //function to delete the selected record

            //create an instance of the Inventory List
            clsStaffCollection AllStaffs = new clsStaffCollection();
            //find the record to delete
            AllStaffs.ThisStaff.Find(mStaffId);
            //delete the record
            AllStaffs.Delete();
        }


        private void btnYes_Click(object sender, EventArgs e)
        {
            string message = "The Staff has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteStaff();
                //redirect to the main form
                StaffManageForm SM = new StaffManageForm();
                this.Hide();
                SM.ShowDialog();
                this.Close();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            StaffManageForm SM = new StaffManageForm();
            this.Hide();
            SM.ShowDialog();
            this.Close();
        }

        private void StaffDeleteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
