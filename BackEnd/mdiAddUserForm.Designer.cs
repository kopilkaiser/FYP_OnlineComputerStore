
namespace BackEnd
{
    partial class mdiAddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.lblPassword2 = new System.Windows.Forms.Label();
            this.lblPassword1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(474, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 38);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(317, 297);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(134, 38);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "&Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(317, 223);
            this.txtPassword2.Multiline = true;
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Size = new System.Drawing.Size(215, 32);
            this.txtPassword2.TabIndex = 2;
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(317, 178);
            this.txtPassword1.Multiline = true;
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.Size = new System.Drawing.Size(215, 32);
            this.txtPassword1.TabIndex = 1;
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(317, 122);
            this.txtEMail.Multiline = true;
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(215, 32);
            this.txtEMail.TabIndex = 0;
            // 
            // lblPassword2
            // 
            this.lblPassword2.AutoSize = true;
            this.lblPassword2.Location = new System.Drawing.Point(175, 226);
            this.lblPassword2.Name = "lblPassword2";
            this.lblPassword2.Size = new System.Drawing.Size(121, 17);
            this.lblPassword2.TabIndex = 4;
            this.lblPassword2.Text = "Confirm Password";
            // 
            // lblPassword1
            // 
            this.lblPassword1.AutoSize = true;
            this.lblPassword1.Location = new System.Drawing.Point(175, 178);
            this.lblPassword1.Name = "lblPassword1";
            this.lblPassword1.Size = new System.Drawing.Size(100, 17);
            this.lblPassword1.TabIndex = 5;
            this.lblPassword1.Text = "New Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Email Address";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(43, 394);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 12;
            // 
            // mdiAddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.txtPassword1);
            this.Controls.Add(this.txtEMail);
            this.Controls.Add(this.lblPassword2);
            this.Controls.Add(this.lblPassword1);
            this.Controls.Add(this.label1);
            this.Name = "mdiAddUserForm";
            this.Text = "Add User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.Label lblPassword2;
        private System.Windows.Forms.Label lblPassword1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
    }
}