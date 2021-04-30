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
    public partial class SupportDeleteForm : Form
    {
        private int mSupportId = 0;

        public int SupportID
        {
            set
            {
                mSupportId = value;
            }
        }
        public SupportDeleteForm()
        {
            InitializeComponent();
        }
    }
}
