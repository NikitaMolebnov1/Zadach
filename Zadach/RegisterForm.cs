using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string hashed = password;
                string insert = "INSERT INTO Users (Username, PasswordHash) VALUES (@user, @pass)";

                try
                {
                    using (var cmd = new SQLiteCommand(insert, connection))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", hashed);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Регистрация успешна!");
                    this.Close();
                }
                catch (SQLiteException)
                {
                    MessageBox.Show("Пользователь уже существует");
                }
            }
        }
    }
}