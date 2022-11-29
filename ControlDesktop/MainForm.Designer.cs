
namespace ControlDesktopUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.appTitleLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.accountManagerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.listeningServerLabel = new System.Windows.Forms.Label();
            this.appAutoLoadLabel = new System.Windows.Forms.Label();
            this.autoListeningServerLabel = new System.Windows.Forms.Label();
            this.listeningServerButton = new System.Windows.Forms.Button();
            this.appAutoLoadButton = new System.Windows.Forms.Button();
            this.autoListeningServerButton = new System.Windows.Forms.Button();
            this.mainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainNotifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internetConnectionLabel = new System.Windows.Forms.Label();
            this.internetConnectionButton = new System.Windows.Forms.Button();
            this.showTutorButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.mainNotifyIconContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // appTitleLabel
            // 
            this.appTitleLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.appTitleLabel.Location = new System.Drawing.Point(60, 34);
            this.appTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.appTitleLabel.Name = "appTitleLabel";
            this.appTitleLabel.Size = new System.Drawing.Size(412, 112);
            this.appTitleLabel.TabIndex = 0;
            this.appTitleLabel.Text = "Программа по контролю компьютера при помощи телеграмм-бота";
            this.appTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountManagerToolStripButton,
            this.aboutToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(532, 28);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // accountManagerToolStripButton
            // 
            this.accountManagerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.accountManagerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("accountManagerToolStripButton.Image")));
            this.accountManagerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.accountManagerToolStripButton.Name = "accountManagerToolStripButton";
            this.accountManagerToolStripButton.Size = new System.Drawing.Size(188, 25);
            this.accountManagerToolStripButton.Text = "Управление уч. записью";
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripButton.Image")));
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(110, 25);
            this.aboutToolStripButton.Text = "О программе";
            // 
            // listeningServerLabel
            // 
            this.listeningServerLabel.AutoSize = true;
            this.listeningServerLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listeningServerLabel.Location = new System.Drawing.Point(12, 175);
            this.listeningServerLabel.Name = "listeningServerLabel";
            this.listeningServerLabel.Size = new System.Drawing.Size(246, 28);
            this.listeningServerLabel.TabIndex = 10;
            this.listeningServerLabel.Text = "Прослушивание сервера:";
            // 
            // appAutoLoadLabel
            // 
            this.appAutoLoadLabel.AutoSize = true;
            this.appAutoLoadLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.appAutoLoadLabel.Location = new System.Drawing.Point(12, 228);
            this.appAutoLoadLabel.Name = "appAutoLoadLabel";
            this.appAutoLoadLabel.Size = new System.Drawing.Size(251, 28);
            this.appAutoLoadLabel.TabIndex = 11;
            this.appAutoLoadLabel.Text = "Автозагрузка программы:";
            // 
            // autoListeningServerLabel
            // 
            this.autoListeningServerLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.autoListeningServerLabel.Location = new System.Drawing.Point(12, 281);
            this.autoListeningServerLabel.Name = "autoListeningServerLabel";
            this.autoListeningServerLabel.Size = new System.Drawing.Size(247, 167);
            this.autoListeningServerLabel.TabIndex = 12;
            this.autoListeningServerLabel.Text = "Запуск прослушивания сервера при включении приложения:";
            // 
            // listeningServerButton
            // 
            this.listeningServerButton.Location = new System.Drawing.Point(349, 165);
            this.listeningServerButton.Name = "listeningServerButton";
            this.listeningServerButton.Size = new System.Drawing.Size(171, 48);
            this.listeningServerButton.TabIndex = 13;
            this.listeningServerButton.Text = "Включить";
            this.listeningServerButton.UseVisualStyleBackColor = true;
            this.listeningServerButton.Click += new System.EventHandler(this.listeningServerButton_Click);
            // 
            // appAutoLoadButton
            // 
            this.appAutoLoadButton.Location = new System.Drawing.Point(349, 218);
            this.appAutoLoadButton.Name = "appAutoLoadButton";
            this.appAutoLoadButton.Size = new System.Drawing.Size(171, 48);
            this.appAutoLoadButton.TabIndex = 14;
            this.appAutoLoadButton.Text = "Включить";
            this.appAutoLoadButton.UseVisualStyleBackColor = true;
            this.appAutoLoadButton.Click += new System.EventHandler(this.appAutoLoadButton_Click);
            // 
            // autoListeningServerButton
            // 
            this.autoListeningServerButton.Location = new System.Drawing.Point(349, 303);
            this.autoListeningServerButton.Name = "autoListeningServerButton";
            this.autoListeningServerButton.Size = new System.Drawing.Size(171, 48);
            this.autoListeningServerButton.TabIndex = 15;
            this.autoListeningServerButton.Text = "Включить";
            this.autoListeningServerButton.UseVisualStyleBackColor = true;
            this.autoListeningServerButton.Click += new System.EventHandler(this.autoListeningServerButton_Click);
            // 
            // mainNotifyIcon
            // 
            this.mainNotifyIcon.ContextMenuStrip = this.mainNotifyIconContextMenuStrip;
            this.mainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mainNotifyIcon.Icon")));
            this.mainNotifyIcon.Text = "Control computer";
            this.mainNotifyIcon.Visible = true;
            // 
            // mainNotifyIconContextMenuStrip
            // 
            this.mainNotifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAppToolStripMenuItem,
            this.closeAppToolStripMenuItem});
            this.mainNotifyIconContextMenuStrip.Name = "mainNotifyIconContextMenuStrip";
            this.mainNotifyIconContextMenuStrip.Size = new System.Drawing.Size(195, 48);
            this.mainNotifyIconContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainNotifyIconContextMenuStrip_ItemClicked);
            // 
            // openAppToolStripMenuItem
            // 
            this.openAppToolStripMenuItem.Name = "openAppToolStripMenuItem";
            this.openAppToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.openAppToolStripMenuItem.Text = "Открыть приложение";
            // 
            // closeAppToolStripMenuItem
            // 
            this.closeAppToolStripMenuItem.Name = "closeAppToolStripMenuItem";
            this.closeAppToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.closeAppToolStripMenuItem.Text = "Выход";
            // 
            // internetConnectionLabel
            // 
            this.internetConnectionLabel.AutoSize = true;
            this.internetConnectionLabel.Location = new System.Drawing.Point(116, 448);
            this.internetConnectionLabel.Name = "internetConnectionLabel";
            this.internetConnectionLabel.Size = new System.Drawing.Size(300, 28);
            this.internetConnectionLabel.TabIndex = 16;
            this.internetConnectionLabel.Text = "Нету подключения к интернету";
            this.internetConnectionLabel.Visible = false;
            // 
            // internetConnectionButton
            // 
            this.internetConnectionButton.Location = new System.Drawing.Point(179, 491);
            this.internetConnectionButton.Name = "internetConnectionButton";
            this.internetConnectionButton.Size = new System.Drawing.Size(174, 43);
            this.internetConnectionButton.TabIndex = 17;
            this.internetConnectionButton.Text = "Восстановить";
            this.internetConnectionButton.UseVisualStyleBackColor = true;
            this.internetConnectionButton.Visible = false;
            this.internetConnectionButton.Click += new System.EventHandler(this.internetConnectionButton_Click);
            // 
            // showTutorButton
            // 
            this.showTutorButton.Location = new System.Drawing.Point(472, 516);
            this.showTutorButton.Name = "showTutorButton";
            this.showTutorButton.Size = new System.Drawing.Size(50, 50);
            this.showTutorButton.TabIndex = 18;
            this.showTutorButton.Text = "?";
            this.showTutorButton.UseVisualStyleBackColor = true;
            this.showTutorButton.Click += new System.EventHandler(this.showTutorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 570);
            this.Controls.Add(this.showTutorButton);
            this.Controls.Add(this.internetConnectionButton);
            this.Controls.Add(this.internetConnectionLabel);
            this.Controls.Add(this.autoListeningServerButton);
            this.Controls.Add(this.appAutoLoadButton);
            this.Controls.Add(this.listeningServerButton);
            this.Controls.Add(this.autoListeningServerLabel);
            this.Controls.Add(this.appAutoLoadLabel);
            this.Controls.Add(this.listeningServerLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.appTitleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление компьютером";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.mainNotifyIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appTitleLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton accountManagerToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.Label listeningServerLabel;
        private System.Windows.Forms.Label appAutoLoadLabel;
        private System.Windows.Forms.Label autoListeningServerLabel;
        private System.Windows.Forms.Button listeningServerButton;
        private System.Windows.Forms.Button appAutoLoadButton;
        private System.Windows.Forms.Button autoListeningServerButton;
        private System.Windows.Forms.NotifyIcon mainNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip mainNotifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openAppToolStripMenuItem;
        private System.Windows.Forms.Label internetConnectionLabel;
        private System.Windows.Forms.Button internetConnectionButton;
        private System.Windows.Forms.ToolStripMenuItem closeAppToolStripMenuItem;
        private System.Windows.Forms.Button showTutorButton;
    }
}