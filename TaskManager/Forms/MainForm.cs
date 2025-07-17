using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Core.Models;
using TaskManager.Core.Service.Implementation;
using TaskManager.Core.Service.Interface;

namespace TaskManager.WinForms
{
    public partial class MainForm : Form
    {
        private readonly ITaskService _taskService;
        private UserEntity? _loggedInUser;
        private int? _selectedTaskId;

        public MainForm(ITaskService taskService)
        {
            this._taskService = taskService;

            InitializeComponent();

            txtTitle.TextChanged += ValidateFormInputs;
            txtDescription.TextChanged += ValidateFormInputs;
            txtCategory.TextChanged += ValidateFormInputs;
            dtpDueDate.ValueChanged += ValidateFormInputs;
            chkIsComplete.CheckedChanged += ValidateFormInputs;

            ValidateFormInputs(null, EventArgs.Empty);
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadTasksAsync();
        }

        private async Task LoadTasksAsync()
        {
            try
            {
                var tasks = await _taskService.GetAllTasksForUserAsync(GetCurrentUserId());

                dataGridViewTasks.DataSource = tasks.Select(t => new
                {
                    t.Id,
                    t.Title,
                    t.Description,
                    t.DueDate,
                    t.Category,
                    t.IsComplete,
                    t.CreatedAt,
                    t.UpdatedAt
                }).ToList();
                dataGridViewTasks.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα κατά τη φόρτωση των εργασιών:\n" + ex.Message);
            }
        }

        public void SetLoggedInUser(UserEntity user)
        {
            _loggedInUser = user;

            lblUserWelcome.Text = $"Welcome, {user.UserName}";
        }

        private int GetCurrentUserId() => _loggedInUser?.Id ?? 0;


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var task = new TaskItemEntity
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                DueDate = dtpDueDate.Value,
                Category = txtCategory.Text,
                IsComplete = chkIsComplete.Checked,
                UserId = GetCurrentUserId()
            };

            try
            {

                if (_selectedTaskId.HasValue)
                {
                    await _taskService.UpdateTaskAsync(_selectedTaskId.Value, task);
                    _selectedTaskId = null;
                }
                else
                {
                    await _taskService.AddTaskAsync(task);
                }
                ClearInputs();
                await LoadTasksAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Αποτυχία αποθήκευσης:\n" + ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.CurrentRow == null)
                return;

            string title = dataGridViewTasks.CurrentRow.Cells["Title"].Value?.ToString();
            if (!int.TryParse(dataGridViewTasks.CurrentRow.Cells["Id"].Value?.ToString(), out int taskId))
                return;

            var result = MessageBox.Show($"Διαγραφή της εργασίας '{title}'?", "Επιβεβαίωση", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await _taskService.DeleteTaskByIdAsync(taskId, GetCurrentUserId());
                    await LoadTasksAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Αποτυχία διαγραφής:\n" + ex.Message);
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.CurrentRow == null)
                return;

            if (!int.TryParse(dataGridViewTasks.CurrentRow.Cells["Id"].Value?.ToString(), out int taskId))
                return;

            _selectedTaskId = taskId;


            txtTitle.Text = dataGridViewTasks.CurrentRow.Cells["Title"].Value?.ToString();
            txtDescription.Text = dataGridViewTasks.CurrentRow.Cells["Description"].Value?.ToString();
            txtCategory.Text = dataGridViewTasks.CurrentRow.Cells["Category"].Value?.ToString();
            chkIsComplete.Checked = Convert.ToBoolean(dataGridViewTasks.CurrentRow.Cells["IsComplete"].Value);
            dtpDueDate.Value = Convert.ToDateTime(dataGridViewTasks.CurrentRow.Cells["DueDate"].Value);

        }
        private void ClearInputs()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            txtCategory.Clear();
            dtpDueDate.Value = DateTime.Today;
            chkIsComplete.Checked = false;
        }

        private void ValidateFormInputs(object? sender, EventArgs e)
        {
            bool isValidAdd =
                !string.IsNullOrWhiteSpace(txtTitle.Text) &&
                !string.IsNullOrWhiteSpace(txtDescription.Text) &&
                !string.IsNullOrWhiteSpace(txtCategory.Text);


            btnAdd.Enabled = isValidAdd;
        }


    }
}
