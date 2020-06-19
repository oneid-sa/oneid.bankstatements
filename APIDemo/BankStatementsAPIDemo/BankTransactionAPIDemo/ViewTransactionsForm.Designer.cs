namespace BankTransactionAPIDemo
{
    partial class ViewTransactionsForm
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
            this.dateToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshTransactionsButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.transactionListDataGridView = new System.Windows.Forms.DataGridView();
            this.aggrgrationsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.categoryListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transactionListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateToDateTimePicker
            // 
            this.dateToDateTimePicker.Enabled = false;
            this.dateToDateTimePicker.Location = new System.Drawing.Point(333, 12);
            this.dateToDateTimePicker.Name = "dateToDateTimePicker";
            this.dateToDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateToDateTimePicker.TabIndex = 22;
            // 
            // dateFromDateTimePicker
            // 
            this.dateFromDateTimePicker.Enabled = false;
            this.dateFromDateTimePicker.Location = new System.Drawing.Point(72, 12);
            this.dateFromDateTimePicker.Name = "dateFromDateTimePicker";
            this.dateFromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateFromDateTimePicker.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Date To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Date From:";
            // 
            // refreshTransactionsButton
            // 
            this.refreshTransactionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshTransactionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.refreshTransactionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshTransactionsButton.Location = new System.Drawing.Point(415, 510);
            this.refreshTransactionsButton.Name = "refreshTransactionsButton";
            this.refreshTransactionsButton.Size = new System.Drawing.Size(103, 56);
            this.refreshTransactionsButton.TabIndex = 24;
            this.refreshTransactionsButton.Text = "Refresh Transactions";
            this.refreshTransactionsButton.UseVisualStyleBackColor = false;
            this.refreshTransactionsButton.Visible = false;
            this.refreshTransactionsButton.Click += new System.EventHandler(this.refreshTransactionsButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(11, 510);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(103, 56);
            this.closeButton.TabIndex = 23;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // transactionListDataGridView
            // 
            this.transactionListDataGridView.AllowUserToAddRows = false;
            this.transactionListDataGridView.AllowUserToDeleteRows = false;
            this.transactionListDataGridView.AllowUserToOrderColumns = true;
            this.transactionListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transactionListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactionListDataGridView.Location = new System.Drawing.Point(12, 194);
            this.transactionListDataGridView.Name = "transactionListDataGridView";
            this.transactionListDataGridView.ReadOnly = true;
            this.transactionListDataGridView.RowHeadersVisible = false;
            this.transactionListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.transactionListDataGridView.Size = new System.Drawing.Size(1074, 310);
            this.transactionListDataGridView.TabIndex = 25;
            this.transactionListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.transactionListDataGridView_CellContentClick);
            this.transactionListDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.transactionListDataGridView_CellFormatting);
            // 
            // aggrgrationsListView
            // 
            this.aggrgrationsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aggrgrationsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.aggrgrationsListView.GridLines = true;
            this.aggrgrationsListView.HideSelection = false;
            this.aggrgrationsListView.Location = new System.Drawing.Point(10, 38);
            this.aggrgrationsListView.Name = "aggrgrationsListView";
            this.aggrgrationsListView.Size = new System.Drawing.Size(1076, 58);
            this.aggrgrationsListView.TabIndex = 26;
            this.aggrgrationsListView.TileSize = new System.Drawing.Size(168, 30);
            this.aggrgrationsListView.UseCompatibleStateImageBehavior = false;
            this.aggrgrationsListView.View = System.Windows.Forms.View.Tile;
            this.aggrgrationsListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.aggrgrationsListView_DrawItem);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // categoryListView
            // 
            this.categoryListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.categoryListView.GridLines = true;
            this.categoryListView.HideSelection = false;
            this.categoryListView.Location = new System.Drawing.Point(10, 102);
            this.categoryListView.Name = "categoryListView";
            this.categoryListView.Size = new System.Drawing.Size(1076, 86);
            this.categoryListView.TabIndex = 27;
            this.categoryListView.TileSize = new System.Drawing.Size(168, 30);
            this.categoryListView.UseCompatibleStateImageBehavior = false;
            this.categoryListView.View = System.Windows.Forms.View.Tile;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(120, 510);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(103, 56);
            this.exportButton.TabIndex = 28;
            this.exportButton.Text = "Export to CSV";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // ViewTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 578);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.categoryListView);
            this.Controls.Add(this.aggrgrationsListView);
            this.Controls.Add(this.transactionListDataGridView);
            this.Controls.Add(this.refreshTransactionsButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.dateToDateTimePicker);
            this.Controls.Add(this.dateFromDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewTransactionsForm";
            this.Text = "View Transactions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.transactionListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateToDateTimePicker;
        private System.Windows.Forms.DateTimePicker dateFromDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refreshTransactionsButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView transactionListDataGridView;
        private System.Windows.Forms.ListView aggrgrationsListView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView categoryListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button exportButton;
    }
}