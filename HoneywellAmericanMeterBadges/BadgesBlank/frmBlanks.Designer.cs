namespace HoneywellAmericanMeterBadges.BlankBadges
{
    partial class frmBlanks
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetDetails = new System.Windows.Forms.Button();
            this.txtBlankPartNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.blankBadgeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blankDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blankBadgeNumbersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.honeywellAmericanMeterBadgesDataSet = new HoneywellAmericanMeterBadges.HoneywellAmericanMeterBadgesDataSet();
            this.blankBadgeNumbersTableAdapter = new HoneywellAmericanMeterBadges.HoneywellAmericanMeterBadgesDataSetTableAdapters.BlankBadgeNumbersTableAdapter();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blankBadgeNumbersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.honeywellAmericanMeterBadgesDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(215, 305);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Enabled = false;
            this.btnModify.Location = new System.Drawing.Point(144, 305);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(71, 23);
            this.btnModify.TabIndex = 15;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(73, 305);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(144, 135);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(122, 20);
            this.txtDescription.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Description:";
            // 
            // btnGetDetails
            // 
            this.btnGetDetails.Location = new System.Drawing.Point(144, 77);
            this.btnGetDetails.Name = "btnGetDetails";
            this.btnGetDetails.Size = new System.Drawing.Size(100, 23);
            this.btnGetDetails.TabIndex = 11;
            this.btnGetDetails.Text = "Get Details";
            this.btnGetDetails.UseVisualStyleBackColor = true;
            this.btnGetDetails.Click += new System.EventHandler(this.BtnGetDetails_Click);
            // 
            // txtBlankPartNumber
            // 
            this.txtBlankPartNumber.Location = new System.Drawing.Point(144, 51);
            this.txtBlankPartNumber.Name = "txtBlankPartNumber";
            this.txtBlankPartNumber.Size = new System.Drawing.Size(100, 20);
            this.txtBlankPartNumber.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Blank Part Number:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(312, 351);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.blankBadgeNumberDataGridViewTextBoxColumn,
            this.blankDescriptionDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.blankBadgeNumbersBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(312, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(429, 277);
            this.dataGridView1.TabIndex = 18;
            // 
            // blankBadgeNumberDataGridViewTextBoxColumn
            // 
            this.blankBadgeNumberDataGridViewTextBoxColumn.DataPropertyName = "BlankBadgeNumber";
            this.blankBadgeNumberDataGridViewTextBoxColumn.HeaderText = "BlankBadgeNumber";
            this.blankBadgeNumberDataGridViewTextBoxColumn.Name = "blankBadgeNumberDataGridViewTextBoxColumn";
            this.blankBadgeNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.blankBadgeNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // blankDescriptionDataGridViewTextBoxColumn
            // 
            this.blankDescriptionDataGridViewTextBoxColumn.DataPropertyName = "BlankDescription";
            this.blankDescriptionDataGridViewTextBoxColumn.HeaderText = "BlankDescription";
            this.blankDescriptionDataGridViewTextBoxColumn.Name = "blankDescriptionDataGridViewTextBoxColumn";
            this.blankDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.blankDescriptionDataGridViewTextBoxColumn.Width = 150;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 50;
            // 
            // blankBadgeNumbersBindingSource
            // 
            this.blankBadgeNumbersBindingSource.DataMember = "BlankBadgeNumbers";
            this.blankBadgeNumbersBindingSource.DataSource = this.honeywellAmericanMeterBadgesDataSet;
            // 
            // honeywellAmericanMeterBadgesDataSet
            // 
            this.honeywellAmericanMeterBadgesDataSet.DataSetName = "HoneywellAmericanMeterBadgesDataSet";
            this.honeywellAmericanMeterBadgesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // blankBadgeNumbersTableAdapter
            // 
            this.blankBadgeNumbersTableAdapter.ClearBeforeFill = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(641, 351);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close Window";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(144, 173);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(71, 20);
            this.txtStatus.TabIndex = 21;
            // 
            // frmBlanks
            // 
            this.AcceptButton = this.btnGetDetails;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 399);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetDetails);
            this.Controls.Add(this.txtBlankPartNumber);
            this.Controls.Add(this.label1);
            this.Name = "frmBlanks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blank Badges";
            this.Load += new System.EventHandler(this.frmBlanks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blankBadgeNumbersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.honeywellAmericanMeterBadgesDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetDetails;
        private System.Windows.Forms.TextBox txtBlankPartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private HoneywellAmericanMeterBadgesDataSet honeywellAmericanMeterBadgesDataSet;
        private System.Windows.Forms.BindingSource blankBadgeNumbersBindingSource;
        private HoneywellAmericanMeterBadgesDataSetTableAdapters.BlankBadgeNumbersTableAdapter blankBadgeNumbersTableAdapter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn blankBadgeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn blankDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStatus;
    }
}