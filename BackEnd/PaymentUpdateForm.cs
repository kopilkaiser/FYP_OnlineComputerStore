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
    public partial class PaymentUpdateForm : Form
    {

        private int mPaymentId = 0;

        public int PaymentID
        {
            set
            {
                mPaymentId = value;
            }
        }

        public PaymentUpdateForm()
        {
            InitializeComponent();
        }

        private void PaymentUpdateForm_Load(object sender, EventArgs e)
        {
            //display the current data for the record
            DisplayPayment();
            txtDatePurchased.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            comboBoxMethod.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            string Error = AllPayments.ThisPayment.Valid(txtPayeeName.Text, Convert.ToString(comboBoxMethod.SelectedItem), txtAmount.Text, txtCardNumber.Text, txtDatePurchased.Text, txtEmail.Text);
            string message = "Are you sure to Update the existing Payment details?";
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

                    //All Done so Redirect to the previous Form
                    PaymentManageForm PM = new PaymentManageForm();
                    this.Hide();
                    PM.ShowDialog();
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
            PaymentManageForm PM = new PaymentManageForm();
            this.Hide();
            PM.ShowDialog();
            this.Close();
        }

        public void Update()
        {
            //create an instance of the Inventory Collection
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //validate the data on the Windows Form
            string Error = AllPayments.ThisPayment.Valid(txtPayeeName.Text, Convert.ToString(comboBoxMethod.SelectedItem), txtAmount.Text, txtCardNumber.Text, txtDatePurchased.Text, txtEmail.Text);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to UPDATE
                AllPayments.ThisPayment.Find(mPaymentId);

                //get the data entered by the user
                AllPayments.ThisPayment.PayeeName = txtPayeeName.Text;
                AllPayments.ThisPayment.Amount = Convert.ToDecimal(txtAmount.Text);
                AllPayments.ThisPayment.Method = Convert.ToString(comboBoxMethod.Text);
                AllPayments.ThisPayment.DatePurchased = Convert.ToDateTime(txtDatePurchased.Text);
                AllPayments.ThisPayment.Email = txtEmail.Text;
                AllPayments.ThisPayment.CardNumber = Convert.ToString(txtCardNumber.Text);



                //UPDATE the record
                AllPayments.Update();
                //All Done so Redirect to the previous Form
                PaymentManageForm PM = new PaymentManageForm();
                this.Hide();
                PM.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "There were problems with the data entered: " + Error;
            }
        }

        public void DisplayPayment()
        {
            //create an instance of the Inventory Collection
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //find the record from the database to UPDATE
            AllPayments.ThisPayment.Find(mPaymentId);
            //Display the data for this record
            txtPaymentId.Text = AllPayments.ThisPayment.PaymentId.ToString();
            txtPayeeName.Text = AllPayments.ThisPayment.PayeeName;
            txtAmount.Text = AllPayments.ThisPayment.Amount.ToString();
            txtCardNumber.Text = AllPayments.ThisPayment.CardNumber.ToString();
            txtDatePurchased.Text = AllPayments.ThisPayment.DatePurchased.ToString();
            txtEmail.Text = AllPayments.ThisPayment.Email;
            comboBoxMethod.SelectedItem = AllPayments.ThisPayment.Method;

        }
    }
}
