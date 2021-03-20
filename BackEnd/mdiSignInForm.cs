using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackEnd
{
    public partial class mdiSignInForm : Form
    {
        private clsSecurity mSec;

        public clsSecurity Sec
        {
            get
            {
                return mSec;
            }
        }
        public mdiSignInForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //try to sign in and record any errors
            string Error = mSec.SignIn(txtEMail.Text, txtPassword.Text);
            //if there were no errors
            if (Error == "")
            {
                //close this form
                this.Close();
            }
            else
            {
                //otherwise show any errors
                lblError.Text = Error;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close the form    
            this.Close();
        }

        private void mdiSignInForm_Load(object sender, EventArgs e)
        {
            mSec = new clsSecurity();
        }

     
    }
}
