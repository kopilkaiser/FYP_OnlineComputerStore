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
    public partial class StaffManageForm : Form
    {
        public StaffManageForm()
        {
            InitializeComponent();
        }

        private void StaffManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Customer Database List
            lblError.Text = "Total " + DisplayStaffs("") + " records in the Database";
            //Clear all selections in the ListBox
            lstStaffs.ClearSelected();
        }

        Int32 DisplayStaffs(string NameFilter)
        {
            clsStaffCollection AllStaffs = new clsStaffCollection();
            AllStaffs.ReportByName(NameFilter);
            //set the data source to the list of Customers in the collection
            lstStaffs.DataSource = AllStaffs.StaffList;
            //set the name of the Primary Key
            lstStaffs.ValueMember = "StaffId";
            //set the data field to display
            lstStaffs.DisplayMember = "AllDetails";

            return AllStaffs.Count;
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            string message = "Are you sure to go back to the Main Menu?";
            string caption = "User Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            //Displays the MessageBox
            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                mdiMainMenuForm mdiMF = new mdiMainMenuForm();

                this.Hide();
                mdiMF.ShowDialog();
                this.Close();
            }
        }
    }
}
