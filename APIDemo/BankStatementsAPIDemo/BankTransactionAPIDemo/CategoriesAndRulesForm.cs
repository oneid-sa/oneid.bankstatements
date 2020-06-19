using BankTransactionAPIDemo.models;
using Newtonsoft.Json;
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
    public partial class CategoriesAndRulesForm : Form
    {
        private string token;
        private string username;
        public CategoriesAndRulesForm(string Token, String UserName)
        {
            InitializeComponent();
            username = UserName;
            token = Token;
            loadCategories();
            loadRules();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void loadRules()
        {
            try
            {

                //userDefinedRuleId

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericGetWithBearerTokenAuthentication(RESTManager.RequestTypeAction.auth, Properties.Settings.Default.BankStatementsURL + String.Format("/company/user/rules/list?username={0}", username), null, token);


                if (webAPIResponse.ResponseCode == 200)
                {


                    List<CategoryRuleResponseItem> categoryRuleResponseItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CategoryRuleResponseItem>>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    if (categoryRuleResponseItemList == null)
                    {
                        MessageBox.Show("No rules were returned !");
                        return;
                    }



                    if (categoryRuleResponseItemList.Count <= 0)
                    {
                        MessageBox.Show("No rules were returned !");
                        return;
                    }

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = categoryRuleResponseItemList;
                    rulesListDataGridView.DataSource = bindingSource;
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

        private void runCategorisationRule()
        {
            try
            {

                int ruleID = -1;

                if (rulesListDataGridView.SelectedRows.Count <= 0)
                {
                    return;
                }

                int selectedrowindex = rulesListDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = rulesListDataGridView.Rows[selectedrowindex];
                CategoryRuleResponseItem categoryRuleResponseItem = (CategoryRuleResponseItem)selectedRow.DataBoundItem;

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericGetWithBearerTokenAuthentication(RESTManager.RequestTypeAction.auth, Properties.Settings.Default.BankStatementsURL + String.Format("/company/user/rules/run?username={0}&ruleid={1}", username, categoryRuleResponseItem.userDefinedRuleId), null, token);


                if (webAPIResponse.ResponseCode == 200)
                {

                    MessageBox.Show("Success");
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




        private void loadCategories()
        {
            try
            {

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericGetWithBearerTokenAuthentication(RESTManager.RequestTypeAction.auth, Properties.Settings.Default.BankStatementsURL + String.Format("/company/user/categories/list?cobrandLevel=false&userLevel=true&username={0}", username), null, token);


                if (webAPIResponse.ResponseCode == 200)
                {


                    CategoryListResponse categoryListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoryListResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    if (categoryListResponse == null)
                    {
                        MessageBox.Show("No categories were returned !");
                        return;
                    }

                    if (categoryListResponse.transactionCategory == null)
                    {
                        MessageBox.Show("No categories were returned !");
                        return;
                    }

                    if (categoryListResponse.transactionCategory.Count <= 0)
                    {
                        MessageBox.Show("No categories were returned !");
                        return;
                    }

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = categoryListResponse.transactionCategory;
                    categoryDataGridView.DataSource = bindingSource;
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

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            if (categoryDataGridView.SelectedRows.Count > 0)
            {
                int selectedrowindex = categoryDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = categoryDataGridView.Rows[selectedrowindex];
                Category category = (Category)selectedRow.DataBoundItem;
                string parentID = category.id.ToString();
                string parentcategory = category.category;                
                AddCategoryForm addCategoryForm = new AddCategoryForm(parentcategory, parentID, username, token);
                if (addCategoryForm.ShowDialog() == DialogResult.OK)
                {
                    loadCategories();
                }
                addCategoryForm.Dispose();
                this.BringToFront();
            }
        }

        private void CategoriesAndRulesForm_Shown(object sender, EventArgs e)
        {
            categoryDataGridView.Width = Convert.ToInt32((this.Width / 2) * 0.8);
            rulesListDataGridView.Width = Convert.ToInt32((this.Width / 2) * 0.8);
            rulesListDataGridView.Left = Convert.ToInt32((categoryDataGridView.Left + categoryDataGridView.Width) * 1.2);

        }

        private void CategoriesAndRulesForm_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }

}
