namespace drinkOrder_3Tiers_Pattern.Presentation_Layer
{
    partial class AddOrder_Form
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_OrderID = new System.Windows.Forms.TextBox();
            this.cbx_Drinks = new System.Windows.Forms.ComboBox();
            this.num_Quantity = new System.Windows.Forms.NumericUpDown();
            this.num_Sale = new System.Windows.Forms.NumericUpDown();
            this.btn_AddOrder = new System.Windows.Forms.Button();
            this.btn_CancelOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Sale)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OrderID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Drink Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sale (%)";
            // 
            // txt_OrderID
            // 
            this.txt_OrderID.Location = new System.Drawing.Point(157, 58);
            this.txt_OrderID.Name = "txt_OrderID";
            this.txt_OrderID.Size = new System.Drawing.Size(120, 20);
            this.txt_OrderID.TabIndex = 4;
            // 
            // cbx_Drinks
            // 
            this.cbx_Drinks.FormattingEnabled = true;
            this.cbx_Drinks.Location = new System.Drawing.Point(157, 132);
            this.cbx_Drinks.Name = "cbx_Drinks";
            this.cbx_Drinks.Size = new System.Drawing.Size(213, 21);
            this.cbx_Drinks.TabIndex = 5;
            // 
            // num_Quantity
            // 
            this.num_Quantity.Location = new System.Drawing.Point(157, 214);
            this.num_Quantity.Name = "num_Quantity";
            this.num_Quantity.Size = new System.Drawing.Size(120, 20);
            this.num_Quantity.TabIndex = 6;
            // 
            // num_Sale
            // 
            this.num_Sale.Location = new System.Drawing.Point(157, 291);
            this.num_Sale.Name = "num_Sale";
            this.num_Sale.Size = new System.Drawing.Size(120, 20);
            this.num_Sale.TabIndex = 7;
            // 
            // btn_AddOrder
            // 
            this.btn_AddOrder.Location = new System.Drawing.Point(62, 367);
            this.btn_AddOrder.Name = "btn_AddOrder";
            this.btn_AddOrder.Size = new System.Drawing.Size(119, 44);
            this.btn_AddOrder.TabIndex = 8;
            this.btn_AddOrder.Text = "ADD";
            this.btn_AddOrder.UseVisualStyleBackColor = true;
            this.btn_AddOrder.Click += new System.EventHandler(this.btn_AddOrder_Click);
            // 
            // btn_CancelOrder
            // 
            this.btn_CancelOrder.Location = new System.Drawing.Point(251, 367);
            this.btn_CancelOrder.Name = "btn_CancelOrder";
            this.btn_CancelOrder.Size = new System.Drawing.Size(119, 44);
            this.btn_CancelOrder.TabIndex = 9;
            this.btn_CancelOrder.Text = "CANCEL";
            this.btn_CancelOrder.UseVisualStyleBackColor = true;
            this.btn_CancelOrder.Click += new System.EventHandler(this.btn_CancelOrder_Click);
            // 
            // AddOrder_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_CancelOrder);
            this.Controls.Add(this.btn_AddOrder);
            this.Controls.Add(this.num_Sale);
            this.Controls.Add(this.num_Quantity);
            this.Controls.Add(this.cbx_Drinks);
            this.Controls.Add(this.txt_OrderID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddOrder_Form";
            this.Text = "AddOrder_Form";
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Sale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_OrderID;
        private System.Windows.Forms.ComboBox cbx_Drinks;
        private System.Windows.Forms.NumericUpDown num_Quantity;
        private System.Windows.Forms.NumericUpDown num_Sale;
        private System.Windows.Forms.Button btn_AddOrder;
        private System.Windows.Forms.Button btn_CancelOrder;
    }
}