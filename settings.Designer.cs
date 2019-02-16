namespace Amazon_s_Best_Prices
{
    partial class settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.urlBox = new System.Windows.Forms.CheckBox();
            this.updateBox = new System.Windows.Forms.CheckBox();
            this.notificationBox = new System.Windows.Forms.CheckBox();
            this.asteriskBox = new System.Windows.Forms.CheckBox();
            this.clearBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Amazon_s_Best_Prices.Properties.Resources.gradient;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.urlBox);
            this.panel1.Controls.Add(this.updateBox);
            this.panel1.Controls.Add(this.notificationBox);
            this.panel1.Controls.Add(this.asteriskBox);
            this.panel1.Controls.Add(this.clearBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 177);
            this.panel1.TabIndex = 0;
            // 
            // urlBox
            // 
            this.urlBox.AutoSize = true;
            this.urlBox.BackColor = System.Drawing.Color.Transparent;
            this.urlBox.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.urlBox.ForeColor = System.Drawing.Color.White;
            this.urlBox.Location = new System.Drawing.Point(31, 45);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(134, 17);
            this.urlBox.TabIndex = 9;
            this.urlBox.Text = "Substitute tracker url";
            this.urlBox.UseVisualStyleBackColor = false;
            this.urlBox.CheckedChanged += new System.EventHandler(this.urlBox_CheckedChanged);
            // 
            // updateBox
            // 
            this.updateBox.AutoSize = true;
            this.updateBox.BackColor = System.Drawing.Color.Transparent;
            this.updateBox.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.updateBox.ForeColor = System.Drawing.Color.White;
            this.updateBox.Location = new System.Drawing.Point(31, 137);
            this.updateBox.Name = "updateBox";
            this.updateBox.Size = new System.Drawing.Size(199, 17);
            this.updateBox.TabIndex = 8;
            this.updateBox.Text = "Check for updates in background";
            this.updateBox.UseVisualStyleBackColor = false;
            this.updateBox.CheckedChanged += new System.EventHandler(this.updateBox_CheckedChanged);
            // 
            // notificationBox
            // 
            this.notificationBox.AutoSize = true;
            this.notificationBox.BackColor = System.Drawing.Color.Transparent;
            this.notificationBox.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.notificationBox.ForeColor = System.Drawing.Color.White;
            this.notificationBox.Location = new System.Drawing.Point(31, 91);
            this.notificationBox.Name = "notificationBox";
            this.notificationBox.Size = new System.Drawing.Size(163, 17);
            this.notificationBox.TabIndex = 7;
            this.notificationBox.Text = "Allow update notifications";
            this.notificationBox.UseVisualStyleBackColor = false;
            this.notificationBox.CheckedChanged += new System.EventHandler(this.notificationBox_CheckedChanged);
            // 
            // asteriskBox
            // 
            this.asteriskBox.AutoSize = true;
            this.asteriskBox.BackColor = System.Drawing.Color.Transparent;
            this.asteriskBox.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.asteriskBox.ForeColor = System.Drawing.Color.White;
            this.asteriskBox.Location = new System.Drawing.Point(31, 114);
            this.asteriskBox.Name = "asteriskBox";
            this.asteriskBox.Size = new System.Drawing.Size(191, 17);
            this.asteriskBox.TabIndex = 6;
            this.asteriskBox.Text = "Add asterisk on updated tracker";
            this.asteriskBox.UseVisualStyleBackColor = false;
            this.asteriskBox.CheckedChanged += new System.EventHandler(this.asteriskBox_CheckedChanged);
            // 
            // clearBox
            // 
            this.clearBox.AutoSize = true;
            this.clearBox.BackColor = System.Drawing.Color.Transparent;
            this.clearBox.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.clearBox.ForeColor = System.Drawing.Color.White;
            this.clearBox.Location = new System.Drawing.Point(31, 68);
            this.clearBox.Name = "clearBox";
            this.clearBox.Size = new System.Drawing.Size(161, 17);
            this.clearBox.TabIndex = 5;
            this.clearBox.Text = "Clear url box when clicked";
            this.clearBox.UseVisualStyleBackColor = false;
            this.clearBox.CheckedChanged += new System.EventHandler(this.clearBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Settings";
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(400, 177);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.settings_FormClosing);
            this.Load += new System.EventHandler(this.settings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox clearBox;
        private System.Windows.Forms.CheckBox asteriskBox;
        private System.Windows.Forms.CheckBox notificationBox;
        private System.Windows.Forms.CheckBox updateBox;
        private System.Windows.Forms.CheckBox urlBox;
    }
}