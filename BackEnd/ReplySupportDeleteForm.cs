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
    public partial class ReplySupportDeleteForm : Form
    {
        private int mReplySupportId = 0;

        public int ReplySupportID
        {
            set
            {
                mReplySupportId = value;
            }
        }
        public ReplySupportDeleteForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            string message = "The Reply has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteReplySupport();
                //All done so redirect back to the main page
                ReplySupportManageForm RSM = new ReplySupportManageForm();
                this.Hide();
                RSM.ShowDialog();
                this.Close();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //All done so redirect back to the main page
            ReplySupportManageForm RSM = new ReplySupportManageForm();
            this.Hide();
            RSM.ShowDialog();
            this.Close();
        }

        void DeleteReplySupport()
        {
            //function to delete the selected record

            //create an instance of the Reply Support collection
            clsReplySupportCollection AllReplySupports = new clsReplySupportCollection();
            //find the record to delete
            AllReplySupports.ThisReplySupport.Find(mReplySupportId);
            //delete the record
            AllReplySupports.Delete();
        }
    }
}
