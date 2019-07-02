namespace HoneywellAmericanMeterBadges.Customers
{
    partial class frmAddModifyCustomers
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddModifyCustomers));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerNumber = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerNotes = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCustStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRequirement = new System.Windows.Forms.ComboBox();
            this.honeywellAmericanMeterBadgesDataSet = new HoneywellAmericanMeterBadges.HoneywellAmericanMeterBadgesDataSet();
            this.requirementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requirementsTableAdapter = new HoneywellAmericanMeterBadges.HoneywellAmericanMeterBadgesDataSetTableAdapters.RequirementsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.honeywellAmericanMeterBadgesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer #:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Notes:";
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(168, 54);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerNumber.TabIndex = 3;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(168, 89);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 20);
            this.txtCustomerName.TabIndex = 4;
            // 
            // txtCustomerNotes
            // 
            this.txtCustomerNotes.Location = new System.Drawing.Point(168, 196);
            this.txtCustomerNotes.Multiline = true;
            this.txtCustomerNotes.Name = "txtCustomerNotes";
            this.txtCustomerNotes.Size = new System.Drawing.Size(250, 72);
            this.txtCustomerNotes.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(272, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(168, 296);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Status:";
            // 
            // cboCustStatus
            // 
            this.cboCustStatus.FormattingEnabled = true;
            this.cboCustStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cboCustStatus.Location = new System.Drawing.Point(168, 124);
            this.cboCustStatus.Name = "cboCustStatus";
            this.cboCustStatus.Size = new System.Drawing.Size(121, 21);
            this.cboCustStatus.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Requirement Code:";
            // 
            // cboRequirement
            // 
            this.cboRequirement.DataSource = this.requirementsBindingSource;
            this.cboRequirement.DisplayMember = "RequirementCode";
            this.cboRequirement.FormattingEnabled = true;
            this.cboRequirement.Location = new System.Drawing.Point(168, 160);
            this.cboRequirement.Name = "cboRequirement";
            this.cboRequirement.Size = new System.Drawing.Size(121, 21);
            this.cboRequirement.TabIndex = 17;
            this.cboRequirement.ValueMember = "RequirementCode";
            // 
            // honeywellAmericanMeterBadgesDataSet
            // 
            this.honeywellAmericanMeterBadgesDataSet.DataSetName = "HoneywellAmericanMeterBadgesDataSet";
            this.honeywellAmericanMeterBadgesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // requirementsBindingSource
            // 
            this.requirementsBindingSource.DataMember = "Requirements";
            this.requirementsBindingSource.DataSource = this.honeywellAmericanMeterBadgesDataSet;
            // 
            // requirementsTableAdapter
            // 
            this.requirementsTableAdapter.ClearBeforeFill = true;
            // 
            // frmAddModifyCustomers
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(506, 374);
            this.ControlBox = false;
            this.Controls.Add(this.cboRequirement);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboCustStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtCustomerNotes);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtCustomerNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAddModifyCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAddModifyCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.honeywellAmericanMeterBadgesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerNumber;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerNotes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCustStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboRequirement;
        private HoneywellAmericanMeterBadgesDataSet honeywellAmericanMeterBadgesDataSet;
        private System.Windows.Forms.BindingSource requirementsBindingSource;
        private HoneywellAmericanMeterBadgesDataSetTableAdapters.RequirementsTableAdapter requirementsTableAdapter;
    }
}