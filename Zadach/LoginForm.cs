using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class LoginForm : Form
    {
        public static int CurrentUserId = -1;
        public static string CurrentUsername = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT Id FROM Users WHERE Username = @user AND PasswordHash = @pass";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        CurrentUserId = Convert.ToInt32(result);
                        CurrentUsername = username;
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}