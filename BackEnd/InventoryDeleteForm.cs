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
    public partial class InventoryDeleteForm : Form
    {
        private int mInventoryId = 0;
        public int InventoryID
        {
            set
            {
                mInventoryId = value;
            }
        }
        public InventoryDeleteForm()
        {
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //redirect to the main form
            InventoryManageForm InvManageForm = new InventoryManageForm();
            this.Hide();
            InvManageForm.ShowDialog();
            this.Close();
        }

        void DeleteInventory()
        {
            //function to delete the selected record

            //create an instance of the Inventory List
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //find the record to delete
            AllInventories.ThisInventory.Find(mInventoryId);
            //delete the record
            AllInventories.Delete();
        }

        private void btnYes_Click_1(object sender, EventArgs e)
        {
            string message = "The Inventory has been deleted successfully.";
            string caption = "Deletion Confirmation";
            DialogResult result;
            MessageBoxButtons button = MessageBoxButtons.OK;

            result = MessageBox.Show(message, caption, button);

            if (result == DialogResult.OK)
            {
                //delete the record
                DeleteInventory();
                //redirect to the main form
                InventoryManageForm InvManageForm = new InventoryManageForm();
                this.Hide();
                InvManageForm.ShowDialog();
                this.Close();
            }

        }

        private void InventoryDeleteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
