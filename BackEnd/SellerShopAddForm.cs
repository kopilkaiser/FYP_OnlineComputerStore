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
    public partial class SellerShopAddForm : Form
    {
        int ShopId;
        public SellerShopAddForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            string Error = AllSellerShops.ThisSellerShop.Valid(txtShopName.Text, txtSellerName.Text, txtEmail.Text, Convert.ToString(comboBoxRating.SelectedItem));
            string message = "Are you sure to Add the new Seller Shop to the Database?";
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

                    //all done so redirect back to the main page
                    SellerShopManageForm SSM = new SellerShopManageForm();
                    this.Hide();
                    SSM.ShowDialog();
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
            SellerShopManageForm SSM = new SellerShopManageForm();
            this.Hide();
            SSM.ShowDialog();
            this.Close();
        }

        void Add()
        {
            //create an instance of the Inventory Collenction
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            //validate the data on the web form
            string Error = AllSellerShops.ThisSellerShop.Valid(txtShopName.Text, txtSellerName.Text, txtEmail.Text, Convert.ToString(comboBoxRating.SelectedItem));
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllSellerShops.ThisSellerShop.ShopName = txtShopName.Text;
                AllSellerShops.ThisSellerShop.SellerName = txtSellerName.Text;
                AllSellerShops.ThisSellerShop.Email = txtEmail.Text;
                AllSellerShops.ThisSellerShop.Rating = Convert.ToInt32(comboBoxRating.SelectedItem);
                AllSellerShops.ThisSellerShop.DateOpened = Convert.ToDateTime(txtDateOpened.Text);


                //add the record
                AllSellerShops.Add();
                //all done so redirect back to the main page
                SellerShopManageForm SSM = new SellerShopManageForm();
                this.Hide();
                SSM.ShowDialog();
                this.Close();
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered : " + Error;
            }
        }

        private void SellerShopAddForm_Load(object sender, EventArgs e)
        {
            txtDateOpened.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtShopName.Text = "";
            txtSellerName.Text = "";
            txtEmail.Text = "";
            comboBoxRating.Text = "";
            comboBoxRating.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
