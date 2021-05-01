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
    public partial class OrderUpdateForm : Form
    {
        private int mOrderId = 0;

        public int OrderID
        {
            set
            {
                mOrderId = value;
            }
        }
        public OrderUpdateForm()
        {
            InitializeComponent();
        }

        private void OrderUpdateForm_Load(object sender, EventArgs e)
        {
            //display the current data for the record
            DisplayOrder();
            txtDateOrdered.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            string Error = AllOrders.ThisOrder.Valid(txtEmail.Text, txtTotalPrice.Text, txtDateOrdered.Text, txtShippingAddress.Text, txtPhonenum.Text);
            string message = "Are you sure to Update the existing Order?";
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

                    //All done so redirect back to the main page
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

        public void DisplayOrder()
        {
            //create an instance of the Inventory Collection
            clsOrderCollection AllOrders = new clsOrderCollection();
            //find the record from the database to UPDATE
            AllOrders.ThisOrder.Find(mOrderId);
            //Display the data for this record
            txtOrderId.Text = AllOrders.ThisOrder.OrderId.ToString();
            txtEmail.Text = AllOrders.ThisOrder.Email;
            txtTotalPrice.Text = AllOrders.ThisOrder.TotalPrice.ToString();
            txtPhonenum.Text = AllOrders.ThisOrder.Phonenum.ToString();
            txtDateOrdered.Text = AllOrders.ThisOrder.DateOrdered.ToString();
            txtShippingAddress.Text = AllOrders.ThisOrder.ToString();
        }

        public void Update()
        {
            //create an instance of the Inventory Collection
            clsOrderCollection AllOrders = new clsOrderCollection();
            //validate the data on the Windows Form
            string Error = AllOrders.ThisOrder.Valid(txtEmail.Text, txtTotalPrice.Text, txtDateOrdered.Text, txtShippingAddress.Text, txtPhonenum.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllOrders.ThisOrder.Find(mOrderId);
                //get the data entered by the user

                AllOrders.ThisOrder.Email = txtEmail.Text;
                AllOrders.ThisOrder.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
                AllOrders.ThisOrder.DateOrdered = Convert.ToDateTime(txtDateOrdered.Text);
                AllOrders.ThisOrder.ShippingAddress = Convert.ToString(txtShippingAddress.Text);
                AllOrders.ThisOrder.Phonenum = txtPhonenum.Text;


                //UPDATE the record
                AllOrders.Update();
                //All done so redirect back to the main page
                OrderManageForm OM = new OrderManageForm();
                this.Hide();
                OM.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }

        }
    }
}
