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
    public partial class InventoryUpdateForm : Form
    {
        private int mInventoryId = 0;
        
        public int InventoryID
        {
            set
            {
                mInventoryId = value;
            }
        }

        public InventoryUpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateInventoryForm_Load(object sender, EventArgs e)
        {
            //display the current data for the record
            DisplayInventory();
            txtDateAdded.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            string Error = AllInventories.ThisInventory.Valid(txtName.Text, txtPrice.Text, txtQuantity.Text, Convert.ToString(comboBoxCategory.SelectedItem), txtDateAdded.Text);
            string message = "Are you sure to Update the existing Inventory in the Database?";
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

                    //create an instance of ManageInventoryForm
                    InventoryManageForm mdiMF = new InventoryManageForm();
                    //hide the current form
                    this.Hide();
                    //show the Manaage Inventory Form
                    mdiMF.ShowDialog();
                    //close the current form
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
            InventoryManageForm IF = new InventoryManageForm();
            this.Hide();
            IF.ShowDialog();
            this.Close();
        }

        public void DisplayInventory()
        {
            //create an instance of the Inventory Collection
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //find the record from the database to UPDATE
            AllInventories.ThisInventory.Find(mInventoryId);
            //Display the data for this record
            txtInventoryId.Text = AllInventories.ThisInventory.InventoryId.ToString();
            txtName.Text = AllInventories.ThisInventory.Name;
            txtPrice.Text = AllInventories.ThisInventory.Price.ToString();
            txtQuantity.Text = AllInventories.ThisInventory.Quantity.ToString();
            txtDateAdded.Text = AllInventories.ThisInventory.DateAdded.ToString();
            chkActive.Checked = AllInventories.ThisInventory.Active;
            comboBoxCategory.SelectedItem = AllInventories.ThisInventory.Category;

        }

        public void Update()
        {
            //create an instance of the Inventory Collection
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //validate the data on the Windows Form
            String Error = AllInventories.ThisInventory.Valid(txtName.Text, txtPrice.Text, txtQuantity.Text, Convert.ToString(comboBoxCategory.SelectedItem), txtDateAdded.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllInventories.ThisInventory.Find(mInventoryId);
                //get the data entered by the user

                AllInventories.ThisInventory.Name = txtName.Text;
                AllInventories.ThisInventory.Price = Convert.ToDecimal(txtPrice.Text);
                AllInventories.ThisInventory.Quantity = Convert.ToInt32(txtQuantity.Text);
                AllInventories.ThisInventory.Category = Convert.ToString(comboBoxCategory.SelectedItem);
                AllInventories.ThisInventory.DateAdded = Convert.ToDateTime(Convert.ToString(txtDateAdded.Text));
                AllInventories.ThisInventory.Active = chkActive.Checked;
                //UPDATE the record
                AllInventories.Update();
                //All Done so Redirect to the previous Form
                InventoryManageForm IF = new InventoryManageForm();
                this.Hide();
                IF.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }
            
        }

    }
}
