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
    public partial class UserListForm : Form
    {
        string token = "";
        public UserListForm()
        {
            InitializeComponent();
        }

        public UserListForm(string Token)
        {
            InitializeComponent();
            token = Token;
            loadUseRList();
        }

        private void loadUseRList()
        {
            try
            {

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                WebAPIResponse webAPIResponse  = RESTManager.Instance.CallGenericGetWithBearerTokenAuthentication(RESTManager.RequestTypeAction.auth, Properties.Settings.Default.SecurityURL+"/company/user/list", null, token);



                UserListResponse userListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserListResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                {

                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore

                });

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = userListResponse.users;
                userListDataGridView.DataSource = bindingSource;

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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void viewUserAccountsButton_Click(object sender, EventArgs e)
        {
            if (userListDataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = userListDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = userListDataGridView.Rows[selectedrowindex];
                string username = Convert.ToString(selectedRow.Cells["loginName"].Value);
                ViewUserAccountsForm viewUserAccountsForm = new ViewUserAccountsForm(token, username);
                viewUserAccountsForm.ShowDialog();
                viewUserAccountsForm.Dispose();
                this.BringToFront();

            }
            
        }
    }
}
