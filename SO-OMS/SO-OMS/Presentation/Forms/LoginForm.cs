using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Infrastructure.Repositories;
using Application.UseCases;
using Presentation.ViewModels;

namespace Presentation.Forms
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

        public LoginForm()
        {
            InitializeComponent();

            // DB接続とViewModelの初期化
            var connection = new SqlConnection("Server=localhost;Database=OliveShopDB;Trusted_Connection=True;");
            connection.Open();
            var repo = new SqlAdminRepository(connection);
            var useCase = new LoginUseCase(repo);
            _viewModel = new LoginViewModel(useCase);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _viewModel.Username = txtUsername.Text;
            _viewModel.Password = txtPassword.Text;

            bool result = _viewModel.Login();

            if (result)
            {
                MessageBox.Show("ログイン成功！");
                // TODO: 次の画面に遷移する処理をここに追加
            }
            else
            {
                MessageBox.Show("ログイン失敗: " + _viewModel.ErrorMessage,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.label1.Location = new System.Drawing.Point(77, 111);
            this.label1.Text = "さぬきオリーブ受注管理システム";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.label2.Location = new System.Drawing.Point(112, 71);
            this.label2.Text = "SO-OMS";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 174);
            this.label3.Text = "ユーザー名";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 219);
            this.label4.Text = "パスワード";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(142, 171);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(152, 19);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(142, 216);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(152, 19);
            this.txtPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(159, 274);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.Text = "ログイン";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // LoginForm
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
