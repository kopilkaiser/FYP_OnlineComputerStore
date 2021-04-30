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


namespace NewBackEnd
{
    public partial class InventoryAddForm : Form
    {
        int InventoryId;

        public InventoryAddForm()
        {
            InitializeComponent();
        }

        void Add()
        {
            //create an instance of the Inventory Collenction
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //validate the data on the web form
            string Error = AllInventories.ThisInventory.Valid(txtName.Text, txtPrice.Text, txtQuantity.Text, Convert.ToString(comboBoxCategory.SelectedItem), txtDateAdded.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllInventories.ThisInventory.Name = txtName.Text;
                AllInventories.ThisInventory.Price = Convert.ToDecimal(txtPrice.Text);
                AllInventories.ThisInventory.Quantity = Convert.ToInt32(txtQuantity.Text);
                AllInventories.ThisInventory.DateAdded = Convert.ToDateTime(txtDateAdded.Text);
                AllInventories.ThisInventory.Active = chkActive.Checked;
                AllInventories.ThisInventory.Category = Convert.ToString(comboBoxCategory.SelectedItem);
                AllInventories.ThisInventory.Description = Convert.ToString(txtDescription.Text);
                AllInventories.ThisInventory.ImagePath = Convert.ToString(txtImagePath.Text);

                //add the record
                AllInventories.Add();
                //all done so redirect back to the main page
                InventoryManageForm IM = new InventoryManageForm();
                this.Hide();
                IM.ShowDialog();
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
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            string Error = AllInventories.ThisInventory.Valid(txtName.Text, txtPrice.Text, txtQuantity.Text, Convert.ToString(comboBoxCategory.SelectedItem), txtDateAdded.Text);
            string message = "Are you sure to Add the new Inventory to the Database?";
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
            InventoryManageForm IM = new InventoryManageForm();

            this.Hide();
            IM.ShowDialog();
            this.Close();
        }

        private void InventoryAddForm_Load(object sender, EventArgs e)
        {

            InventoryId = Convert.ToInt32(InventoryId);


            //Display the details of the Inventory
            txtDateAdded.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            comboBoxCategory.Text = "";
            chkActive.Checked = true;
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InventoryAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if the "Esc" Key is pressed press the button "Cancel"
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }

        }
    }
}
