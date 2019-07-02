namespace HoneywellAmericanMeterBadges
{
    partial class frmSetUpMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetUpMaintenance));
            this.btnBlankBadges = new System.Windows.Forms.Button();
            this.btnFinishedBadges = new System.Windows.Forms.Button();
            this.btnRequirements = new System.Windows.Forms.Button();
            this.btnStatuses = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBlankBadges
            // 
            this.btnBlankBadges.BackColor = System.Drawing.Color.LightCoral;
            this.btnBlankBadges.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlankBadges.Location = new System.Drawing.Point(285, 130);
            this.btnBlankBadges.Name = "btnBlankBadges";
            this.btnBlankBadges.Size = new System.Drawing.Size(142, 39);
            this.btnBlankBadges.TabIndex = 9;
            this.btnBlankBadges.Text = "Blank Badges";
            this.btnBlankBadges.UseVisualStyleBackColor = false;
            this.btnBlankBadges.Click += new System.EventHandler(this.BtnBlankBadges_Click);
            // 
            // btnFinishedBadges
            // 
            this.btnFinishedBadges.BackColor = System.Drawing.Color.LightCoral;
            this.btnFinishedBadges.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishedBadges.Location = new System.Drawing.Point(47, 130);
            this.btnFinishedBadges.Name = "btnFinishedBadges";
            this.btnFinishedBadges.Size = new System.Drawing.Size(142, 39);
            this.btnFinishedBadges.TabIndex = 8;
            this.btnFinishedBadges.Text = "Finished Badges";
            this.btnFinishedBadges.UseVisualStyleBackColor = false;
            this.btnFinishedBadges.Click += new System.EventHandler(this.BtnFinishedBadges_Click);
            // 
            // btnRequirements
            // 
            this.btnRequirements.BackColor = System.Drawing.Color.LightCoral;
            this.btnRequirements.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequirements.Location = new System.Drawing.Point(285, 47);
            this.btnRequirements.Name = "btnRequirements";
            this.btnRequirements.Size = new System.Drawing.Size(142, 39);
            this.btnRequirements.TabIndex = 7;
            this.btnRequirements.Text = "Requirements";
            this.btnRequirements.UseVisualStyleBackColor = false;
            this.btnRequirements.Click += new System.EventHandler(this.BtnRequirements_Click);
            // 
            // btnStatuses
            // 
            this.btnStatuses.BackColor = System.Drawing.Color.LightCoral;
            this.btnStatuses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatuses.Location = new System.Drawing.Point(166, 214);
            this.btnStatuses.Name = "btnStatuses";
            this.btnStatuses.Size = new System.Drawing.Size(142, 39);
            this.btnStatuses.TabIndex = 6;
            this.btnStatuses.Text = "Statuses";
            this.btnStatuses.UseVisualStyleBackColor = false;
            this.btnStatuses.Click += new System.EventHandler(this.BtnStatuses_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.LightCoral;
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.Location = new System.Drawing.Point(47, 47);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(142, 39);
            this.btnCustomers.TabIndex = 5;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.BtnCustomers_Click);
            // 
            // frmSetUpMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(475, 285);
            this.Controls.Add(this.btnBlankBadges);
            this.Controls.Add(this.btnFinishedBadges);
            this.Controls.Add(this.btnRequirements);
            this.Controls.Add(this.btnStatuses);
            this.Controls.Add(this.btnCustomers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetUpMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set-Up / Maintenance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBlankBadges;
        private System.Windows.Forms.Button btnFinishedBadges;
        private System.Windows.Forms.Button btnRequirements;
        private System.Windows.Forms.Button btnStatuses;
        private System.Windows.Forms.Button btnCustomers;
    }
}