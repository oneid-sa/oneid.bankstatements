namespace BankTransactionAPIDemo
{
    partial class AddCategoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.parentCategoryNameTextBox = new System.Windows.Forms.TextBox();
            this.newCategoryNameTextBox = new System.Windows.Forms.TextBox();
            this.createCategoryButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parent Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Category Name:";
            // 
            // parentCategoryNameTextBox
            // 
            this.parentCategoryNameTextBox.Enabled = false;
            this.parentCategoryNameTextBox.Location = new System.Drawing.Point(12, 25);
            this.parentCategoryNameTextBox.Name = "parentCategoryNameTextBox";
            this.parentCategoryNameTextBox.Size = new System.Drawing.Size(196, 20);
            this.parentCategoryNameTextBox.TabIndex = 2;
            // 
            // newCategoryNameTextBox
            // 
            this.newCategoryNameTextBox.Location = new System.Drawing.Point(12, 64);
            this.newCategoryNameTextBox.Name = "newCategoryNameTextBox";
            this.newCategoryNameTextBox.Size = new System.Drawing.Size(196, 20);
            this.newCategoryNameTextBox.TabIndex = 3;
            // 
            // createCategoryButton
            // 
            this.createCategoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.createCategoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createCategoryButton.Location = new System.Drawing.Point(12, 94);
            this.createCategoryButton.Name = "createCategoryButton";
            this.createCategoryButton.Size = new System.Drawing.Size(103, 56);
            this.createCategoryButton.TabIndex = 31;
            this.createCategoryButton.Text = "Create Category";
            this.createCategoryButton.UseVisualStyleBackColor = false;
            this.createCategoryButton.Click += new System.EventHandler(this.createCategoryButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(124, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 56);
            this.button1.TabIndex = 32;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 157);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createCategoryButton);
            this.Controls.Add(this.newCategoryNameTextBox);
            this.Controls.Add(this.parentCategoryNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddCategoryForm";
            this.Text = "Add Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox parentCategoryNameTextBox;
        private System.Windows.Forms.TextBox newCategoryNameTextBox;
        private System.Windows.Forms.Button createCategoryButton;
        private System.Windows.Forms.Button button1;
    }
}