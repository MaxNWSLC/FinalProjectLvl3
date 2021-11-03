
namespace SaleMyStuffApp
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.SellButton = new System.Windows.Forms.Button();
            this.CancelSellButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShopPriceLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeForm = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // SellButton
            // 
            this.SellButton.BackColor = System.Drawing.Color.Wheat;
            this.SellButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SellButton.FlatAppearance.BorderSize = 0;
            this.SellButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SellButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.SellButton.Image = global::SaleMyStuffApp.Properties.Resources.saved1;
            this.SellButton.Location = new System.Drawing.Point(0, 0);
            this.SellButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.SellButton.Name = "SellButton";
            this.SellButton.Size = new System.Drawing.Size(325, 80);
            this.SellButton.TabIndex = 5;
            this.SellButton.Text = "Sell";
            this.SellButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SellButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SellButton.UseVisualStyleBackColor = false;
            this.SellButton.Click += new System.EventHandler(this.SellButton_Click);
            // 
            // CancelButton
            // 
            this.CancelSellButton.BackColor = System.Drawing.Color.Wheat;
            this.CancelSellButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CancelSellButton.FlatAppearance.BorderSize = 0;
            this.CancelSellButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelSellButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F);
            this.CancelSellButton.Image = global::SaleMyStuffApp.Properties.Resources.smallcancel;
            this.CancelSellButton.Location = new System.Drawing.Point(325, 0);
            this.CancelSellButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CancelSellButton.Name = "CancelButton";
            this.CancelSellButton.Size = new System.Drawing.Size(325, 80);
            this.CancelSellButton.TabIndex = 6;
            this.CancelSellButton.Text = "Cancel";
            this.CancelSellButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelSellButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelSellButton.UseVisualStyleBackColor = false;
            this.CancelSellButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CancelSellButton);
            this.panel1.Controls.Add(this.SellButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 420);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 80);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(476, 62);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F);
            this.nameLabel.Location = new System.Drawing.Point(24, 62);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(198, 28);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "Name Of The Item";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(24, 118);
            this.PriceLabel.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(206, 28);
            this.PriceLabel.TabIndex = 10;
            this.PriceLabel.Text = "Recomended Price:";
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(24, 236);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(245, 28);
            this.infoLabel.TabIndex = 11;
            this.infoLabel.Text = "Description of the Item";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(162, 146);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(256, 34);
            this.priceTextBox.TabIndex = 13;
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(29, 267);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(597, 134);
            this.infoTextBox.TabIndex = 14;
            this.infoTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 28);
            this.label1.TabIndex = 15;
            this.label1.Text = "Your Price:";
            // 
            // ShopPriceLabel
            // 
            this.ShopPriceLabel.AutoSize = true;
            this.ShopPriceLabel.Location = new System.Drawing.Point(24, 90);
            this.ShopPriceLabel.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.ShopPriceLabel.Name = "ShopPriceLabel";
            this.ShopPriceLabel.Size = new System.Drawing.Size(124, 28);
            this.ShopPriceLabel.TabIndex = 16;
            this.ShopPriceLabel.Text = "Shop Price:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.closeForm);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 25);
            this.panel2.TabIndex = 17;
            // 
            // closeForm
            // 
            this.closeForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeForm.Image = global::SaleMyStuffApp.Properties.Resources.smallclose;
            this.closeForm.Location = new System.Drawing.Point(620, 0);
            this.closeForm.Name = "closeForm";
            this.closeForm.Size = new System.Drawing.Size(30, 25);
            this.closeForm.TabIndex = 2;
            this.closeForm.TabStop = false;
            this.closeForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::SaleMyStuffApp.Properties.Resources.smallsell;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 25);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label2.Location = new System.Drawing.Point(32, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sell Form";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(650, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ShopPriceLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sell";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.Button CancelSellButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.RichTextBox infoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ShopPriceLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox closeForm;
    }
}