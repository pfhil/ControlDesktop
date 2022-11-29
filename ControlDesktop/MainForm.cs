using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ControlDesktopPresentation.Views;
using Microsoft.Win32;

namespace ControlDesktopUI
{
    public partial class MainForm : Form, IMainView
    {
        ApplicationContext _context;

        public MainForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            base.Show();
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        private bool _listeningServer = false;
        private bool _autoLoadApp = false;
        private bool _autoListeningServer = false;

        public string ExecutablePath
        {
            get => Application.ExecutablePath;
        }

        public bool ListeningServer 
        { 
            get => _listeningServer;
            set
            {
                listeningServerButton.Text = value ? "Выключить" : "Включить";
                _listeningServer = value;
            }
        }

        public bool AutoLoadApp
        {
            get => _autoLoadApp;
            set
            {
                appAutoLoadButton.Text = value ? "Выключить" : "Включить";
                _autoLoadApp = value;
            }
        }

        public bool AutoListeningServer
        {
            get => _autoListeningServer;
            set
            {
                autoListeningServerButton.Text = value ? "Выключить" : "Включить";
                _autoListeningServer = value;
            }
        }

        public event Action ShowAccountManagerView;
        public event Action ShowAboutView;
        public event Action ToggleAutoLoadApp;
        public event Action ToggleListeningServer;
        public event Action ToggleAutoListeningServer;
        public event Action TryUnblockInternetFunctionality;
        public event Action FormActivated;

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowTutorial()
        {
            MessageBox.Show("Здравствуйте. Спасибо за установку данной программы");
            MessageBox.Show("Данная программа предназначена для удаленного контроля компьютера");
            MessageBox.Show("Для начала работы с ботом необходимо пройти процедуру регистрации при помощи кнопки в левом верхнем углу данного окна - \"Управление уч. записью\"");
            MessageBox.Show("После регистрации вам необходимо запустить процесс прослушивания сервера и найти бота в телеграмме под именем Control_Computer_Bot и начать с ним разговор, а после следовать его инструкциям");
            MessageBox.Show("Учтите, что если вы закроете окно данного приложения, то оно не прекратит свою работу. Вы можете найти иконку в панели уведомлений Windows и кликнуть на нее правой кнопкой мыши чтобы окончательно завершить работу приложения или снова открыть его");
            MessageBox.Show("Вы всегда можете снова просмотреть эти сообщения при помощи кнопки в правом нижнем углу экрана");
        }

        public void BlockInternetFunctionality()
        {
            listeningServerButton.Enabled = false;
            accountManagerToolStripButton.Enabled = false;
            internetConnectionLabel.Visible = true;
            internetConnectionButton.Visible = true;
        }

        public void UnblockInternetFunctionality()
        {
            listeningServerButton.Enabled = true;
            accountManagerToolStripButton.Enabled = true;
            internetConnectionLabel.Visible = false;
            internetConnectionButton.Visible = false;
        }

        public void BlockListeningServerButton()
        {
            listeningServerButton.Enabled = false;
        }

        public void UnBlockListeningServerButton()
        {
            listeningServerButton.Enabled = true;
        }

        public void StopListening()
        {
            (new Thread((s) =>
            {
                this.listeningServerButton.BeginInvoke((MethodInvoker)(() =>
                {
                    this.listeningServerButton.Text = "Включить";
                    this._listeningServer = false;
                }));

            })).Start();
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == accountManagerToolStripButton)
            {
                ShowAccountManagerView?.Invoke();
            }
            if (e.ClickedItem == aboutToolStripButton)
            {
                //ShowAboutView?.Invoke();
                Form infoForm = new InfoForm();
                infoForm.ShowDialog();
            }
        }

        private void listeningServerButton_Click(object sender, EventArgs e)
        {
            ToggleListeningServer?.Invoke();
        }

        private void appAutoLoadButton_Click(object sender, EventArgs e)
        {
            ToggleAutoLoadApp?.Invoke();
            if (!AutoLoadApp)
            {
                const string applicationName = "ControlDesktop";
                const string pathRegistryKeyStartup =
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

                using (RegistryKey registryKeyStartup =
                    Registry.LocalMachine.OpenSubKey(pathRegistryKeyStartup, true))
                {
                    registryKeyStartup.DeleteValue(applicationName, false);
                }
            }
            else
            {
                const string applicationName = "ControlDesktop";
                const string pathRegistryKeyStartup =
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

                using (RegistryKey registryKeyStartup =
                    Registry.LocalMachine.OpenSubKey(pathRegistryKeyStartup, true))
                {
                    registryKeyStartup.SetValue(
                        applicationName,
                        string.Format("\"{0}\"", System.Reflection.Assembly.GetExecutingAssembly().Location));
                }
            }
        }

        private void autoListeningServerButton_Click(object sender, EventArgs e)
        {
            ToggleAutoListeningServer?.Invoke();
        }

        private void internetConnectionButton_Click(object sender, EventArgs e)
        {
            TryUnblockInternetFunctionality?.Invoke();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void mainNotifyIconContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == openAppToolStripMenuItem)
            {
                base.Show();
            }
            if (e.ClickedItem == closeAppToolStripMenuItem)
            {
                Application.ExitThread();
            }
        }

        private void showTutorButton_Click(object sender, EventArgs e)
        {
            this.ShowTutorial();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            FormActivated?.Invoke();
        }
    }
}
