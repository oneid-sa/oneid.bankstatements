namespace BankTransactionAPIDemo
{
    partial class Mainform
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.getUserListButton = new System.Windows.Forms.Button();
            this.loginResultText = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.securityTokenTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TransactionGroupBox = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.categoriesAndRulesButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.viewDataSetInfoButton = new System.Windows.Forms.Button();
            this.viewAccountTransactionsButton = new System.Windows.Forms.Button();
            this.accountsDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.retrieveBankUniqueReferenceTextBox = new System.Windows.Forms.TextBox();
            this.viewAccountsButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.retrieveAccountHolderIDTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.createUserGroupBox = new System.Windows.Forms.GroupBox();
            this.accountHolderIDTextBox = new System.Windows.Forms.TextBox();
            this.localeTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.createUserButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.finishSessionButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.TransactionGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.createUserGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getUserListButton);
            this.groupBox1.Controls.Add(this.loginResultText);
            this.groupBox1.Controls.Add(this.loginButton);
            this.groupBox1.Controls.Add(this.passwordTextbox);
            this.groupBox1.Controls.Add(this.usernameTextbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.securityTokenTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(283, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 205);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Secutiy API Demo";
            // 
            // getUserListButton
            // 
            this.getUserListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.getUserListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getUserListButton.Location = new System.Drawing.Point(227, 140);
            this.getUserListButton.Name = "getUserListButton";
            this.getUserListButton.Size = new System.Drawing.Size(103, 56);
            this.getUserListButton.TabIndex = 14;
            this.getUserListButton.Text = "Get User List";
            this.getUserListButton.UseVisualStyleBackColor = false;
            this.getUserListButton.Visible = false;
            this.getUserListButton.Click += new System.EventHandler(this.getUserListButton_Click_1);
            // 
            // loginResultText
            // 
            this.loginResultText.AutoSize = true;
            this.loginResultText.Location = new System.Drawing.Point(183, 176);
            this.loginResultText.Name = "loginResultText";
            this.loginResultText.Size = new System.Drawing.Size(0, 15);
            this.loginResultText.TabIndex = 7;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(68, 139);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(103, 56);
            this.loginButton.TabIndex = 13;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(73, 48);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.Size = new System.Drawing.Size(212, 21);
            this.passwordTextbox.TabIndex = 11;
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(73, 24);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(212, 21);
            this.usernameTextbox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Token:";
            // 
            // securityTokenTextBox
            // 
            this.securityTokenTextBox.Location = new System.Drawing.Point(73, 72);
            this.securityTokenTextBox.Multiline = true;
            this.securityTokenTextBox.Name = "securityTokenTextBox";
            this.securityTokenTextBox.Size = new System.Drawing.Size(432, 62);
            this.securityTokenTextBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // TransactionGroupBox
            // 
            this.TransactionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionGroupBox.Controls.Add(this.finishSessionButton);
            this.TransactionGroupBox.Controls.Add(this.closeButton);
            this.TransactionGroupBox.Controls.Add(this.groupBox3);
            this.TransactionGroupBox.Controls.Add(this.groupBox2);
            this.TransactionGroupBox.Controls.Add(this.createUserGroupBox);
            this.TransactionGroupBox.Location = new System.Drawing.Point(12, 229);
            this.TransactionGroupBox.Name = "TransactionGroupBox";
            this.TransactionGroupBox.Size = new System.Drawing.Size(798, 536);
            this.TransactionGroupBox.TabIndex = 3;
            this.TransactionGroupBox.TabStop = false;
            this.TransactionGroupBox.Text = "Transaction";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(16, 474);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(103, 56);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.categoriesAndRulesButton);
            this.groupBox3.Controls.Add(this.exportButton);
            this.groupBox3.Controls.Add(this.viewDataSetInfoButton);
            this.groupBox3.Controls.Add(this.viewAccountTransactionsButton);
            this.groupBox3.Controls.Add(this.accountsDataGridView);
            this.groupBox3.Location = new System.Drawing.Point(285, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 511);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Accounts";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // categoriesAndRulesButton
            // 
            this.categoriesAndRulesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.categoriesAndRulesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesAndRulesButton.Location = new System.Drawing.Point(127, 274);
            this.categoriesAndRulesButton.Name = "categoriesAndRulesButton";
            this.categoriesAndRulesButton.Size = new System.Drawing.Size(219, 56);
            this.categoriesAndRulesButton.TabIndex = 15;
            this.categoriesAndRulesButton.Text = "Categories and Rules";
            this.categoriesAndRulesButton.UseVisualStyleBackColor = false;
            this.categoriesAndRulesButton.Visible = false;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(230, 455);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(103, 56);
            this.exportButton.TabIndex = 8;
            this.exportButton.Text = "Export to CSV";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // viewDataSetInfoButton
            // 
            this.viewDataSetInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewDataSetInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.viewDataSetInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewDataSetInfoButton.Location = new System.Drawing.Point(121, 455);
            this.viewDataSetInfoButton.Name = "viewDataSetInfoButton";
            this.viewDataSetInfoButton.Size = new System.Drawing.Size(103, 56);
            this.viewDataSetInfoButton.TabIndex = 7;
            this.viewDataSetInfoButton.Text = "View Dataset Info";
            this.viewDataSetInfoButton.UseVisualStyleBackColor = false;
            this.viewDataSetInfoButton.Click += new System.EventHandler(this.viewDataSetInfoButton_Click);
            // 
            // viewAccountTransactionsButton
            // 
            this.viewAccountTransactionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewAccountTransactionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.viewAccountTransactionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAccountTransactionsButton.Location = new System.Drawing.Point(12, 455);
            this.viewAccountTransactionsButton.Name = "viewAccountTransactionsButton";
            this.viewAccountTransactionsButton.Size = new System.Drawing.Size(103, 56);
            this.viewAccountTransactionsButton.TabIndex = 6;
            this.viewAccountTransactionsButton.Text = "View Transactions";
            this.viewAccountTransactionsButton.UseVisualStyleBackColor = false;
            this.viewAccountTransactionsButton.Click += new System.EventHandler(this.viewAccountTransactionsButton_Click);
            // 
            // accountsDataGridView
            // 
            this.accountsDataGridView.AllowUserToAddRows = false;
            this.accountsDataGridView.AllowUserToDeleteRows = false;
            this.accountsDataGridView.AllowUserToOrderColumns = true;
            this.accountsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountsDataGridView.Location = new System.Drawing.Point(6, 19);
            this.accountsDataGridView.Name = "accountsDataGridView";
            this.accountsDataGridView.ReadOnly = true;
            this.accountsDataGridView.RowHeadersVisible = false;
            this.accountsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountsDataGridView.Size = new System.Drawing.Size(485, 430);
            this.accountsDataGridView.TabIndex = 1;
            this.accountsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.accountsDataGridView_CellFormatting);
            this.accountsDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.accountsDataGridView_CellPainting);
            this.accountsDataGridView.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.accountsDataGridView_CellParsing);
            this.accountsDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.accountsDataGridView_CellValuePushed);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.retrieveBankUniqueReferenceTextBox);
            this.groupBox2.Controls.Add(this.viewAccountsButton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.retrieveAccountHolderIDTextBox);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(16, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 182);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client Bank Login";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Unique Reference:";
            // 
            // retrieveBankUniqueReferenceTextBox
            // 
            this.retrieveBankUniqueReferenceTextBox.Location = new System.Drawing.Point(11, 71);
            this.retrieveBankUniqueReferenceTextBox.Name = "retrieveBankUniqueReferenceTextBox";
            this.retrieveBankUniqueReferenceTextBox.Size = new System.Drawing.Size(193, 20);
            this.retrieveBankUniqueReferenceTextBox.TabIndex = 16;
            // 
            // viewAccountsButton
            // 
            this.viewAccountsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.viewAccountsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAccountsButton.Location = new System.Drawing.Point(118, 118);
            this.viewAccountsButton.Name = "viewAccountsButton";
            this.viewAccountsButton.Size = new System.Drawing.Size(103, 56);
            this.viewAccountsButton.TabIndex = 5;
            this.viewAccountsButton.Text = "View Accounts";
            this.viewAccountsButton.UseVisualStyleBackColor = false;
            this.viewAccountsButton.Click += new System.EventHandler(this.viewAccountsButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ID Number:";
            // 
            // retrieveAccountHolderIDTextBox
            // 
            this.retrieveAccountHolderIDTextBox.Location = new System.Drawing.Point(11, 32);
            this.retrieveAccountHolderIDTextBox.MaxLength = 13;
            this.retrieveAccountHolderIDTextBox.Name = "retrieveAccountHolderIDTextBox";
            this.retrieveAccountHolderIDTextBox.Size = new System.Drawing.Size(194, 20);
            this.retrieveAccountHolderIDTextBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(9, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 56);
            this.button1.TabIndex = 4;
            this.button1.Text = "Client Bank Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // createUserGroupBox
            // 
            this.createUserGroupBox.Controls.Add(this.accountHolderIDTextBox);
            this.createUserGroupBox.Controls.Add(this.localeTextBox);
            this.createUserGroupBox.Controls.Add(this.emailTextBox);
            this.createUserGroupBox.Controls.Add(this.label6);
            this.createUserGroupBox.Controls.Add(this.label5);
            this.createUserGroupBox.Controls.Add(this.label4);
            this.createUserGroupBox.Controls.Add(this.createUserButton);
            this.createUserGroupBox.Location = new System.Drawing.Point(16, 19);
            this.createUserGroupBox.Name = "createUserGroupBox";
            this.createUserGroupBox.Size = new System.Drawing.Size(263, 166);
            this.createUserGroupBox.TabIndex = 0;
            this.createUserGroupBox.TabStop = false;
            this.createUserGroupBox.Text = "Create User";
            // 
            // accountHolderIDTextBox
            // 
            this.accountHolderIDTextBox.Location = new System.Drawing.Point(9, 32);
            this.accountHolderIDTextBox.MaxLength = 13;
            this.accountHolderIDTextBox.Name = "accountHolderIDTextBox";
            this.accountHolderIDTextBox.Size = new System.Drawing.Size(194, 20);
            this.accountHolderIDTextBox.TabIndex = 0;
            // 
            // localeTextBox
            // 
            this.localeTextBox.Location = new System.Drawing.Point(9, 179);
            this.localeTextBox.Name = "localeTextBox";
            this.localeTextBox.Size = new System.Drawing.Size(194, 20);
            this.localeTextBox.TabIndex = 12;
            this.localeTextBox.Text = "en_ZA";
            this.localeTextBox.Visible = false;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(9, 77);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(196, 20);
            this.emailTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Locale";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ID Number:";
            // 
            // createUserButton
            // 
            this.createUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.createUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserButton.Location = new System.Drawing.Point(6, 103);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(103, 56);
            this.createUserButton.TabIndex = 2;
            this.createUserButton.Text = "Start Session";
            this.createUserButton.UseVisualStyleBackColor = false;
            this.createUserButton.Click += new System.EventHandler(this.createUserButton_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::BankTransactionAPIDemo.Properties.Resources.SmallLogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 205);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // finishSessionButton
            // 
            this.finishSessionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.finishSessionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishSessionButton.Location = new System.Drawing.Point(290, 240);
            this.finishSessionButton.Name = "finishSessionButton";
            this.finishSessionButton.Size = new System.Drawing.Size(219, 56);
            this.finishSessionButton.TabIndex = 16;
            this.finishSessionButton.Text = "Finish Session";
            this.finishSessionButton.UseVisualStyleBackColor = false;
            this.finishSessionButton.Visible = false;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 777);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TransactionGroupBox);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "Mainform";
            this.Text = "Simplifi Transactions Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mainform_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TransactionGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.createUserGroupBox.ResumeLayout(false);
            this.createUserGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label loginResultText;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox securityTokenTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox TransactionGroupBox;
        private System.Windows.Forms.GroupBox createUserGroupBox;
        private System.Windows.Forms.Button createUserButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox accountHolderIDTextBox;
        private System.Windows.Forms.TextBox localeTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button viewAccountsButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox retrieveAccountHolderIDTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button getUserListButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView accountsDataGridView;
        private System.Windows.Forms.Button viewAccountTransactionsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button viewDataSetInfoButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button categoriesAndRulesButton;
        private System.Windows.Forms.TextBox retrieveBankUniqueReferenceTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button finishSessionButton;
    }
}

