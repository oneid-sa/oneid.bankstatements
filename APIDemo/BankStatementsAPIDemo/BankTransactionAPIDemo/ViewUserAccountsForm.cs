using BankTransactionAPIDemo.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankTransactionAPIDemo
{
    public partial class ViewUserAccountsForm : Form
    {
        string token;
        string username;
        public ViewUserAccountsForm()
        {
            InitializeComponent();
        }

        public ViewUserAccountsForm(string Token, string Username)
        {
            InitializeComponent();
            token = Token;
            username = Username;
            loadAccounts();
        }

        private void loadAccounts()
        {
            try
            {

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericGetWithBearerTokenAuthentication(RESTManager.RequestTypeAction.auth, Properties.Settings.Default.SecurityURL + "/company/user/account?username=" + username, null, token);


                if (webAPIResponse.ResponseCode == 200)
                {

                    AccountResponse accountResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AccountResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    if (accountResponse == null)
                    {
                        MessageBox.Show("No accounts are linked to this user. Please make sure user is registered and  the client did a Bank Login !");
                        return;
                    }

                    if (accountResponse.account == null)
                    {
                        MessageBox.Show("No accounts are linked to this user. Please make sure user is registered and  the client did a Bank Login !");
                        return;
                    }

                    if (accountResponse.account.Count <= 0)
                    {
                        MessageBox.Show("No accounts are linked to this user. Please make sure user is registered and  the client did a Bank Login !");
                        return;
                    }

                    accountsDataGridView.ReadOnly = false;
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = accountResponse.account;
                    accountsDataGridView.DataSource = bindingSource;
                    accountsDataGridView.ReadOnly = true;
                }
                else
                {
                    throw new Exception(String.Format("Call was not succesfull. Response Code {0} with reason {1} has been returned. Detail : {2}", webAPIResponse.ResponseCode, webAPIResponse.ResponseDescription, webAPIResponse.ResponseResult));
                }

                //if (webAPIResponse.ResponseCode == 200)
                //{
                //    MessageBox.Show("Success");
                //}
                //else
                //{
                //    throw new Exception(String.Format("Call was not succesfull. Response Code {0} with reason {1} has been returned. Detail : {2}", webAPIResponse.ResponseCode, webAPIResponse.ResponseDescription, webAPIResponse.ResponseResult));
                //}

                //userListTextBox.Text = response;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void viewAccountTransactionsButton_Click(object sender, EventArgs e)
        {
            if (accountsDataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = accountsDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = accountsDataGridView.Rows[selectedrowindex];
                string container = Convert.ToString(selectedRow.Cells["CONTAINER"].Value);
                int accountID = Convert.ToInt32(selectedRow.Cells["id"].Value);
                ViewTransactionsForm viewTransactionsForm = new ViewTransactionsForm(token, username, container, accountID, "");
                viewTransactionsForm.ShowDialog();
                viewTransactionsForm.Dispose();
                this.BringToFront();

            }
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void viewDataSetInfoButton_Click(object sender, EventArgs e)
        {
            if (accountsDataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = accountsDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = accountsDataGridView.Rows[selectedrowindex];
                Account account = (Account)selectedRow.DataBoundItem;               
                ViewAccountDataSets viewAccountDataSets = new ViewAccountDataSets(account);
                viewAccountDataSets.ShowDialog();
                viewAccountDataSets.Dispose();
                this.BringToFront();

            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (accountsDataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = username + "-AccountsOutput.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
                            accountsDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                            // Select all the cells
                            accountsDataGridView.SelectAll();
                            // Copy selected cells to DataObject
                            DataObject dataObject = accountsDataGridView.GetClipboardContent();
                            // Get the text of the DataObject, and serialize it to a file
                            File.WriteAllText(sfd.FileName, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
                            //int columnCount = transactionListDataGridView.Columns.Count;
                            //string columnNames = "";
                            //string[] outputCsv = new string[transactionListDataGridView.Rows.Count + 1];
                            //for (int i = 0; i < columnCount; i++)
                            //{
                            //    columnNames += transactionListDataGridView.Columns[i].HeaderText.ToString() + ",";
                            //}
                            //outputCsv[0] += columnNames;

                            //for (int i = 1; (i - 1) < transactionListDataGridView.Rows.Count; i++)
                            //{
                            //    for (int j = 0; j < columnCount; j++)
                            //    {
                            //        outputCsv[i] += transactionListDataGridView.Rows[i - 1].Cells[j].Value.ToString() + ",";
                            //    }
                            //}

                            //File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Data To Export !!!", "Info");
            }
        }

        private void accountsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((accountsDataGridView.Rows[e.RowIndex].DataBoundItem != null) &&
      (accountsDataGridView.Columns[e.ColumnIndex].DataPropertyName.Contains("balance")))
            {
                string amount = "";
                Amount amountObject = (Amount)accountsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                amount = amountObject.currency + " " + amountObject.amount.ToString();
                //accountsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = amount;
                e.Value = amount;
            }
        }
    }
}
