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
    public partial class Mainform : Form
    {

        bool loggedin = false;
        public Mainform()
        {
            InitializeComponent();
            securityTokenTextBox.Enabled = false;
            usernameTextbox.Text = Properties.Settings.Default.UserName;
            passwordTextbox.Text = Properties.Settings.Default.Password;
            performLogin();
            listCompanies();

        }

        public void validateValues(TextBox[] Textboxes, String[] ErrorValidationMessages)
        {
            bool result = false;
            int counter = 0;


            try
            {
                if (Textboxes.Length != ErrorValidationMessages.Length)
                {
                    throw new Exception("Textbox count and message count are not equal !!");
                }

                foreach (TextBox textbox in Textboxes)
                {
                    if (textbox.Text.Trim() == "")
                    {
                        textbox.Focus();
                        throw new Exception(ErrorValidationMessages[counter]);

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }


        private void performLogin()
        {

            MessageForm messageForm = null;
            try
            {
                loggedin = false;
                
                //AutoClosingMessageBox.Show("Logging User in", "Login", 2000);

                messageForm = new MessageForm("Logging System User in", Properties.Resources.SmallLogo);
                messageForm.Show();


                validateValues(new TextBox[] { usernameTextbox, passwordTextbox }, new String[] { "Username needs a value ! ", "Password needs a value !" });
                Login login = new Login();
                login.username = usernameTextbox.Text;
                login.password = passwordTextbox.Text;

                if (Properties.Settings.Default.SaveJSON)
                {
                    File.WriteAllText("LoginRequest.JSON", login.ToJSON());
                }

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<string>("auth", Properties.Settings.Default.SecurityURL, login.ToJSON(), null, "");

                string jsonResult = webAPIResponse.ResponseResult;

                if (webAPIResponse.ResponseCode == 200)
                {

                    if (Properties.Settings.Default.SaveJSON)
                    {
                        File.WriteAllText("LoginResponse.JSON", jsonResult);
                    }

                    LoginResponse loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(Convert.ToString(jsonResult), new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    securityTokenTextBox.Text = loginResponse.token;
                    loginResultText.Text = loginResponse.message;

                }
                else
                {
                    throw new Exception("Error occured. Response code : " + webAPIResponse.ResponseCode.ToString() + ", Reason : " + webAPIResponse.ResponseDescription + ", Detail : -----------\n" + webAPIResponse.ResponseResult + "-----------\n");
                }

                messageForm.Close();
                messageForm.Dispose();
                loggedin = true;
                //resultJSONTextBox.Text = jsonResult;
            }
            catch (Exception ex)
            {
                if (messageForm != null)
                {
                    messageForm.Close();
                    messageForm.Dispose();
                }

                if (Properties.Settings.Default.ShowErrorMessageDetail)
                {
                    MessageBox.Show(ex.ToString());
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                loggedin = false;

            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            performLogin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewCompaniesButton_Click(object sender, EventArgs e)
        {
            listCompanies();
        }

        private void listCompanies()
        {
            
            try
            {

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericGetWithBearerTokenAuthentication(RESTManager.RequestTypeAction.auth, Properties.Settings.Default.SecurityURL + "/auth/company/list", null, securityTokenTextBox.Text);


                if (Properties.Settings.Default.SaveJSON)
                {
                    File.WriteAllText("CompanyList.json", webAPIResponse.ResponseResult);
                }



                if (webAPIResponse.ResponseCode == 200)
                {
                    CompanyListResponse companyListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<CompanyListResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = companyListResponse.companys;
                    companiesDataGridView.DataSource = bindingSource;

                    //foreach (DataGridViewRow row in companiesDataGridView.Rows)
                    //{
                    //    if (row.Cells["status"].Value != null)
                    //    {
                    //        string status = row.Cells["status"].Value.ToString().ToUpper();

                    //        if (status == "Y")
                    //        {
                    //            row.DefaultCellStyle.BackColor = Color.Green;
                    //            row.DefaultCellStyle.ForeColor = Color.White;
                    //        }
                    //        else if (status == "N")
                    //        {
                    //            row.DefaultCellStyle.BackColor = Color.Crimson;
                    //            row.DefaultCellStyle.ForeColor = Color.White;
                    //        }
                    //    }
                    //}

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

        private void loadUseRList()
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddUpdateUser addUpdateUser = new AddUpdateUser(1, new Company(), securityTokenTextBox.Text);
            addUpdateUser.ShowDialog();
            addUpdateUser.Dispose();
            listCompanies();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (companiesDataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = companiesDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = companiesDataGridView.Rows[selectedrowindex];
                AddUpdateUser addUpdateUser = new AddUpdateUser(2, (selectedRow.DataBoundItem as Company), securityTokenTextBox.Text);
                addUpdateUser.ShowDialog();
                addUpdateUser.Dispose();
                listCompanies();
                this.BringToFront();

            }
            else
            {
                MessageBox.Show("No companies have been selected.");
            }
        }

        private void activateDeactivateButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (companiesDataGridView.SelectedCells.Count <= 0)
                {
                    return;
                }

                if (MessageBox.Show("Are you sure you want to continue ?", "Change Company Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                int selectedrowindex = companiesDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = companiesDataGridView.Rows[selectedrowindex];

                string newStatus = "Y";


                Company company = (selectedRow.DataBoundItem as Company);

                if (company.status != null)
                {
                    if (company.status.ToUpper() == "Y")
                    {
                        newStatus = "N";
                    }
                }  
                                  
                


                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericGetWithBearerTokenAuthentication(RESTManager.RequestTypeAction.auth, Properties.Settings.Default.SecurityURL + String.Format("/auth/company/change/status?id={0}&action={1}", company.id, newStatus) , null, securityTokenTextBox.Text);


                if (Properties.Settings.Default.SaveJSON)
                {
                    File.WriteAllText("CompanyList.json", webAPIResponse.ResponseResult);
                }



                if (webAPIResponse.ResponseCode == 200)
                {
                    CompanyListResponse companyListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<CompanyListResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = companyListResponse.companys;
                    companiesDataGridView.DataSource = bindingSource;

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

        private void companiesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void companiesDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.companiesDataGridView.Columns["status"].Index)
                {
                    string status = e.Value.ToString();

                    if (status != null)
                    {

                        if (status.ToUpper() == "Y")
                        {
                            //activateDeactivateButton.Text = "Deactivate";
                            companiesDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                            companiesDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                        }
                        else
                        {
                            //activateDeactivateButton.Text = "Activate";
                            companiesDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Crimson;
                            companiesDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

                        }
                    }
                }
            }
            catch
            {

            }

        }

        private void companiesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (companiesDataGridView.SelectedRows.Count == 1)
                {
                    if (companiesDataGridView.SelectedRows[0].Cells["status"].Value.ToString().ToUpper() == "Y")
                    {
                        activateDeactivateButton.Text = "Deactivate";
                    }
                    if (companiesDataGridView.SelectedRows[0].Cells["status"].Value.ToString().ToUpper() == "N")
                    {
                        activateDeactivateButton.Text = "Activate";
                    }
                }

            }
            catch
            {

            }

        }
    }
}
