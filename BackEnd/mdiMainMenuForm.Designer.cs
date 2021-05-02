
namespace BackEnd
{
    partial class mdiMainMenuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSellerProducts = new System.Windows.Forms.Button();
            this.btnSellerShop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSupportManagement = new System.Windows.Forms.Button();
            this.btnManageOrder = new System.Windows.Forms.Button();
            this.btnReviewManage = new System.Windows.Forms.Button();
            this.btnManagePayment = new System.Windows.Forms.Button();
            this.btnManageInventory = new System.Windows.Forms.Button();
            this.btnManageStaff = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(327, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Management Hub";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Maroon;
            this.lblTime.Location = new System.Drawing.Point(48, 14);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 17);
            this.lblTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(805, 571);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "© Developed by Kopil Kaiser";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Maroon;
            this.lblDate.Location = new System.Drawing.Point(47, 34);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 17);
            this.lblDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(14, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Location = new System.Drawing.Point(851, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 67);
            this.panel1.TabIndex = 8;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.IndianRed;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(99, 551);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 34);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(16, 551);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(77, 34);
            this.btnSignOut.TabIndex = 10;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "GalaxyTech®";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Company:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label7.Location = new System.Drawing.Point(20, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 26);
            this.label7.TabIndex = 0;
            this.label7.Text = "Seller Management";
            // 
            // btnSellerProducts
            // 
            this.btnSellerProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellerProducts.Location = new System.Drawing.Point(38, 121);
            this.btnSellerProducts.Margin = new System.Windows.Forms.Padding(2);
            this.btnSellerProducts.Name = "btnSellerProducts";
            this.btnSellerProducts.Size = new System.Drawing.Size(165, 49);
            this.btnSellerProducts.TabIndex = 2;
            this.btnSellerProducts.Text = "Manage Seller Products";
            this.btnSellerProducts.UseVisualStyleBackColor = true;
            this.btnSellerProducts.Click += new System.EventHandler(this.btnSellerProducts_Click);
            // 
            // btnSellerShop
            // 
            this.btnSellerShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellerShop.Location = new System.Drawing.Point(38, 51);
            this.btnSellerShop.Margin = new System.Windows.Forms.Padding(2);
            this.btnSellerShop.Name = "btnSellerShop";
            this.btnSellerShop.Size = new System.Drawing.Size(165, 49);
            this.btnSellerShop.TabIndex = 2;
            this.btnSellerShop.Text = "Manage Seller Shop";
            this.btnSellerShop.UseVisualStyleBackColor = true;
            this.btnSellerShop.Click += new System.EventHandler(this.btnSellerShop_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Cornsilk;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnSellerShop);
            this.panel2.Controls.Add(this.btnSellerProducts);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(676, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 218);
            this.panel2.TabIndex = 13;
            // 
            // btnSupportManagement
            // 
            this.btnSupportManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupportManagement.Location = new System.Drawing.Point(355, 121);
            this.btnSupportManagement.Margin = new System.Windows.Forms.Padding(2);
            this.btnSupportManagement.Name = "btnSupportManagement";
            this.btnSupportManagement.Size = new System.Drawing.Size(122, 67);
            this.btnSupportManagement.TabIndex = 2;
            this.btnSupportManagement.Text = "Support Management";
            this.btnSupportManagement.UseVisualStyleBackColor = true;
            this.btnSupportManagement.Click += new System.EventHandler(this.btnSupportManagement_Click);
            // 
            // btnManageOrder
            // 
            this.btnManageOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageOrder.Location = new System.Drawing.Point(355, 24);
            this.btnManageOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageOrder.Name = "btnManageOrder";
            this.btnManageOrder.Size = new System.Drawing.Size(122, 67);
            this.btnManageOrder.TabIndex = 2;
            this.btnManageOrder.Text = "Order Management";
            this.btnManageOrder.UseVisualStyleBackColor = true;
            this.btnManageOrder.Click += new System.EventHandler(this.btnManageOrder_Click);
            // 
            // btnReviewManage
            // 
            this.btnReviewManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewManage.Location = new System.Drawing.Point(65, 121);
            this.btnReviewManage.Margin = new System.Windows.Forms.Padding(2);
            this.btnReviewManage.Name = "btnReviewManage";
            this.btnReviewManage.Size = new System.Drawing.Size(122, 67);
            this.btnReviewManage.TabIndex = 1;
            this.btnReviewManage.Text = "Review Management";
            this.btnReviewManage.UseVisualStyleBackColor = true;
            this.btnReviewManage.Click += new System.EventHandler(this.btnReviewManage_Click_1);
            // 
            // btnManagePayment
            // 
            this.btnManagePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagePayment.Location = new System.Drawing.Point(210, 121);
            this.btnManagePayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnManagePayment.Name = "btnManagePayment";
            this.btnManagePayment.Size = new System.Drawing.Size(122, 67);
            this.btnManagePayment.TabIndex = 1;
            this.btnManagePayment.Text = "Payment Management";
            this.btnManagePayment.UseVisualStyleBackColor = true;
            this.btnManagePayment.Click += new System.EventHandler(this.btnManagePayment_Click);
            // 
            // btnManageInventory
            // 
            this.btnManageInventory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnManageInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageInventory.Location = new System.Drawing.Point(65, 24);
            this.btnManageInventory.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageInventory.Name = "btnManageInventory";
            this.btnManageInventory.Size = new System.Drawing.Size(122, 67);
            this.btnManageInventory.TabIndex = 1;
            this.btnManageInventory.Text = "Inventory Management";
            this.btnManageInventory.UseVisualStyleBackColor = true;
            this.btnManageInventory.Click += new System.EventHandler(this.btnManageInventory_Click);
            // 
            // btnManageStaff
            // 
            this.btnManageStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageStaff.Location = new System.Drawing.Point(210, 24);
            this.btnManageStaff.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageStaff.Name = "btnManageStaff";
            this.btnManageStaff.Size = new System.Drawing.Size(122, 67);
            this.btnManageStaff.TabIndex = 1;
            this.btnManageStaff.Text = "Staff Management";
            this.btnManageStaff.UseVisualStyleBackColor = true;
            this.btnManageStaff.Click += new System.EventHandler(this.btnManageStaff_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FloralWhite;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnManageStaff);
            this.panel3.Controls.Add(this.btnManageInventory);
            this.panel3.Controls.Add(this.btnManagePayment);
            this.panel3.Controls.Add(this.btnReviewManage);
            this.panel3.Controls.Add(this.btnManageOrder);
            this.panel3.Controls.Add(this.btnSupportManagement);
            this.panel3.Location = new System.Drawing.Point(87, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(544, 218);
            this.panel3.TabIndex = 14;
            // 
            // mdiMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1005, 597);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mdiMainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.mdiMainMenuForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSellerProducts;
        private System.Windows.Forms.Button btnSellerShop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSupportManagement;
        private System.Windows.Forms.Button btnManageOrder;
        private System.Windows.Forms.Button btnReviewManage;
        private System.Windows.Forms.Button btnManagePayment;
        private System.Windows.Forms.Button btnManageInventory;
        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Panel panel3;
    }
}