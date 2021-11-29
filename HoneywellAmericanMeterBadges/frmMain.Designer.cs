namespace HoneywellAmericanMeterBadges
{
    partial class frmMain
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
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnOrderSerialEntry = new System.Windows.Forms.Button();
            this.btnReviewReporting = new System.Windows.Forms.Button();
            this.btnSetUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Britannic Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblLogo.Location = new System.Drawing.Point(53, 26);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(450, 32);
            this.lblLogo.TabIndex = 6;
            this.lblLogo.Text = "Honeywell American Meter Badges";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOrderSerialEntry
            // 
            this.btnOrderSerialEntry.BackColor = System.Drawing.Color.LightCoral;
            this.btnOrderSerialEntry.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnOrderSerialEntry.FlatAppearance.BorderSize = 2;
            this.btnOrderSerialEntry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnOrderSerialEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderSerialEntry.Location = new System.Drawing.Point(157, 115);
            this.btnOrderSerialEntry.Name = "btnOrderSerialEntry";
            this.btnOrderSerialEntry.Size = new System.Drawing.Size(242, 54);
            this.btnOrderSerialEntry.TabIndex = 7;
            this.btnOrderSerialEntry.Text = "Order / Serial Number Entry";
            this.btnOrderSerialEntry.UseVisualStyleBackColor = false;
            this.btnOrderSerialEntry.Click += new System.EventHandler(this.BtnOrderSerialEntry_Click);
            // 
            // btnReviewReporting
            // 
            this.btnReviewReporting.BackColor = System.Drawing.Color.LightCoral;
            this.btnReviewReporting.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnReviewReporting.FlatAppearance.BorderSize = 2;
            this.btnReviewReporting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnReviewReporting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewReporting.Location = new System.Drawing.Point(157, 226);
            this.btnReviewReporting.Name = "btnReviewReporting";
            this.btnReviewReporting.Size = new System.Drawing.Size(242, 54);
            this.btnReviewReporting.TabIndex = 8;
            this.btnReviewReporting.Text = "Review / Reporting";
            this.btnReviewReporting.UseVisualStyleBackColor = false;
            this.btnReviewReporting.Click += new System.EventHandler(this.BtnReviewReporting_Click);
            // 
            // btnSetUp
            // 
            this.btnSetUp.BackColor = System.Drawing.Color.LightCoral;
            this.btnSetUp.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnSetUp.FlatAppearance.BorderSize = 2;
            this.btnSetUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnSetUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetUp.Location = new System.Drawing.Point(157, 337);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Size = new System.Drawing.Size(242, 54);
            this.btnSetUp.TabIndex = 9;
            this.btnSetUp.Text = "Set Up / Maintenance";
            this.btnSetUp.UseVisualStyleBackColor = false;
            this.btnSetUp.Click += new System.EventHandler(this.BtnSetUp_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(557, 464);
            this.Controls.Add(this.btnSetUp);
            this.Controls.Add(this.btnReviewReporting);
            this.Controls.Add(this.btnOrderSerialEntry);
            this.Controls.Add(this.lblLogo);
            this.Name = "frmMain";
            this.Text = "American Meter Badges and Serial Numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnOrderSerialEntry;
        private System.Windows.Forms.Button btnReviewReporting;
        private System.Windows.Forms.Button btnSetUp;
    }
}