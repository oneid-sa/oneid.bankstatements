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
    public partial class MessageForm : Form
    {

        public MessageForm(string Message, Image BackGround)
        {
            InitializeComponent();
            setMessage(Message);
            setMessageImage(BackGround);
        }

        public void setMessage(string Message)
        {
            this.messageLabel.Text = Message;
            //this.messageLabel.Location = new Point((this.Width / 2) - (this.messageLabel.Width / 2), this.messageLabel.Height);
            this.messageLabel.Refresh();
        }

        public void setMessageImage(Image ImageValue)
        {
            this.pictureBoxForMessage.Image = ImageValue;
            //this.pictureBoxForMessage.Location = new Point((this.Width / 2) - (this.pictureBoxForMessage.Width / 2), this.pictureBoxForMessage.Top);
            this.pictureBoxForMessage.Refresh();
        }

        public MessageForm()
        {
            InitializeComponent();
        }
    }
}
