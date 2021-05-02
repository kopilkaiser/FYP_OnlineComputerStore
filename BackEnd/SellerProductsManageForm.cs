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
    public partial class SellerProductsManageForm : Form
    {
        public SellerProductsManageForm()
        {
            InitializeComponent();
        }

        private void SellerProductsManageForm_Load(object sender, EventArgs e)
        {
            //update the ListBox with the Inventory Database List
            lblError.Text = "Total " + DisplaySellerProducts("") + " records in the Database";
            //Clear all selections in the ListBox
            lstSellerProducts.ClearSelected();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplaySellerProducts(txtEmail.Text);
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayInventories function to the record count var
            RecordCount = DisplaySellerProducts("");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
            //clear the Category filter text box
            txtEmail.Text = "";

            lstSellerProducts.ClearSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsSellerShopLine ASellerShopLine = new clsSellerShopLine();
            ASellerShopLine.SellerShopLineId = -1;
            SellerProductsAddForm SPA = new SellerProductsAddForm();
            this.Hide();
            SPA.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var to store the primary Key value of the record to be Edited
            Int32 SellerShopLineId;
            //if a record has been selected from the list
            if (lstSellerProducts.SelectedIndex != -1)
            {
                //get the Primary Key value of the record to DELETE
                SellerShopLineId = Convert.ToInt32(lstSellerProducts.SelectedValue);
                //store the data in the session object

                //redirect to the selected Form
                SellerProductsUpdateForm SPU = new SellerProductsUpdateForm();
                //store the data in the session object
                SPU.SellerShopLineID = SellerShopLineId;
                this.Hide();
                SPU.ShowDialog();
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
            Int32 SellerShopLineId;
            //if a record has been selected from the list
            if (lstSellerProducts.SelectedIndex != -1)
            {
                //get the primary key value of the record to delete
                SellerShopLineId = Convert.ToInt32(lstSellerProducts.SelectedValue);

                //redirect to the delete page
                SellerProductsDeleteForm SPD = new SellerProductsDeleteForm();
                //store the data in the session object
                SPD.SellerShopLineID = SellerShopLineId;
                this.Hide();
                SPD.ShowDialog();
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

        Int32 DisplaySellerProducts(string EmailFilter)
        {
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            AllSellerShopLines.ReportByEmail(EmailFilter);
            //set the data source to the list of Inventories in the collection
            lstSellerProducts.DataSource = AllSellerShopLines.SellerShopLineList;
            //set the name of the primary Key
            lstSellerProducts.ValueMember = "SellerShopLineId";
            //set the data field to display
            lstSellerProducts.DisplayMember = "AllDetails";


            return AllSellerShopLines.Count;
        }
    }
}
