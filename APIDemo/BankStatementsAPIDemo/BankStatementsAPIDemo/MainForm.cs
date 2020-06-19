using Simplifi.BankStatementsAPIDemo.models;
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
using System.Diagnostics;

namespace Simplifi.BankStatementsAPIDemo
{
    public partial class MainForm : Form
    {
        bool loggedin = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            performLogin();
        }

        private void hidePanels()
        {
            absaPanel.Visible = false;
            capitecPanel.Visible = false;
            fnbPanel.Visible = false;
            nedbankPanel.Visible = false;
            standardbankPanel.Visible = false;
            nedbankNewProfilePanel.Visible = false;
            nedbankOldProfilePanel.Visible = false;
        }

        private void clearTextBoxes(TextBox[] TextBoxes)
        {
            foreach (TextBox textBox in TextBoxes)
            {
                textBox.Clear();
            }
        }

        private void clearFields()
        {
            try
            {
                clearTextBoxes(new TextBox[] { absaUserNumberTextBox, absaAbsolutePasswordTextBox, absaAccountNumberTextBox });
                clearTextBoxes(new TextBox[] { capitecAccountNumberUserNameTextBox, capitecPasswordTextBox });
                clearTextBoxes(new TextBox[] { fnbUsernameTextBox, fnbPasswordTextBox });
                clearTextBoxes(new TextBox[] { standardbankEmailTextBox, standardBankPasswordTextBox });
                clearTextBoxes(new TextBox[] { nedbankOldProfileProfileNumberTextBox, nedbankOldProfilePinTextBox, nedbankOldProfilePasswordTextBox });
                clearTextBoxes(new TextBox[] { nedbankNewProfileUsernameTextBox, nedbankNewProfilePasswordTextBox });
            } catch (Exception e)
            {
                if (Properties.Settings.Default.ShowErrorMessageDetail)
                {
                    MessageBox.Show(e.ToString());
                }
                else
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void checkedChange(object sender, EventArgs e)
        {
            hidePanels();
            clearFields();


            if (!loggedin)
            {
                MessageBox.Show("You need to log in first !");
                return;
            }

            switch (((RadioButton)sender).Name)
            {
                case "absaRadioButton":
                {
                        
                        absaPanel.Visible = true;
                        absaAccountNumberTextBox.Focus();
                        break;
                }
                case "capitectRadioButton":
                    {
                        
                        capitecPanel.Visible = true;
                        capitecAccountNumberUserNameTextBox.Focus();
                        break;
                    }
                case "fnbRadioButton":
                    {
                        
                        fnbPanel.Visible = true;
                        fnbUsernameTextBox.Focus();
                        break;
                    }
                case "nedbankRadioButton":
                    {
                        nedbankPanel.Visible = true;
                        break;
                    }
                case "standardBankRadioButton":
                    {
                        
                        standardbankPanel.Visible = true;
                        standardbankEmailTextBox.Focus();
                        break;
                    }
                case "nedbankOldProfileRadioButton":
                    {
                        
                        nedbankPanel.Visible = true;
                        nedbankOldProfilePanel.Visible = true;
                        nedbankOldProfileProfileNumberTextBox.Focus();
                        break;
                    }
                case "nedbankNewProfileRadioButton":
                    {
                        
                        nedbankPanel.Visible = true;                        
                        nedbankNewProfilePanel.Visible = true;
                        nedbankNewProfileUsernameTextBox.Focus();
                        break;
                    }
            }

            button1.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            hidePanels();
            usernameTextbox.Text = Properties.Settings.Default.UserName;
            passwordTextbox.Text = Properties.Settings.Default.Password;
            if (Properties.Settings.Default.AutoLogin)
            {
                performLogin();
            }

        }

        private void resetScreen()
        {
            button1.Visible = false;
            accountDetailPanel.Visible = false;
            downloadStatementButton.Visible = false;
            button1.Visible = false;
            accountDetailPanel.Visible = false;
            downloadStatementButton.Visible = false;
            absaRadioButton.Checked = false;
            nedbankRadioButton.Checked = false;
            standardBankRadioButton.Checked = false;
            fnbRadioButton.Checked = false;
            capitectRadioButton.Checked = false;
            hidePanels();
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


                validateValues(new TextBox[] { usernameTextbox, passwordTextbox }, new String[] {"Username needs a value ! ", "Password needs a value !"  });
                Login login = new Login();
                login.username = usernameTextbox.Text;
                login.password = passwordTextbox.Text;

                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<string>("authentication", Properties.Settings.Default.SecurityURL, login.ToJSON(), null, securityTokenTextBox.Text);

                string jsonResult = webAPIResponse.ResponseResult;

                if (webAPIResponse.ResponseCode == 200)
                {

                    LoginResponse loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(Convert.ToString(jsonResult), new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    securityTokenTextBox.Text = loginResponse.token;
                    loginResultText.Text = loginResponse.loginResponse;
                } else
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

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
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
            } catch (Exception e)
            {
                throw e;
            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Code";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private void populateAccountInformation(BankLoginResponse BankLoginResponseValue)
        {
            try
            {
                if (BankLoginResponseValue.Result.ToUpper() == "SUCCESS")
                {
                    accountDetailPanel.Visible = true;
                    downloadStatementButton.Visible = true;
                    sessionIDTextBox.Text = BankLoginResponseValue.sessionId;
                    bankloginResponseTextBox.Text = BankLoginResponseValue.Result;
                    additionalMessageTextBox.Text = BankLoginResponseValue.AdditionalMessage;
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = BankLoginResponseValue.accounts;
                    accountsComboBox.DataSource = bindingSource;
                    accountsComboBox.DisplayMember = "accountNumber";
                    accountsComboBox.ValueMember = "accountId";
                    
                } else
                {
                    //AutoClosingMessageBox.Show("Account Detail Could not be retrieved. Additional message is : " + BankLoginResponseValue.AdditionalMessage, "Account(s)", 1000);
                }
            } catch (Exception e)
            {
                if (Properties.Settings.Default.ShowErrorMessageDetail)
                {
                    MessageBox.Show(e.ToString());
                }
                else
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void accountsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account account = accountsComboBox.SelectedItem as Account;
            statementDownLoadableTextBox.Text = account.bankStatementsDownloadable.ToString();
            accountIDTextBox.Text = account.accountId;
            accountDescriptionTextBox.Text = account.description;


        }

        public static byte[] Base64DecodeToByteArray(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return base64EncodedBytes;
        }

        public static string Base64DecodeToString(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void downloadStatementButton_Click(object sender, EventArgs e)
        {
            MessageForm messageForm = null;

            try
            {
                messageForm = new MessageForm("Checking and Retrieving Bankstatement", Properties.Resources.SmallLogo);
                messageForm.Show();
                BankStatementRequest bankStatementRequest = new BankStatementRequest();
                bankStatementRequest.accountId = accountIDTextBox.Text;
                bankStatementRequest.sessionId = sessionIDTextBox.Text;
                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<string>("bankstatements", Properties.Settings.Default.BankStatementsURL, bankStatementRequest.ToJSON(), null, securityTokenTextBox.Text);

                string jsonResult = webAPIResponse.ResponseResult;
                if (webAPIResponse.ResponseCode == 200)
                { 
                    BankStatementResult bankStatementResult = Newtonsoft.Json.JsonConvert.DeserializeObject<BankStatementResult>(Convert.ToString(jsonResult), new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    try
                    {
                        FindAndKillProcess("AcroRd32");
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("Could not Close Adobe. Error is : " + exx.ToString());
                    }
                    string fileName = Environment.CurrentDirectory + "\\LatestStatement{0}.pdf";
                    for (int i = 1; i < 4; i++)
                    {
                        File.Delete(String.Format(fileName,i));
                    }


                    try
                    {
                        if (bankStatementResult.bankStatements == null)
                        {
                            throw new Exception("Bankstatement is empty !!");
                        }
                        
                    }
                    catch
                    {

                    }
                    messageForm.setMessage("Bankstatement retreived. Saving and opening bankstatement.");
                    int fileCounter = 1;
                    foreach (BankStatement bankstatement in bankStatementResult.bankStatements)
                    {
                        File.WriteAllBytes(String.Format(fileName,fileCounter), Base64DecodeToByteArray(bankstatement.bankStatement));
                        System.Diagnostics.Process.Start(String.Format(fileName, fileCounter));
                        fileCounter++;
                    }
                    
                    
                    messageForm.Close();
                    messageForm.Dispose();
                } else
                {
                    throw new Exception("Error occured. Response code : " + webAPIResponse.ResponseCode.ToString() + ", Reason : " + webAPIResponse.ResponseDescription + ", -----------\n Detail : " + webAPIResponse.ResponseResult + "-----------\n");
                }

                resetScreen();

             

            } catch (Exception ex)
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
            }

        }
        public bool FindAndKillProcess(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    //To know if it works
                    //MessageBox.Show(clsProcess);
                    clsProcess.Kill();
                    return true;
                }
            }
            //process not found, return false
            return false;
        }


        private void absaPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void bankStatementSimpleRequestButton_Click(object sender, EventArgs e)
        {
            try
            {
                validateValues(new TextBox[] { requesterContactEmailTextBox, requesterContactTelnumberTextBox, requesterNameTextBox, requesterSurnameTextBox, requesterUniqueReferenceTextBox, clientEmailTextBox, clientNameTextBox, clientSurnameTextBox, clientTelNumberTextBox, clientUniqueIdentifierTextBox },
                                new string[] { "Requester Contact Email needs a value !", "Requester Contact Tel Number needs a value !", "Requester Name needs a value !", "Requester Surname needs a value !", "Requester Unique Reference needs a value !", "Client Email needs a value !", "Client Name needs a value !", "Client Surname needs a value !", "Client Tel Number needs a value !", "Client Unique Identifier needs a value !" });
                BankStatementSimpleRequest bankstatementSimpleRequest = new BankStatementSimpleRequest();
                bankstatementSimpleRequest.BankStatementReason = statementReasonCombobox.Text;
                bankstatementSimpleRequest.ClientEmail = clientEmailTextBox.Text;
                bankstatementSimpleRequest.ClientName = clientNameTextBox.Text;
                bankstatementSimpleRequest.ClientSurname = clientSurnameTextBox.Text;
                bankstatementSimpleRequest.ClientTelNumber = clientTelNumberTextBox.Text;
                bankstatementSimpleRequest.ClientUniqueIdentifier = clientUniqueIdentifierTextBox.Text;
                bankstatementSimpleRequest.RequesterContactEmail = requesterContactEmailTextBox.Text;
                bankstatementSimpleRequest.RequesterContactTelNumber = requesterContactTelnumberTextBox.Text;
                bankstatementSimpleRequest.RequesterName = requesterNameTextBox.Text;
                bankstatementSimpleRequest.RequesterSurname = requesterSurnameTextBox.Text;
                bankstatementSimpleRequest.RequesterUniqueReference = requesterUniqueReferenceTextBox.Text;


                WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<string>("BankStatementSimpleRequest", Properties.Settings.Default.BankStatementsURL, bankstatementSimpleRequest.ToJSON(), null, securityTokenTextBox.Text);

                if (webAPIResponse.ResponseCode == 200)
                {
                    BankStatementSimpleRequestPostResult bankStatementSimpleRequestPostResult = Newtonsoft.Json.JsonConvert.DeserializeObject<BankStatementSimpleRequestPostResult>(Convert.ToString(webAPIResponse.ResponseResult), new JsonSerializerSettings
                    {

                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore

                    });

                    MessageBox.Show("Post succesfull : " + webAPIResponse.ResponseResult);

                    resultTransactionReferenceTextBox.Text = bankStatementSimpleRequestPostResult.UniqueReferenceID;


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bankStatementSimpleRequestButton_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleAPIRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            simlebankstatementRequestDemoGroupbox.Visible = true;
        }

        private void advancedAPIRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            advancedAPIGroupBox.Visible = true;
        }

        private void getSimpleRequestStatusButton_Click(object sender, EventArgs e)
        {
            try
            {
                validateValues(new TextBox[] { resultTransactionReferenceTextBox },
                                new string[] { "Transaction Reference needs a value !" });

                String response = RESTManager.Instance.CallGenericGetWithBearerTokenAuthentication(RESTManager.RequestTypeAction.BankStatementSimpleRequest, Properties.Settings.Default.BankStatementsURL+@"/"+ RESTManager.RequestTypeAction.BankStatementSimpleRequest+@"/"+resultTransactionReferenceTextBox.Text,  null, securityTokenTextBox.Text);


                    //Banks bankStatementSimpleRequestPostResult = Newtonsoft.Json.JsonConvert.DeserializeObject<BankStatementSimpleRequestPostResult>(Convert.ToString(webAPIResponse.ResponseResult), new JsonSerializerSettings
                    //{

                    //    TypeNameHandling = TypeNameHandling.Auto,
                    //    NullValueHandling = NullValueHandling.Ignore

                    //});

                    MessageBox.Show("Post succesfull : " + response);








            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string jsonRequest = "";
            MessageForm messageForm = null;
            try
            {
                string feedbackDetails = "Sending Bank Login. Please check your mobile device for possible interaction required.";
                bool visible = this.absaPanel.Visible;
                if (visible)
                {
                    this.validateValues(new TextBox[]
                    {
                        this.absaUserNumberTextBox,
                        this.absaAbsolutePasswordTextBox,
                        this.absaAccountNumberTextBox
                    }, new string[]
                    {
                        "Usernumber needs a value !",
                        "Password needs a value !",
                        "Account number needs a value !"
                    });
                    messageForm = new MessageForm(feedbackDetails, Properties.Resources.absa_logo);
                    jsonRequest = new AbsaLogin
                    {
                        userNumber = MainForm.Base64Encode(this.absaUserNumberTextBox.Text),
                        absolutePassword = MainForm.Base64Encode(this.absaAbsolutePasswordTextBox.Text),
                        accountNumber = MainForm.Base64Encode(this.absaAccountNumberTextBox.Text),
                        pin = MainForm.Base64Encode(this.absaPinTextBox.Text)
                    }.ToJSON();
                }
                bool visible2 = this.capitecPanel.Visible;
                if (visible2)
                {
                    this.validateValues(new TextBox[]
                    {
                        this.capitecAccountNumberUserNameTextBox,
                        this.capitecPasswordTextBox
                    }, new string[]
                    {
                        "Account Number / Username needs a value !",
                        "Password needs a value !"
                    });
                    messageForm = new MessageForm(feedbackDetails, Properties.Resources.Capitec);
                    jsonRequest = new CapitecLogin
                    {
                        accountNumber = MainForm.Base64Encode(this.capitecAccountNumberUserNameTextBox.Text),
                        password = MainForm.Base64Encode(this.capitecPasswordTextBox.Text)
                    }.ToJSON();
                }
                bool visible3 = this.fnbPanel.Visible;
                if (visible3)
                {
                    this.validateValues(new TextBox[]
                    {
                        this.fnbUsernameTextBox,
                        this.fnbPasswordTextBox
                    }, new string[]
                    {
                        "Username needs a value !",
                        "Password needs a value !"
                    });
                    messageForm = new MessageForm(feedbackDetails, Properties.Resources.FNB_Logo);
                    jsonRequest = new FNBLogin
                    {
                        username = MainForm.Base64Encode(this.fnbUsernameTextBox.Text),
                        password = MainForm.Base64Encode(this.fnbPasswordTextBox.Text)
                    }.ToJSON();
                }
                bool visible4 = this.standardbankPanel.Visible;
                if (visible4)
                {
                    this.validateValues(new TextBox[]
                    {
                        this.standardbankEmailTextBox,
                        this.standardBankPasswordTextBox
                    }, new string[]
                    {
                        "Email needs a value !",
                        "Password needs a value !"
                    });
                    messageForm = new MessageForm(feedbackDetails, Properties.Resources.Standardbank);
                    jsonRequest = new StandarBankLogin
                    {
                        email = MainForm.Base64Encode(this.standardbankEmailTextBox.Text),
                        password = MainForm.Base64Encode(this.standardBankPasswordTextBox.Text)
                    }.ToJSON();
                }
                bool visible5 = this.nedbankPanel.Visible;
                if (visible5)
                {
                    bool visible6 = this.nedbankOldProfilePanel.Visible;
                    if (visible6)
                    {
                        this.validateValues(new TextBox[]
                        {
                            this.nedbankOldProfileProfileNumberTextBox,
                            this.nedbankOldProfilePinTextBox,
                            this.nedbankOldProfilePasswordTextBox
                        }, new string[]
                        {
                            "Profile number needs a value !",
                            "Pin needs a value !",
                            "Password needs a value !"
                        });
                        jsonRequest = new NedbankLoginOld
                        {
                            profile =
                            {
                                accountNumber = MainForm.Base64Encode(this.nedbankOldProfileProfileNumberTextBox.Text),
                                accountPin = MainForm.Base64Encode(this.nedbankOldProfilePinTextBox.Text),
                                password = MainForm.Base64Encode(this.nedbankOldProfilePasswordTextBox.Text)
                            }
                        }.ToJSON();
                    }
                    bool visible7 = this.nedbankNewProfilePanel.Visible;
                    if (visible7)
                    {
                        this.validateValues(new TextBox[]
                        {
                            this.nedbankNewProfileUsernameTextBox,
                            this.nedbankNewProfilePasswordTextBox
                        }, new string[]
                        {
                            "Username needs a value !",
                            "Password needs a value !"
                        });
                        jsonRequest = new NedbankLoginNew
                        {
                            profile =
                            {
                                username = MainForm.Base64Encode(this.nedbankNewProfileUsernameTextBox.Text),
                                password = MainForm.Base64Encode(this.nedbankNewProfilePasswordTextBox.Text)
                            }
                        }.ToJSON();
                    }
                    messageForm = new MessageForm(feedbackDetails, Properties.Resources.Nedbank);
                }
                try
                {
                    messageForm.Show();
                    WebAPIResponse webAPIResponse = RESTManager.Instance.CallGenericRestPostBearerToken<string>("BankLogin", Properties.Settings.Default.BankStatementsURL, jsonRequest, null, this.securityTokenTextBox.Text);
                    string jsonResult = webAPIResponse.ResponseResult;
                    bool flag = webAPIResponse.ResponseCode == 200;
                    if (flag)
                    {
                        BankLoginResponse bankLoginResponse = JsonConvert.DeserializeObject<BankLoginResponse>(Convert.ToString(jsonResult), new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto,
                            NullValueHandling = NullValueHandling.Ignore
                        });
                        messageForm.setMessage("Bank Details have been succesfully retrieved !");
                        this.populateAccountInformation(bankLoginResponse);
                    }
                    else
                    {
                        bool flag2 = webAPIResponse.ResponseCode == 202;
                        if (!flag2)
                        {
                            throw new Exception(string.Concat(new string[]
                            {
                                "Error occured. Response code : ",
                                webAPIResponse.ResponseCode.ToString(),
                                ", Reason : ",
                                webAPIResponse.ResponseDescription,
                                ", -----------\n Detail : ",
                                webAPIResponse.ResponseResult,
                                "-----------\n"
                            }));
                        }
                        string jsonResultTwoFA = webAPIResponse.ResponseResult;
                        TwoFAResponse twoFAResponse = JsonConvert.DeserializeObject<TwoFAResponse>(Convert.ToString(jsonResultTwoFA), new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto,
                            NullValueHandling = NullValueHandling.Ignore
                        });
                        messageForm.Hide();
                        string code = "";
                        while (code.Trim().Length <= 0)
                        {
                            MainForm.ShowInputDialog(ref code);
                        }
                        TwoFARequest twoFARequest = new TwoFARequest();
                        twoFARequest.sessionId = twoFAResponse.sessionId;
                        twoFARequest.code = code;
                        messageForm.Show();
                        messageForm.setMessage("Sending Two Factor Authentication");
                        File.WriteAllText(Environment.CurrentDirectory + "\\TwoFArequest.json", twoFARequest.ToJSON());
                        WebAPIResponse webAPIResponseTwoFA = RESTManager.Instance.CallGenericRestPostBearerToken<string>("TwoFA", Properties.Settings.Default.BankStatementsURL, twoFARequest.ToJSON(), null, this.securityTokenTextBox.Text);
                        bool flag3 = webAPIResponseTwoFA.ResponseCode == 200;
                        if (flag3)
                        {
                            File.WriteAllText(Environment.CurrentDirectory + "\\sbjsonaccountdetails.json", webAPIResponseTwoFA.ResponseResult);
                            BankLoginResponse bankLoginResponse2 = JsonConvert.DeserializeObject<BankLoginResponse>(Convert.ToString(webAPIResponseTwoFA.ResponseResult), new JsonSerializerSettings
                            {
                                TypeNameHandling = TypeNameHandling.Auto,
                                NullValueHandling = NullValueHandling.Ignore
                            });
                            messageForm.setMessage("Bank Details have been succesfully retrieved !");
                            this.populateAccountInformation(bankLoginResponse2);
                        }
                    }
                }
                catch (Exception ex)
                {
                    bool flag4 = messageForm != null;
                    if (flag4)
                    {
                        messageForm.Close();
                        messageForm.Dispose();
                    }
                    bool showErrorMessageDetail = Properties.Settings.Default.ShowErrorMessageDetail;
                    if (showErrorMessageDetail)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally
                {
                    bool flag5 = messageForm != null;
                    if (flag5)
                    {
                        messageForm.Close();
                        messageForm.Dispose();
                    }
                }
            }
            catch (Exception exe)
            {
                bool showErrorMessageDetail2 = Properties.Settings.Default.ShowErrorMessageDetail;
                if (showErrorMessageDetail2)
                {
                    MessageBox.Show(exe.ToString());
                }
                else
                {
                    MessageBox.Show(exe.Message);
                }
            }
        }
    }
}
