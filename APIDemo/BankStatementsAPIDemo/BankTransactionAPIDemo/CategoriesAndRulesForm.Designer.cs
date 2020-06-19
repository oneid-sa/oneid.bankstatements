namespace BankTransactionAPIDemo
{
    partial class CategoriesAndRulesForm
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
            this.categoryDataGridView = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.addRuleButton = new System.Windows.Forms.Button();
            this.rulesListDataGridView = new System.Windows.Forms.DataGridView();
            this.ruleCategorizationRuleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rulesListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryDataGridView
            // 
            this.categoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.categoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoryDataGridView.Location = new System.Drawing.Point(12, 12);
            this.categoryDataGridView.MultiSelect = false;
            this.categoryDataGridView.Name = "categoryDataGridView";
            this.categoryDataGridView.ReadOnly = true;
            this.categoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoryDataGridView.Size = new System.Drawing.Size(643, 514);
            this.categoryDataGridView.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(230, 539);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(103, 56);
            this.closeButton.TabIndex = 24;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addCategoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.addCategoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategoryButton.Location = new System.Drawing.Point(12, 539);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(103, 56);
            this.addCategoryButton.TabIndex = 25;
            this.addCategoryButton.Text = "Add Category";
            this.addCategoryButton.UseVisualStyleBackColor = false;
            this.addCategoryButton.Click += new System.EventHandler(this.addCategoryButton_Click);
            // 
            // addRuleButton
            // 
            this.addRuleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addRuleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.addRuleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRuleButton.Location = new System.Drawing.Point(121, 539);
            this.addRuleButton.Name = "addRuleButton";
            this.addRuleButton.Size = new System.Drawing.Size(103, 56);
            this.addRuleButton.TabIndex = 26;
            this.addRuleButton.Text = "Add Rule";
            this.addRuleButton.UseVisualStyleBackColor = false;
            // 
            // rulesListDataGridView
            // 
            this.rulesListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rulesListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rulesListDataGridView.Location = new System.Drawing.Point(674, 12);
            this.rulesListDataGridView.Name = "rulesListDataGridView";
            this.rulesListDataGridView.Size = new System.Drawing.Size(601, 514);
            this.rulesListDataGridView.TabIndex = 27;
            // 
            // ruleCategorizationRuleButton
            // 
            this.ruleCategorizationRuleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ruleCategorizationRuleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ruleCategorizationRuleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruleCategorizationRuleButton.Location = new System.Drawing.Point(674, 539);
            this.ruleCategorizationRuleButton.Name = "ruleCategorizationRuleButton";
            this.ruleCategorizationRuleButton.Size = new System.Drawing.Size(103, 56);
            this.ruleCategorizationRuleButton.TabIndex = 28;
            this.ruleCategorizationRuleButton.Text = "Run Categorization Rule";
            this.ruleCategorizationRuleButton.UseVisualStyleBackColor = false;
            // 
            // CategoriesAndRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 607);
            this.Controls.Add(this.ruleCategorizationRuleButton);
            this.Controls.Add(this.rulesListDataGridView);
            this.Controls.Add(this.addRuleButton);
            this.Controls.Add(this.addCategoryButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.categoryDataGridView);
            this.Name = "CategoriesAndRulesForm";
            this.Text = "Categories And Rules";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CategoriesAndRulesForm_Load);
            this.Shown += new System.EventHandler(this.CategoriesAndRulesForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rulesListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView categoryDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.Button addRuleButton;
        private System.Windows.Forms.DataGridView rulesListDataGridView;
        private System.Windows.Forms.Button ruleCategorizationRuleButton;
    }
}