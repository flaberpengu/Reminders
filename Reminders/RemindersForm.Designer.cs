namespace Reminders
{
    partial class RemindersForm
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
            this.tbNewReminder = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tbDueDay = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.tbDueMonth = new System.Windows.Forms.TextBox();
            this.tbDueYear = new System.Windows.Forms.TextBox();
            this.btnAddReminder = new System.Windows.Forms.Button();
            this.lblReminderHeader = new System.Windows.Forms.Label();
            this.lblSetHeader = new System.Windows.Forms.Label();
            this.lblDueHeader = new System.Windows.Forms.Label();
            this.lblCompletedHeader = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblToggleDone = new System.Windows.Forms.Label();
            this.cbToggleDone = new System.Windows.Forms.CheckBox();
            this.btnPageDown = new System.Windows.Forms.Button();
            this.tbPageNum = new System.Windows.Forms.TextBox();
            this.btnPageUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNewReminder
            // 
            this.tbNewReminder.Location = new System.Drawing.Point(859, 35);
            this.tbNewReminder.Multiline = true;
            this.tbNewReminder.Name = "tbNewReminder";
            this.tbNewReminder.Size = new System.Drawing.Size(410, 170);
            this.tbNewReminder.TabIndex = 0;
            this.tbNewReminder.TextChanged += new System.EventHandler(this.checkIfCreationInputsValidChangeButton);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(983, 58);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "New...";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.showCreationFieldsHideCreateButton);
            // 
            // tbDueDay
            // 
            this.tbDueDay.Location = new System.Drawing.Point(859, 220);
            this.tbDueDay.Name = "tbDueDay";
            this.tbDueDay.Size = new System.Drawing.Size(80, 20);
            this.tbDueDay.TabIndex = 2;
            this.tbDueDay.TextChanged += new System.EventHandler(this.checkIfCreationInputsValidChangeButton);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(766, 38);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(75, 13);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "Reminder text:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(766, 214);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(84, 26);
            this.lblDueDate.TabIndex = 4;
            this.lblDueDate.Text = "Due Date \r\n(DD MM YYYY):";
            // 
            // tbDueMonth
            // 
            this.tbDueMonth.Location = new System.Drawing.Point(1024, 220);
            this.tbDueMonth.Name = "tbDueMonth";
            this.tbDueMonth.Size = new System.Drawing.Size(80, 20);
            this.tbDueMonth.TabIndex = 7;
            this.tbDueMonth.TextChanged += new System.EventHandler(this.checkIfCreationInputsValidChangeButton);
            // 
            // tbDueYear
            // 
            this.tbDueYear.Location = new System.Drawing.Point(1189, 220);
            this.tbDueYear.Name = "tbDueYear";
            this.tbDueYear.Size = new System.Drawing.Size(80, 20);
            this.tbDueYear.TabIndex = 8;
            this.tbDueYear.TextChanged += new System.EventHandler(this.checkIfCreationInputsValidChangeButton);
            // 
            // btnAddReminder
            // 
            this.btnAddReminder.Location = new System.Drawing.Point(859, 255);
            this.btnAddReminder.Name = "btnAddReminder";
            this.btnAddReminder.Size = new System.Drawing.Size(410, 23);
            this.btnAddReminder.TabIndex = 9;
            this.btnAddReminder.Text = "Create Reminder";
            this.btnAddReminder.UseVisualStyleBackColor = true;
            this.btnAddReminder.Click += new System.EventHandler(this.createReminder);
            // 
            // lblReminderHeader
            // 
            this.lblReminderHeader.AutoSize = true;
            this.lblReminderHeader.Location = new System.Drawing.Point(12, 35);
            this.lblReminderHeader.Name = "lblReminderHeader";
            this.lblReminderHeader.Size = new System.Drawing.Size(52, 13);
            this.lblReminderHeader.TabIndex = 10;
            this.lblReminderHeader.Text = "Reminder";
            // 
            // lblSetHeader
            // 
            this.lblSetHeader.AutoSize = true;
            this.lblSetHeader.Location = new System.Drawing.Point(455, 35);
            this.lblSetHeader.Name = "lblSetHeader";
            this.lblSetHeader.Size = new System.Drawing.Size(23, 13);
            this.lblSetHeader.TabIndex = 11;
            this.lblSetHeader.Text = "Set";
            // 
            // lblDueHeader
            // 
            this.lblDueHeader.AutoSize = true;
            this.lblDueHeader.Location = new System.Drawing.Point(575, 35);
            this.lblDueHeader.Name = "lblDueHeader";
            this.lblDueHeader.Size = new System.Drawing.Size(27, 13);
            this.lblDueHeader.TabIndex = 12;
            this.lblDueHeader.Text = "Due";
            // 
            // lblCompletedHeader
            // 
            this.lblCompletedHeader.AutoSize = true;
            this.lblCompletedHeader.Location = new System.Drawing.Point(686, 38);
            this.lblCompletedHeader.Name = "lblCompletedHeader";
            this.lblCompletedHeader.Size = new System.Drawing.Size(57, 13);
            this.lblCompletedHeader.TabIndex = 13;
            this.lblCompletedHeader.Text = "Completed";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1189, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.hideFieldsShowCreateButtonClearFields);
            // 
            // lblToggleDone
            // 
            this.lblToggleDone.AutoSize = true;
            this.lblToggleDone.Location = new System.Drawing.Point(766, 452);
            this.lblToggleDone.Name = "lblToggleDone";
            this.lblToggleDone.Size = new System.Drawing.Size(111, 13);
            this.lblToggleDone.TabIndex = 15;
            this.lblToggleDone.Text = "Show only completed:";
            // 
            // cbToggleDone
            // 
            this.cbToggleDone.AutoSize = true;
            this.cbToggleDone.Location = new System.Drawing.Point(880, 452);
            this.cbToggleDone.Name = "cbToggleDone";
            this.cbToggleDone.Size = new System.Drawing.Size(15, 14);
            this.cbToggleDone.TabIndex = 16;
            this.cbToggleDone.UseVisualStyleBackColor = true;
            this.cbToggleDone.CheckedChanged += new System.EventHandler(this.toggleShowCompleted);
            // 
            // btnPageDown
            // 
            this.btnPageDown.Location = new System.Drawing.Point(15, 851);
            this.btnPageDown.Name = "btnPageDown";
            this.btnPageDown.Size = new System.Drawing.Size(31, 20);
            this.btnPageDown.TabIndex = 17;
            this.btnPageDown.Text = "<";
            this.btnPageDown.UseVisualStyleBackColor = true;
            this.btnPageDown.Click += new System.EventHandler(this.pageDown);
            // 
            // tbPageNum
            // 
            this.tbPageNum.Location = new System.Drawing.Point(52, 851);
            this.tbPageNum.Name = "tbPageNum";
            this.tbPageNum.ReadOnly = true;
            this.tbPageNum.Size = new System.Drawing.Size(31, 20);
            this.tbPageNum.TabIndex = 18;
            this.tbPageNum.TabStop = false;
            this.tbPageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPageUp
            // 
            this.btnPageUp.Location = new System.Drawing.Point(89, 851);
            this.btnPageUp.Name = "btnPageUp";
            this.btnPageUp.Size = new System.Drawing.Size(31, 20);
            this.btnPageUp.TabIndex = 19;
            this.btnPageUp.Text = ">";
            this.btnPageUp.UseVisualStyleBackColor = true;
            this.btnPageUp.Click += new System.EventHandler(this.pageUp);
            // 
            // RemindersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 886);
            this.Controls.Add(this.btnPageUp);
            this.Controls.Add(this.tbPageNum);
            this.Controls.Add(this.btnPageDown);
            this.Controls.Add(this.cbToggleDone);
            this.Controls.Add(this.lblToggleDone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCompletedHeader);
            this.Controls.Add(this.lblDueHeader);
            this.Controls.Add(this.lblSetHeader);
            this.Controls.Add(this.lblReminderHeader);
            this.Controls.Add(this.btnAddReminder);
            this.Controls.Add(this.tbDueYear);
            this.Controls.Add(this.tbDueMonth);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.tbDueDay);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbNewReminder);
            this.Name = "RemindersForm";
            this.Text = "Reminders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.exitProgram);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNewReminder;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox tbDueDay;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.TextBox tbDueMonth;
        private System.Windows.Forms.TextBox tbDueYear;
        private System.Windows.Forms.Button btnAddReminder;
        private System.Windows.Forms.Label lblReminderHeader;
        private System.Windows.Forms.Label lblSetHeader;
        private System.Windows.Forms.Label lblDueHeader;
        private System.Windows.Forms.Label lblCompletedHeader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblToggleDone;
        private System.Windows.Forms.CheckBox cbToggleDone;
        private System.Windows.Forms.Button btnPageDown;
        private System.Windows.Forms.TextBox tbPageNum;
        private System.Windows.Forms.Button btnPageUp;
    }
}

