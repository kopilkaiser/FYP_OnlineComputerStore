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
    public partial class SellerShopUpdateForm : Form
    {
        private int mShopId = 0;

        public int ShopID
        {
            set
            {
                mShopId = value;
            }
        }

        public SellerShopUpdateForm()
        {
            InitializeComponent();
        }

        private void SellerShopUpdateForm_Load(object sender, EventArgs e)
        {
            //display the current data for the record
            DisplaySellerShop();
            txtDateOpened.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            comboBoxRating.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void DisplaySellerShop()
        {
            //create an instance of the Seller Shop Collection
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            //find the record from the database to UPDATE
            AllSellerShops.ThisSellerShop.Find(mShopId);
            //Display the data for this record
            txtShopId.Text = AllSellerShops.ThisSellerShop.ShopId.ToString();
            txtEmail.Text = AllSellerShops.ThisSellerShop.Email;
            txtShopName.Text = AllSellerShops.ThisSellerShop.ShopName.ToString();
            txtSellerName.Text = AllSellerShops.ThisSellerShop.SellerName.ToString();
            txtDateOpened.Text = AllSellerShops.ThisSellerShop.DateOpened.ToString();
            comboBoxRating.Text = AllSellerShops.ThisSellerShop.Rating.ToString();
        }

        public void Update()
        {
            //create an instance of the Seller Shop Collection
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            //validate the data on the Windows Form
            string Error = AllSellerShops.ThisSellerShop.Valid(txtShopName.Text, txtSellerName.Text, txtEmail.Text, Convert.ToString(comboBoxRating.SelectedItem));
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllSellerShops.ThisSellerShop.Find(mShopId);
                //get the data entered by the user

                AllSellerShops.ThisSellerShop.ShopName = txtShopName.Text;
                AllSellerShops.ThisSellerShop.SellerName = txtSellerName.Text;
                AllSellerShops.ThisSellerShop.Email = txtEmail.Text;
                AllSellerShops.ThisSellerShop.Rating = Convert.ToInt32(comboBoxRating.SelectedItem);
                AllSellerShops.ThisSellerShop.DateOpened = Convert.ToDateTime(txtDateOpened.Text);


                //UPDATE the record
                AllSellerShops.Update();
                //all done so redirect back to the main page
                SellerShopManageForm SSM = new SellerShopManageForm();
                this.Hide();
                SSM.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();
            string Error = AllSellerShops.ThisSellerShop.Valid(txtShopName.Text, txtSellerName.Text, txtEmail.Text, Convert.ToString(comboBoxRating.SelectedItem));
            string message = "Are you sure to Update the existing Seller Shop Details?";
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
    }
}
