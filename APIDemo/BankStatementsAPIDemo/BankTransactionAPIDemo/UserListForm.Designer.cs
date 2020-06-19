namespace BankTransactionAPIDemo
{
    partial class UserListForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.userListDataGridView = new System.Windows.Forms.DataGridView();
            this.deactivateactivateUserButton = new System.Windows.Forms.Button();
            this.viewUserAccountsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(460, 420);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(103, 56);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // userListDataGridView
            // 
            this.userListDataGridView.AllowUserToAddRows = false;
            this.userListDataGridView.AllowUserToDeleteRows = false;
            this.userListDataGridView.AllowUserToOrderColumns = true;
            this.userListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userListDataGridView.Location = new System.Drawing.Point(12, 12);
            this.userListDataGridView.Name = "userListDataGridView";
            this.userListDataGridView.ReadOnly = true;
            this.userListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userListDataGridView.Size = new System.Drawing.Size(776, 375);
            this.userListDataGridView.TabIndex = 10;
            // 
            // deactivateactivateUserButton
            // 
            this.deactivateactivateUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.deactivateactivateUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deactivateactivateUserButton.Location = new System.Drawing.Point(12, 420);
            this.deactivateactivateUserButton.Name = "deactivateactivateUserButton";
            this.deactivateactivateUserButton.Size = new System.Drawing.Size(103, 56);
            this.deactivateactivateUserButton.TabIndex = 11;
            this.deactivateactivateUserButton.Text = "Deactivate User";
            this.deactivateactivateUserButton.UseVisualStyleBackColor = false;
            // 
            // viewUserAccountsButton
            // 
            this.viewUserAccountsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.viewUserAccountsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewUserAccountsButton.Location = new System.Drawing.Point(121, 420);
            this.viewUserAccountsButton.Name = "viewUserAccountsButton";
            this.viewUserAccountsButton.Size = new System.Drawing.Size(103, 56);
            this.viewUserAccountsButton.TabIndex = 12;
            this.viewUserAccountsButton.Text = "View User Accounts";
            this.viewUserAccountsButton.UseVisualStyleBackColor = false;
            this.viewUserAccountsButton.Click += new System.EventHandler(this.viewUserAccountsButton_Click);
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.viewUserAccountsButton);
            this.Controls.Add(this.deactivateactivateUserButton);
            this.Controls.Add(this.userListDataGridView);
            this.Controls.Add(this.closeButton);
            this.Name = "UserListForm";
            this.Text = "UserList";
            ((System.ComponentModel.ISupportInitialize)(this.userListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView userListDataGridView;
        private System.Windows.Forms.Button deactivateactivateUserButton;
        private System.Windows.Forms.Button viewUserAccountsButton;
    }
}