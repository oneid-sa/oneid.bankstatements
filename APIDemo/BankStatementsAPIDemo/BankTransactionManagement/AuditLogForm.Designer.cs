namespace BankTransactionManagement
{
    partial class AuditLogForm
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
            this.dateToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.viewUsageAuditsButton = new System.Windows.Forms.Button();
            this.usageAuditsDataGridView = new System.Windows.Forms.DataGridView();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UniqueReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountHolderIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usageAuditsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateToDateTimePicker
            // 
            this.dateToDateTimePicker.Location = new System.Drawing.Point(334, 12);
            this.dateToDateTimePicker.Name = "dateToDateTimePicker";
            this.dateToDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateToDateTimePicker.TabIndex = 26;
            // 
            // dateFromDateTimePicker
            // 
            this.dateFromDateTimePicker.Location = new System.Drawing.Point(73, 12);
            this.dateFromDateTimePicker.Name = "dateFromDateTimePicker";
            this.dateFromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateFromDateTimePicker.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Date To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Date From:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.exportButton);
            this.groupBox3.Controls.Add(this.closeButton);
            this.groupBox3.Controls.Add(this.viewUsageAuditsButton);
            this.groupBox3.Controls.Add(this.usageAuditsDataGridView);
            this.groupBox3.Location = new System.Drawing.Point(11, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1383, 578);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Usage Audits";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(230, 522);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(103, 56);
            this.exportButton.TabIndex = 8;
            this.exportButton.Text = "Export to CSV";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(121, 522);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(103, 56);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            // 
            // viewUsageAuditsButton
            // 
            this.viewUsageAuditsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewUsageAuditsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.viewUsageAuditsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewUsageAuditsButton.Location = new System.Drawing.Point(12, 522);
            this.viewUsageAuditsButton.Name = "viewUsageAuditsButton";
            this.viewUsageAuditsButton.Size = new System.Drawing.Size(103, 56);
            this.viewUsageAuditsButton.TabIndex = 6;
            this.viewUsageAuditsButton.Text = "View Usage Audits";
            this.viewUsageAuditsButton.UseVisualStyleBackColor = false;
            this.viewUsageAuditsButton.Click += new System.EventHandler(this.viewUsageAuditsButton_Click);
            // 
            // usageAuditsDataGridView
            // 
            this.usageAuditsDataGridView.AllowUserToAddRows = false;
            this.usageAuditsDataGridView.AllowUserToDeleteRows = false;
            this.usageAuditsDataGridView.AllowUserToOrderColumns = true;
            this.usageAuditsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usageAuditsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.usageAuditsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usageAuditsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyID,
            this.CreatedAt,
            this.UsageID,
            this.TransactionDescription,
            this.UniqueReference,
            this.AccountHolderIdentifier,
            this.Message,
            this.RoleID});
            this.usageAuditsDataGridView.Location = new System.Drawing.Point(6, 19);
            this.usageAuditsDataGridView.Name = "usageAuditsDataGridView";
            this.usageAuditsDataGridView.ReadOnly = true;
            this.usageAuditsDataGridView.RowHeadersVisible = false;
            this.usageAuditsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usageAuditsDataGridView.Size = new System.Drawing.Size(1361, 497);
            this.usageAuditsDataGridView.TabIndex = 1;
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(8, 47);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(0, 13);
            this.CountLabel.TabIndex = 28;
            // 
            // CompanyID
            // 
            this.CompanyID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompanyID.DataPropertyName = "companyId";
            this.CompanyID.HeaderText = "Company ID";
            this.CompanyID.Name = "CompanyID";
            this.CompanyID.ReadOnly = true;
            this.CompanyID.Width = 90;
            // 
            // CreatedAt
            // 
            this.CreatedAt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CreatedAt.DataPropertyName = "usageDate";
            this.CreatedAt.HeaderText = "Usage Date";
            this.CreatedAt.Name = "CreatedAt";
            this.CreatedAt.ReadOnly = true;
            this.CreatedAt.Width = 89;
            // 
            // UsageID
            // 
            this.UsageID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UsageID.DataPropertyName = "id";
            this.UsageID.HeaderText = "Usage ID";
            this.UsageID.Name = "UsageID";
            this.UsageID.ReadOnly = true;
            this.UsageID.Width = 77;
            // 
            // TransactionDescription
            // 
            this.TransactionDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TransactionDescription.DataPropertyName = "transactionDescription";
            this.TransactionDescription.HeaderText = "Transaction Desc";
            this.TransactionDescription.Name = "TransactionDescription";
            this.TransactionDescription.ReadOnly = true;
            this.TransactionDescription.Width = 106;
            // 
            // UniqueReference
            // 
            this.UniqueReference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UniqueReference.DataPropertyName = "uniqueReference";
            this.UniqueReference.HeaderText = "Unique Reference";
            this.UniqueReference.Name = "UniqueReference";
            this.UniqueReference.ReadOnly = true;
            this.UniqueReference.Width = 109;
            // 
            // AccountHolderIdentifier
            // 
            this.AccountHolderIdentifier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AccountHolderIdentifier.DataPropertyName = "accountHolderIdentifier";
            this.AccountHolderIdentifier.HeaderText = "AccountHolder Identifier";
            this.AccountHolderIdentifier.Name = "AccountHolderIdentifier";
            this.AccountHolderIdentifier.ReadOnly = true;
            this.AccountHolderIdentifier.Width = 133;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "message";
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Visible = false;
            // 
            // RoleID
            // 
            this.RoleID.DataPropertyName = "roleId";
            this.RoleID.HeaderText = "Role ID";
            this.RoleID.Name = "RoleID";
            this.RoleID.ReadOnly = true;
            this.RoleID.Visible = false;
            // 
            // AuditLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 664);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dateToDateTimePicker);
            this.Controls.Add(this.dateFromDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AuditLogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuditLogForm";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usageAuditsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateToDateTimePicker;
        private System.Windows.Forms.DateTimePicker dateFromDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button viewUsageAuditsButton;
        private System.Windows.Forms.DataGridView usageAuditsDataGridView;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn UniqueReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountHolderIdentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleID;
    }
}