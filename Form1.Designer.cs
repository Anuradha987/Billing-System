namespace Billing2
{
    partial class ProductRegi
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
            this.txtbarcodeRegi = new System.Windows.Forms.TextBox();
            this.txtnameRegi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpriceRegi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnaddRegi = new System.Windows.Forms.Button();
            this.btndeleteRegi = new System.Windows.Forms.Button();
            this.btnupdateRegi = new System.Windows.Forms.Button();
            this.dgvProductsRegi = new System.Windows.Forms.DataGridView();
            this.txtsearchRegi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtidRegi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnnext = new System.Windows.Forms.Button();
            this.productRegipicturebox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsRegi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productRegipicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barcode";
            // 
            // txtbarcodeRegi
            // 
            this.txtbarcodeRegi.Location = new System.Drawing.Point(137, 285);
            this.txtbarcodeRegi.Name = "txtbarcodeRegi";
            this.txtbarcodeRegi.Size = new System.Drawing.Size(167, 22);
            this.txtbarcodeRegi.TabIndex = 1;
            // 
            // txtnameRegi
            // 
            this.txtnameRegi.Location = new System.Drawing.Point(137, 353);
            this.txtnameRegi.Name = "txtnameRegi";
            this.txtnameRegi.Size = new System.Drawing.Size(167, 22);
            this.txtnameRegi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtpriceRegi
            // 
            this.txtpriceRegi.Location = new System.Drawing.Point(137, 401);
            this.txtpriceRegi.Name = "txtpriceRegi";
            this.txtpriceRegi.Size = new System.Drawing.Size(167, 22);
            this.txtpriceRegi.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Price";
            // 
            // btnaddRegi
            // 
            this.btnaddRegi.Location = new System.Drawing.Point(50, 475);
            this.btnaddRegi.Name = "btnaddRegi";
            this.btnaddRegi.Size = new System.Drawing.Size(75, 23);
            this.btnaddRegi.TabIndex = 6;
            this.btnaddRegi.Text = "Add";
            this.btnaddRegi.UseVisualStyleBackColor = true;
            this.btnaddRegi.Click += new System.EventHandler(this.btnaddRegi_Click);
            // 
            // btndeleteRegi
            // 
            this.btndeleteRegi.Location = new System.Drawing.Point(50, 529);
            this.btndeleteRegi.Name = "btndeleteRegi";
            this.btndeleteRegi.Size = new System.Drawing.Size(75, 23);
            this.btndeleteRegi.TabIndex = 7;
            this.btndeleteRegi.Text = "Delete";
            this.btndeleteRegi.UseVisualStyleBackColor = true;
            this.btndeleteRegi.Click += new System.EventHandler(this.btndeleteRegi_Click);
            // 
            // btnupdateRegi
            // 
            this.btnupdateRegi.Location = new System.Drawing.Point(162, 475);
            this.btnupdateRegi.Name = "btnupdateRegi";
            this.btnupdateRegi.Size = new System.Drawing.Size(75, 23);
            this.btnupdateRegi.TabIndex = 8;
            this.btnupdateRegi.Text = "Update";
            this.btnupdateRegi.UseVisualStyleBackColor = true;
            this.btnupdateRegi.Click += new System.EventHandler(this.btnupdateRegi_Click);
            // 
            // dgvProductsRegi
            // 
            this.dgvProductsRegi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductsRegi.Location = new System.Drawing.Point(431, 94);
            this.dgvProductsRegi.Name = "dgvProductsRegi";
            this.dgvProductsRegi.RowHeadersWidth = 51;
            this.dgvProductsRegi.RowTemplate.Height = 24;
            this.dgvProductsRegi.Size = new System.Drawing.Size(719, 428);
            this.dgvProductsRegi.TabIndex = 9;
            this.dgvProductsRegi.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProductsRegi_RowHeaderMouseClick);
            this.dgvProductsRegi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvProductsRegi_MouseClick);
            // 
            // txtsearchRegi
            // 
            this.txtsearchRegi.Location = new System.Drawing.Point(536, 43);
            this.txtsearchRegi.Name = "txtsearchRegi";
            this.txtsearchRegi.Size = new System.Drawing.Size(168, 22);
            this.txtsearchRegi.TabIndex = 11;
            this.txtsearchRegi.TextChanged += new System.EventHandler(this.searchRegi_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Search";
            // 
            // txtidRegi
            // 
            this.txtidRegi.Location = new System.Drawing.Point(137, 237);
            this.txtidRegi.Name = "txtidRegi";
            this.txtidRegi.Size = new System.Drawing.Size(167, 22);
            this.txtidRegi.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Product ID";
            // 
            // btnnext
            // 
            this.btnnext.Location = new System.Drawing.Point(737, 566);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 46);
            this.btnnext.TabIndex = 14;
            this.btnnext.Text = "Next page";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // productRegipicturebox
            // 
            this.productRegipicturebox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.productRegipicturebox.Location = new System.Drawing.Point(54, 43);
            this.productRegipicturebox.Name = "productRegipicturebox";
            this.productRegipicturebox.Size = new System.Drawing.Size(250, 153);
            this.productRegipicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productRegipicturebox.TabIndex = 15;
            this.productRegipicturebox.TabStop = false;
            this.productRegipicturebox.Click += new System.EventHandler(this.productRegipicturebox_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 529);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductRegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 637);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.productRegipicturebox);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.txtidRegi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtsearchRegi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvProductsRegi);
            this.Controls.Add(this.btnupdateRegi);
            this.Controls.Add(this.btndeleteRegi);
            this.Controls.Add(this.btnaddRegi);
            this.Controls.Add(this.txtpriceRegi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnameRegi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbarcodeRegi);
            this.Controls.Add(this.label1);
            this.Name = "ProductRegi";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsRegi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productRegipicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbarcodeRegi;
        private System.Windows.Forms.TextBox txtnameRegi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpriceRegi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnaddRegi;
        private System.Windows.Forms.Button btndeleteRegi;
        private System.Windows.Forms.Button btnupdateRegi;
        private System.Windows.Forms.DataGridView dgvProductsRegi;
        private System.Windows.Forms.TextBox txtsearchRegi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtidRegi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.PictureBox productRegipicturebox;
        private System.Windows.Forms.Button button1;
    }
}

