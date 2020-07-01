using BankTransactionManagement.models;
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

namespace BankTransactionManagement
{
    public partial class AddUpdateUser : Form
    {
        int mode = -1;
        Company company = null;
        string token = "";

        public AddUpdateUser()
        {
            InitializeComponent();
        }

        public AddUpdateUser(int Mode, Company CompanyValue, String Token)
        {
            InitializeComponent();
            mode = Mode;
            company = CompanyValue;
            token = Token;
            if (mode == 2 && company == null)
            {
                throw new Exception("Company cannot be null when updating !!");
            }
            loadValues();

            
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

        private void loadValues()
        {
            if (mode == 2)
            {
                usernameTextBox.Enabled = false;
                companyNameTextBox.Text = company.companyName;
                addressTextBox.Text = company.address;
                emailTextBox.Text = company.email;
                usernameTextBox.Text = company.username;
                passwordTextBox.Text = company.password;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void manageCompany()
        {
            try
            {
                //if (!this.ValidateChildren())
                //{
                //    return;
                //}

                WebAPIResponse webAPIResponse = null;

                if (mode == 1)
                {
                    CompanyCreateRequest companyCreateRequest = new CompanyCreateRequest();
                    companyCreateRequest.companyName = companyNameTextBox.Text;
                    companyCreateRequest.address = addressTextBox.Text;
                    companyCreateRequest.email = emailTextBox.Text;
                    companyCreateRequest.loginname = usernameTextBox.Text;
                    companyCreateRequest.password = passwordTextBox.Text;
                    webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<string>("auth/company/create", Properties.Settings.Default.SecurityURL, companyCreateRequest.ToJSON(), null, token);
                }

                if (mode ==2)
                {
                    CompanyEditRequest companyEditRequest = new CompanyEditRequest();
                    companyEditRequest.id = company.id;
                    companyEditRequest.companyName = companyNameTextBox.Text;
                    companyEditRequest.address = addressTextBox.Text;
                    companyEditRequest.email = emailTextBox.Text;
                    companyEditRequest.password = passwordTextBox.Text;

                    webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<string>("auth/company/edit", Properties.Settings.Default.SecurityURL, companyEditRequest.ToJSON(), null, token);
                }

                if (webAPIResponse.ResponseResult.Contains("errorCode"))
                {
                    ErrorResponse errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    throw new Exception(String.Format("Call was not succesfull. Error Code {0} with reason {1} has been returned. Reference : {2}", errorResponse.errorCode, errorResponse.errorMessage, errorResponse.referenceCode));
                }
                else if (webAPIResponse.ResponseResult.Contains("statusCode"))
                {
                    SuccessResponse successResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<SuccessResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    if (successResponse.statusCode == 200)
                    {
                        MessageBox.Show("Succesful !");
                        this.DialogResult = DialogResult.OK;

                    } else
                    {
                        throw new Exception(String.Format("Call was not succesfull. Response Code {0} with reason {1} has been returned. Detail : {2}", webAPIResponse.ResponseCode, webAPIResponse.ResponseDescription, webAPIResponse.ResponseResult));
                    }

                } else
                {
                    throw new Exception(String.Format("Call was not succesfull. Response Code {0} with reason {1} has been returned. Detail : {2}", webAPIResponse.ResponseCode, webAPIResponse.ResponseDescription, webAPIResponse.ResponseResult));
                }

                //NewSessionRequest newSessionRequest = new NewSessionRequest();
                //newSessionRequest.accountHolderIdentifier = accountHolderIDTextBox.Text;
                //newSessionRequest.emailAddress = emailTextBox.Text; ;

                ////userDetail.user.password = "Hubino@123";

                ////string json = "{  \"user\": {    \"loginName\": \"hubtester1\",    \"email\": \"testerHub02@mailinator.com\",    \"password\": \"Hubino@123\",    \"name\": {      \"first\": \"FNAME\",      \"last\": \"LNAME\"    },    \"address\": {      \"address1\": \"200 Lincoln Ave\",      \"state\": \"CA\",      \"city\": \"Salinas\",      \"zip\": \"93901\",      \"country\": \"US\"    },    \"preferences\": {      \"currency\": \"USD\",      \"locale\": \"en_US\"    }  }}";

                //if (Properties.Settings.Default.SaveJSON)
                //{
                //    File.WriteAllText("UserRegisterRequest.JSON", newSessionRequest.ToJSON());
                //}

                

                ////userDetail = JsonConvert.DeserializeObject<UserDetail>(webAPIResponse.ResponseResult, new JS)

                //if (webAPIResponse.ResponseCode == 200)
                //{

                //    if (Properties.Settings.Default.SaveJSON)
                //    {
                //        File.WriteAllText("UserRegisterResponse.JSON", webAPIResponse.ResponseResult);
                //    }

                //    NewSessionResponse newSessionResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<NewSessionResponse>(webAPIResponse.ResponseResult, new JsonSerializerSettings
                //    {

                //        TypeNameHandling = TypeNameHandling.Auto,
                //        NullValueHandling = NullValueHandling.Ignore

                //    });


                //    accountHolderID = newSessionResponse.accountHolderIdentifier;
                //    retrieveAccountHolderIDTextBox.Text = accountHolderID;
                //    retrieveBankUniqueReferenceTextBox.Text = newSessionResponse.uniqueReference;
                //    MessageBox.Show("Success creating new Session for accountholder id : " + accountHolderID);

                //}
                //else
                //{
                //    throw new Exception(String.Format("Call was not succesfull. Response Code {0} with reason {1} has been returned. Detail : {2}", webAPIResponse.ResponseCode, webAPIResponse.ResponseDescription, webAPIResponse.ResponseResult));
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool includeLowercase = true;
            bool includeUppercase = true;
            bool includeNumeric = true;
            bool includeSpecial = false;
            bool includeSpaces = false;
            int lengthOfPassword = 16;

            passwordTextBox.Text = PasswordGenerator.GeneratePassword(includeLowercase, includeUppercase, includeNumeric, includeSpecial, includeSpaces, lengthOfPassword);


            while (!PasswordGenerator.PasswordIsValid(includeLowercase, includeUppercase, includeNumeric, includeSpecial, includeSpaces, passwordTextBox.Text))
            {
                passwordTextBox.Text = PasswordGenerator.GeneratePassword(includeLowercase, includeUppercase, includeNumeric, includeSpecial, includeSpaces, lengthOfPassword);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                validateValues(new TextBox[] { companyNameTextBox, addressTextBox, emailTextBox, usernameTextBox, passwordTextBox }, new String[] { "Company name needs a value ! ", "Address needs a value !", "Email needs a value !", "Username needs a value !", "Password needs a value !" });
                manageCompany();
            } catch (Exception ex)
            {
                MessageBox.Show("An error occured : " + ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
