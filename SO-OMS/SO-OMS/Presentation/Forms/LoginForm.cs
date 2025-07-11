using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SO_OMS.Infrastructure.Repositories;
using SO_OMS.Application.UseCases;
using SO_OMS.Presentation.ViewModels;
using SO_OMS.Presentation.Forms;

namespace SO_OMS.Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private System.ComponentModel.IContainer components;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private LoginViewModel _viewModel;
        private readonly LoginUseCase _loginUseCase;

        // コンストラクタ
        public LoginForm(LoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
            InitializeComponent();
            _viewModel = new LoginViewModel(_loginUseCase);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _viewModel.Username = txtUsername.Text;
            _viewModel.Password = txtPassword.Text;

            bool result = _viewModel.Login();

            if (result)
            {
                MessageBox.Show("ログイン成功！");
                var dashboard = new DashboardForm();
                dashboard.Show();
                this.Hide();
                // ダッシュボードが閉じられたらアプリ終了
                dashboard.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("ログイン失敗: " + _viewModel.ErrorMessage,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.label1.Location = new System.Drawing.Point(77, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "さぬきオリーブ受注管理システム";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.label2.Location = new System.Drawing.Point(112, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "SO-OMS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "ユーザー名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "パスワード";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(142, 171);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(152, 19);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(142, 216);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 19);
            this.txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(159, 274);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "ログイン";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(399, 364);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "ログイン";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
