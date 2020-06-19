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
    public partial class AddCategoryForm : Form
    {
        string parentCategoryName;
        string parentCategoryID;
        string userName;
        string token;

        public AddCategoryForm(string ParentCategoryName, string ParentCategoryID, string UserName, string Token)
        {
            InitializeComponent();
            parentCategoryName = ParentCategoryName;
            parentCategoryID = ParentCategoryID;
            userName = UserName;
            token = Token;
            parentCategoryNameTextBox.Text = parentCategoryName;
        }

        private void createCategoryButton_Click(object sender, EventArgs e)
        {
            createCategory();
        }

        private void createCategory()
        {
            try
            {
                //if (!this.ValidateChildren())
                //{
                //    return;
                //}

                if (newCategoryNameTextBox.Text.Trim().Length <=0)
                {
                    MessageBox.Show("Category name needs a value !");
                    newCategoryNameTextBox.Focus();
                    return;
                }

                NewCategoryRequest newCategoryRequest = new NewCategoryRequest();
                newCategoryRequest.categoryName = newCategoryNameTextBox.Text;
                newCategoryRequest.parentCategoryId = parentCategoryID;
                newCategoryRequest.username = userName;

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<string>("company/user/categories/create", Properties.Settings.Default.SecurityURL, newCategoryRequest.ToJSON(), null, token);

                if (webAPIResponse.ResponseCode == 200)
                {
                    MessageBox.Show("Success !");
                    this.DialogResult = DialogResult.OK;
                    return;

                }
                else
                {
                    throw new Exception(String.Format("Call was not succesfull. Response Code {0} with reason {1} has been returned. Detail : {2}", webAPIResponse.ResponseCode, webAPIResponse.ResponseDescription, webAPIResponse.ResponseResult));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
