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
    public partial class SupportDeleteForm : Form
    {
        private int mSupportId = 0;

        public int SupportID
        {
            set
            {
                mSupportId = value;
            }
        }
        public SupportDeleteForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string message = "The Support has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteSupport();
                //All done so redirect back to the main page
                SupportManageForm SM = new SupportManageForm();
                this.Hide();
                SM.ShowDialog();
                this.Close();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //All done so redirect back to the main page
            SupportManageForm SM = new SupportManageForm();
            this.Hide();
            SM.ShowDialog();
            this.Close();
        }

        void DeleteSupport()
        {
            //function to delete the selected record

            //create an instance of the Inventory List
            clsSupportCollection AllSupports = new clsSupportCollection();
            //find the record to delete
            AllSupports.ThisSupport.Find(mSupportId);
            //delete the record
            AllSupports.Delete();
        }
    }
}
