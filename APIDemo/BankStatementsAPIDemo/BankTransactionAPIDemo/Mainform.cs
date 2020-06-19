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
    public partial class Mainform : Form
    {
        bool loggedin = false;
        private string accountHolderID;

        public Mainform()
        {
            InitializeComponent();
            usernameTextbox.Text = Properties.Settings.Default.UserName;
            passwordTextbox.Text = Properties.Settings.Default.Password;
            docleanUp();

            if (Properties.Settings.Default.AutoLogin)
            {
                performLogin();
            }

        }

        private void docleanUp()
        {
            foreach (FileInfo f in new DirectoryInfo(Environment.CurrentDirectory).GetFiles("banklogin*.html"))
            {
                try
                {
                    f.Delete();
                }
                catch
                {

                }

            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            performLogin();            
        }

        private void resetScreen()
        {

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
                resetScreen();
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

        private void createUserButton_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void createUser()
        {
            try
            {
                //if (!this.ValidateChildren())
                //{
                //    return;
                //}

                NewSessionRequest newSessionRequest = new NewSessionRequest();
                newSessionRequest.accountHolderIdentifier = accountHolderIDTextBox.Text;
                newSessionRequest.emailAddress = emailTextBox.Text; ;

                //userDetail.user.password = "Hubino@123";

                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                if (Properties.Settings.Default.SaveJSON)
                {
                    File.WriteAllText("UserRegisterRequest.JSON", newSessionRequest.ToJSON());
                }

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<string>("company/user/register", Properties.Settings.Default.SecurityURL, newSessionRequest.ToJSON(), null, securityTokenTextBox.Text);

                //userDetail = JsonConvert.DeserializeObject<UserDetail>(webAPIResponse.ResponseResult, new JS)

                if (webAPIResponse.ResponseCode == 200)
                {

                    if (Properties.Settings.Default.SaveJSON)
                    {
                        File.WriteAllText("UserRegisterResponse.JSON", webAPIResponse.ResponseResult);
                    }

                    NewSessionResponse newSessionResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<NewSessionResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });
                    

                    accountHolderID = newSessionResponse.accountHolderIdentifier;
                    retrieveAccountHolderIDTextBox.Text = accountHolderID;
                    retrieveBankUniqueReferenceTextBox.Text = newSessionResponse.uniqueReference;
                    MessageBox.Show("Success creating new Session for accountholder id : " + accountHolderID);

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

        private void createUserButton_Click_1(object sender, EventArgs e)
        {
            long value;
            
            if (!long.TryParse(accountHolderIDTextBox.Text, out value))
            {
                MessageBox.Show("IDNumber is not valid !");
                accountHolderIDTextBox.Focus();
                return;
            }

            string errorMessage;

            if (!ValidEmailAddress(emailTextBox.Text, out errorMessage))
            {
                MessageBox.Show("Email Address is not valid !");
                emailTextBox.Focus();
                return;
            }

            createUser();
        }

        private void getUserListButton_Click(object sender, EventArgs e)
        {
            getUserList();
        }

        private void getUserList()
        {
            UserListForm userListForm = new UserListForm(securityTokenTextBox.Text);
            userListForm.ShowDialog();
            userListForm.Dispose();
            this.BringToFront();
        }

        private void loginNameTextBox_Validating(object sender, CancelEventArgs e)
        {

        }

        public bool ValidNumber(string value, string fieldDescription, out string errorMessage)
        {
            errorMessage = "";

            if (value.Length == 0)
            {
                errorMessage = " is required.";
                return false;
            }

            // Confirm that there is an "@" and a "." in the email address, and in the correct order.
            long numericValue;
            if (long.TryParse(value, out numericValue))
            {
                return true;
            }

            errorMessage = fieldDescription + " must be validnumeric value.\n" +
               "For example '7811065500081' ";
            return false;
        }

        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            // Confirm that the email address string is not empty.
            if (emailAddress.Length == 0)
            {
                errorMessage = "email address is required.";
                return false;
            }

            // Confirm that there is an "@" and a "." in the email address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "email address must be valid email address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            openBankLogin();
        }

        private void openBankLogin()
        {
            try
            {
                //if (!this.ValidateChildren())
                //{
                //    return;
                //}


                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                string filename = String.Format("banklogin{0}.html", retrieveAccountHolderIDTextBox.Text);
                string filenamejs = String.Format("banklogin{0}js.html", retrieveAccountHolderIDTextBox.Text);

                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch
                    {
                        MessageBox.Show(String.Format("The file {0} could not be deleted. Please close the file and then try again.", filename));
                        return;
                    }
                }

                AccountHolderRequestDetails accountHolderRequestDetails = new AccountHolderRequestDetails();
                accountHolderRequestDetails.accountHolderIdentifier = retrieveAccountHolderIDTextBox.Text;
                accountHolderRequestDetails.uniqueReference = retrieveBankUniqueReferenceTextBox.Text;

                if (Properties.Settings.Default.SaveJSON)
                {
                    File.WriteAllText("ClientBankLoginRequest.JSON", accountHolderRequestDetails.ToJSON());
                }

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<WebAPIResponse>("",Properties.Settings.Default.SecurityURL + "/company/user/accountlink", accountHolderRequestDetails.ToJSON(),  null, securityTokenTextBox.Text);

                if (webAPIResponse.ResponseCode == 200)
                {

                    if (Properties.Settings.Default.SaveJSON)
                    {
                        File.WriteAllText("ClientBankLoginResponse.JSON", webAPIResponse.ResponseResult);
                    }

                    BankLoginResponse bankLoginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BankLoginResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    //string htmlText = String.Format(Properties.Settings.Default.HTMLTemplate, bankLoginResponse.fastLink, bankLoginResponse.fastLinkJwtToken, bankLoginResponse.finAppid, bankLoginResponse.callbackUrl);
                    string htmlText = Properties.Settings.Default.HTMLTemplate.Replace("param1", bankLoginResponse.jwtToken);
                    //string javascripText = Properties.Settings.Default.JSTemplate.Replace("param1", bankLoginResponse.fastLink).Replace("param2", bankLoginResponse.fastLinkJwtToken);


                    File.WriteAllText(filename, htmlText);
                    //File.WriteAllText(filenamejs, javascripText);

                    System.Diagnostics.Process.Start(filename);
                    //System.Diagnostics.Process.Start(filenamejs);

                    //MessageBox.Show("Success");

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

        private void loadAccounts()
        {
            try
            {
                //string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                accountsDataGridView.Rows.Clear();
                AccountHolderRequestDetails accountHolderRequestDetails = new AccountHolderRequestDetails();
                accountHolderRequestDetails.accountHolderIdentifier = retrieveAccountHolderIDTextBox.Text;
                accountHolderRequestDetails.uniqueReference = retrieveBankUniqueReferenceTextBox.Text;

                if (Properties.Settings.Default.SaveJSON)
                {
                    File.WriteAllText("AccountListRequest.JSON", accountHolderRequestDetails.ToJSON());
                }

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<WebAPIResponse>("", Properties.Settings.Default.SecurityURL + "/company/user/account", accountHolderRequestDetails.ToJSON(),  null, securityTokenTextBox.Text);


                if (webAPIResponse.ResponseCode == 200)
                {

                    if (Properties.Settings.Default.SaveJSON)
                    {
                        File.WriteAllText("AccountListResponse.JSON", webAPIResponse.ResponseResult);
                    }

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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void viewAccountsButton_Click(object sender, EventArgs e)
        {

            if (retrieveAccountHolderIDTextBox.Text.Trim().Length <= 0)
            {
                MessageBox.Show("ID Number needs a value !");
                retrieveAccountHolderIDTextBox.Focus();
                return;
            }
            accountHolderID = retrieveAccountHolderIDTextBox.Text;
            loadAccounts();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (retrieveAccountHolderIDTextBox.Text.Trim().Length <= 0)
            {
                MessageBox.Show("ID Number needs a value !");
                retrieveAccountHolderIDTextBox.Focus();
                return;
            }
            accountHolderID = retrieveAccountHolderIDTextBox.Text;
            openBankLogin();
        }

        private void viewAccountTransactionsButton_Click(object sender, EventArgs e)
        {
            if (accountsDataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = accountsDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = accountsDataGridView.Rows[selectedrowindex];
                string container = Convert.ToString(selectedRow.Cells["CONTAINER"].Value);
                int accountID = Convert.ToInt32(selectedRow.Cells["id"].Value);
                ViewTransactionsForm viewTransactionsForm = new ViewTransactionsForm(securityTokenTextBox.Text, retrieveAccountHolderIDTextBox.Text, container, accountID, retrieveBankUniqueReferenceTextBox.Text);
                viewTransactionsForm.ShowDialog();
                viewTransactionsForm.Dispose();
                accountsDataGridView.Rows.Clear();
                this.BringToFront();

            } else
            {
                MessageBox.Show("No acounts have been selected.");
            }
        }

        private void getUserListButton_Click_1(object sender, EventArgs e)
        {
            UserListForm userListForm = new UserListForm(securityTokenTextBox.Text);
            userListForm.ShowDialog();
            userListForm.Dispose();
            this.BringToFront();
        }

        private void categoriesAndRulesButton_Click(object sender, EventArgs e)
        {
            showCategories();
        }

        private void showCategories()
        {
            if (retrieveAccountHolderIDTextBox.Text.Trim().Length <= 0)
            {
                MessageBox.Show("ID Number needs a value !");
                retrieveAccountHolderIDTextBox.Focus();
                return;
            }
            accountHolderID = retrieveAccountHolderIDTextBox.Text;
            CategoriesAndRulesForm categoriesAndRulesForm = new CategoriesAndRulesForm(securityTokenTextBox.Text, retrieveAccountHolderIDTextBox.Text);
            categoriesAndRulesForm.ShowDialog();
            categoriesAndRulesForm.Dispose();
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
                sfd.FileName = accountHolderID + "-AccountsOutput.csv";
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

        private void Mainform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.U)
            {
                getUserList();                
            }
        }

        private void categoriesAndRulesButton_Click_1(object sender, EventArgs e)
        {
            
            showCategories();
        }

        private void accountsDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void accountsDataGridView_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (accountsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("Amount"))
            {

            }
        }

        private void accountsDataGridView_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
           
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

        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            docleanUp();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void finishSessionButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon ...");
        }
    }
}
