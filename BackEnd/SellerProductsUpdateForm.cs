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
    public partial class SellerProductsUpdateForm : Form
    {
        private int mSellerShopLineId = 0;

        public int SellerShopLineID
        {
            set
            {
                mSellerShopLineId = value;
            }
        }
        public SellerProductsUpdateForm()
        {
            InitializeComponent();
        }

        private void SellerProductsUpdateForm_Load(object sender, EventArgs e)
        {
            //display the current data for the record
            DisplaySellerProduct();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            String Error = AllSellerShopLines.ThisSellerShopLine.Valid(txtEmail.Text, txtProductName.Text, txtPrice.Text, txtQuantity.Text, txtDescription.Text);
            string message = "Are you sure to Update the existing Seller Product?";
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

                    //create an instance of SellerProductsManageForm
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
            SellerProductsManageForm SPM = new SellerProductsManageForm();
            this.Hide();
            SPM.ShowDialog();
            this.Close();
        }


        public void DisplaySellerProduct()
        {
            //create an instance of the SellerShopLine Collection
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            //find the record from the database to UPDATE
            AllSellerShopLines.ThisSellerShopLine.Find(mSellerShopLineId);
            //Display the data for this record
            txtSellerShopLineId.Text = AllSellerShopLines.ThisSellerShopLine.SellerShopLineId.ToString();
            txtEmail.Text = AllSellerShopLines.ThisSellerShopLine.Email;
            txtPrice.Text = AllSellerShopLines.ThisSellerShopLine.Price.ToString();
            txtQuantity.Text = AllSellerShopLines.ThisSellerShopLine.Quantity.ToString();
            txtProductName.Text = AllSellerShopLines.ThisSellerShopLine.ProductName.ToString();
            txtDescription.Text = AllSellerShopLines.ThisSellerShopLine.Description;
        }

        public void Update()
        {
            //create an instance of the SellerShopLine Collection
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();
            //validate the data on the Windows Form
            String Error = AllSellerShopLines.ThisSellerShopLine.Valid(txtEmail.Text, txtProductName.Text, txtPrice.Text, txtQuantity.Text, txtDescription.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllSellerShopLines.ThisSellerShopLine.Find(mSellerShopLineId);
                //get the data entered by the user

                AllSellerShopLines.ThisSellerShopLine.Email = txtEmail.Text;
                AllSellerShopLines.ThisSellerShopLine.Price = Convert.ToDecimal(txtPrice.Text);
                AllSellerShopLines.ThisSellerShopLine.Quantity = Convert.ToInt32(txtQuantity.Text);
                AllSellerShopLines.ThisSellerShopLine.ProductName = Convert.ToString(txtProductName.Text);
                AllSellerShopLines.ThisSellerShopLine.Description = Convert.ToString(txtDescription.Text);



                //UPDATE the record
                AllSellerShopLines.Update();
                //All Done so Redirect to the previous Form
                SellerProductsManageForm SPM = new SellerProductsManageForm();
                this.Hide();
                SPM.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }

        }
    }
}
