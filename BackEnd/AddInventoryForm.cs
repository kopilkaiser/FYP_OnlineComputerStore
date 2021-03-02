using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Web.UI.WebControls;
using ClassLibrary;
using System.Data.SqlClient;
namespace BackEnd
{
    public partial class AddInventoryForm : Form
    {
        int InventoryId;

        clsInventory AnInventory = new clsInventory();
        public AddInventoryForm()
        {
            InitializeComponent();
        }

    

       

        void DisplayInventory()
        {
            //create an instance of the inventory collection
            clsInventoryCollection AllInventories = new clsInventoryCollection();
            //find the record to update
            AllInventories.ThisInventory.Find(InventoryId);
            //display the data for this record
            txtName.Text = AllInventories.ThisInventory.Name;
            txtPrice.Text = AllInventories.ThisInventory.Price.ToString();
            txtQuantity.Text = AllInventories.ThisInventory.Quantity.ToString();
            txtDateAdded.Text = AllInventories.ThisInventory.DateAdded.ToString();
            //txtCategory.Text = AllInventories.ThisInventory.Category;
            chkActive.Checked = AllInventories.ThisInventory.Active;
            comboBoxCategory.SelectedText = AllInventories.ThisInventory.Category;


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
                //add the record
                AllInventories.Add();
                //all done so redirect back to the main page
               // InventoryManageForm IM = new InventoryManageForm();
                this.Hide();
               // IM.Show();
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
            //add the new record
            Add();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //InventoryManageForm IM = new InventoryManageForm();

            this.Hide();
           ////////// IM.Show();
            this.Close();
        }

        private void AddInventoryForm_Load(object sender, EventArgs e)
        {
            //InventoryId = Convert.ToInt32(InventoryId);


            //DisplayInventory();
            txtDateAdded.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");           
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";

            chkActive.Checked = false;
        }
    }
}
