using BankTransactionManagement.models;
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

namespace BankTransactionManagement
{
    public partial class AuditLogForm : Form
    {
        Company company = null;
        string token = "";
        public AuditLogForm(Company CompanyValue, string Token)
        {
            InitializeComponent();
            company = CompanyValue;
            token = Token;
            var currentDate = DateTime.Now;
            dateFromDateTimePicker.Value = currentDate.AddDays(-30);
            dateToDateTimePicker.Value = currentDate;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void viewUsageAuditsButton_Click(object sender, EventArgs e)
        {
            loadUsageData();
        }

        private void loadUsageData()
        {
            try
            {

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";
                AuditRequest auditRequest = new AuditRequest();
                auditRequest.companyId = company.id;
                auditRequest.limit = 1000000;
                auditRequest.page_no = 0;
                auditRequest.sortby = "created_at";
                auditRequest.start_date = dateFromDateTimePicker.Value.ToString("yyyy-MM-dd");
                auditRequest.end_date = dateToDateTimePicker.Value.ToString("yyyy-MM-dd");

                if (Properties.Settings.Default.SaveJSON)
                {
                    File.WriteAllText("UsageAuditListRequest.JSON", auditRequest.ToJSON());
                }


                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<WebAPIResponse>("", Properties.Settings.Default.SecurityURL + "/auth/auditlog/history", auditRequest.ToJSON(), null, token);

                if (webAPIResponse.ResponseCode == 200)
                {

                    if (Properties.Settings.Default.SaveJSON)
                    {
                        File.WriteAllText("UsageAuditListResponse.JSON", webAPIResponse.ResponseResult);
                    }

                    AuditListResponse auditListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AuditListResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });


                    if (auditListResponse == null)
                    {
                        MessageBox.Show("No usage audits were returned for this company !");
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }

                    if (auditListResponse.tableAuditLogs == null)
                    {
                        MessageBox.Show("No usage audits were returned for this company !");
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }

                    if (auditListResponse.tableAuditLogs.content == null)
                    {
                        MessageBox.Show("No usage audits were returned for this company !");
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }

                    if (auditListResponse.tableAuditLogs.content.Count <= 0)
                    {
                        MessageBox.Show("No usage audits were returned for this company !");
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }

                    //usageAuditsDataGridView.Items.Clear();

                    //var uniqueCategoryTypes = transactionResponse.transaction.Where(item => item.categoryType != null).Select(item => item.categoryType).Distinct().ToList();
                    ////aggrgrationsListView.View = View.List;
                    ////SetHeight(aggrgrationsListView, 50);
                    //foreach (string categoryType in uniqueCategoryTypes)
                    //{
                    //    double total = transactionResponse.transaction.Where(sumItem => sumItem.categoryType == categoryType).Where(sumItem => sumItem.amount != null).Sum(sumItem => sumItem.amount.amount);
                    //    ListViewItem item = new ListViewItem(new string[] { categoryType, Math.Round(total, 2).ToString() }, 0);
                    //    aggrgrationsListView.Items.Add(item);
                    //}

                    //var baseTypes = transactionResponse.transaction.Select(item => item.baseType).Distinct().ToList();
                    ////aggrgrationsListView.View = View.List;
                    ////SetHeight(aggrgrationsListView, 50);
                    //foreach (string baseType in baseTypes)
                    //{
                    //    double total = transactionResponse.transaction.Where(sumItem => sumItem.baseType == baseType).Where(sumItem => sumItem.amount != null).Sum(sumItem => sumItem.amount.amount);
                    //    ListViewItem item = new ListViewItem(new string[] { baseType, Math.Round(total, 2).ToString() }, 0);
                    //    //item.BackColor = Color.Gray;
                    //    aggrgrationsListView.Items.Add(item);
                    //}

                    //var categories = transactionResponse.transaction.Select(item => item.category).Distinct().ToList();
                    //categoryListView.Items.Clear();
                    ////aggrgrationsListView.View = View.List;
                    ////SetHeight(aggrgrationsListView, 50);
                    //foreach (string category in categories)
                    //{
                    //    double total = transactionResponse.transaction.Where(sumItem => sumItem.category == category).Where(sumItem => sumItem.amount != null).Sum(sumItem => sumItem.amount.amount);
                    //    ListViewItem item = new ListViewItem(new string[] { category, Math.Round(total, 2).ToString() }, 0);
                    //    //item.BackColor = Color.Gray;
                    //    categoryListView.Items.Add(item);
                    //}

                    //double expensesTotal = transactionResponse.transaction.Where(item => item.categoryType == "EXPENSE").Sum(item => item.amount.amount);
                    //double incomeTotal = transactionResponse.transaction.Where(item => item.categoryType == "INCOME").Sum(item => item.amount.amount);
                    //aggrgrationsListView.View = View.Tile;
                    //SetHeight(aggrgrationsListView, 25);
                    //ListViewItem expensesItem = new ListViewItem(new string[] {"Expenses", Math.Round(expensesTotal,2).ToString() }, 0);
                    //ListViewItem incomeItem = new ListViewItem(new string[] { "Income", Math.Round(incomeTotal, 2).ToString() }, 0);
                    //aggrgrationsListView.Items.Add(expensesItem);
                    //aggrgrationsListView.Items.Add(incomeItem);


                    IEnumerable<AuditResponse> filteredlist = auditListResponse.tableAuditLogs.content.Where(item => item.message.Contains("USER-TRANSACTIONS")).ToList();

                    

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = filteredlist;
                    usageAuditsDataGridView.DataSource = bindingSource;


                    CountLabel.Text = String.Format("{0} records returned ", usageAuditsDataGridView.Rows.Count);
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

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (usageAuditsDataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = company.companyName + "-UsageAuditsOutputOutput" + dateFromDateTimePicker.Value.ToString("yyyy-MM-dd") + "-" + dateToDateTimePicker.Value.ToString("yyyy-MM-dd") +".csv";
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
                            usageAuditsDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                            // Select all the cells
                            usageAuditsDataGridView.SelectAll();
                            // Copy selected cells to DataObject
                            DataObject dataObject = usageAuditsDataGridView.GetClipboardContent();
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
    }
}
