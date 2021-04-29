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
    public partial class OrderAddForm : Form
    {
        int OrderId;
        public OrderAddForm()
        {
            InitializeComponent();
        }

        private void OrderAddForm_Load(object sender, EventArgs e)
        {
            OrderId = Convert.ToInt32(OrderId);


            //Display the details of the Inventory
            txtDateOrdered.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtEmail.Text = "";
            txtTotalPrice.Text = "";
            txtPhonenum.Text = "";
            txtShippingAddress.Text = "";
        }

        void Add()
        {
            //create an instance of the Order Collenction
            clsOrderCollection AllOrders = new clsOrderCollection();
            //validate the data on the web form
            string Error = AllOrders.ThisOrder.Valid(txtEmail.Text, txtTotalPrice.Text, txtDateOrdered.Text, txtShippingAddress.Text, txtPhonenum.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllOrders.ThisOrder.Email = txtEmail.Text;
                AllOrders.ThisOrder.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
                AllOrders.ThisOrder.DateOrdered = Convert.ToDateTime(txtDateOrdered.Text);
                AllOrders.ThisOrder.ShippingAddress = Convert.ToString(txtShippingAddress.Text);
                AllOrders.ThisOrder.Phonenum = txtPhonenum.Text;

                //add the record
                AllOrders.Add();
                //all done so redirect back to the main page
                OrderManageForm OM = new OrderManageForm();
                this.Hide();
                OM.ShowDialog();
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
            clsOrderCollection AllOrders = new clsOrderCollection();
            string Error = AllOrders.ThisOrder.Valid(txtEmail.Text, txtTotalPrice.Text, txtDateOrdered.Text, txtShippingAddress.Text, txtPhonenum.Text);
            string message = "Are you sure to Add the new Order to the Database?";
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
                    OrderManageForm OM = new OrderManageForm();
                    this.Hide();
                    OM.ShowDialog();
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
            OrderManageForm OM = new OrderManageForm();
            this.Hide();
            OM.ShowDialog();
            this.Close();
        }

        private void txtShippingAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDateOrdered_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhonenum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOrderId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
