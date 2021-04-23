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
    public partial class PaymentAddForm : Form
    {
        int PaymentId;
        public PaymentAddForm()
        {
            InitializeComponent();
        }

        void Add()
        {
            //create an instance of the Inventory Collenction
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //validate the data on the web form
            string Error = AllPayments.ThisPayment.Valid(txtPayeeName.Text, Convert.ToString(comboBoxMethod.SelectedItem), txtAmount.Text, txtCardNumber.Text, txtDatePurchased.Text, txtEmail.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //get the data entered by the user
                AllPayments.ThisPayment.PayeeName = txtPayeeName.Text;
                AllPayments.ThisPayment.Amount = Convert.ToDecimal(txtAmount.Text);
                AllPayments.ThisPayment.Method = Convert.ToString(comboBoxMethod.Text);
                AllPayments.ThisPayment.DatePurchased = Convert.ToDateTime(txtDatePurchased.Text);
                AllPayments.ThisPayment.Email = txtEmail.Text;
                AllPayments.ThisPayment.CardNumber = Convert.ToString(txtCardNumber.Text);


                //add the record
                AllPayments.Add();
                //all done so redirect back to the main page
                PaymentManageForm PM = new PaymentManageForm();
                this.Hide();
                PM.ShowDialog();
                this.Close();
            }
            else
            {
                //report an error
                lblError.Text = "Following Errors : " + Error;
            }
        }


        private void PaymentAddForm_Load(object sender, EventArgs e)
        {
            PaymentId = Convert.ToInt32(PaymentId);

            txtDatePurchased.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtPayeeName.Text = "";
            txtCardNumber.Text = "";
            txtAmount.Text = "";
            txtEmail.Text = "";
            comboBoxMethod.Text = "";
            comboBoxMethod.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            string Error = AllPayments.ThisPayment.Valid(txtPayeeName.Text, Convert.ToString(comboBoxMethod.SelectedItem), txtAmount.Text, txtCardNumber.Text, txtDatePurchased.Text, txtEmail.Text);
            string message = "Are you sure to Add the new Payment to the Database?";
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
                    PaymentManageForm PM = new PaymentManageForm();
                    this.Hide();
                    PM.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                //report an error
                lblError.Text = "Following Errors : " + Error;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PaymentManageForm PM = new PaymentManageForm();
            this.Hide();
            PM.ShowDialog();
            this.Close();
        }
    }
}
