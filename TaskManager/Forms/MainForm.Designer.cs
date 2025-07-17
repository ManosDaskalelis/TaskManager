using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManager.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblCategory;
        private TextBox txtCategory;
        private Label lblDueDate;
        private DateTimePicker dtpDueDate;
        private Button btnAdd;
        private DataGridView dataGridViewTasks;
        private Label lblUserWelcome;
        private CheckBox chkIsComplete;
        private Button btnEdit;
        private Button btnDelete;

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
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblCategory = new Label();
            txtCategory = new TextBox();
            lblDueDate = new Label();
            dtpDueDate = new DateTimePicker();
            btnAdd = new Button();
            dataGridViewTasks = new DataGridView();
            lblUserWelcome = new Label();
            chkIsComplete = new CheckBox();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(41, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(107, 10);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(362, 27);
            txtTitle.TabIndex = 2;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(10, 40);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 20);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(107, 40);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(362, 27);
            txtDescription.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(10, 70);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 20);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Category:";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(107, 70);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(362, 27);
            txtCategory.TabIndex = 6;
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(10, 100);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(75, 20);
            lblDueDate.TabIndex = 7;
            lblDueDate.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(107, 100);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(262, 27);
            dtpDueDate.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(394, 99);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridViewTasks
            // 
            dataGridViewTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewTasks.ColumnHeadersHeight = 29;
            dataGridViewTasks.Location = new Point(10, 140);
            dataGridViewTasks.Name = "dataGridViewTasks";
            dataGridViewTasks.RowHeadersWidth = 51;
            dataGridViewTasks.Size = new Size(892, 395);
            dataGridViewTasks.TabIndex = 10;
            // 
            // lblUserWelcome
            // 
            lblUserWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserWelcome.Location = new Point(722, 9);
            lblUserWelcome.Name = "lblUserWelcome";
            lblUserWelcome.Size = new Size(180, 20);
            lblUserWelcome.TabIndex = 0;
            lblUserWelcome.Text = "Welcome,";
            lblUserWelcome.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkIsComplete
            // 
            chkIsComplete.AutoSize = true;
            chkIsComplete.Location = new Point(475, 13);
            chkIsComplete.Name = "chkIsComplete";
            chkIsComplete.Size = new Size(136, 24);
            chkIsComplete.TabIndex = 0;
            chkIsComplete.Text = "Ολοκληρώθηκε";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(705, 540);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Edit";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(795, 540);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(932, 615);
            Controls.Add(chkIsComplete);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(lblUserWelcome);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblCategory);
            Controls.Add(txtCategory);
            Controls.Add(lblDueDate);
            Controls.Add(dtpDueDate);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewTasks);
            Name = "MainForm";
            Text = "Task Manager";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
