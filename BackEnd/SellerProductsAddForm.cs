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
    public partial class SellerProductsAddForm : Form
    {
        int SellerShopLineId;

        public SellerProductsAddForm()
        {
            InitializeComponent();
        }

        private void SellerProductsAddForm_Load(object sender, EventArgs e)
        {
            SellerShopLineId = Convert.ToInt32(SellerShopLineId);


            //Display the details of the Inventory
            txtEmail.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtDescription.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            String Error = AllSellerShopLines.ThisSellerShopLine.Valid(txtEmail.Text, txtProductName.Text, txtPrice.Text, txtQuantity.Text, txtDescription.Text);
            string message = "Are you sure to Add the new Seller Product to the Database?";
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

                    //All Done so Redirect to the previous Form
                    SellerProductsManageForm SPM = new SellerProductsManageForm();
                    this.Hide();
                    SPM.ShowDialog();
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
            //All Done so Redirect to the previous Form
            SellerProductsManageForm SPM = new SellerProductsManageForm();
            this.Hide();
            SPM.ShowDialog();
            this.Close();
        }

        void Add()
        {
            //create an instance of the SellerShopLine Collection
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            //validate the data on the Windows Form
            String Error = AllSellerShopLines.ThisSellerShopLine.Valid(txtEmail.Text, txtProductName.Text, txtPrice.Text, txtQuantity.Text, txtDescription.Text);
            //if the data is OK then add it to the object
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllSellerShopLines.ThisSellerShopLine.Email = txtEmail.Text;
                AllSellerShopLines.ThisSellerShopLine.Price = Convert.ToDecimal(txtPrice.Text);
                AllSellerShopLines.ThisSellerShopLine.Quantity = Convert.ToInt32(txtQuantity.Text);
                AllSellerShopLines.ThisSellerShopLine.ProductName = Convert.ToString(txtProductName.Text);
                AllSellerShopLines.ThisSellerShopLine.Description = Convert.ToString(txtDescription.Text);


                //add the record
                AllSellerShopLines.Add();
                //All Done so Redirect to the previous Form
                SellerProductsManageForm SPM = new SellerProductsManageForm();
                this.Hide();
                SPM.ShowDialog();
                this.Close();
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }
    }
}
