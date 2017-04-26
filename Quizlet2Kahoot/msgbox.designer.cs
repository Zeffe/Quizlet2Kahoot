namespace Citadel
{
    partial class msgbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(msgbox));
            this.thirteenForm1 = new Xenon.ThirteenForm();
            this.btnYes = new Xenon.ThirteenButton();
            this.btnNo = new Xenon.ThirteenButton();
            this.btnOk = new Xenon.ThirteenButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.thirteenControlBox1 = new Xenon.ThirteenControlBox();
            this.thirteenForm1.SuspendLayout();
            this.SuspendLayout();
            // 
            // thirteenForm1
            // 
            this.thirteenForm1.AccentColor = System.Drawing.Color.DodgerBlue;
            this.thirteenForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.thirteenForm1.ColorScheme = Xenon.ThirteenForm.ColorSchemes.Dark;
            this.thirteenForm1.Controls.Add(this.btnYes);
            this.thirteenForm1.Controls.Add(this.btnNo);
            this.thirteenForm1.Controls.Add(this.btnOk);
            this.thirteenForm1.Controls.Add(this.lblMessage);
            this.thirteenForm1.Controls.Add(this.thirteenControlBox1);
            this.thirteenForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thirteenForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.thirteenForm1.ForeColor = System.Drawing.Color.White;
            this.thirteenForm1.Location = new System.Drawing.Point(0, 0);
            this.thirteenForm1.Name = "thirteenForm1";
            this.thirteenForm1.Size = new System.Drawing.Size(163, 75);
            this.thirteenForm1.TabIndex = 0;
            this.thirteenForm1.Text = "thirteenForm1";
            // 
            // btnYes
            // 
            this.btnYes.AccentColor = System.Drawing.Color.DodgerBlue;
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnYes.ColorScheme = Xenon.ThirteenButton.ColorSchemes.Dark;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(53, 37);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(51, 23);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.AccentColor = System.Drawing.Color.DodgerBlue;
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnNo.ColorScheme = Xenon.ThirteenButton.ColorSchemes.Dark;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Location = new System.Drawing.Point(76, 37);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(51, 23);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccentColor = System.Drawing.Color.DodgerBlue;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnOk.ColorScheme = Xenon.ThirteenButton.ColorSchemes.Dark;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(24, 37);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(51, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 44);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(83, 16);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "placeHolder";
            // 
            // thirteenControlBox1
            // 
            this.thirteenControlBox1.AccentColor = System.Drawing.Color.DodgerBlue;
            this.thirteenControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.thirteenControlBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.thirteenControlBox1.ColorScheme = Xenon.ThirteenControlBox.ColorSchemes.Dark;
            this.thirteenControlBox1.ForeColor = System.Drawing.Color.White;
            this.thirteenControlBox1.Location = new System.Drawing.Point(60, 3);
            this.thirteenControlBox1.Name = "thirteenControlBox1";
            this.thirteenControlBox1.Size = new System.Drawing.Size(100, 25);
            this.thirteenControlBox1.TabIndex = 5;
            this.thirteenControlBox1.Text = "thirteenControlBox1";
            // 
            // msgbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 75);
            this.Controls.Add(this.thirteenForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "msgbox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "msgbox";
            this.thirteenForm1.ResumeLayout(false);
            this.thirteenForm1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Xenon.ThirteenForm thirteenForm1;
        private System.Windows.Forms.Label lblMessage;
        private Xenon.ThirteenButton btnYes;
        private Xenon.ThirteenButton btnNo;
        private Xenon.ThirteenButton btnOk;
        private Xenon.ThirteenControlBox thirteenControlBox1;
    }
}