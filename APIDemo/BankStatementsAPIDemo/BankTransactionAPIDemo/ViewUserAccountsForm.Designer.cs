namespace BankTransactionAPIDemo
{
    partial class ViewUserAccountsForm
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
            this.accountsDataGridView = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.viewAccountTransactionsButton = new System.Windows.Forms.Button();
            this.viewDataSetInfoButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // accountsDataGridView
            // 
            this.accountsDataGridView.AllowUserToAddRows = false;
            this.accountsDataGridView.AllowUserToDeleteRows = false;
            this.accountsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.accountsDataGridView.Name = "accountsDataGridView";
            this.accountsDataGridView.ReadOnly = true;
            this.accountsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountsDataGridView.Size = new System.Drawing.Size(776, 352);
            this.accountsDataGridView.TabIndex = 0;
            this.accountsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.accountsDataGridView_CellFormatting);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(339, 382);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(103, 56);
            this.closeButton.TabIndex = 13;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // viewAccountTransactionsButton
            // 
            this.viewAccountTransactionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.viewAccountTransactionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAccountTransactionsButton.Location = new System.Drawing.Point(12, 382);
            this.viewAccountTransactionsButton.Name = "viewAccountTransactionsButton";
            this.viewAccountTransactionsButton.Size = new System.Drawing.Size(103, 56);
            this.viewAccountTransactionsButton.TabIndex = 14;
            this.viewAccountTransactionsButton.Text = "View Transactions";
            this.viewAccountTransactionsButton.UseVisualStyleBackColor = false;
            this.viewAccountTransactionsButton.Click += new System.EventHandler(this.viewAccountTransactionsButton_Click);
            // 
            // viewDataSetInfoButton
            // 
            this.viewDataSetInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewDataSetInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.viewDataSetInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewDataSetInfoButton.Location = new System.Drawing.Point(121, 382);
            this.viewDataSetInfoButton.Name = "viewDataSetInfoButton";
            this.viewDataSetInfoButton.Size = new System.Drawing.Size(103, 56);
            this.viewDataSetInfoButton.TabIndex = 17;
            this.viewDataSetInfoButton.Text = "View Dataset Info";
            this.viewDataSetInfoButton.UseVisualStyleBackColor = false;
            this.viewDataSetInfoButton.Click += new System.EventHandler(this.viewDataSetInfoButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(230, 382);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(103, 56);
            this.exportButton.TabIndex = 29;
            this.exportButton.Text = "Export to CSV";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // ViewUserAccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.viewDataSetInfoButton);
            this.Controls.Add(this.viewAccountTransactionsButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.accountsDataGridView);
            this.Name = "ViewUserAccountsForm";
            this.Text = "ViewUserAccounts";
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView accountsDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button viewAccountTransactionsButton;
        private System.Windows.Forms.Button viewDataSetInfoButton;
        private System.Windows.Forms.Button exportButton;
    }
}