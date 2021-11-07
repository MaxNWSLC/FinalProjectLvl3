
namespace SaleMyStuffApp
{
    partial class Form3
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.apPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.themeName = new System.Windows.Forms.Label();
            this.themeListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passBox2 = new System.Windows.Forms.TextBox();
            this.passBox1 = new System.Windows.Forms.TextBox();
            this.newPassLabel = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.newPassButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.closeForm = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.apPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.closeForm);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 25);
            this.panel2.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label5.Location = new System.Drawing.Point(32, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Settings";
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.sidePanel.Controls.Add(this.button3);
            this.sidePanel.Controls.Add(this.button2);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 25);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(225, 775);
            this.sidePanel.TabIndex = 24;
            // 
            // apPanel
            // 
            this.apPanel.Controls.Add(this.button5);
            this.apPanel.Controls.Add(this.button4);
            this.apPanel.Controls.Add(this.label2);
            this.apPanel.Controls.Add(this.themeName);
            this.apPanel.Controls.Add(this.themeListBox);
            this.apPanel.Controls.Add(this.label1);
            this.apPanel.Controls.Add(this.button1);
            this.apPanel.Controls.Add(this.newPassButton);
            this.apPanel.Controls.Add(this.passBox2);
            this.apPanel.Controls.Add(this.passBox1);
            this.apPanel.Controls.Add(this.newPassLabel);
            this.apPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apPanel.Location = new System.Drawing.Point(225, 25);
            this.apPanel.Name = "apPanel";
            this.apPanel.Size = new System.Drawing.Size(975, 775);
            this.apPanel.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 28);
            this.label2.TabIndex = 28;
            this.label2.Text = "Choose Side of the SidePanel";
            // 
            // themeName
            // 
            this.themeName.AutoSize = true;
            this.themeName.Location = new System.Drawing.Point(269, 94);
            this.themeName.Name = "themeName";
            this.themeName.Size = new System.Drawing.Size(81, 28);
            this.themeName.TabIndex = 27;
            this.themeName.Text = "Theme";
            this.themeName.Visible = false;
            // 
            // themeListBox
            // 
            this.themeListBox.FormattingEnabled = true;
            this.themeListBox.ItemHeight = 28;
            this.themeListBox.Items.AddRange(new object[] {
            "Linen (Default)",
            "Dark",
            "Lime",
            "Orange"});
            this.themeListBox.Location = new System.Drawing.Point(524, 94);
            this.themeListBox.Name = "themeListBox";
            this.themeListBox.Size = new System.Drawing.Size(182, 116);
            this.themeListBox.TabIndex = 24;
            this.themeListBox.SelectedValueChanged += new System.EventHandler(this.themeListBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 28);
            this.label1.TabIndex = 26;
            this.label1.Text = "Choose Color Theme";
            // 
            // passBox2
            // 
            this.passBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passBox2.Location = new System.Drawing.Point(507, 209);
            this.passBox2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.passBox2.Name = "passBox2";
            this.passBox2.PasswordChar = '*';
            this.passBox2.Size = new System.Drawing.Size(337, 34);
            this.passBox2.TabIndex = 33;
            // 
            // passBox1
            // 
            this.passBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passBox1.Location = new System.Drawing.Point(130, 209);
            this.passBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.passBox1.Name = "passBox1";
            this.passBox1.PasswordChar = '*';
            this.passBox1.Size = new System.Drawing.Size(337, 34);
            this.passBox1.TabIndex = 32;
            // 
            // newPassLabel
            // 
            this.newPassLabel.AutoSize = true;
            this.newPassLabel.Location = new System.Drawing.Point(360, 108);
            this.newPassLabel.Name = "newPassLabel";
            this.newPassLabel.Size = new System.Drawing.Size(255, 28);
            this.newPassLabel.TabIndex = 31;
            this.newPassLabel.Text = "Choose a new password";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Wheat;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::SaleMyStuffApp.Properties.Resources.right;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(532, 396);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 70);
            this.button5.TabIndex = 30;
            this.button5.Text = "Right";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Wheat;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::SaleMyStuffApp.Properties.Resources.left;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Location = new System.Drawing.Point(243, 396);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 70);
            this.button4.TabIndex = 29;
            this.button4.Text = "Left";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Wheat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::SaleMyStuffApp.Properties.Resources.saved;
            this.button1.Location = new System.Drawing.Point(302, 582);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(370, 70);
            this.button1.TabIndex = 25;
            this.button1.Text = "Apply Changes";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // newPassButton
            // 
            this.newPassButton.BackColor = System.Drawing.Color.Wheat;
            this.newPassButton.FlatAppearance.BorderSize = 0;
            this.newPassButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newPassButton.Image = global::SaleMyStuffApp.Properties.Resources.history;
            this.newPassButton.Location = new System.Drawing.Point(302, 396);
            this.newPassButton.Name = "newPassButton";
            this.newPassButton.Size = new System.Drawing.Size(370, 70);
            this.newPassButton.TabIndex = 34;
            this.newPassButton.Text = "Save Password";
            this.newPassButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newPassButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.newPassButton.UseVisualStyleBackColor = false;
            this.newPassButton.Click += new System.EventHandler(this.newPassButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Wheat;
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.button3.Image = global::SaleMyStuffApp.Properties.Resources.acc;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(225, 94);
            this.button3.TabIndex = 2;
            this.button3.Text = "Acc Settings";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Wheat;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.button2.Image = global::SaleMyStuffApp.Properties.Resources.main;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 94);
            this.button2.TabIndex = 1;
            this.button2.Text = "App Settings";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // closeForm
            // 
            this.closeForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeForm.Image = global::SaleMyStuffApp.Properties.Resources.smallclose;
            this.closeForm.Location = new System.Drawing.Point(1170, 0);
            this.closeForm.Name = "closeForm";
            this.closeForm.Size = new System.Drawing.Size(30, 25);
            this.closeForm.TabIndex = 2;
            this.closeForm.TabStop = false;
            this.closeForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::SaleMyStuffApp.Properties.Resources.smallSettings;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 25);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.apPanel);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.sidePanel.ResumeLayout(false);
            this.apPanel.ResumeLayout(false);
            this.apPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox closeForm;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel apPanel;
        private System.Windows.Forms.Label themeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox themeListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label newPassLabel;
        private System.Windows.Forms.Button newPassButton;
        private System.Windows.Forms.TextBox passBox2;
        private System.Windows.Forms.TextBox passBox1;
    }
}