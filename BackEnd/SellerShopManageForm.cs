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
    public partial class SellerShopManageForm : Form
    {
        public SellerShopManageForm()
        {
            InitializeComponent();
        }

        private void SellerShopManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Inventory Database List
            lblError.Text = "Total " + DisplaySellerShops("") + " records in the Database";
            //Clear all selections in the ListBox
            lstSellerShops.ClearSelected();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplaySellerShops(txtEmail.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplaySellerShops("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtEmail.Text = "";

            lstSellerShops.ClearSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsSellerShop ASellerShop = new clsSellerShop();
            ASellerShop.ShopId = -1;
            SellerShopAddForm SSA = new SellerShopAddForm();
            this.Hide();
            SSA.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 ShopId;
            //if a record has been selected from the list
            if (lstSellerShops.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                ShopId = Convert.ToInt32(lstSellerShops.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                SellerShopUpdateForm UpdateSellerShop = new SellerShopUpdateForm();
                //store the data in the session object
                UpdateSellerShop.ShopID = ShopId;
                this.Hide();
                UpdateSellerShop.ShowDialog();
                this.Close();
            }
            //if no record has been selected
            else
            {
                //Display an error
                lblError.Text = "Please select a record to Update from the List";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //var to store the primary key value of the record to be edited
            Int32 ShopId;
            //if a record has been selected from the list
            if (lstSellerShops.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                ShopId = Convert.ToInt32(lstSellerShops.SelectedValue);

                //redirect to the delete page
                SellerShopDeleteForm SSD = new SellerShopDeleteForm();
                //store the data in the session object
                SSD.ShopID = ShopId;
                this.Hide();
                SSD.ShowDialog();
            }
            else //if no record has been selected
            {
                //display an error
                lblError.Text = "Please select a record to edit from the list";
            }
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

        Int32 DisplaySellerShops(string EmailFilter)
        {
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            AllSellerShops.ReportByEmail(EmailFilter);
            //set the data source to the list of Inventories in the collection
            lstSellerShops.DataSource = AllSellerShops.SellerShopList;
            //set the name of the primary Key
            lstSellerShops.ValueMember = "ShopId";
            //set the data field to display
            lstSellerShops.DisplayMember = "AllDetails";


            return AllSellerShops.Count;
        }
    }
}
