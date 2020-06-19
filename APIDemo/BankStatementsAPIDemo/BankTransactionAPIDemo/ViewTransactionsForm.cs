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
    public partial class ViewTransactionsForm : Form
    {
        string token;
        string username;
        string container;
        int accountid;
        string fromDate;
        string toDate;
        string uniquereference;

        //2013-02-04

        public ViewTransactionsForm(string Token, string Username, string Container, int Accountid, string UniqueReference)
        {
            InitializeComponent();
            token = Token;
            username = Username;
            container = Container;
            accountid = Accountid;
            var currentDate = DateTime.Now;
            dateFromDateTimePicker.Value = currentDate.AddDays(-90);
            dateToDateTimePicker.Value = currentDate;
            toDate = currentDate.ToString("yyyy-MM-dd");
            fromDate = currentDate.AddDays(-90).ToString("yyyy-MM-dd");
            uniquereference = UniqueReference;
            loadTransactions();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void loadTransactions()
        {
            try
            {

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";
                AccountTransactionRequest accountTransactionRequest = new AccountTransactionRequest();
                accountTransactionRequest.accountHolderIdentifier = username;
                accountTransactionRequest.accountid = accountid.ToString();
                accountTransactionRequest.container = container;
                accountTransactionRequest.fromDate = fromDate;
                accountTransactionRequest.toDate = toDate;
                accountTransactionRequest.uniqueReference = uniquereference;

                if (Properties.Settings.Default.SaveJSON)
                {
                    File.WriteAllText("TransactionListRequest.JSON", accountTransactionRequest.ToJSON());
                }



                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<WebAPIResponse>("", Properties.Settings.Default.SecurityURL + "/company/user/transactions", accountTransactionRequest.ToJSON(), null, token);

                if (webAPIResponse.ResponseCode == 200)
                {

                    if (Properties.Settings.Default.SaveJSON)
                    {
                        File.WriteAllText("TransactionListResponse.JSON", webAPIResponse.ResponseResult);
                    }

                    TransactionResponse transactionResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TransactionResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });


                    if (transactionResponse == null)
                    {
                        MessageBox.Show("No transactions were returned for this account !");
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }

                    if (transactionResponse.transaction == null)
                    {
                        MessageBox.Show("No transactions were returned for this account !");
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }

                    aggrgrationsListView.Items.Clear();

                    var uniqueCategoryTypes = transactionResponse.transaction.Where(item => item.categoryType != null).Select(item => item.categoryType).Distinct().ToList();
                    //aggrgrationsListView.View = View.List;
                    //SetHeight(aggrgrationsListView, 50);
                    foreach (string categoryType in uniqueCategoryTypes)
                    {
                        double total = transactionResponse.transaction.Where(sumItem => sumItem.categoryType == categoryType).Where(sumItem => sumItem.amount != null).Sum(sumItem => sumItem.amount.amount);
                        ListViewItem item = new ListViewItem(new string[] { categoryType, Math.Round(total, 2).ToString() }, 0);
                        aggrgrationsListView.Items.Add(item);
                    }

                    var baseTypes = transactionResponse.transaction.Select(item => item.baseType).Distinct().ToList();
                    //aggrgrationsListView.View = View.List;
                    //SetHeight(aggrgrationsListView, 50);
                    foreach (string baseType in baseTypes)
                    {
                        double total = transactionResponse.transaction.Where(sumItem => sumItem.baseType == baseType).Where(sumItem => sumItem.amount != null).Sum(sumItem => sumItem.amount.amount);
                        ListViewItem item = new ListViewItem(new string[] { baseType, Math.Round(total, 2).ToString() }, 0);
                        //item.BackColor = Color.Gray;
                        aggrgrationsListView.Items.Add(item);
                    }

                    var categories = transactionResponse.transaction.Select(item => item.category).Distinct().ToList();
                    categoryListView.Items.Clear();
                    //aggrgrationsListView.View = View.List;
                    //SetHeight(aggrgrationsListView, 50);
                    foreach (string category in categories)
                    {
                        double total = transactionResponse.transaction.Where(sumItem => sumItem.category == category).Where(sumItem => sumItem.amount != null).Sum(sumItem => sumItem.amount.amount);
                        ListViewItem item = new ListViewItem(new string[] { category, Math.Round(total, 2).ToString() }, 0);
                        //item.BackColor = Color.Gray;
                        categoryListView.Items.Add(item);
                    }

                    //double expensesTotal = transactionResponse.transaction.Where(item => item.categoryType == "EXPENSE").Sum(item => item.amount.amount);
                    //double incomeTotal = transactionResponse.transaction.Where(item => item.categoryType == "INCOME").Sum(item => item.amount.amount);
                    //aggrgrationsListView.View = View.Tile;
                    //SetHeight(aggrgrationsListView, 25);
                    //ListViewItem expensesItem = new ListViewItem(new string[] {"Expenses", Math.Round(expensesTotal,2).ToString() }, 0);
                    //ListViewItem incomeItem = new ListViewItem(new string[] { "Income", Math.Round(incomeTotal, 2).ToString() }, 0);
                    //aggrgrationsListView.Items.Add(expensesItem);
                    //aggrgrationsListView.Items.Add(incomeItem);


                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = transactionResponse.transaction;
                    transactionListDataGridView.DataSource = bindingSource;
                } else
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

        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        private void copyAlltoClipboard()
        {
            transactionListDataGridView.SelectAll();
            DataObject dataObj = transactionListDataGridView.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void refreshTransactionsButton_Click(object sender, EventArgs e)
        {
            if (dateFromDateTimePicker.Value > dateToDateTimePicker.Value)
            {
                MessageBox.Show("Date From cannot be later than Date To");
                return;
            }
            toDate = dateToDateTimePicker.Value.ToString("yyyy-MM-dd");
            fromDate = dateFromDateTimePicker.Value.ToString("yyyy-MM-dd");
            loadTransactions();
        }

        private void aggrgrationsListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            if ((e.State & ListViewItemStates.Selected) != 0)
                e.DrawFocusRectangle();

            Rectangle bounds = e.Bounds;
            Font font = ((ListView)sender).Font;
            Font nameFont = new Font(font.FontFamily,
                font.Size,
                FontStyle.Underline | FontStyle.Bold,
                font.Unit,
                font.GdiCharSet,
                font.GdiVerticalFont);

            using (StringFormat sf = new StringFormat())
            {
                e.Graphics.DrawString(e.Item.SubItems[0].Text,
                    nameFont, Brushes.Black, bounds, sf);
                bounds.Y += 17;
                for (int i = 1; i < e.Item.SubItems.Count; ++i, bounds.Y += 15)
                    e.Graphics.DrawString(e.Item.SubItems[i].Text,
                        font, Brushes.Black, bounds, sf);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (transactionListDataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = username + "-TransactionsOutput.csv";
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
                            transactionListDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                            // Select all the cells
                            transactionListDataGridView.SelectAll();
                            // Copy selected cells to DataObject
                            DataObject dataObject = transactionListDataGridView.GetClipboardContent();
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

        private void transactionListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((transactionListDataGridView.Rows[e.RowIndex].DataBoundItem != null) &&
(transactionListDataGridView.Columns[e.ColumnIndex].DataPropertyName.Contains("amount")))
            {
                if (transactionListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string amount = "";
                    Amount amountObject = (Amount)transactionListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    amount = amountObject.currency + " " + amountObject.amount.ToString();
                    //accountsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = amount;
                    e.Value = amount;
                }
            }
            if ((transactionListDataGridView.Rows[e.RowIndex].DataBoundItem != null) &&
(transactionListDataGridView.Columns[e.ColumnIndex].DataPropertyName.Contains("price")))
            {
                if (transactionListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string amount = "";
                    Amount amountObject = (Amount)transactionListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    amount = amountObject.currency + " " + amountObject.amount.ToString();
                    //accountsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = amount;
                    e.Value = amount;
                }
            }
            if ((transactionListDataGridView.Rows[e.RowIndex].DataBoundItem != null) &&
(transactionListDataGridView.Columns[e.ColumnIndex].DataPropertyName.Contains("comission")))
            {
                if (transactionListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string amount = "";
                    Amount amountObject = (Amount)transactionListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    amount = amountObject.currency + " " + amountObject.amount.ToString();
                    //accountsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = amount;
                    e.Value = amount;
                }
            }
        }

        private void transactionListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
