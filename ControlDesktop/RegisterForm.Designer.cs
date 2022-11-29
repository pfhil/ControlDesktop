
namespace ControlDesktopUI
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Location = new System.Drawing.Point(96, 28);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(249, 28);
            this.formTitleLabel.TabIndex = 0;
            this.formTitleLabel.Text = "Регистрация приложения";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(12, 106);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(73, 28);
            this.loginLabel.TabIndex = 1;
            this.loginLabel.Text = "Логин:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 162);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(85, 28);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Пароль:";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(125, 103);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(303, 34);
            this.loginTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(125, 159);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(264, 34);
            this.PasswordTextBox.TabIndex = 4;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(12, 216);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(191, 45);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "Регистрация";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // hideButton
            // 
            this.hideButton.BackgroundImage = global::ControlDesktopUI.Properties.Resources.icons8_hide_50;
            this.hideButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hideButton.Location = new System.Drawing.Point(394, 159);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(34, 34);
            this.hideButton.TabIndex = 7;
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(237, 216);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(191, 45);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 278);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация приложения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.Button cancelButton;
    }
}