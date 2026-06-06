using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        private int? editingTaskId = null;

        public MainForm()
        {
            InitializeComponent();
            LoadTasks();
            cmbFilterComplexity.SelectedIndex = 0;
            this.Text = $"Менеджер задач - {LoginForm.CurrentUsername}";
        }

        private void LoadTasks()
        {
            int? complexity = null;
            if (cmbFilterComplexity.SelectedIndex > 0)
                complexity = cmbFilterComplexity.SelectedIndex;

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT 
                        Id, 
                        Title, 
                        Description,
                        CASE DayOfWeek
                            WHEN 0 THEN 'Понедельник'
                            WHEN 1 THEN 'Вторник'
                            WHEN 2 THEN 'Среда'
                            WHEN 3 THEN 'Четверг'
                            WHEN 4 THEN 'Пятница'
                            WHEN 5 THEN 'Суббота'
                            WHEN 6 THEN 'Воскресенье'
                        END AS DayOfWeekName,
                        AssignedTo,
                        CreatedAt
                    FROM Tasks
                    WHERE UserId = @uid";

                if (complexity.HasValue)
                    query += " AND Complexity = @comp";
                query += " ORDER BY CreatedAt DESC";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@uid", LoginForm.CurrentUserId);
                    if (complexity.HasValue)
                        cmd.Parameters.AddWithValue("@comp", complexity.Value);

                    var adapter = new SQLiteDataAdapter(cmd);
                    var dt = new System.Data.DataTable();
                    adapter.Fill(dt);

                    dgvTasks.DataSource = dt;

                    if (dgvTasks.Columns.Contains("Id"))
                        dgvTasks.Columns["Id"].Visible = false;

                    if (dgvTasks.Columns.Contains("Title"))
                        dgvTasks.Columns["Title"].HeaderText = "Название";

                    if (dgvTasks.Columns.Contains("Description"))
                        dgvTasks.Columns["Description"].HeaderText = "Описание";

                    if (dgvTasks.Columns.Contains("DayOfWeekName"))
                        dgvTasks.Columns["DayOfWeekName"].HeaderText = "День недели";

                    if (dgvTasks.Columns.Contains("AssignedTo"))
                        dgvTasks.Columns["AssignedTo"].HeaderText = "Назначена";

                    if (dgvTasks.Columns.Contains("CreatedAt"))
                        dgvTasks.Columns["CreatedAt"].HeaderText = "Дата создания";
                }
            }
        }

        private void ClearInputs()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            cmbDayOfWeek.SelectedIndex = 0;
            txtAssignedTo.Text = "";
            editingTaskId = null;
            btnAdd.Text = "Добавить";
            btnEdit.Text = "Редактировать";
        }

        private void LoadTaskForEdit(int taskId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT Title, Description, DayOfWeek, AssignedTo FROM Tasks WHERE Id = @id AND UserId = @uid";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", taskId);
                    cmd.Parameters.AddWithValue("@uid", LoginForm.CurrentUserId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTitle.Text = reader["Title"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                            int dayOfWeek = Convert.ToInt32(reader["DayOfWeek"]);
                            cmbDayOfWeek.SelectedIndex = dayOfWeek;
                            txtAssignedTo.Text = reader["AssignedTo"]?.ToString() ?? "";
                            editingTaskId = taskId;
                            btnAdd.Text = "Обновить";
                            btnEdit.Text = "Отменить";
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название задачи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                if (editingTaskId.HasValue)
                {
                    string update = @"
                        UPDATE Tasks 
                        SET Title = @title, Description = @desc, DayOfWeek = @dayOfWeek,
                            AssignedTo = @assignedTo
                        WHERE Id = @id AND UserId = @uid";

                    using (var cmd = new SQLiteCommand(update, connection))
                    {
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@dayOfWeek", cmbDayOfWeek.SelectedIndex);
                        cmd.Parameters.AddWithValue("@assignedTo", string.IsNullOrWhiteSpace(txtAssignedTo.Text) ? (object)DBNull.Value : txtAssignedTo.Text);
                        cmd.Parameters.AddWithValue("@id", editingTaskId.Value);
                        cmd.Parameters.AddWithValue("@uid", LoginForm.CurrentUserId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Задача обновлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string insert = @"
                        INSERT INTO Tasks (UserId, Title, Description, DayOfWeek, CreatedAt, AssignedTo, Complexity)
                        VALUES (@uid, @title, @desc, @dayOfWeek, @date, @assignedTo, 1)";

                    using (var cmd = new SQLiteCommand(insert, connection))
                    {
                        cmd.Parameters.AddWithValue("@uid", LoginForm.CurrentUserId);
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@dayOfWeek", cmbDayOfWeek.SelectedIndex);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@assignedTo", string.IsNullOrWhiteSpace(txtAssignedTo.Text) ? (object)DBNull.Value : txtAssignedTo.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Задача добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            ClearInputs();
            LoadTasks();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (editingTaskId.HasValue)
            {
                ClearInputs();
            }
            else
            {
                if (dgvTasks.CurrentRow == null)
                {
                    MessageBox.Show("Выберите задачу для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int taskId = Convert.ToInt32(dgvTasks.CurrentRow.Cells["Id"].Value);
                LoadTaskForEdit(taskId);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null)
            {
                MessageBox.Show("Выберите задачу для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int taskId = Convert.ToInt32(dgvTasks.CurrentRow.Cells["Id"].Value);
            string taskTitle = dgvTasks.CurrentRow.Cells["Title"].Value.ToString();

            if (MessageBox.Show($"Удалить задачу \"{taskTitle}\"?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string delete = "DELETE FROM Tasks WHERE Id = @id AND UserId = @uid";
                    using (var cmd = new SQLiteCommand(delete, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", taskId);
                        cmd.Parameters.AddWithValue("@uid", LoginForm.CurrentUserId);
                        cmd.ExecuteNonQuery();
                    }
                }

                if (editingTaskId == taskId)
                    ClearInputs();

                LoadTasks();
                MessageBox.Show("Задача удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void cmbFilterComplexity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTasks();
        }
    }
}