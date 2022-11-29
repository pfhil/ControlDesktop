using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlDesktopPresentation.Views;

namespace ControlDesktopUI
{
    public partial class RegisterForm : Form, IRegisterView
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public new void Show()
        {
            base.ShowDialog();
        }

        public string Login
        {
            get => loginTextBox.Text;
            set => loginTextBox.Text = value;
        }

        public string Password
        {
            get => PasswordTextBox.Text;
            set => PasswordTextBox.Text = value;
        }

        public event Action Register;
        public event Action Cancel;

        private void registerButton_Click(object sender, EventArgs e)
        {
            Register?.Invoke();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Cancel?.Invoke();
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            PasswordTextBox.PasswordChar = PasswordTextBox.PasswordChar == '*' ? '\0' : '*';
        }
    }
}
