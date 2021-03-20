
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
            this.btnManageInventory = new System.Windows.Forms.Button();
            this.btnManagePayment = new System.Windows.Forms.Button();
            this.btnManageStaff = new System.Windows.Forms.Button();
            this.btnManageCustomer = new System.Windows.Forms.Button();
            this.btnManageOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Menu";
            // 
            // btnManageInventory
            // 
            this.btnManageInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageInventory.Location = new System.Drawing.Point(83, 116);
            this.btnManageInventory.Name = "btnManageInventory";
            this.btnManageInventory.Size = new System.Drawing.Size(163, 83);
            this.btnManageInventory.TabIndex = 1;
            this.btnManageInventory.Text = "Inventory Management";
            this.btnManageInventory.UseVisualStyleBackColor = true;
            // 
            // btnManagePayment
            // 
            this.btnManagePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagePayment.Location = new System.Drawing.Point(276, 236);
            this.btnManagePayment.Name = "btnManagePayment";
            this.btnManagePayment.Size = new System.Drawing.Size(163, 83);
            this.btnManagePayment.TabIndex = 1;
            this.btnManagePayment.Text = "Payment Management";
            this.btnManagePayment.UseVisualStyleBackColor = true;
            // 
            // btnManageStaff
            // 
            this.btnManageStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageStaff.Location = new System.Drawing.Point(276, 116);
            this.btnManageStaff.Name = "btnManageStaff";
            this.btnManageStaff.Size = new System.Drawing.Size(163, 83);
            this.btnManageStaff.TabIndex = 1;
            this.btnManageStaff.Text = "Staff Management";
            this.btnManageStaff.UseVisualStyleBackColor = true;
            // 
            // btnManageCustomer
            // 
            this.btnManageCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageCustomer.Location = new System.Drawing.Point(83, 236);
            this.btnManageCustomer.Name = "btnManageCustomer";
            this.btnManageCustomer.Size = new System.Drawing.Size(163, 83);
            this.btnManageCustomer.TabIndex = 1;
            this.btnManageCustomer.Text = "Customer Management";
            this.btnManageCustomer.UseVisualStyleBackColor = true;
            // 
            // btnManageOrder
            // 
            this.btnManageOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageOrder.Location = new System.Drawing.Point(469, 116);
            this.btnManageOrder.Name = "btnManageOrder";
            this.btnManageOrder.Size = new System.Drawing.Size(163, 83);
            this.btnManageOrder.TabIndex = 2;
            this.btnManageOrder.Text = "Order Management";
            this.btnManageOrder.UseVisualStyleBackColor = true;
            // 
            // mdiMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageOrder);
            this.Controls.Add(this.btnManageCustomer);
            this.Controls.Add(this.btnManageStaff);
            this.Controls.Add(this.btnManagePayment);
            this.Controls.Add(this.btnManageInventory);
            this.Controls.Add(this.label1);
            this.Name = "mdiMainMenuForm";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageInventory;
        private System.Windows.Forms.Button btnManagePayment;
        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Button btnManageCustomer;
        private System.Windows.Forms.Button btnManageOrder;
    }
}