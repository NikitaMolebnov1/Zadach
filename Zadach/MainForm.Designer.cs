namespace TaskManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbFilterComplexity = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDayOfWeek = new System.Windows.Forms.Label();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.lblAssignedTo = new System.Windows.Forms.Label();
            this.txtAssignedTo = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.BackgroundColor = System.Drawing.Color.White;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(12, 180);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.RowTemplate.Height = 35;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(960, 420);
            this.dgvTasks.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTitle.Location = new System.Drawing.Point(120, 35);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(320, 29);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.PlaceholderText = "Введите название задачи";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDescription.Location = new System.Drawing.Point(120, 75);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(380, 29);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.PlaceholderText = "Введите описание";
            // 
            // lblDayOfWeek
            // 
            this.lblDayOfWeek.AutoSize = true;
            this.lblDayOfWeek.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDayOfWeek.Location = new System.Drawing.Point(15, 115);
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            this.lblDayOfWeek.Size = new System.Drawing.Size(99, 21);
            this.lblDayOfWeek.TabIndex = 3;
            this.lblDayOfWeek.Text = "День недели:";
            // 
            // cmbDayOfWeek
            // 
            this.cmbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDayOfWeek.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbDayOfWeek.FormattingEnabled = true;
            this.cmbDayOfWeek.Items.AddRange(new object[] {
                "Понедельник",
                "Вторник",
                "Среда",
                "Четверг",
                "Пятница",
                "Суббота",
                "Воскресенье"
            });
            this.cmbDayOfWeek.Location = new System.Drawing.Point(120, 112);
            this.cmbDayOfWeek.Name = "cmbDayOfWeek";
            this.cmbDayOfWeek.Size = new System.Drawing.Size(150, 29);
            this.cmbDayOfWeek.TabIndex = 4;
            this.cmbDayOfWeek.SelectedIndex = 0;
            // 
            // lblAssignedTo
            // 
            this.lblAssignedTo.AutoSize = true;
            this.lblAssignedTo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAssignedTo.Location = new System.Drawing.Point(300, 115);
            this.lblAssignedTo.Name = "lblAssignedTo";
            this.lblAssignedTo.Size = new System.Drawing.Size(93, 21);
            this.lblAssignedTo.TabIndex = 5;
            this.lblAssignedTo.Text = "Назначить:";
            // 
            // txtAssignedTo
            // 
            this.txtAssignedTo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAssignedTo.Location = new System.Drawing.Point(399, 112);
            this.txtAssignedTo.Name = "txtAssignedTo";
            this.txtAssignedTo.Size = new System.Drawing.Size(200, 29);
            this.txtAssignedTo.TabIndex = 6;
            this.txtAssignedTo.PlaceholderText = "Кому назначить";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAdd.Location = new System.Drawing.Point(640, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 35);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEdit.Location = new System.Drawing.Point(640, 80);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 35);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDelete.Location = new System.Drawing.Point(640, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRefresh.Location = new System.Drawing.Point(140, 35);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 32);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbFilterComplexity
            // 
            this.cmbFilterComplexity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterComplexity.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbFilterComplexity.FormattingEnabled = true;
            this.cmbFilterComplexity.Items.AddRange(new object[] { "Все", "1", "2", "3", "4", "5" });
            this.cmbFilterComplexity.Location = new System.Drawing.Point(140, 35);
            this.cmbFilterComplexity.Name = "cmbFilterComplexity";
            this.cmbFilterComplexity.Size = new System.Drawing.Size(100, 28);
            this.cmbFilterComplexity.TabIndex = 11;
            this.cmbFilterComplexity.SelectedIndexChanged += new System.EventHandler(this.cmbFilterComplexity_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFilter.Location = new System.Drawing.Point(15, 38);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(90, 20);
            this.lblFilter.TabIndex = 12;
            this.lblFilter.Text = "Сложность:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTitle.Location = new System.Drawing.Point(15, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(85, 21);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Название:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDescription.Location = new System.Drawing.Point(15, 78);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(85, 21);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Описание:";
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.lblTitle);
            this.groupBoxInput.Controls.Add(this.txtTitle);
            this.groupBoxInput.Controls.Add(this.lblDescription);
            this.groupBoxInput.Controls.Add(this.txtDescription);
            this.groupBoxInput.Controls.Add(this.lblDayOfWeek);
            this.groupBoxInput.Controls.Add(this.cmbDayOfWeek);
            this.groupBoxInput.Controls.Add(this.lblAssignedTo);
            this.groupBoxInput.Controls.Add(this.txtAssignedTo);
            this.groupBoxInput.Controls.Add(this.btnAdd);
            this.groupBoxInput.Controls.Add(this.btnEdit);
            this.groupBoxInput.Controls.Add(this.btnDelete);
            this.groupBoxInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(770, 160);
            this.groupBoxInput.TabIndex = 15;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Добавление / Редактирование задачи";
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.lblFilter);
            this.groupBoxFilter.Controls.Add(this.cmbFilterComplexity);
            this.groupBoxFilter.Controls.Add(this.btnRefresh);
            this.groupBoxFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxFilter.Location = new System.Drawing.Point(790, 12);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(260, 160);
            this.groupBoxFilter.TabIndex = 16;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Фильтрация";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 612);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.dgvTasks);
            this.MinimumSize = new System.Drawing.Size(1078, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер задач";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbDayOfWeek;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbFilterComplexity;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDayOfWeek;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label lblAssignedTo;
        private System.Windows.Forms.TextBox txtAssignedTo;
    }
}