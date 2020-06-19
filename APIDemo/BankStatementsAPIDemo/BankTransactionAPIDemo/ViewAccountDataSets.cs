using BankTransactionAPIDemo.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankTransactionAPIDemo
{
    
    public partial class ViewAccountDataSets : Form
    {
        Account accountValue;
        public ViewAccountDataSets(Account AccountValue)
        {
            InitializeComponent();
            accountValue = AccountValue;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = accountValue.dataset;
            accountDatasetViewdataGridView.DataSource = bindingSource;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
