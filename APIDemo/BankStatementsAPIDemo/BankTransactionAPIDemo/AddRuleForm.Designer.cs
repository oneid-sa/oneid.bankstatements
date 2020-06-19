namespace BankTransactionAPIDemo
{
    partial class AddRuleForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.createRuleButton = new System.Windows.Forms.Button();
            this.parentCategoryNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldComboBox = new System.Windows.Forms.ComboBox();
            this.operationComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(111, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 56);
            this.button1.TabIndex = 38;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // createRuleButton
            // 
            this.createRuleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.createRuleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRuleButton.Location = new System.Drawing.Point(2, 180);
            this.createRuleButton.Name = "createRuleButton";
            this.createRuleButton.Size = new System.Drawing.Size(103, 56);
            this.createRuleButton.TabIndex = 37;
            this.createRuleButton.Text = "Create Rule";
            this.createRuleButton.UseVisualStyleBackColor = false;
            // 
            // parentCategoryNameTextBox
            // 
            this.parentCategoryNameTextBox.Enabled = false;
            this.parentCategoryNameTextBox.Location = new System.Drawing.Point(12, 25);
            this.parentCategoryNameTextBox.Name = "parentCategoryNameTextBox";
            this.parentCategoryNameTextBox.Size = new System.Drawing.Size(196, 20);
            this.parentCategoryNameTextBox.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Field:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Category:";
            // 
            // fieldComboBox
            // 
            this.fieldComboBox.FormattingEnabled = true;
            this.fieldComboBox.Items.AddRange(new object[] {
            "description",
            "amount"});
            this.fieldComboBox.Location = new System.Drawing.Point(12, 64);
            this.fieldComboBox.Name = "fieldComboBox";
            this.fieldComboBox.Size = new System.Drawing.Size(196, 21);
            this.fieldComboBox.TabIndex = 39;
            // 
            // operationComboBox
            // 
            this.operationComboBox.FormattingEnabled = true;
            this.operationComboBox.Items.AddRange(new object[] {
            "description",
            "amount"});
            this.operationComboBox.Location = new System.Drawing.Point(12, 104);
            this.operationComboBox.Name = "operationComboBox";
            this.operationComboBox.Size = new System.Drawing.Size(196, 21);
            this.operationComboBox.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Operation:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 20);
            this.textBox1.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Value:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(231, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(448, 220);
            this.dataGridView1.TabIndex = 44;
            // 
            // AddRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 244);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.operationComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fieldComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createRuleButton);
            this.Controls.Add(this.parentCategoryNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddRuleForm";
            this.Text = "Add Rule";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button createRuleButton;
        private System.Windows.Forms.TextBox parentCategoryNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fieldComboBox;
        private System.Windows.Forms.ComboBox operationComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}